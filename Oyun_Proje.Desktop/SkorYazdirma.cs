
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Oyun_Proje.Desktop
{
    internal static class SkorYazdirma
    {
        
        private static List<Label[]> skorTablosu =new List<Label[]>();
        private static int kacKisi = 5;  // ilk kac kisi gozuksun


        public static void txtEkle(string isim, int puan)
        {
            string suankiZaman = DateTime.Now.ToShortDateString();

            List<string[]> listeLineArray = new List<string[]>();  // puana göre sort etmek icin.
            List<string> liste = File.ReadAllLines(@"..\Veriler\OyuncuPuanTablosu.txt").ToList();  //
            liste.Add(isim + "-" + Convert.ToString(puan) + "-" + suankiZaman );  // yeni bir kullanıcı puanını tabloya ekleme
            liste.ForEach(line => listeLineArray.Add(line.Split('-')));  //  - karakterine göre parcalama.
                
            listeLineArray.Sort((x,y)=> Convert.ToInt32(y[1]).CompareTo(Convert.ToInt32(x[1]))); // burada sıralaması için puanalrı veriyorum
            liste.Clear();  // burada yeni sıralanmış txt içerisindeki metinleri eklemek için eski sırayı siliyorum.
            listeLineArray.ForEach(dizi => liste.Add(string.Join("-", dizi))); // txt'ye yazdırmak için yeni listeyi ekleme.
            File.WriteAllLines(@"..\Veriler\OyuncuPuanTablosu.txt", liste.ToArray());

        }

        public static List<Label[]> Goster()
        {
            // Her bir yazdırma çağırıldığında büyük bir ihtimal yeni bir kayıt olacağından
            // eski top5 'i bir temizliyorum ve yeni top 5 'i bulduruyorum
            skorTablosu.Clear(); 
            Label labelName;
            Label labelSkor;
            int sizeY = 40;

            // top_skors formuna eklenecek label'lar için ayarlamaların yapılması
            for (int i = 0; i < kacKisi; i++)
            {
                labelName = new Label();
                labelSkor = new Label();
                labelName.Location = new Point(57, 52+i* sizeY + 10);
                labelSkor.Location=new Point(212, 52 + i * sizeY + 10);
                labelName.ForeColor = Color.Black;
                labelSkor.ForeColor = Color.Black;
                labelName.Size = new Size(70, sizeY);
                labelSkor.Size = new Size(70, sizeY);
                Label[] labeldizi = new Label[2];
                labeldizi[0] = labelName;
                labeldizi[1]=labelSkor;
                skorTablosu.Add(labeldizi);
            }
            List<string[]> liste = new List<string[]>();
            File.ReadAllLines(@"..\Veriler\OyuncuPuanTablosu.txt").Take(kacKisi).ToList().ForEach(satir => liste.Add(satir.Split('-')));
            for (int i = 0; i < liste.Count; i++)
            {
                skorTablosu.ElementAt(i).ElementAt(0).Text = liste.ElementAt(i).ElementAt(0);
                skorTablosu.ElementAt(i).ElementAt(1).Text = liste.ElementAt(i).ElementAt(1);
            }


            return skorTablosu;
        }

    }
}
