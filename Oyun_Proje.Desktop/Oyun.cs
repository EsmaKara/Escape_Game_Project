﻿
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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Label = System.Windows.Forms.Label;
using Timer = System.Windows.Forms.Timer;

namespace Oyun_Proje.Desktop
{
    internal class Oyun:IOyun
    {
        Label lblOyuncuİsmi;
        Label lblLevel;
        Label lblCan;
        Label lblSure;
        Point lokasyon;
        Font font;
        Size size;
        int puan;
        public List<Label> labelListe;

        Bloks blok;

        public Oyun()
        {
            labelListe = new List<Label>();
            lblSure = new Label();
            lblCan = new Label();
            lblLevel = new Label();
            lblOyuncuİsmi = new Label();
            labelListe.Add(lblOyuncuİsmi);
            labelListe.Add(lblLevel);
            labelListe.Add(lblCan);
            labelListe.Add(lblSure);
            font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Regular);
            size = new Size(160, 80);
            lokasyon = new Point(40,28);
            labelListe.ForEach(label =>
            {
                label.Location = lokasyon;
                label.ForeColor = Color.White;
                label.Font = font;
                label.Size = size;
                lokasyon.X += 80 * 3;
            });

            //labelListe.Select((label) => label.Location).Sum(sayi => sayi.X).ToString();

            blok = new Bloks();
        }


        public void OyunuBaslat(Timer zamanlayici, ref bool basladiMi, ref int level, Panel pnlOyunBİlgi)
        {
            zamanlayici.Start();
            zamanlayici.Enabled = true;
            basladiMi = true;
            level = 1;

            this.PanelAyarla(pnlOyunBİlgi);
        }

        public void BaslatCiz(Graphics ciz, Tuzaklar nesne, Karakter karakter, Surpriz_Kutu srpzKutu, bool basladiMi, int level)
        {
            if (basladiMi == true)
            {
                nesne.TuzakCiz(ciz, karakter);
                blok.BlokEkle(ciz, level);
                if (srpzKutu != null)
                    if (srpzKutu.X != 0)
                        srpzKutu.KutuCiz(ciz, srpzKutu);
                karakter.KarakterCiz(ciz, karakter);
            }
        }

        public void OyunuYazdir(Graphics ciz, Tuzaklar nesne, Karakter karakter, Surpriz_Kutu srpzKutu, int level)
        {
            blok.BlokEkle(ciz, level);
            if (srpzKutu != null)
                if (srpzKutu.X != 0)
                    srpzKutu.KutuCiz(ciz, srpzKutu);
            if (level == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (nesne.tuzaklar[i] != null)
                        if (karakter.X == nesne.tuzaklar[i].X && karakter.Y == nesne.tuzaklar[i].Y)
                        {
                            nesne.SabitTuzakGoster(ciz, karakter);
                        }
                }
            }
            else
                nesne.TuzakCiz(ciz, karakter);
            karakter.KarakterCiz(ciz, karakter);
        }

        public void LevelGecme(Timer zamanlayici, Karakter karakter)
        {
            zamanlayici.Stop();
            zamanlayici.Enabled = false;
            if (karakter.Can != 3)
                karakter.Can += 1;
            karakter.X = 80;
            karakter.Y = 240;
        }

        public void YenidenBaslat(ref Karakter karakter, ref int sayi, ref int level, ref bool basladiMi)
        {
            sayi = 0;
            karakter = new Karakter();
            level = 1;
            basladiMi = true;
        }

        public void OyunuBitir(Timer zamanlayici)
        {
            zamanlayici.Stop();
            zamanlayici.Enabled = false;
            MessageBox.Show("Hey, it's finally over. Isn't it beautiful?");
        }


        /// <summary>
        /// Oyun esnasında gösterilecek bilgiler için oluşturulan panel kontrolünün özelleriklerinin ayarlanması
        /// </summary>
        /// <param name="pnlOyunBilgi"> panelin kendisi parametre olarak verilir </param>
        public void PanelAyarla(Panel pnlOyunBilgi)
        {
            pnlOyunBilgi.Size = new Size(1300, 120);
            pnlOyunBilgi.BackColor = Color.Black;
            pnlOyunBilgi.Location = new Point(0, 0);
            pnlOyunBilgi.Dock = DockStyle.Top;
        }

        /// <summary>
        /// Panelde görünmesi gereken label kontrollerinin metinlerine atama gerçekleştirilir
        /// </summary>
        /// <param name="isim"> kullanıcının menü ekranındaki textbox aracına girdiği metin </param>
        /// <param name="level"></param>
        /// <param name="karakter"> kalan can için karakter parametresi </param>
        /// <param name="zamanlayici"> sürenin yazdırılması için </param>
        public void PanelEkranaYazdir(string isim, int level, Karakter karakter, int zamanlayici)
        {
            lblOyuncuİsmi.Text = "Player Name: \n \n" + isim;
            lblLevel.Text = "Level: \n \n" + Convert.ToString(level);
            lblCan.Text = "Remaining Life: \n \n" + Convert.ToString(karakter.Can);
            lblSure.Text = "Time: \n \n" + zamanlayici.ToString();
        }

        /// <summary>
        ///  Oyun sonunda puan hesaplamak için çağırılan fonksiyon
        /// </summary>
        /// <param name="karakter"> karakterin can sayısına ulaşmak için paremetre </param>
        /// <param name="sayi"> geçen süre </param>
        /// <returns></returns>
        public int PuanHesapla(Karakter karakter, int sayi)
        {
            puan = karakter.Can * 500 + (1000 - sayi);
            return puan;
        }

        /// <summary>
        ///  Oyunun hikayeyle bitmesini istediğim için oyun sonunda gösterilecek fotoğrafların ayarlanması
        /// </summary>
        /// <param name="ciz"> fotoğraf çizdirildiği için Graphics nesnesine ihtiyaç duyulur </param>
        public void HikayeyiGoster(Graphics ciz)
        {


            Image ımage = Image.FromFile("SonHikaye1.png");
            ciz.DrawImage(ımage, 80, 150, 200, 200);
            ımage = Image.FromFile("FinalHeader.jpeg");
            ciz.DrawImage(ımage, 280, 50, 400, 100);
            ımage = Image.FromFile("SonHikaye2.jpeg");
            ciz.DrawImage(ımage, 280, 150, 200, 200);
            ımage = Image.FromFile("SonHikaye3.jpeg");
            ciz.DrawImage(ımage, 480, 150, 200, 200);
            ımage = Image.FromFile("SonHikaye4.jpeg");
            ciz.DrawImage(ımage, 680, 150, 200, 200);

        }

    }
}
