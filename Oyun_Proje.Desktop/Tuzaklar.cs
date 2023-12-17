
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    internal class Tuzaklar : Cisim
    {
        public Tuzaklar[] tuzaklar = new Tuzaklar[10];
        public int can = 3;
        public Timer zamanlayici;

        public Tuzaklar()
        {
            zamanlayici = new Timer();
            rnd = new Random();
        }

        public void CanAzalt(Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
            {
                if (tuzaklar[i] != null)
                {
                    if (tuzaklar[i].X == karakter.X && tuzaklar[i].Y == karakter.Y)
                    {
                        if (karakter.Can > 0)
                        {
                            karakter.Can -= 1;
                        }
                        break;
                    }
                }
            }
            if (karakter.Can == 0)
            {
                MessageBox.Show("YOU DIED IN PAIN..");
            }
        }
        public virtual void Hareket(Karakter karakter)   {   }
        public virtual void TuzakCiz(Graphics cizim, Karakter karakter) { }
        public virtual void TuzakOlustur() { }
    }

    internal class Sabit_Tuzak : Tuzaklar
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

        public override void TuzakCiz(Graphics sbtTuzak, Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
            {
                rastgeleSayi = rnd.Next(0, 3);
                if (tuzaklar[i] != null)
                    sbtTuzak.DrawImage(resimler[rastgeleSayi], tuzaklar[i].X, tuzaklar[i].Y, Boyut, Boyut);
            }
        }

        public void SabitTuzakGoster(Graphics sbtTuzak, Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
            {
                if (karakter.X >= tuzaklar[i].X)
                {
                    if (karakter.Y == tuzaklar[i].Y)
                    {
                        rastgeleSayi = rnd.Next(0, 3);
                        if (tuzaklar[i] != null)
                            sbtTuzak.DrawImage(resimler[rastgeleSayi], tuzaklar[i].X, tuzaklar[i].Y, Boyut, Boyut);
                    }
                }
            }
        }
    }

    internal class Dusen_Tuzak : Tuzaklar
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
            for (int i =0; i < 10; i++)
            {
                if(karakter.Can > 0)
                    if (tuzaklar[i] != null)
                        if (tuzaklar[i].X == karakter.X && tuzaklar[i].Y == karakter.Y)
                            CanAzalt(karakter);
                if (tuzaklar[i] != null)
                    tuzaklar[i].Y += Boyut;
            }
        }
    }

    internal class Canavar_Tuzak : Tuzaklar
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
                else if(i == 4)
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
                if (karakter.Can > 0)
                    if (tuzaklar[i] != null)
                        if (tuzaklar[i].X == karakter.X && tuzaklar[i].Y == karakter.Y)
                            CanAzalt(karakter);
                if (tuzaklar[i] != null)
                    tuzaklar[i].X -= Boyut;
            }
        }
    }
}
