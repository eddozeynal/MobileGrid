using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileGrid
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Person> people = new List<Person>();
            people.Add(new Person { PersonName = "Eldar" });
            people.Add(new Person { PersonName = "Bəylər" });
            people.Add(new Person { PersonName = "Musa" });
            people.Add(new Person { PersonName = "Kənan" });
            people.Add(new Person { PersonName = "Elçin" });
            people.Add(new Person { PersonName = "Məhəmməd" });
            people.Add(new Person { PersonName = "Amil" });
            people.Add(new Person { PersonName = "Murad" });
            people.Add(new Person { PersonName = "Nüsrət" });
            people.Add(new Person { PersonName = "Sevda" });
            people.Add(new Person { PersonName = "Məhsəti" });
            people.Add(new Person { PersonName = "Rövşən" });
            people.Add(new Person { PersonName = "Elnarə" });
            people.Add(new Person { PersonName = "Emil" });
            people.Add(new Person { PersonName = "Turallar" });
            people.Add(new Person { PersonName = "Namiq" });
            people.Add(new Person { PersonName = "Paşa" });
            people.Add(new Person { PersonName = "Orxan" });
            people.Add(new Person { PersonName = "Vəsairə" });
            mobileGridControl1.GridRowType = typeof(GridRowPeronView);
            mobileGridControl1.DataSource = people;
            mobileGridControl1.SelectedRowChanged += MobileGridControl1_SelectedRowChanged;
            mobileGridControl1.GridRowButtonClicked += MobileGridControl1_GridRowButtonClicked;


            //List<ItemViewOnPeron> people = new List<ItemViewOnPeron>();
            //people.Add(new ItemViewOnPeron { PersonName = "PIC_ABULOV NIZAMI", Amount = 50, Date = DateTime.Now, Peron = "S110" });
            //people.Add(new ItemViewOnPeron { PersonName = "PIC_SAMIR ELIYEV", Amount = 120, Date = DateTime.Now, Peron = "S070" });
            //people.Add(new ItemViewOnPeron { PersonName = "PIC_EHMEDLI SHAMO", Amount = 250, Date = DateTime.Now, Peron = "S082" });
            //people.Add(new ItemViewOnPeron { PersonName = "PIC_SEYFIYEV SHADMAN", Amount = 10, Date = DateTime.Now, Peron = "S770" });
            //people.Add(new ItemViewOnPeron { PersonName = "PIC_RESHAD CAVADOV", Amount = 80, Date = DateTime.Now, Peron = "S090" });
            //people.Add(new ItemViewOnPeron { PersonName = "PIC_NESIROV FAMIL", Amount = 74, Date = DateTime.Now, Peron = "S092" });
            //mobileGridControl1.GridRowType = typeof(GridRowItemSearchView);
            //mobileGridControl1.DateFormat = "[dd] HH:mm";
            //mobileGridControl1.DataSource = people;
            //mobileGridControl1.SelectedRowChanged += MobileGridControl1_SelectedRowChanged;
            //mobileGridControl1.GridRowButtonClicked += MobileGridControl1_GridRowButtonClicked;
        }

        private void MobileGridControl1_GridRowButtonClicked(object sender, GridRowButtonClickedEventArgs e)
        {
            listBox1.Items.Add(((e.RowData as Person).PersonName));
        }

        private void MobileGridControl1_SelectedRowChanged(object sender, EventArgs e)
        {
            if (mobileGridControl1.SelectedRowData == null) return;
            listBox1.Items.Add(((mobileGridControl1.SelectedRowData as Person).PersonName));
        }
    }

    public class Person
    {
        public string PersonName { get; set; }
    }

    public class ItemViewOnPeron
    {
        public string PersonName { get; set; }
        public string Peron { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
