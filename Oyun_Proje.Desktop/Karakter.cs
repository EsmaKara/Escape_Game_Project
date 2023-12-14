using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    internal class Karakter:GenelSınıf
    {
        public Karakter()
        {
            resim = Image.FromFile("Karakter.ico");
            X = 1;
            Y = 200;
        }

        public void KarakterCiz(Graphics karakterCiz)
        {
            karakterCiz.DrawImage(resim, X, Y, Boyut, Boyut);
        }

        public void HareketEt(KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.Left: this.SolaGit(); break;
                case Keys.Right: this.SagaGit(); break;
                case Keys.Up: this.YukariGit(); break;
                case Keys.Down: this.AsagiGit(); break;
            }
        }
        public void SolaGit()   {   X -= Boyut;    }
        public void SagaGit()   {   X += Boyut;    }
        public void YukariGit() {   Y -= Boyut;    }
        public void AsagiGit()  {   Y += Boyut;    }
    }
}