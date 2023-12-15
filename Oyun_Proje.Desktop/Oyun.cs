using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Oyun_Proje.Desktop
{
    internal class Oyun
    {
        Bloks blok;
        Karakter karakter;
        Timer zamanlayici;
        Sabit_Tuzak sbtTuzak;
        bool basladiMi;
        public Oyun()
        {
            blok = new Bloks();
            karakter = new Karakter();
            zamanlayici = new Timer();
            sbtTuzak = new Sabit_Tuzak();
            basladiMi = false;

            zamanlayici.Interval = 1000;
        }

        public static void EkraniTemizle()
        {
        }

        public void OyunuBaslat(Timer zaman)
        {
        }

        public static void OyunuBitir(int can, ref Timer zamanlayici)
        {
            if (can == 0)
                zamanlayici.Stop();
        }


        public static void Ciz() 
        { 

        }

    }
}
