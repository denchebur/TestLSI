using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLSI
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Queries queries = new Queries();
        private DateTime date;
        private DateTime date2;
        private string location;
        
        private SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TestLSI.Properties.Settings.ExportsConnectionString"].ConnectionString);
        
        public Form1()
        {
            InitializeComponent();
            conn.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "exportsDataSet.Export". При необходимости она может быть перемещена или удалена.
            this.exportTableAdapter.Fill(this.exportsDataSet.Export);        
        }

        
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            date = dateEdit1.DateTime;
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            date2 = dateEdit2.DateTime;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                location = comboBox1.SelectedValue.ToString();  // idk why this line drops exception, but I tried to fix it
                
            }
            catch(NullReferenceException ex) 
            {           
                MessageBox.Show("Wrong location selected!");
                location = comboBox1.Items[0].ToString();
                dateEdit1.Focus();
            }          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            var sql = queries.GenerateQueryReport(location, date, date2);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);       
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            
        }

        private void simpleButton2_Click(object sender, EventArgs e) // Its my first expirence with DevExpress, and idk where close button 
        {
            location = "123";
            conn.Close();          
            Application.Exit(); 
            
        }
    }
}