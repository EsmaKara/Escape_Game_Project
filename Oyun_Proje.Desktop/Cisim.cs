
using System;
using System.Drawing;

namespace Oyun_Proje.Desktop
{
    internal class Cisim
    {
        private int x;
        private int y;
        private int boyut;
        protected Image resim;
        public Image[] resimler;
        protected int rastgeleSayi;
        protected int sayac;
        public Random rnd;

        public Cisim() { boyut = 80; }
        public int X
        {
            get => x;
            set
            {
                if (value <= 1040 && value >= 30)
                    x = value;
            }
        }
        public int Y
        {
            get => y;
            set
            {
                if (value <= 590 && value >= 30)
                    y = value;
            }
        }
        public int Boyut { get => boyut; }
    }
}
