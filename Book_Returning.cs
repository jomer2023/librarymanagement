using System;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Book_Returning : Form
    {
        public Book_Returning()
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
