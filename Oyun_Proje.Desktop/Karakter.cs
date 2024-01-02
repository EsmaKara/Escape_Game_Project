
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
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    internal class Karakter : Cisim
    {
        private int can;

        public int Can { get => can; set => can = value; }

        public Karakter()
        {
            resim = Image.FromFile("Karakter.ico");
            X = 0;
            Y = 240;
            Can = 3;
        }

        public void KarakterCiz(Graphics karakterCiz, Karakter karakter)
        {
            karakterCiz.DrawImage(resim, karakter.X, karakter.Y, Boyut, Boyut);
        }

        // yakalanan tuşun bilgisine göre hareket fonksiyonlarının çağırılması
        public void HareketEt(KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.Left: SolaGit(); break;
                case Keys.Right: SagaGit(); break;
                case Keys.Up: YukariGit(); break;
                case Keys.Down: AsagiGit(); break;
            }
        }
        // hareket durumlarında oyun oynanış alanından çıkma durumlarının kontrolüyle
        // birlikte hareketlerin gerçekleştirilmesi
        public void SolaGit() 
        { 
            if (X > 0)
                X -= Boyut; 
        }
        public void SagaGit()
        {
            if (X != 880)
                X += Boyut;
        }
        public void AsagiGit()
        {
            if (Y != 240 + Boyut)
                Y += Boyut;
        }
        public void YukariGit()
        {
            if (Y != 240 - Boyut)
                Y -= Boyut;
        }

    }
}