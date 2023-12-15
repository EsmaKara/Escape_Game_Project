using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyun_Proje.Desktop
{
    internal class Cisim:Oyun
    {
        private static int x;
        private static int y;
        private static int boyut;
        protected static Image resim;

        public Cisim() { boyut = 80; }
        public static int X
        {
            get => x;
            set
            {
                if (value <= 1040 && value >= 30)
                    x = value;
            }
        }
        public static int Y
        {
            get => y;
            set
            {
                if (value <= 590 && value >= 30)
                    y = value;
            }
        }
        public static int Boyut { get => boyut; }
    }
}
