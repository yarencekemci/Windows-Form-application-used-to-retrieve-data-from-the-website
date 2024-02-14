using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Veri_Cekme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adres = "http://www.meb.gov.tr";
            WebRequest istek = HttpWebRequest.Create(adres);
            WebResponse cevap;
            cevap = istek.GetResponse(); 
            StreamReader donenbilgiler= new StreamReader(cevap.GetResponseStream());
            string gelen= donenbilgiler.ReadToEnd();
            int baslıkbaslangic = gelen.IndexOf("<title>")+7;
            // baslık getir dedigimizde title yazısı cıkmaması icin +7 yazıldı.
            int baslıkbitisi = gelen.Substring(baslıkbaslangic).IndexOf("</title>");
            string baslık = gelen.Substring(baslıkbaslangic, baslıkbitisi);
            MessageBox.Show(baslık);
        }
    }
}
