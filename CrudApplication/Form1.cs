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

namespace CrudApplication
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UUG2AVV;Initial Catalog=crudApplication;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            dataRetrivel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clearBoxes()
        {

            nameBox.Text = "";
            cnicBox.Text = "";
            emailBox.Text = "";
            contactBox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string cnic = cnicBox.Text;
            string email = emailBox.Text;
            string contact = contactBox.Text;

             con.Open();

            string firstQuery = "insert into userRecords(Name,CNIC,Email,Contact) values(@fname, @cnic, @email,@contact)";
            SqlCommand cmd = new SqlCommand(firstQuery, con);

            cmd.Parameters.AddWithValue("@fname", name);
            cmd.Parameters.AddWithValue("@cnic", cnic);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@contact", contact);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Your Data has been saved😊");
            clearBoxes();
            con.Close();
        }

        private void dataRetrivel() 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from userRecords", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.Rows.Clear();
            for(int i=0; i < ds.Tables[0].Rows.Count; i++)
            {
                string name = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string cnic = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                string email = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                string contact = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                DataGridViewRow dataPush = new DataGridViewRow();
                dataPush.CreateCells(dataGridView1);
                dataPush.Cells[0].Value = name;
                dataPush.Cells[1].Value = cnic;
                dataPush.Cells[2].Value = email;
                dataPush.Cells[3].Value = contact;
                dataGridView1.Rows.Add(dataPush);
            }
            con.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            dataRetrivel();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            nameBox.Text = row.Cells[0].Value.ToString();
            cnicBox.Text = row.Cells[1].Value.ToString();
            emailBox.Text = row.Cells[2].Value.ToString();
            contactBox.Text = row.Cells[3].Value.ToString();
        }

        private void deleteRecords()
        {
            con.Open();
            string id = nameBox.Text;

            SqlCommand cmd = new SqlCommand("delete from userRecords where Name=@a", con);
            cmd.Parameters.AddWithValue("@a", id);
            cmd.ExecuteNonQuery();

            MessageBox.Show("GONE");
            con.Close();
            dataRetrivel();
            clearBoxes();
        }


        private void UpdateRecords()
        {
            con.Open();
            string name = nameBox.Text;
            string cnic = cnicBox.Text;
            string email = emailBox.Text;
            string contact = contactBox.Text;
            
            SqlCommand cmd = new SqlCommand("update userRecords set CNIC=@newCNIC, Email=@newEmail, Contact=@newContact where Name=@newName", con);
            cmd.Parameters.AddWithValue("newName", name);
            cmd.Parameters.AddWithValue("newContact", contact);
            cmd.Parameters.AddWithValue("newEmail", email);
            cmd.Parameters.AddWithValue("newCNIC", cnic);

            cmd.ExecuteNonQuery();

            MessageBox.Show("The Record has been updated!");
            con.Close();
            dataRetrivel();
            clearBoxes();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteRecords();
        }


        private void update_button_Click(object sender, EventArgs e)
        {
            UpdateRecords();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();

            string Query = "SELECT * FROM userRecords WHERE CONCAT (Name, CNIC, Email, Contact) LIKE '%" + searchBox.Text + "%'";
            SqlCommand CMD = new SqlCommand(Query, con);
            SqlDataAdapter DiscordAdpater = new SqlDataAdapter(CMD);
            DataSet DiscordSet = new DataSet();

            DiscordAdpater.Fill(DiscordSet);
            dataGridView1.Rows.Clear();

            for (int i = 0; i < DiscordSet.Tables[0].Rows.Count; ++i)
            {
                DataGridViewRow Rows = new DataGridViewRow();

                string User_Name = DiscordSet.Tables[0].Rows[i].ItemArray[0].ToString();
                string User_CNIC = DiscordSet.Tables[0].Rows[i].ItemArray[1].ToString();
                string User_Contact = DiscordSet.Tables[0].Rows[i].ItemArray[2].ToString();
                string User_Email = DiscordSet.Tables[0].Rows[i].ItemArray[3].ToString();

                Rows.CreateCells(dataGridView1);
                Rows.Cells[0].Value = User_CNIC;
                Rows.Cells[1].Value = User_Name;
                Rows.Cells[2].Value = User_Contact;
                Rows.Cells[3].Value = User_Email;

                dataGridView1.Rows.Add(Rows);
            }
            con.Close();


        }
    }
}
