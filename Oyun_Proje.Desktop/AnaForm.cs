
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace Oyun_Proje.Desktop
{
    public partial class AnaForm : Form
    {
        Top_Skors formTop;

        Panel pnlOyunBilgi;
        Timer zamanlayici;
        Oyun oyun;
        
        Sabit_Tuzak sbtTuzak;
        Dusen_Tuzak dsnTuzak;
        Canavar_Tuzak cnvrTuzak;
        Karakter karakter;
        Surpriz_Kutu srpzKutu;

        bool basladiMi;
        bool durduMu;
        private int level;
        private int sayi;
        public AnaForm()
        {
            DoubleBuffered = true;
            InitializeComponent();

            formTop = new Top_Skors();

            zamanlayici = new Timer();
            oyun = new Oyun();
            
            sbtTuzak = new Sabit_Tuzak();
            dsnTuzak = new Dusen_Tuzak();
            cnvrTuzak = new Canavar_Tuzak();
            karakter = new Karakter();
            srpzKutu = new Surpriz_Kutu();

            pnlOyunBilgi = new Panel();
            pnlOyunBilgi.Size = new Size(1300, 120);
            pnlOyunBilgi.BackColor = Color.Black;
            pnlOyunBilgi.Location = new Point(0,0);
            pnlOyunBilgi.Dock = DockStyle.Top;
            pnlOyunBilgi.Controls.AddRange(oyun.labelListe.ToArray());

            basladiMi = false;
            durduMu = false;
            zamanlayici.Interval = 1000;

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

            oyun.PanelEkranaYazdir(pnlOyunBilgi, txtName.Text, level, karakter, sayi);

            sayi++;
        }

        private void AnaForm_Paint(object sender, PaintEventArgs e)
        {
            if (level == 1)
            {
                if (basladiMi == true)
                {
                    oyun.OyunuBaslat(e.Graphics, sbtTuzak, karakter, srpzKutu, basladiMi, level);

                    this.Controls.Add(pnlOyunBilgi);
                }

                oyun.OyunuYazdir(e.Graphics, sbtTuzak, karakter, srpzKutu, level);
                this.Controls.Add(pnlOyunBilgi);
            }

            else if (level == 2)
            {
                oyun.OyunuYazdir(e.Graphics, dsnTuzak, karakter, srpzKutu, level);
                this.Controls.Add(pnlOyunBilgi);
            }

            else if (level == 3)
            {
                oyun.OyunuYazdir(e.Graphics, cnvrTuzak, karakter, srpzKutu, level);
                this.Controls.Add(pnlOyunBilgi);
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
                if (durduMu == false)
                {
                    zamanlayici.Stop();
                    zamanlayici.Enabled = false;
                    MessageBox.Show("The game stopped. Press 'P' again to continue. ");
                    durduMu = true;
                }
                else
                {
                    zamanlayici.Start();
                    zamanlayici.Enabled = true;
                    durduMu = false;
                }
            }
            else
            {
                if (durduMu == false)
                {
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
                            oyun.YenidenBaslat(ref karakter, ref sayi, ref level, ref basladiMi);

                            this.Controls.Clear();
                            Invalidate();
                            sbtTuzak.TuzakOlustur();
                        }

                        if (karakter.X == 880)
                        {
                            oyun.LevelGecme(zamanlayici, karakter);
                            MessageBox.Show("Oh, you are recovering well. ");
                            this.Controls.Clear();

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
                        else if (karakter.Can == 0)
                        {
                            oyun.YenidenBaslat(ref karakter, ref sayi, ref level, ref basladiMi);

                            this.Controls.Clear();
                            Invalidate();
                            sbtTuzak.TuzakOlustur();
                        }
                        Invalidate();
                        if (karakter.X == 160)
                        {
                            zamanlayici.Start();
                            zamanlayici.Enabled = true;
                            basladiMi = false;
                        }

                        if (karakter.X == 880)
                        {
                            oyun.LevelGecme(zamanlayici, karakter);
                            MessageBox.Show("What's that, are you OKAY? ");
                            this.Controls.Clear();

                            level = 3;
                            Invalidate();
                        }
                    }

                    else if (level == 3)
                    {
                        Invalidate();
                        if (karakter.Can != 0)
                            cnvrTuzak.CanAzalt(karakter);
                        else
                        {
                            oyun.YenidenBaslat(ref karakter, ref sayi, ref level, ref basladiMi);
                            this.Controls.Clear();
                            for (int i = 0; i < 10; i++)
                                if (cnvrTuzak.tuzaklarinDizisi[i] != null)
                                    for (int j = 0; j < 10; j++)
                                        cnvrTuzak.tuzaklarinDizisi[i][j] = null;
                            
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
                            oyun.OyunuBitir(zamanlayici);

                            this.Controls.Clear();
                            level = 4;

                            formTop.pnlYaz.Controls.AddRange(SkorYazdirma.Yazdir(txtName.Text, oyun.PuanHesapla(karakter, sayi)).ToArray());
                            // buraya hikaye eklenecek ve puan gösterilecek eğer ilk beşteyse de yazılsın tebrikler ilk 5'e girdiniz
                            Invalidate();
                        }
                    }

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
            formTop.Show();
        }
    }
}
