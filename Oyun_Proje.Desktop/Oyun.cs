
using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Oyun_Proje.Desktop
{
    internal class Oyun
    {
        Label lblOyuncuİsmi;
        Label lblLevel;
        Label lblCan;
        Label lblSure;
        Point lokasyon;
        Font font;
        Size size;
        int puan;

        public Oyun()
        {
            lblSure = new Label();
            lblCan = new Label();
            lblLevel = new Label();
            lblOyuncuİsmi = new Label();

            size = new Size(160, 80);
            lokasyon = new Point(40,28);
            font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Regular);
        }

        public void LabelEkle(Label label, Panel panel)
        {
            label.Location = lokasyon;
            label.ForeColor = Color.White;
            label.Font = font;
            label.Size = size;
            panel.Controls.Add(label);
            lokasyon.X += 80 * 3;
        }

        public void EkranaYazdir(Panel panel, string isim, int level, Karakter karakter, int zamanlayici)
        {
            lblOyuncuİsmi.Text = "Player Name: \n \n" + isim;
            lblLevel.Text = "Level: \n \n" + Convert.ToString(level);
            lblCan.Text = "Kalan Can: \n \n" + Convert.ToString(karakter.Can);
            lblSure.Text = "Süre: \n \n" + zamanlayici.ToString();

            LabelEkle(lblOyuncuİsmi, panel);
            LabelEkle(lblLevel, panel);
            LabelEkle(lblCan, panel);
            LabelEkle(lblSure, panel);

            panel.Size = new Size(1300, 120);
            panel.Location = new Point(0, 0);
            panel.Dock = DockStyle.Top;
        }

        public void EkraniTemizle()
        {
        }

        public void PuanHesapla(Karakter karakter, int sayi)
        {
            puan = karakter.Can * 500 + (1000 - sayi);
        }

        public void HikayeyiGoster(Graphics ciz)
        {
            Image ımage = Image.FromFile("SonHikaye1.png");
            ciz.DrawImage(ımage, 80, 150, 200, 200);
            ımage = Image.FromFile("SonHikaye2.jpeg");
            ciz.DrawImage(ımage, 280, 150, 200, 200);
            ımage = Image.FromFile("SonHikaye3.jpeg");
            ciz.DrawImage(ımage, 480, 150, 200, 200);
            ımage = Image.FromFile("SonHikaye4.jpeg");
            ciz.DrawImage(ımage, 680, 150, 200, 200);

        }

        public void OyunuBaslat(Timer zaman)
        {
        }
    }
}
