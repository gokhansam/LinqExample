using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqIntro
{
    // LINQ
    // Language Integrated Query: Dil ile bütünleştirilmiş sorgulama
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var names = new List<string>()
            {
                "tsubasa",
                "Misaki",
                "Hyuga",
                "Misugi",
                "Wakashimuza",
            };

            //Linq ile dönen sorgu sonucu asla null olamaz
            //Eger ki sonuç dönmüyorsa; bu içerdiği eleman sayısı 0 olan bir koleksiyon anlamına gelir
            //Linq Syntax           
            var tsubasaNames = from n in names
                               where n == "Tsubasa" && n == "d"
                               select n;

            var tsubasa = tsubasaNames.Single(); //sorgunun bize tek bir eleman döndereceğini bildiğimiz için; Single kullandık
            //Single() kullanmak pek doğru olmaz. eleman yoksa, patlar;;; eleman birden fazlaysa; patlar

            var tsubasa2 = tsubasaNames.FirstOrDefault();// kullanırsak hata alma ihtimalimiz düşer.

            //Bu aşşağıdaki ifade her zaman IEnumarable döndürür
            //from n in names
            //where n == "Tsubasa"
            //select n;


            //aşşağıdaki farklı bir yazım stilidir.
            var tsubasaNames2 = (from n in names
                                 where n == "Tsubasa" && n == "d"
                                 select n).FirstOrDefault();

            var tsubasaNamesCount = (from n in names
                                     where n == "Tsubasa"
                                     select n).Count();

            // sıralama yaptık
            var orderName = (from n in names
                             where n == "Tsubasa"
                             orderby n ascending
                             select n);

            // Küçük a harfini içeren kayıtları dönderecek
            var filteredAndorderedNames = (from n in names
                                           where n.Contains('a')
                                           orderby n
                                           select n);

            var queryResult = from n in names
                              where n.StartsWith('M')
                              select n;


        }
    }
}