using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override void TuzakCiz(Graphics cnvrTuzak, Karakter karakter)
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
                            cnvrTuzak.DrawImage(resimler[rastgeleSayi], tuzaklarinDizisi[sayi][i].X, tuzaklarinDizisi[sayi][i].Y, Boyut, 78);
                        }
                        else if (tuzaklarinDizisi[sayi][i].X == 80)
                            tuzaklarinDizisi[sayi][i] = null;
                    }
                }
            }
        }

        public override void Hareket(Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
            {
                if (tuzaklar[i] != null)
                    tuzaklar[i].X -= Boyut;
                if (karakter.Can > 0)
                    if (tuzaklar[i] != null)
                        if (tuzaklar[i].X == karakter.X && tuzaklar[i].Y == karakter.Y)
                            CanAzalt(karakter);
            }
        }
    }
}
