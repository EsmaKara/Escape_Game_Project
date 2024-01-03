
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
    internal class Dusen_Tuzak:Tuzaklar
    {
        public Dusen_Tuzak()
        {
            resim = Image.FromFile("dsnTuzak.ico");
        }
        /// <summary>
        /// dizimin elemanı için nesne oluşturulup koordinatları için rastgele sayılar üretiyorum
        /// bu rastgele sayılar için mod 80 0 olmalı ki çizdirdiğim blok/karakter vb. elemanlarım 
        /// ile entegre boyutlara ve koordinatlara sahip olsun 
        /// </summary>
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
        
        // tuzakların koordinatlara göre çizdirilmesi
        public override void TuzakCiz(Graphics dusenCiz)
        {
            for (int i = 0; i < 10; i++)
            {
                if (tuzaklar[i] != null)
                    dusenCiz.DrawImage(resim, tuzaklar[i].X, tuzaklar[i].Y, Boyut, Boyut);
            }
        }

        /// <summary>
        /// fonksiyonların y ekseninde hareketi
        /// </summary>
        /// <param name="karakter"> CanAzalt fonksiyonuna parametre vermek için </param>
        public override void Hareket(Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
                if (tuzaklar[i] != null)
                    tuzaklar[i].Y += Boyut;
            if (karakter.Can > 0)
                CanAzalt(karakter);
        }
    }
}
