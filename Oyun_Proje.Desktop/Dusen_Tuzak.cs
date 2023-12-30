using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyun_Proje.Desktop
{
    internal class Dusen_Tuzak:Tuzaklar
    {
        public Dusen_Tuzak()
        {
            sayac = 0;
            zamanlayici.Interval = 3000;
            resim = Image.FromFile("dsnTuzak.ico");
        }
        public override void TuzakOlustur()
        {
            for (sayac = 0; sayac < 10; sayac++)
            {
                tuzaklar[sayac] = new Dusen_Tuzak();
                tuzaklar[sayac].X = 0;
                tuzaklar[sayac].Y = 0;

                for (; ; )
                {
                    rastgeleSayi = rnd.Next(160, 801);
                    if (rastgeleSayi % 80 == 0)
                    {
                        tuzaklar[sayac].X = rastgeleSayi;
                        break;
                    }
                }
                for (; ; )
                {
                    rastgeleSayi = rnd.Next(0, 321);
                    if (rastgeleSayi % 80 == 0)
                    {
                        tuzaklar[sayac].Y = rastgeleSayi;
                        break;
                    }
                }
            }
        }
        public override void TuzakCiz(Graphics dusenCiz, Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
            {
                rastgeleSayi = rnd.Next(0, 3);
                if (tuzaklar[i] != null)
                    dusenCiz.DrawImage(resim, tuzaklar[i].X, tuzaklar[i].Y, Boyut, Boyut);
            }
        }

        public override void Hareket(Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
            {
                if (tuzaklar[i] != null)
                    tuzaklar[i].Y += Boyut;
                if (karakter.Can > 0)
                    if (tuzaklar[i] != null)
                        if (tuzaklar[i].X == karakter.X && tuzaklar[i].Y == karakter.Y)
                            CanAzalt(karakter);
            }
        }
    }
}
