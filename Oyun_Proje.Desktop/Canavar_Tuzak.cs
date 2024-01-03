
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
    internal class Canavar_Tuzak:Tuzaklar
    {
        public Tuzaklar[][] tuzaklarinDizisi;
        int sayi;

        public Canavar_Tuzak()
        {
            sayi = 0;
            sayac = 0;
            tuzaklarinDizisi = new Tuzaklar[10][];
            tuzaklar = new Tuzaklar[Boyut];
            resimler = new Image[6];

            // birden fazla fotoğraf kullanacağım için atamaları yapıyorum
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                    resimler[i] = Image.FromFile("cnvrTuzak1.ico");
                else if (i == 1)
                    resimler[i] = Image.FromFile("cnvrTuzak2.ico");
                else if (i == 2)
                    resimler[i] = Image.FromFile("cnvrTuzak3.ico");
                else if (i == 3)
                    resimler[i] = Image.FromFile("cnvrTuzak4.ico");
                else if (i == 4)
                    resimler[i] = Image.FromFile("cnvrTuzak5.ico");
                else
                    resimler[i] = Image.FromFile("cnvrTuzak6.ico");
            }
        }

        /// <summary>
        /// tuzaklar y'leri rastgele olacak biçimde oluşturulur
        /// sürekli bir oluşturma yapısı için sayac yardımıyla kontrol edilir
        /// </summary>
        public override void TuzakOlustur()
        {
            tuzaklar[sayac] = new Canavar_Tuzak();
            tuzaklar[sayac].X = 800;
            tuzaklar[sayac].Y = 0;

            for (; ; )
            {
                rastgeleSayi = rnd.Next(160, 321);
                if (rastgeleSayi % 80 == 0)
                {
                    tuzaklar[sayac].Y = rastgeleSayi;
                    break;
                }
            }

            if (sayac < 9)
                sayac++;
            else
                sayac = 0;

            if (sayi < 9)
                sayi++;
            else
                sayi = 0;
            tuzaklarinDizisi[sayi] = tuzaklar;
        }

        /// <summary>
        /// canavarlarımın içerisinde bulunduğu dizilerimi tutan dizimin boş olmadığı takdirde 
        /// sayi'ncı elemanının içerisindeki dizide dolaşarak rastgele resimlerle canavarların çizdirilmesi 
        /// </summary>
        /// <param name="ciz"> çizim için Graphics nesnesi </param>
        public override void TuzakCiz(Graphics ciz)
        {
            if (tuzaklarinDizisi[sayi] != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (tuzaklarinDizisi[sayi][i] != null)
                    {
                        if (tuzaklarinDizisi[sayi][i].X != 80)
                        {
                            rastgeleSayi = rnd.Next(0, 6);
                            ciz.DrawImage(resimler[rastgeleSayi], tuzaklarinDizisi[sayi][i].X, tuzaklarinDizisi[sayi][i].Y, Boyut, 78);
                        }
                        else if (tuzaklarinDizisi[sayi][i].X == 80)
                            tuzaklarinDizisi[sayi][i] = null;
                    }
                }
            }
        }

        /// <summary>
        /// tuzakların x ekseninde hareketini sağlar
        /// </summary>
        /// <param name="karakter"> CanAzalt fonksiyonuna parametre vermek için</param>
        public override void Hareket(Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
            {
                if (tuzaklar[i] != null)
                    tuzaklar[i].X -= Boyut;
            }
            if (karakter.Can > 0)
                CanAzalt(karakter);
        }
    }
}
