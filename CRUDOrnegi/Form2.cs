using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDOrnegi
{
    public partial class Form2 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        List<IDbDataParameter> myparameters;
        string connectionString;

        bool IsNewPress = false;
        public Form2()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            myparameters = new List<IDbDataParameter>();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            btnGuncelle.Enabled = false;
            DataAccessService service = new DataAccessService(new CategoryDataAccess(connection, command));
            string commandText = "SELECT CategoryID,CategoryName,Description,Picture FROM Categories";
            var catList = service.GetAllCategories(commandText);
            Combo2BindEt(catList);
            Combo1BindEt(catList);
            cmbCat2.SelectedValueChanged += cmbCat2_SelectedValueChanged;

        }
        private void cmbCat2_SelectedValueChanged(object sender, EventArgs e)
        {
            //var t = ((CRUDOrnegi.Category)((System.Windows.Forms.ComboBox)sender).SelectedItem).CategoryID;
            //int secilenId = ((Category)cmbCat2.SelectedValue).CategoryID;
            var m = cmbCat2.SelectedValue;
        }

        private void cmbCat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int categoryId = ((Category)((ComboBox)sender).SelectedItem).CategoryID;
            byte[] pic = (cmbCat2.SelectedItem as Category).Picture;
            using (MemoryStream buf = new MemoryStream(pic, 78, pic.Length - 78))
            {
                pictureBox1.Image = Image.FromStream(buf);
            }

            textBox1.Text = (cmbCat2.SelectedItem as Category).Description;
            int categoryId = (cmbCat2.SelectedItem as Category).CategoryID;

            RefreshProducts();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((Product)listBox1.SelectedItem == null)
                return;

            Product pr = (Product)listBox1.SelectedItem;
            myparameters.Clear();
            myparameters.Add(new SqlParameter());
            ProductDataAccess ser = new ProductDataAccess(connection, command, myparameters);
            var product = ser.Select(pr.ProductId);

            txtFiyat.Text = product.Price.ToString();
            txtStok.Text = product.UnitInStock.ToString();
            txtUrunAdi.Text = product.ProductName;
            //btnGuncelle.Enabled = false;
        }
        private void txtStok_TextChanged(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = true;
        }
        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = true;
        }
        private void txtUrunAdi_TextChanged(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = true;
        }

        private void txtUrunAdi_Enter(object sender, EventArgs e)
        {
            Tetikle();
        }
        private void txtStok_Enter(object sender, EventArgs e)
        {
            Tetikle();
        }
        private void Tetikle()
        {
            if (btnGuncelle.Enabled || IsNewPress)
            {
                txtUrunAdi.TextChanged -= new EventHandler(txtUrunAdi_TextChanged);
                txtFiyat.TextChanged -= new EventHandler(txtFiyat_TextChanged);
                txtStok.TextChanged -= new EventHandler(txtStok_TextChanged);
            }
            else
            {
                txtUrunAdi.TextChanged += new EventHandler(txtUrunAdi_TextChanged);
                txtFiyat.TextChanged += new EventHandler(txtFiyat_TextChanged);
                txtStok.TextChanged += new EventHandler(txtStok_TextChanged);
            }
        }
        private void txtFiyat_Enter(object sender, EventArgs e)
        {
            Tetikle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            myparameters.Clear();
            myparameters.Add(new SqlParameter());
            myparameters.Add(new SqlParameter());
            myparameters.Add(new SqlParameter());
            myparameters.Add(new SqlParameter());

            ProductDataAccess ser = new ProductDataAccess(connection, command, myparameters);
            var product = new Product();
            product.ProductId = (listBox1.SelectedItem as Product).ProductId;
            product.ProductName = txtUrunAdi.Text;
            product.Price = decimal.Parse(txtFiyat.Text);
            product.UnitInStock = int.Parse(txtStok.Text);

            if (ser.Update(product) > 0)
            {
                MessageBox.Show("Update gerceklesti");            
                string commandText = "Select ProductID,ProductName,UnitsInStock,UnitPrice from Products where CategoryID=@CategoryId";
                myparameters.Clear();
                myparameters.Add(new SqlParameter());
                DataAccessService service = new DataAccessService(new ProductDataAccess(connection, command, myparameters));
                var plist = service.GetProductsByCategory(commandText, (cmbCat2.SelectedItem as Category).CategoryID);
                ListBoxBindEt(plist);
            }
            else
                MessageBox.Show("Update Gerceklesemedi");

        }

        #region Helpers
        private void ListBoxBindEt(List<Product> liste)
        {
            if (listBox1.DataSource != null)
            {
                listBox1.DataSource = null;
            }

            listBox1.DataSource = liste;
            listBox1.ValueMember = "ProductId";
            listBox1.DisplayMember = "ProductName";
        }
        private void Combo1BindEt(List<Category> catList)
        {
            cmbCat.DataSource = catList;
            cmbCat.DisplayMember = "CategoryName"; //Kategori
            cmbCat.ValueMember = "CategoryID";   //KategoriId
        }
        private void Combo2BindEt(List<Category> catList)
        {
            cmbCat2.DataSource = catList;
            cmbCat2.DisplayMember = "CategoryName";
            cmbCat2.ValueMember = "CategoryID";
        }
        #endregion

        private void btnYeni_Click(object sender, EventArgs e)
        {
            txtFiyat.Text = string.Empty;
            txtStok.Text = string.Empty;
            txtUrunAdi.Text = string.Empty;

            IsNewPress = true;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName = txtUrunAdi.Text;
            product.Price = decimal.Parse(txtFiyat.Text);
            product.UnitInStock = int.Parse(txtStok.Text);
            product.CategoryId = (cmbCat2.SelectedItem as Category).CategoryID;

            myparameters.Clear();
            myparameters.Add(new SqlParameter());
            myparameters.Add(new SqlParameter());
            myparameters.Add(new SqlParameter());
            myparameters.Add(new SqlParameter());
            DataAccessService service = new DataAccessService(new ProductDataAccess(connection, command, myparameters));
            service.AddProduct(product);
            RefreshProducts();
        }

        private void RefreshProducts()
        {
            DataAccessService service = new DataAccessService(new ProductDataAccess(connection, command, myparameters));
            myparameters.Clear();
            myparameters.Add(new SqlParameter());
            string commandText = "Select ProductID,ProductName,UnitsInStock,UnitPrice from Products where CategoryID=@CategoryId";
         
            var plist = service.GetProductsByCategory(commandText, (cmbCat2.SelectedItem as Category).CategoryID);
            ListBoxBindEt(plist);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            myparameters.Clear();
            myparameters.Add(new SqlParameter());
            DataAccessService service = new DataAccessService(new ProductDataAccess(connection, command, myparameters));
            service.DeleteProduct((listBox1.SelectedItem as Product).ProductId);
            txtFiyat.Text = string.Empty;
            txtStok.Text = string.Empty;
            txtUrunAdi.Text = string.Empty;
            RefreshProducts();

        }
    }
}
