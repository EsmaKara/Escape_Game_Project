using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oyun_Proje.Desktop
{
    internal class Tuzaklar:Cisim
    {
        protected Tuzaklar[] tuzaklar = new Tuzaklar[10];
        public Image[] resimler = new Image[3];
        public int can = 3;

        public Random rnd = new Random();

        public void CanAzalt(Karakter karakter, ref Timer zamanlayici)
        {
            for (int i = 0; i < 10; i++)
            {
                if (tuzaklar[i].X == karakter.X)
                {
                    if(can > 0)
                        can -= 1;
                    break;
                }
            }
            Oyun.OyunuBitir(can,ref zamanlayici);
        }
        public void Hareket()
        {

        }
    }

    internal class Sabit_Tuzak:Tuzaklar
    {
        private int sayac;
        private int rastgeleSayi;
        public Sabit_Tuzak()
        {
            for (int i = 0; i < 3; i++) 
            {
                if(i == 0) 
                    resimler[i] = Image.FromFile("sbtTuzak1.jpeg");
                if (i == 1)
                    resimler[i] = Image.FromFile("sbtTuzak2.jpeg");
                if (i == 2)
                    resimler[i] = Image.FromFile("sbtTuzak3.jpeg");
            }
        }
        public void SabitTuzakOlustur()
        {
            for (sayac = 0; sayac < 10; sayac++)
            {
                tuzaklar[sayac] = new Sabit_Tuzak();
                tuzaklar[sayac].X = 0;
                tuzaklar[sayac].Y = 0;

                for (; ;)
                {
                    rastgeleSayi = rnd.Next(80, 801);
                    if (rastgeleSayi % 80 == 0)
                    {
                        tuzaklar[sayac].X = rastgeleSayi;
                        break;
                    }
                }
                for (; ; )
                {
                    rastgeleSayi = rnd.Next(160, 341);
                    if (rastgeleSayi % 80 == 0)
                    {
                        tuzaklar[sayac].Y = rastgeleSayi;
                        break;
                    }
                }
            }
        }

        public void SabitTuzakCiz(Graphics sbtTuzak)
        {
            for (int i = 0; i < 10; i++)
            {
                rastgeleSayi = rnd.Next(0, 3);
                if (tuzaklar[i] != null)
                    sbtTuzak.DrawImage(resimler[rastgeleSayi], tuzaklar[i].X, tuzaklar[i].Y, Boyut, Boyut);
            }
        }
    }
}
