using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDOrnegi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Ogrenci> lst = new List<Ogrenci>();
        List<Ogrenci> lst2 = new List<Ogrenci>();
        private void Form1_Load(object sender, EventArgs e)
        {
            lst.Add(new Ogrenci() { OgrenciId = 1, OgrenciAdi = "mustafa" });
            lst.Add(new Ogrenci() { OgrenciId = 2, OgrenciAdi = "mehmet" });
            comboBox1.DataSource = lst;
            comboBox1.DisplayMember = "OgrenciAdi";
            comboBox1.ValueMember = "OgrenciId";

            lst2.Add(new Ogrenci() { OgrenciId = 1, OgrenciAdi = "xx" });
            lst2.Add(new Ogrenci() { OgrenciId = 2, OgrenciAdi = "yy" });
            listBox1.DataSource = lst2;

            dataGridView1.DataSource = lst2;

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //this.Text = comboBox1.SelectedValue.ToString();
        }
    }
    class Ogrenci
    {
        public int OgrenciId { get; set; }
        public string OgrenciAdi { get; set; }
        public override string ToString()
        {
            return $"{OgrenciId} {OgrenciAdi}";
        }
    }
}
