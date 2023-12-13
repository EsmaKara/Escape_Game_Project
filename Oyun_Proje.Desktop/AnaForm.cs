using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    public partial class AnaForm : Form
    {
        Karakter karakter = new Karakter();
        public AnaForm()
        {
            Width = 1070;
            Height = 620;
            InitializeComponent();


            KeyDown += AnaForm_KeyDown;
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName != null)
            {

            }
        }
    }
}
