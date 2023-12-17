
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

        public Oyun()
        {
            lblSure = new Label();
            lblCan = new Label();
            lblLevel = new Label();
            lblOyuncuİsmi = new Label();

            size = new Size(160, 80);
            lokasyon = new Point(20,28);
            font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Regular);
        }

        public void EkranaYazdir(Panel panel, string isim, int level, Karakter karakter, Timer zamanlayici)
        {
            lblOyuncuİsmi.Text = "Player Name: \n \n" + isim;
            lblLevel.Text = "Level: \n \n" + Convert.ToString(level);
            lblCan.Text = "Kalan Can: \n \n" + Convert.ToString(karakter.Can);
            lblSure.Text = "Süre: \n \n" + zamanlayici.ToString();

            lokasyon.X = 40;
            lblOyuncuİsmi.Location = lokasyon;
            lokasyon.X = 280;
            lblLevel.Location = lokasyon;
            lokasyon.X = 520;
            lblCan.Location = lokasyon;
            lokasyon.X = 760;
            lblSure.Location = lokasyon;

            lblOyuncuİsmi.ForeColor = Color.White;
            lblLevel.ForeColor = Color.White;
            lblCan.ForeColor = Color.White;
            lblSure.ForeColor = Color.White;

            lblOyuncuİsmi.Font = font;
            lblLevel.Font = font;
            lblCan.Font = font;
            lblSure.Font = font;

            lblOyuncuİsmi.Size = size;
            lblLevel.Size = size;
            lblCan.Size = size;
            lblSure.Size = size;

            panel.Controls.Add(lblOyuncuİsmi);
            panel.Controls.Add(lblLevel);
            panel.Controls.Add(lblCan);
            panel.Controls.Add(lblSure);

            panel.Size = new Size(1300, 120);
            panel.Location = new Point(0, 0);
            panel.Dock = DockStyle.Top;
        }

        public void EkraniTemizle()
        {
        }

        public void PuanHesapla()
        {

        }

        public void OyunuBaslat(Timer zaman)
        {
        }
    }
}
