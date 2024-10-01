using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;
        BindingSource showProductList;

        public Form1()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListofProductCategory = { "Beverages", "Bread/Bakery", "Canned/Jarred", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" };
            foreach (string Category in ListofProductCategory)
            {
                cbCategory.Items.Add(Category);
            }

        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDiscription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewProductList.DataSource = showProductList;
        }
        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    throw new StringFormatException("Invalid Product Name Format");
                }
                return name;
            }
            catch(StringFormatException ex) 
            {
                Console.WriteLine("Unexpected Error" + ex.Message);
                return "invalid name";
            }
        }

        public int Quantity(string qty)
        {
            try
            {
                if(!Regex.IsMatch(qty, @"^[0-9]"))
                {
                    throw new NumberFormatException("Invalid Quantity Format. Must be Numeric!!");
                }
                return Convert.ToInt32(qty);
            }
            catch(NumberFormatException nfe)
            {
                MessageBox.Show(nfe.Message);
                Console.WriteLine(nfe.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error" + ex.Message);
                return 0;
            }
        }

        public double SellingPrice(string price)
        {
            try
            {
                if(!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    throw new CurrencyFormatException("Invalid Currency Format");
                }
                return Convert.ToInt32(price);
            }
            catch (CurrencyFormatException cfe)
            {
                MessageBox.Show(cfe.Message);
                Console.WriteLine(cfe.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Unexpected Error" + ex.Message);
                return 0;
            }
        }
        
        public class NumberFormatException: Exception
        {
            public NumberFormatException(string message) : base(message) { }
        }

        public class StringFormatException: Exception
        {
            public StringFormatException(string message) : base(message) { }   
        }

        public class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string message) : base(message) { }
        }
    }
} 

