using System.Data.SqlTypes;
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

        public void KarakterCiz(Graphics karakterCiz)
        {
            karakterCiz.DrawImage(resim, X, Y, Boyut, Boyut);
        }

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
        public void SolaGit() { X -= Boyut; }
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