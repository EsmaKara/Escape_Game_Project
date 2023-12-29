
using System;
using System.Collections.Generic;

//using System.Collections.Generic;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace Oyun_Proje.Desktop
{
    public partial class AnaForm : Form
    {
        List<Panel> ls;

        Bloks blok;
        Karakter karakter;
        Timer zamanlayici;
        Oyun oyun;
        Sabit_Tuzak sbtTuzak;
        Dusen_Tuzak dsnTuzak;
        Canavar_Tuzak cnvrTuzak;
        Surpriz_Kutu srpzKutu;

        Panel pnlOyunBilgi;

        bool basladiMi;
        private int level;
        private int sayi;
        public AnaForm()
        {
            DoubleBuffered = true;
            InitializeComponent();

            karakter = new Karakter();
            zamanlayici = new Timer();
            oyun = new Oyun();
            blok = new Bloks();
            sbtTuzak = new Sabit_Tuzak();
            dsnTuzak = new Dusen_Tuzak();
            cnvrTuzak = new Canavar_Tuzak();
            srpzKutu = new Surpriz_Kutu();

            ls = new List<Panel>();
            pnlOyunBilgi = new Panel();
            basladiMi = false;
            zamanlayici.Interval = 1000;

            Controls.Add(pnlOyunBilgi);

            sayi = 0;

            KeyDown += AnaForm_KeyDown;
            Paint += AnaForm_Paint;
            zamanlayici.Tick += Zamanlayici_Tick;
        }

        private void Zamanlayici_Tick(object sender, EventArgs e)
        {
            dsnTuzak.Hareket(karakter);
            cnvrTuzak.Hareket(karakter);
            Invalidate();

            if(level == 2)
                if(sayi % 4 == 0)
                    dsnTuzak.TuzakOlustur();
            if(level == 3)
                if (sayi % 2 == 0)
                    cnvrTuzak.TuzakOlustur();
            if (sayi % 10 == 0)
            {
                srpzKutu = new Surpriz_Kutu();
                srpzKutu.KutuOlustur(srpzKutu);
            }

            sayi++;

            ls.Add(pnlOyunBilgi);
            oyun.EkranaYazdir(pnlOyunBilgi, txtName.Text, level, karakter, sayi);
            //Controls.Add(pnlOyunBilgi);
            pnlOyunBilgi.Show();
        }

        private void AnaForm_Paint(object sender, PaintEventArgs e)
        {
            if (level == 1)
            {
                if (basladiMi == true)
                {
                    sbtTuzak.TuzakCiz(e.Graphics, karakter);
                    blok.BlokEkle(e.Graphics, level);
                    if (srpzKutu != null)
                        if(srpzKutu.X != 0)
                            srpzKutu.KutuCiz(e.Graphics, srpzKutu);
                    karakter.KarakterCiz(e.Graphics, karakter);

                    ls.Add(pnlOyunBilgi);
                    oyun.EkranaYazdir(pnlOyunBilgi, txtName.Text, level, karakter, sayi);
                    //Controls.Add(pnlOyunBilgi);
                    pnlOyunBilgi.Show();
                }
                for (int i = 0; i < 10; i++)
                {
                    if (sbtTuzak.tuzaklar[i] != null)
                        if (karakter.X == sbtTuzak.tuzaklar[i].X && karakter.Y == sbtTuzak.tuzaklar[i].Y)
                        {
                            blok.BlokEkle(e.Graphics, level);
                            if (srpzKutu != null)
                                if (srpzKutu.X != 0)
                                    srpzKutu.KutuCiz(e.Graphics, srpzKutu);
                            sbtTuzak.SabitTuzakGoster(e.Graphics, karakter);
                            karakter.KarakterCiz(e.Graphics, karakter);

                            ls.Add(pnlOyunBilgi);
                            oyun.EkranaYazdir(pnlOyunBilgi, txtName.Text, level, karakter, sayi);
                            //Controls.Add(pnlOyunBilgi);
                            pnlOyunBilgi.Show();
                        }
                }
            }

            else if (level == 2)
            {
                blok.BlokEkle(e.Graphics, level);
                if (srpzKutu != null)
                    if (srpzKutu.X != 0)
                        srpzKutu.KutuCiz(e.Graphics, srpzKutu);
                dsnTuzak.TuzakCiz(e.Graphics, karakter);
                karakter.KarakterCiz(e.Graphics, karakter);

                ls.Add(pnlOyunBilgi);
                oyun.EkranaYazdir(pnlOyunBilgi, txtName.Text, level, karakter, sayi);
                //Controls.Add(pnlOyunBilgi);
                pnlOyunBilgi.Show();
            }

            else if (level == 3)
            {
                blok.BlokEkle(e.Graphics, level);
                if (srpzKutu != null)
                    if (srpzKutu.X != 0)
                        srpzKutu.KutuCiz(e.Graphics, srpzKutu);
                cnvrTuzak.TuzakCiz(e.Graphics, karakter);
                karakter.KarakterCiz(e.Graphics, karakter);

                ls.Add(pnlOyunBilgi);
                oyun.EkranaYazdir(pnlOyunBilgi, txtName.Text, level, karakter, sayi);
                //Controls.Add(pnlOyunBilgi);
                pnlOyunBilgi.Show();
            }

            else if(level == 4) 
            {
                oyun.HikayeyiGoster(e.Graphics);
                //AnaForm yeniOyunFormu = new AnaForm();
                //yeniOyunFormu.Show();
                //this.Visible = false;
            }
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {

            }

            karakter.HareketEt(e);
            Invalidate();

            if (srpzKutu != null)
                if (karakter.X == srpzKutu.X && karakter.Y == srpzKutu.Y)
                {
                    srpzKutu.RastgeleCan(karakter);
                    srpzKutu = null;
                    Invalidate();
                }

            if (level == 1)
            {
                Invalidate();
                if (karakter.Can != 0)
                    sbtTuzak.CanAzalt(karakter);
                else
                {
                    zamanlayici = new Timer();
                    this.Controls.Clear();
                    karakter = new Karakter();
                    basladiMi = true;
                    Invalidate();
                    sbtTuzak.TuzakOlustur();
                }

                if (karakter.X == 880)
                {
                    zamanlayici.Stop();
                    zamanlayici.Enabled = true;
                    MessageBox.Show("Oh, you are recovering well.");
                    this.Controls.Clear();
                    if(karakter.Can != 3)
                        karakter.Can += 1;
                    karakter.X = 80;
                    karakter.Y = 240;
                    level = 2;
                    if (basladiMi)
                        dsnTuzak.TuzakOlustur();
                    Invalidate();
                }
            }

            else if (level == 2)
            {
                Invalidate();
                if (karakter.Can != 0)
                    dsnTuzak.CanAzalt(karakter);
                else if(karakter.Can == 0)
                {
                    zamanlayici = new Timer();
                    this.Controls.Clear();
                    karakter = new Karakter();
                    level = 1;
                    basladiMi = true;
                    Invalidate();
                    sbtTuzak.TuzakOlustur();
                }
                Invalidate();
                if(karakter.X == 160)
                {
                    zamanlayici.Start();
                    zamanlayici.Enabled = true;
                    basladiMi = false;
                }

                if (karakter.X == 880)
                {
                    zamanlayici.Stop();
                    zamanlayici.Enabled = true;
                    MessageBox.Show("What's that, are you OKAY?");
                    this.Controls.Clear();
                    if (karakter.Can != 3)
                        karakter.Can += 1;
                    karakter.X = 80;
                    karakter.Y = 240;
                    level = 3;
                    Invalidate();
                }
            }

            else if(level == 3)
            {
                Invalidate();
                if (karakter.Can != 0)
                    cnvrTuzak.CanAzalt(karakter);
                else
                {
                    zamanlayici = new Timer();
                    this.Controls.Clear();
                    karakter = new Karakter();
                    for(int i = 0; i < 10; i++)
                        if (cnvrTuzak.tuzaklarinDizisi[i] != null)
                            for (int j = 0; j < 10; j++)
                            cnvrTuzak.tuzaklarinDizisi[i][j] = null;
                    level = 1;
                    basladiMi = true;
                    Invalidate();
                    sbtTuzak.TuzakOlustur();
                }

                Invalidate();
                if (karakter.X == 160)
                {
                    zamanlayici.Start();
                    zamanlayici.Enabled = true;
                }

                if (karakter.X == 880)
                {
                    zamanlayici.Stop();
                    zamanlayici.Enabled = false;
                    MessageBox.Show("Hey, it's finally over. Isn't it beautiful?");
                    this.Controls.Clear();
                    level = 4;
                    oyun.PuanHesapla(karakter, sayi);
                    // buraya hikaye eklenecek ve puan gösterilecek eğer ilk beşteyse de yazılsın tebrikler ilk 5'e girdiniz
                    Invalidate();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length != 0)
            {
                this.Controls.Clear();
                this.Text = "Can't Escape";
                zamanlayici.Start();
                zamanlayici.Enabled = true;
                basladiMi = true;
                level = 1;
                Invalidate();
                sbtTuzak.TuzakOlustur();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            HtP_Form formPlay = new HtP_Form();
            formPlay.ShowDialog();
        }

        private void btnSkors_Click(object sender, EventArgs e)
        {
            Top_Skors formTop = new Top_Skors();
            formTop.ShowDialog();
        }
    }
}
