
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
    internal class Bloks:Cisim
    {
        public Bloks() 
        {
            X = 80;
            Y = 160;
        }

        public void BlokEkle(Graphics blokCiz, int level)
        {
            resim = Image.FromFile("Bloks.jpeg");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    blokCiz.DrawImage(resim, X, Y, Boyut, Boyut);
                    X += Boyut;
                }
                Y += Boyut;
                X -= Boyut*10;
            }
            Y -= Boyut*3;

            if (level == 1)
            {
                resim = Image.FromFile("level1.jpeg");
                blokCiz.DrawImage(resim, Boyut * 11, 160 + Boyut, Boyut, Boyut);
            }
            else if (level == 2)
            {
                resim = Image.FromFile("level2.jpeg");
                blokCiz.DrawImage(resim, Boyut * 11, 160 + Boyut, Boyut, Boyut);
            }
            else if(level == 3)
            {
                resim = Image.FromFile("level3.jpeg");
                blokCiz.DrawImage(resim, Boyut * 11, 160 + Boyut, Boyut, Boyut);
            }

        }
    }
}
