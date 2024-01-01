using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Borrower_List : Form
    {
        public Borrower_List()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Book_List booklist = new Book_List();
            booklist.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
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

        private void Borrower_List_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30;"))
                {
                    string query = "SELECT * FROM s_borrowerlist";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataGridView to the DataTable
                        dataGridView3.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30;"))
                {
                    string query = "SELECT * FROM t_borrowerlist";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataGridView to the DataTable
                        dataGridView4.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }
    }
   }

