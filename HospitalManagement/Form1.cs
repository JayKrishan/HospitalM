using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=.\MSSQLLocalDB; AttachDbFilename=""C:\Users\Kj Max\Desktop\Hospital Management\HospitalManagement\HospitalManagement\HospitalDb.mdf"";Integrated Security=True;Connect Timeout=30; User Instance=True");
                string query = "select * from logindetails where username = '" + txt_username.Text.Trim() + "' and password = '" + txt_password.Text.Trim() + "'";
                sqlcon.Open();
                SqlDataAdapter log = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                log.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    Main_Form objMainForm = new Main_Form();
                    this.Hide();
                    objMainForm.Show();
                }
                else
                {
                    MessageBox.Show("Check your username and password");
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            

        }

    }
}
