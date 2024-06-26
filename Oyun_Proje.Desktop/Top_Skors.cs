﻿
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

using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    public partial class Top_Skors : Form
    {
        public Top_Skors()
        {
            InitializeComponent();
        }

        private void Top_Skors_Load(object sender, System.EventArgs e)
        {
            SkorYazdirma.Goster().ForEach(dizi =>
            {
                this.pnlYaz.Controls.Add(dizi[0]);
                this.pnlYaz.Controls.Add(dizi[1]);
            });
        }
    }
}
