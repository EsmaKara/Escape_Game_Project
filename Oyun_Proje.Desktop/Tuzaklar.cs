
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
                MessageBox.Show("You believe this is a game. Eh, you may be right. But you think you can play it better than me? Think again.." +
                    "\n 'Space' for restart.");
            }
        }
        public virtual void Hareket(Karakter karakter) { }
        public virtual void TuzakCiz(Graphics cizim, Karakter karakter) { }
        public virtual void TuzakOlustur() { }

        public virtual void SabitTuzakGoster(Graphics sbtTuzak, Karakter karakter) { }
    }        
}
