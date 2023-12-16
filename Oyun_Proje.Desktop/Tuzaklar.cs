
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    internal class Tuzaklar : Cisim
    {
        public Tuzaklar[] tuzaklar = new Tuzaklar[10];
        public Image[] resimler = new Image[3];
        public int can = 3;
        protected int sayac;
        protected int rastgeleSayi;
        public Timer zamanlayici;

        public Tuzaklar()
        {
            zamanlayici = new Timer();
        }


        public Random rnd = new Random();

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
        public virtual void Hareket()   {   }
    }

    internal class Sabit_Tuzak : Tuzaklar
    {
        public Sabit_Tuzak()
        {
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
        public void SabitTuzakOlustur()
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
                    rastgeleSayi = rnd.Next(160, 341);
                    if (rastgeleSayi % 80 == 0)
                    {
                        tuzaklar[sayac].Y = rastgeleSayi;
                        break;
                    }
                }
            }
        }

        public void SabitTuzakCiz(Graphics sbtTuzak, Karakter karakter)
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
        public void DusenTuzakOlustur()
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
                    rastgeleSayi = rnd.Next(80, 341);
                    if (rastgeleSayi % 80 == 0)
                    {
                        tuzaklar[sayac].Y = rastgeleSayi;
                        break;
                    }
                }
            }

        }
        public void DusenTuzakCiz (Graphics dusenCiz, Karakter karakter)
        {
            for (int i = 0; i < 10; i++)
            {
                rastgeleSayi = rnd.Next(0, 3);
                if (tuzaklar[i] != null)
                    dusenCiz.DrawImage(resim, tuzaklar[i].X, tuzaklar[i].Y, Boyut, Boyut);
            }
        }

        public override void Hareket()
        {
            for (int i =0; i < 10; i++)
            {
                if (tuzaklar[i] != null)
                    tuzaklar[i].Y += Boyut;
            }
        }
    }
}
