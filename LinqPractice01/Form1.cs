using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqPractice01
{
    public partial class Form1 : Form
    {
        private readonly List<string> _names = new List<string>()
        {
            "tsubasa Ozara",
            "Taro MisaKİ",
            "Jun Misugi",
            "Polat Alemdar",
            "Memati Baş",
            "Can Polat",
            "Hagi",
            "Drogba",
            "Muslera",
            "Melo",
            "Hakan Sukur",
            "Sabri",
        };
        public Form1()
        {
            InitializeComponent();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string k = txtSearchText.Text.Trim();

            var quert = (from n in _names
                         where n.Contains(k)
                         select n).ToList();

            lstNames.DataSource = quert;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstNames.DataSource = _names;
        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            //string k = txtSearchText.Text.ToLowerInvariant();
            var quert = (from n in _names
                         where n.Contains(txtSearchText.Text.ToLowerInvariant())
                         select n).ToList();

            lstNames.DataSource = quert;
        }
    }
}