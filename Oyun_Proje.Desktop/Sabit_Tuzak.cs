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

using System.Drawing;

namespace Oyun_Proje.Desktop
{
    internal class Sabit_Tuzak:Tuzaklar
    {
        public Sabit_Tuzak()
        {
            resimler = new Image[3];
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                    resimler[i] = Image.FromFile("sbtTuzak1.jpeg");
                if (i == 1)
                    resimler[i] = Image.FromFile("sbtTuzak2.jpeg");
                if (i == 2)
                    resimler[i] = Image.FromFile("sbtTuzak3.jpeg");
            }
        }
        public override void TuzakOlustur()
        {
            for (sayac = 0; sayac < 10; sayac++)
            {
                tuzaklar[sayac] = new Sabit_Tuzak();
                tuzaklar[sayac].X = 0;
                tuzaklar[sayac].Y = 0;

                for (; ; )
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
                    rastgeleSayi = rnd.Next(160, 321);
                    if (rastgeleSayi % 80 == 0)
                    {
                        tuzaklar[sayac].Y = rastgeleSayi;
                        break;
                    }
                }
            }
        }

        public override void TuzakCiz(Graphics sbtTuzak)
        {
            for (int i = 0; i < 10; i++)
            {
                rastgeleSayi = rnd.Next(0, 3);
                if (tuzaklar[i] != null)
                    sbtTuzak.DrawImage(resimler[rastgeleSayi], tuzaklar[i].X, tuzaklar[i].Y, Boyut, Boyut);
            }
        }

        /// <summary>
        /// karakter tuzağın üstüne gelmesi durumunda, üstünde durduğu tuzağın ve ondan öncekilerin görünmesini sağlar
        /// </summary>
        /// <param name="ciz"></param>
        /// <param name="karakter"></param>
        public override void SabitTuzakGoster(Graphics ciz, Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
            {
                if (karakter.X >= tuzaklar[i].X)
                {
                    if (karakter.Y == tuzaklar[i].Y)
                    {
                        rastgeleSayi = rnd.Next(0, 3);
                        if (tuzaklar[i] != null)
                            ciz.DrawImage(resimler[rastgeleSayi], tuzaklar[i].X, tuzaklar[i].Y, Boyut, Boyut);
                    }
                }
            }
        }
    
}
}
