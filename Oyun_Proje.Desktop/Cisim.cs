
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
using System.Drawing;

namespace Oyun_Proje.Desktop
{
    internal abstract class Cisim
    {
        // bu projedeki çoğu sınıf bu sınıfı temel almaktadır,
        // bu yüzden hepsinde olması gereken en genel özellikler tanımlanmıştır

        // koordinatlar ve resimler için boyut
        private int x;
        private int y;
        private int boyut;
        // resimlerin oluşturulması/ birden fazla kullanılacaksa bir dizi
        protected Image resim;
        public Image[] resimler;
        // rasgelelik durumları için 
        protected int rastgeleSayi;
        protected int sayac;
        public Random rnd;

        public Cisim() { boyut = 80; }
        /// <summary>
        /// X ve Y için get ve set metotları
        /// formumun boyutlarından büyük veya küçük olamazlar
        /// </summary>
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
        // boyut için atama yapılamaz ancak okunabilir (readonly)
        public int Boyut { get => boyut; }
    }
}
