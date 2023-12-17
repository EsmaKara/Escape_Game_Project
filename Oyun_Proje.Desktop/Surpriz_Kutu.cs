﻿
using System;
using System.Drawing;


namespace Oyun_Proje.Desktop
{
    internal class Surpriz_Kutu:Cisim
    {
        private int sayi;
        public Surpriz_Kutu()
        {
            resimler = new Image[6];
            rnd = new Random();
            sayi = 0;

            resim = Image.FromFile("srpzKutu1.ico");
        }

        public void RastgeleCan(Karakter karakter)
        {
            sayi = rnd.Next(1,11);
            if (sayi == 1 || sayi == 2 || sayi == 3 || sayi == 4 || sayi == 5 || sayi == 6 || sayi == 7 || sayi == 8) 
            {
                if (karakter.Can < 3)
                    karakter.Can += 1;
                else if (sayi == 9 || sayi == 10)
                    karakter.Can -= 1;
            }
        }

        public void KutuOlustur(Surpriz_Kutu kutu)
        {
            for (; ; )
            {
                rastgeleSayi = rnd.Next(80, 801);
                if (rastgeleSayi % 80 == 0)
                {
                    kutu.X = rastgeleSayi;
                    break;
                }
            }
            for (; ; )
            {
                rastgeleSayi = rnd.Next(160, 321);
                if (rastgeleSayi % 80 == 0)
                {
                    kutu.Y = rastgeleSayi;
                    break;
                }
            }
        }

        public void KutuCiz(Graphics kutuCiz, Surpriz_Kutu kutu)
        {
            if (kutu != null)
                kutuCiz.DrawImage(resim, kutu.X, kutu.Y, Boyut, Boyut); 
        }
    }
}
