using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    public partial class AnaForm : Form
    {
        Bloks blok;
        Karakter karakter;
        Timer zamanlayici;
        Oyun oyun;
        bool basladiMi;
        public AnaForm()
        {
            InitializeComponent();

            karakter = new Karakter();
            zamanlayici = new Timer();
            oyun = new Oyun();
            blok = new Bloks(); 
            basladiMi = false;

            KeyDown += AnaForm_KeyDown;
            Paint += AnaForm_Paint;
            Paint += AnaForm_Paint_Basla;
        }


        private void AnaForm_Paint(object sender, PaintEventArgs e)
        {
                karakter.KarakterCiz(e.Graphics);
        }

        private void AnaForm_Paint_Basla(object sender, PaintEventArgs e)
        {
            if (basladiMi == true)
            {
                karakter.KarakterCiz(e.Graphics);
                blok.BlokEkle(e.Graphics);
                basladiMi = false;
            }
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            karakter.HareketEt(e);
            if(e.KeyCode == Keys.P)
            {

            }
            Invalidate();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length != 0)
            {
                this.Controls.Clear();
                zamanlayici.Start();
                basladiMi = true;
                Invalidate();
            }
        }
    }
}
