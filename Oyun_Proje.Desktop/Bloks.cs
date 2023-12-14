using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyun_Proje.Desktop
{
    internal class Bloks:GenelSınıf
    {
        public Bloks() 
        {
            resim = Image.FromFile("Bloks.jpeg");
            X = 80;
            Y = 120;
        }

        public void BlokEkle(Graphics blokCiz)
        {
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    blokCiz.DrawImage(resim, X, Y, Boyut, Boyut);
                    X += Boyut;
                }
                Y += Boyut;
                X -= Boyut*10;
            }
        }
    }
}
