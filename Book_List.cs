using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Book_List : Form
    {
        public Book_List()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                string query = "SELECT * FROM fictional";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Book_Borrowing bookborrowing = new Book_Borrowing();
            bookborrowing.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Borrower_List borrowerlist = new Borrower_List();
            borrowerlist.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Book_Returning bookreturning = new Book_Returning();
            bookreturning.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Book_Reservation bookreservation = new Book_Reservation();
            bookreservation.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Book_Penalty bookpenalty = new Book_Penalty();
            bookpenalty.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                string query = "SELECT * FROM nonfictional";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                string query = "SELECT * FROM academic";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
