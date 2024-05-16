
/*
                Öğrenci Bilgileri
-------------------------------------------------
  Nesneye Dayalı Programlama Dersi Proje Ödevi

 İsim: Esma KARA
 Numara: B221200007
 Mail: esma.kara4@ogr.sakarya.edu.tr

 Bölüm: Bilişim Sistemleri Mühendisliği /2.sınıf
-------------------------------------------------

 */

using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace Oyun_Proje.Desktop
{
    public partial class AnaForm : Form
    {
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
        bool sonlandiMi;
        private int level;
        private int sayi;
        public AnaForm()
        {
            DoubleBuffered = true;
            InitializeComponent();

            zamanlayici = new Timer();
            oyun = new Oyun();
            sbtTuzak = new Sabit_Tuzak();
            dsnTuzak = new Dusen_Tuzak();
            cnvrTuzak = new Canavar_Tuzak();
            karakter = new Karakter();
            srpzKutu = new Surpriz_Kutu();
            pnlOyunBilgi = new Panel();

            pnlOyunBilgi.Controls.AddRange(oyun.labelListe.ToArray());

            basladiMi = false;
            durduMu = false;
            sonlandiMi = false;
            zamanlayici.Interval = 1000;

            sayi = 0;

            KeyDown += AnaForm_KeyDown;
            Paint += AnaForm_Paint;
            zamanlayici.Tick += Zamanlayici_Tick;
        }

        private void Zamanlayici_Tick(object sender, EventArgs e)
        {
            // her saniyede hareket etmesi gereken tuzakların hareket fonksiyonunun çağırılması
            dsnTuzak.Hareket(karakter);
            cnvrTuzak.Hareket(karakter);
            Invalidate();

            oyun.PanelEkranaYazdir(txtName.Text, level, karakter, sayi);

            // levellere göre ve oluşturulması gereken interval'ın farklılıkları nedeniyle sürenin moduna göre
            // tuzakların / sürpriz kutuların oluşturulması
            if (level == 2)
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
            
            // oyuncu ismi, level, kalan can, süre yazdırılan panel
            oyun.PanelEkranaYazdir(txtName.Text, level, karakter, sayi);

            sayi++;
        }

        private void AnaForm_Paint(object sender, PaintEventArgs e)
        {
            // levellere göre oyunun çizdirilmesi
            if (level == 1)
            {
                if (basladiMi == true)
                {
                    oyun.BaslatCiz(e.Graphics, sbtTuzak, karakter, srpzKutu, basladiMi, level);
                    oyun.PanelEkranaYazdir(txtName.Text, level, karakter, sayi);
                    this.Controls.Add(pnlOyunBilgi);
                }

                oyun.OyunuYazdir(e.Graphics, sbtTuzak, karakter, srpzKutu, level);
                this.Controls.Add(pnlOyunBilgi);
            }

            else if (level == 2)
            {
                oyun.OyunuYazdir(e.Graphics, dsnTuzak, karakter, srpzKutu, level);
                oyun.PanelEkranaYazdir(txtName.Text, level, karakter, sayi);
                this.Controls.Add(pnlOyunBilgi);
            }

            else if (level == 3)
            {
                oyun.OyunuYazdir(e.Graphics, cnvrTuzak, karakter, srpzKutu, level);
                oyun.PanelEkranaYazdir(txtName.Text, level, karakter, sayi);
                this.Controls.Add(pnlOyunBilgi);
            }

            // oyun sonunda puan hesabı ve final hikayenin görünmesi
            else if(level == 4 && sonlandiMi == false) 
            {
                SkorYazdirma.txtEkle(txtName.Text, oyun.PuanHesapla(karakter, sayi));
                oyun.HikayeyiGoster(e.Graphics);
                sonlandiMi = true;

                //AnaForm yeniOyunFormu = new AnaForm();
                //yeniOyunFormu.Show();
                //this.Close();
            }
            else if (sonlandiMi)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            // P tuşuyla durdurulduysa bunlar:
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
            // durdurulmadıysa bu kodlar çalışacak
            else
            {
                if (durduMu == false)
                {
                    // hangi tuşa basıldığına göre karakterin hareketi
                    karakter.HareketEt(e);
                    Invalidate();
                    
                    //sürpriz kutu alındığında ne olacağı
                    if (srpzKutu != null)
                        if (karakter.X == srpzKutu.X && karakter.Y == srpzKutu.Y)
                        {
                            srpzKutu.RastgeleCan(karakter);
                            srpzKutu = null;
                            Invalidate();
                        }
                    
                    /* 170-270 arası kodlar için genel açıklama:
                     * can 0 değilse ve tuzağa denk gelindiyse can azaltılır, ama 0'sa oyun yeniden başlatılır
                     * level atlandığında süre durur ve karakter başa geçer
                     * karakter ilerlediğinde süre akmaya başlar 
                     * bitişe ulaşıldığında level geçme fonksiyonu çağırılır
                     * eğerki leveller de sonlandıysa oyun biter
                    */
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

                            Invalidate();
                        }
                    }

                }
            }            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // eğer menüde bir isim girilmediyse butona tıklansa da oyun başlamaz
            if (txtName.Text.Length != 0&& !(txtName.Text.Contains("-")))
            {
                this.Controls.Clear();
                this.Text = "Can't Escape";

                if (txtName.Text == "muhammed" || txtName.Text == "hüseyin" || txtName.Text == "Muhammed")
                    MessageBox.Show("You win, dear teacher.\n Just kidding :)");

                oyun.OyunuBaslat(zamanlayici, ref basladiMi, ref level, pnlOyunBilgi);

                Invalidate();
                sbtTuzak.TuzakOlustur();
            }
            else
            {
                MessageBox.Show("U can't enter '-' or null.");
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            // How to Play formu oluşturulup gösteriliyor
            HtP_Form formPlay = new HtP_Form();
            formPlay.ShowDialog();
        }

        private void btnSkors_Click(object sender, EventArgs e)
        {
            // Top Skors formu oluşturulup gösteriliyor
            Top_Skors formTop = new Top_Skors();
            formTop.ShowDialog();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
