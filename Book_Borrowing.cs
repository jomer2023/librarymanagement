using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Win32.SafeHandles;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Diagnostics;
/* jomer */
namespace Library_Management_System
{
    public partial class Book_Borrowing : Form
    {
        private int currentNumber = 0;
        private int teachertab_currentNumber = 0;
        public Book_Borrowing()
        {
            InitializeComponent();
            
            teacher_tab_buttonfalse();


            btn_borrowbook.Enabled = false;
            label16.Enabled = false;
            label41.Enabled = false;
            button17.Enabled = false;
            buttonfalse();




            /*panel1.Width = 52;
            tabControl1.Location = new Point(74, 4);
            this.Size = new Size(719, 555);*/

        }

       

        private void displaydisplaytitle()
        {
            lbl_title.Text = "Chronicles";
        }

        

        private void hanggangtwolang()
        {
            if (number.Text == "2") { 
                //MessageBox.Show("Only 2 books are allowed to borrowed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonfalse();
                btn_borrowbook.Enabled = true;
                label16.Enabled = true;
                
            }
            
        }

        private void hanggangfivelang()
        {
            if (label37.Text == "5")
            {
                //MessageBox.Show("Only 2 books are allowed to borrowed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                teacher_tab_buttonfalse();
                button17.Enabled = true;
                label41.Enabled = true;
                
            }

        }

        private void UpdateLabel()
        {
            number.Text = currentNumber.ToString();
            label37.Text = teachertab_currentNumber.ToString();
        }
        private void teachertab_UpdateLabel()
        {
            label37.Text = teachertab_currentNumber.ToString();
        }
        private void teacher_tab_buttonfalse()
        {
            
            btn_a.Enabled = false; btn_f.Enabled = false; btn_k.Enabled = false;
            btn_b.Enabled = false; btn_g.Enabled = false; btn_l.Enabled = false;
            btn_c.Enabled = false; btn_h.Enabled = false; btn_m.Enabled = false;
            btn_d.Enabled = false; btn_i.Enabled = false; btn_n.Enabled = false;
            btn_e.Enabled = false; btn_j.Enabled = false; btn_o.Enabled = false;
        }
        private void teacher_tab_buttontrue()
        {

            btn_a.Enabled = true; btn_f.Enabled = true; btn_k.Enabled = true;
            btn_b.Enabled = true; btn_g.Enabled = true; btn_l.Enabled = true;
            btn_c.Enabled = true; btn_h.Enabled = true; btn_m.Enabled = true;
            btn_d.Enabled = true; btn_i.Enabled = true; btn_n.Enabled = true;
            btn_e.Enabled = true; btn_j.Enabled = true; btn_o.Enabled = true;
        }
        private void buttonfalse() 
        {
            button2.Enabled = false; button7.Enabled  = false; button12.Enabled = false;
            button3.Enabled = false; button8.Enabled  = false; button13.Enabled = false;
            button4.Enabled = false; button9.Enabled  = false; button14.Enabled = false;
            button5.Enabled = false; button10.Enabled = false; button15.Enabled = false;
            button6.Enabled = false; button11.Enabled = false; button16.Enabled = false;

            
        }
        private void teachertabbuttonfalse()
        {
            button2.Enabled = false; button7.Enabled = false; button12.Enabled = false;
            button3.Enabled = false; button8.Enabled = false; button13.Enabled = false;
            button4.Enabled = false; button9.Enabled = false; button14.Enabled = false;
            button5.Enabled = false; button10.Enabled = false; button15.Enabled = false;
            button6.Enabled = false; button11.Enabled = false; button16.Enabled = false;
        }
        private void buttontrue()
        {
            button2.Enabled = true; button7.Enabled  = true; button12.Enabled = true;
            button3.Enabled = true; button8.Enabled  = true; button13.Enabled = true;
            button4.Enabled = true; button9.Enabled  = true; button14.Enabled = true;
            button5.Enabled = true; button10.Enabled = true; button15.Enabled = true;
            button6.Enabled = true; button11.Enabled = true; button16.Enabled = true;


        }
        private void teachertabbuttontrue()
        {
            button2.Enabled = true; button7.Enabled = true; button12.Enabled = true;
            button3.Enabled = true; button8.Enabled = true; button13.Enabled = true;
            button4.Enabled = true; button9.Enabled = true; button14.Enabled = true;
            button5.Enabled = true; button10.Enabled = true; button15.Enabled = true;
            button6.Enabled = true; button11.Enabled = true; button16.Enabled = true;
        }
        private void DisableTextBoxes()
        {
            txt_name.ReadOnly = true;
            txt_id.ReadOnly = true;
            com_yearlevel.Enabled = false;
            com_section.Enabled = false;
        }
        private void EnableTextBoxes()
        {
            txt_name.ReadOnly = false;
            txt_id.ReadOnly = false;
            com_yearlevel.Enabled = true;
            com_section.Enabled = true;
        }

        private void thisformrule()
        {
            bool allFieldsFilled = !string.IsNullOrEmpty(txt_name.Text) &&
                                   !string.IsNullOrEmpty(txt_id.Text) &&
                                   !string.IsNullOrEmpty(com_yearlevel.Text) &&
                                   !string.IsNullOrEmpty(com_section.Text);

            if (allFieldsFilled)
            {
                buttontrue();
                DisableTextBoxes();
            }
            else
            {
                buttonfalse();
            }
        }

        private void matchingstudentdata()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM studentinfo WHERE name ='" + txt_name.Text + "' AND studentID = '" + txt_id.Text + "' AND yearlevel = '" + com_yearlevel.Text + "' AND section = '" + com_section.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                lbl_date.Text = DateTime.Now.ToString("yyyy-MM-dd"); // date

                DateTime dueDate = DateTime.Now.AddDays(3);
                lbl_duedate.Text = dueDate.ToString("yyyy-MM-dd"); // due date

                thisformrule();
                buttontrue();
                string enteredName = txt_name.Text;

                if (!string.IsNullOrEmpty(enteredName))
                {
                    lbl_name.Text = enteredName;
                }
                btn_borrowbook.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please enter the correct information before you borrow");
                EnableTextBoxes();
                buttonfalse();
            }


        }
        private int clickedButtonCount = 0;
        
        /*private void insertdata()
        {
            try
            {
                SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                connect.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO s_borrowerlist(@id,name,studentid,yearlevel,section) VALUES (@id,@name,@studentid,@yearlevel,@section)", connect);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@name", txt_name.Text);
                cmd.Parameters.AddWithValue("@studentid", txt_id.Text);
                cmd.Parameters.AddWithValue("@yearlevel", com_yearlevel.Text);
                cmd.Parameters.AddWithValue("@section", comboBox1.Text);
                cmd.ExecuteNonQuery();

                connect.Close();

                MessageBox.Show("Successfully Inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }*/
        

        


        private void label3_Click(object sender, EventArgs e)
        {
            Book_List booklist = new Book_List();
            booklist.Show();
            this.Hide();
             
        }

        private void label2_Click(object sender, EventArgs e)
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
     

        private void Book_Borrowing_Load(object sender, EventArgs e)
        {
            /*string enteredName = txt_name.Text;

            if (!string.IsNullOrEmpty(enteredName))
            {
                MessageBox.Show("Hello " + enteredName + "!");
            }
            else
            {
                MessageBox.Show("Please enter a name before clicking the button.");
            }*/
            
            
            UpdateLabel();
            hanggangtwolang();
            hanggangfivelang();
            
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            matchingstudentdata();
            


            // string enteredName = txt_name.Text;

            // I-set ang value sa Text property ng Label
            //lbl_name.Text = enteredName;

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            
            button2.Enabled = false;
            currentNumber += 1;
            UpdateLabel();
            hanggangtwolang();
            
            if (lbl_title.Text == "Details") { lbl_title.Text = "Chronicles"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, Chronicles"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, Chronicles"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, Chronicles"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, Chronicles"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, Chronicles"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, Chronicles"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, Chronicles"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, Chronicles"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, Chronicles"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, Chronicles"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, Chronicles"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, Chronicles"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, Chronicles"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, Chronicles"; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            button3.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "Quantum"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, Quantum"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, Quantum"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, Quantum"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, Quantum"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, Quantum"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, Quantum"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, Quantum"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, Quantum"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, Quantum"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, Quantum"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, Quantum"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, Quantum"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, Quantum"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, Quantum"; }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "The Ethereal"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, The Ethereal"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "The Ethereal, The Ethereal"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, The Ethereal"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, QThe Etherealuantum"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, The Ethereal"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, The Ethereal"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, The Ethereal"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, The Ethereal"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, The Ethereal"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, The Ethereal"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, The Ethereal"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, The Ethereal"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, The Ethereal"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, The Ethereal"; }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "Echoes"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, Echoes"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, Echoes"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, Echoes"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, Echoes"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, Echoes"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, Echoes"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, Echoes"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, Echoes"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, Echoes"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, Echoes"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, Echoes"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, Echoes"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, Echoes"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, Echoes"; }
        }

        
        private void button6_Click_1(object sender, EventArgs e)
        {
            button6.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "Aethrium"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, Aethrium"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, Aethrium"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, Aethrium"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, Aethrium"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, Aethrium"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, Aethrium"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, Aethrium"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, Aethrium"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, Aethrium"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, Aethrium"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, Aethrium"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, Aethrium"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, Aethrium"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, Aethrium"; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "Power of Habit"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, Power of Habit"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, Power of Habit"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, Power of Habit"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, Power of Habit"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, Power of Habit"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, Power of Habit"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, Power of Habit"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, Power of Habit"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, Power of Habit"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, Power of Habit"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, Power of Habit"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, Power of Habit"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, Power of Habitrium"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, Power of Habit"; }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "Power of Introvert"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, Power of Introvert"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, Power of Introvert"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, Power of Introvert"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, Power of Introvert"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, Power of Introvert"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, Power of Introvert"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, Power of Introvert"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, Power of Introvert"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, Power of Introvert"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, Power of Introvert"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, Power of Introvert"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, Power of Introvert"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, Power of Introvert"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, Power of Introvert"; }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "Sapiens"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, Sapiens"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, Sapiens"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, Sapiens"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, Sapiens"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, Sapiens"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, Sapiens"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, Sapiens"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, Sapiens"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, Sapiens"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, Sapiens"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, Sapiens"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, Sapiens"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, Sapiens"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, Sapiens"; }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "The Wright"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, The Wright"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, The Wright"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, The Wright"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, The Wright"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, The Wright"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, The Wright"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, The Wright"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, The Wright"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, The Wright"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, The Wright"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, The Wright"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, The Wright"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, The Wright"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, The Wright"; }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "Atomic Habits"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, Atomic Habits"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, Atomic Habits"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, Atomic Habits"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, Atomic Habits"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, Atomic Habits"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, Atomic Habits"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, Atomic Habits"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, Atomic Habits"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, Atomic Habits"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, Atomic Habits"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, Atomic Habits"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, Atomic Habits"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, Atomic Habits"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, Atomic Habits"; }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");
            button14.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "S-Scientefic Revolution"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, S-Scientefic Revolution"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, S-Scientefic Revolution"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, S-Scientefic Revolution"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, S-Scientefic Revolution"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, S-Scientefic Revolution"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, S-Scientefic Revolution"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, S-Scientefic Revolution"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, S-Scientefic Revolution"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, S-Scientefic Revolution"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, S-Scientefic Revolution"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, S-Scientefic Revolution"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, S-Scientefic Revolution"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, S-Scientefic Revolution"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, S-Scientefic Revolution"; }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");
            button12.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "Guns, Germs and Steel"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, Guns, Germs and Steel"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, Guns, Germs and Steel"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, Guns, Germs and Steel"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, Guns, Germs and Steel"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, Guns, Germs and Steel"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, Guns, Germs and Steel"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, Guns, Germs and Steel"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, Guns, Germs and Steel"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, Guns, Germs and Steel"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, Guns, Germs and Steel"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, Guns, Germs and Steel"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, Guns, Germs and Steel"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, Guns, Germs and Steel"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, Guns, Germs and Steel"; }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");
            button13.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "The Selfish Gene"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, The Selfish Gene"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, The Selfish Gene"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, The Selfish Gene"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, The Selfish Gene"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, The Selfish Gene"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, The Selfish Gene"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, The Selfish Gene"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, The Selfish Gene"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, The Selfish Gene"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, The Selfish Gene"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, The Selfish Gene"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel,The Selfish Gene"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, The Selfish Gene"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, The Selfish Gene"; }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");

            button15.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "A Brief History"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, A Brief History"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, A Brief History"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, A Brief History"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, A Brief History"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, A Brief History"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, A Brief History"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, A Brief History"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, A Brief History"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, A Brief History"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, A Brief History"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, A Brief History"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, A Brief History"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, A Brief History"; }
            if (lbl_title.Text == "The Social Contract") { lbl_title.Text = "The Social Contract, A Brief History"; }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");
            button16.Enabled = false;
            currentNumber += 1;

            // I-update ang label
            UpdateLabel();
            hanggangtwolang();

            if (lbl_title.Text == "Details") { lbl_title.Text = "The Social Contract"; }
            if (lbl_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, The Social Contract"; }
            if (lbl_title.Text == "Quantum") { lbl_title.Text = "Quantum, The Social Contract"; }
            if (lbl_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, The Social Contract"; }
            if (lbl_title.Text == "Echoes") { lbl_title.Text = "Echoes, The Social Contract"; }
            if (lbl_title.Text == "Aethrium") { lbl_title.Text = "Aethrium, The Social Contract"; }
            if (lbl_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, The Social Contract"; }
            if (lbl_title.Text == "Power of Introvert") { lbl_title.Text = "Power of Introvert, The Social Contract"; }
            if (lbl_title.Text == "Sapiens") { lbl_title.Text = "Sapiens, The Social Contract"; }
            if (lbl_title.Text == "The Wright") { lbl_title.Text = "The Wright, The Social Contract"; }
            if (lbl_title.Text == "Atomic Habits") { lbl_title.Text = "Atomic Habits, The Social Contract"; }
            if (lbl_title.Text == "S-Scientefic Revolution") { lbl_title.Text = "S-Scientefic Revolution, The Social Contract"; }
            if (lbl_title.Text == "Guns, Germs and Steel") { lbl_title.Text = "Guns, Germs and Steel, The Social Contract"; }
            if (lbl_title.Text == "The Selfish Gene") { lbl_title.Text = "The Selfish Gene, The Social Contract"; }
            if (lbl_title.Text == "A Brief History") { lbl_title.Text = "A Brief History, The Social Contract"; }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void button17_Click(object sender, EventArgs e)
        {
            /*try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "INSERT INTO s_borrowerlist (name, studentid, yearlevel, section) VALUES (@Name, @StudentID, @YearLevel, @Section)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Name", txt_name.Text);
                        command.Parameters.AddWithValue("@StudentID", txt_id.Text);
                        command.Parameters.AddWithValue("@YearLevel", string.IsNullOrEmpty(com_yearlevel.Text) ? (object)DBNull.Value : (object)com_yearlevel.Text);
                        command.Parameters.AddWithValue("@Section", string.IsNullOrEmpty(com_section.Text) ? (object)DBNull.Value : (object)com_section.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }*/

            /*try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string queryCheck = "SELECT COUNT(*) FROM s_borrowerlist WHERE name = @Name AND studentid = @StudentID";

                    using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                    {
                        connection.Open();
                        commandCheck.Parameters.AddWithValue("@Name", txt_name.Text);
                        commandCheck.Parameters.AddWithValue("@StudentID", txt_id.Text);

                        int count = (int)commandCheck.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("The information you entered already exists.");
                        }
                        else
                        {
                            // Data doesn't exist, proceed with the insert
                            string queryInsert = "INSERT INTO s_borrowerlist (name, studentid, yearlevel, section) VALUES (@Name, @StudentID, @YearLevel, @Section)";

                            using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@Name", txt_name.Text);
                                commandInsert.Parameters.AddWithValue("@StudentID", txt_id.Text);
                                commandInsert.Parameters.AddWithValue("@YearLevel", string.IsNullOrEmpty(com_yearlevel.Text) ? (object)DBNull.Value : (object)com_yearlevel.Text);
                                commandInsert.Parameters.AddWithValue("@Section", string.IsNullOrEmpty(com_section.Text) ? (object)DBNull.Value : (object)com_section.Text);
                                commandInsert.ExecuteNonQuery();
                                MessageBox.Show("Data inserted successfully.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }*/

            // Check if required fields are empty
            /*if (string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_id.Text) ||
                string.IsNullOrWhiteSpace(com_yearlevel.Text) || string.IsNullOrWhiteSpace(com_section.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return; // Stop execution if any required field is empty
            }

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string queryCheck = "SELECT COUNT(*) FROM s_borrowerlist WHERE name = @Name AND studentid = @StudentID";

                    using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                    {
                        connection.Open();
                        commandCheck.Parameters.AddWithValue("@Name", txt_name.Text);
                        commandCheck.Parameters.AddWithValue("@StudentID", txt_id.Text);

                        int count = (int)commandCheck.ExecuteScalar();

                        if (count > 0)
                        {
                            string enteredName = txt_name.Text;

                            if (!string.IsNullOrEmpty(enteredName))
                            {
                                MessageBox.Show("Hello " + enteredName + "currently, you have borrowed 2 books.");
                            }
                            MessageBox.Show("The information you entered already exists.");
                            EnableTextBoxes();
                        }
                        else
                        {
                            // Data doesn't exist, proceed with the insert
                            string queryInsert = "INSERT INTO s_borrowerlist (name, studentid, yearlevel, section) VALUES (@Name, @StudentID, @YearLevel, @Section)";

                            using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@Name", txt_name.Text);
                                commandInsert.Parameters.AddWithValue("@StudentID", txt_id.Text);
                                commandInsert.Parameters.AddWithValue("@YearLevel", string.IsNullOrEmpty(com_yearlevel.Text) ? (object)DBNull.Value : (object)com_yearlevel.Text);
                                commandInsert.Parameters.AddWithValue("@Section", string.IsNullOrEmpty(com_section.Text) ? (object)DBNull.Value : (object)com_section.Text);
                                commandInsert.ExecuteNonQuery();
                                MessageBox.Show("Data inserted successfully.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }*/
            if (string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_id.Text) ||
    string.IsNullOrWhiteSpace(com_yearlevel.Text) || string.IsNullOrWhiteSpace(com_section.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return; // Stop execution if any required field is empty
            }

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string queryCheck = "SELECT COUNT(*) FROM s_borrowerlist WHERE name = @Name AND studentid = @StudentID";

                    using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                    {
                        connection.Open();
                        commandCheck.Parameters.AddWithValue("@Name", txt_name.Text);
                        commandCheck.Parameters.AddWithValue("@StudentID", txt_id.Text);

                        int count = (int)commandCheck.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Hello " + txt_name.Text + ", you currently have 2 borrowed books.");
                            EnableTextBoxes();  // Adjust this based on your specific logic
                        }
                        else
                        {
                            // Data doesn't exist, proceed with the insert
                            string queryInsert = "INSERT INTO s_borrowerlist (name, studentid, yearlevel, section) VALUES (@Name, @StudentID, @YearLevel, @Section)";

                            using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@Name", txt_name.Text);
                                commandInsert.Parameters.AddWithValue("@StudentID", txt_id.Text);
                                commandInsert.Parameters.AddWithValue("@YearLevel", string.IsNullOrEmpty(com_yearlevel.Text) ? (object)DBNull.Value : (object)com_yearlevel.Text);
                                commandInsert.Parameters.AddWithValue("@Section", string.IsNullOrEmpty(com_section.Text) ? (object)DBNull.Value : (object)com_section.Text);

                                // Check if the insertion was successful
                                int rowsAffected = commandInsert.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data inserted successfully.");
                                }
                                else
                                {
                                    MessageBox.Show("Data not inserted. Check if the information already exists.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button17_Click_1(object sender, EventArgs e)
        {
           
            

        }

        private void label16_Click(object sender, EventArgs e)
        {
            label16.Enabled = false;
            number.Text = "0";
            currentNumber -= 2;

            lbl_title.Text = "Details";
            
            
            buttontrue();
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {
            
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_a.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "Chronicles"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, Chronicles"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, Chronicles"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, Chronicles"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, Chronicles"; }
            if (techartab_title.Text == "Power of Habit") { lbl_title.Text = "Power of Habit, Chronicles"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, Chronicles"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, Chronicles"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, Chronicles"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, Chronicles"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, Chronicles"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, Chronicles"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, Chronicles"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, Chronicles"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, Chronicles"; }*/

        }

        private void button31_Click(object sender, EventArgs e)
        {
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_b.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "Quantum"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, Quantum"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, Quantum"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, Quantum"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, Quantum"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, Quantum"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, Quantum"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, Quantum"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, Quantum"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, Quantum"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, Quantum"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, Quantum"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, Quantum"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, Quantum"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, Quantum"; }*/

        }

        private void button30_Click(object sender, EventArgs e)
        {
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_c.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "The Ethereal"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, The Ethereal"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "The Ethereal, The Ethereal"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, The Ethereal"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, QThe Etherealuantum"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, The Ethereal"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, The Ethereal"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, The Ethereal"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, The Ethereal"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, The Ethereal"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, The Ethereal"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, The Ethereal"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, The Ethereal"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, The Ethereal"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, The Ethereal"; }*/

        }

        private void button29_Click(object sender, EventArgs e)
        {
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_d.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "Echoes"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, Echoes"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, Echoes"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, Echoes"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, Echoes"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, Echoes"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, Echoes"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, Echoes"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, Echoes"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, Echoes"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, Echoes"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, Echoes"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, Echoes"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, Echoes"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, Echoes"; }*/

        }

        private void button28_Click(object sender, EventArgs e)
        {
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_e.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "Aethrium"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, Aethrium"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, Aethrium"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, Aethrium"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, Aethrium"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, Aethrium"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, Aethrium"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, Aethrium"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, Aethrium"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, Aethrium"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, Aethrium"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, Aethrium"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, Aethrium"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, Aethrium"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, Aethrium"; }*/

        }

        private void button25_Click(object sender, EventArgs e)
        {
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_f.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "Power of Habit"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, Power of Habit"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, Power of Habit"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, Power of Habit"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, Power of Habit"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, Power of Habit"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, Power of Habit"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, Power of Habit"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, Power of Habit"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, Power of Habit"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, Power of Habit"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, Power of Habit"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, Power of Habit"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, Power of Habitrium"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, Power of Habit"; }*/

        }

        private void button27_Click(object sender, EventArgs e)
        {
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_g.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "Power of Introvert"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, Power of Introvert"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, Power of Introvert"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, Power of Introvert"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, Power of Introvert"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, Power of Introvert"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, Power of Introvert"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, Power of Introvert"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, Power of Introvert"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, Power of Introvert"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, Power of Introvert"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, Power of Introvert"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, Power of Introvert"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, Power of Introvert"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, Power of Introvert"; }*/

        }

        private void button26_Click(object sender, EventArgs e)
        {
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_h.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "Sapiens"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, Sapiens"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, Sapiens"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, Sapiens"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, Sapiens"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, Sapiens"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, Sapiens"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, Sapiens"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, Sapiens"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, Sapiens"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, Sapiens"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, Sapiens"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, Sapiens"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, Sapiens"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, Sapiens"; }*/

        }

        private void button24_Click(object sender, EventArgs e)
        {
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_i.Enabled = false;
            /*if (techartab_title.Text == "Details") { lbl_title.Text = "The Wright"; }
            if (techartab_title.Text == "Chronicles") { lbl_title.Text = "Chronicles, The Wright"; }
            if (techartab_title.Text == "Quantum") { lbl_title.Text = "Quantum, The Wright"; }
            if (techartab_title.Text == "The Ethereal") { lbl_title.Text = "The Ethereal, The Wright"; }
            if (techartab_title.Text == "Echoes") { lbl_title.Text = "Echoes, The Wright"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, The Wright"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, The Wright"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, The Wright"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, The Wright"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, The Wright"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, The Wright"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, The Wright"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, The Wright"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, The Wright"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, The Wright"; }*/

        }

        private void button23_Click(object sender, EventArgs e)
        {
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_j.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "The Wright"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, The Wright"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, The Wright"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, The Wright"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, The Wright"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, The Wright"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, The Wright"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, The Wright"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, The Wright"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, The Wright"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, The Wright"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, The Wright"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, The Wright"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, The Wright"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, The Wright"; }*/

        }

        private void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_k.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "Atomic Habits"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, Atomic Habits"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, Atomic Habits"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, Atomic Habits"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, Atomic Habits"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, Atomic Habits"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, Atomic Habits"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, Atomic Habits"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, Atomic Habits"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, Atomic Habits"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, Atomic Habits"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, Atomic Habits"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, Atomic Habits"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, Atomic Habits"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, Atomic Habits"; }*/

        }

        private void button21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_l.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "S-Scientefic Revolution"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, S-Scientefic Revolution"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, S-Scientefic Revolution"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, S-Scientefic Revolution"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, S-Scientefic Revolution"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, S-Scientefic Revolution"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, S-Scientefic Revolution"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, S-Scientefic Revolution"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, S-Scientefic Revolution"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, S-Scientefic Revolution"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, S-Scientefic Revolution"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, S-Scientefic Revolution"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, S-Scientefic Revolution"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, S-Scientefic Revolution"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, S-Scientefic Revolution"; }*/

        }

        private void button22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_m.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "Guns, Germs and Steel"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, Guns, Germs and Steel"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, Guns, Germs and Steel"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, Guns, Germs and Steel"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, Guns, Germs and Steel"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, Guns, Germs and Steel"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, Guns, Germs and Steel"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, Guns, Germs and Steel"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, Guns, Germs and Steel"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, Guns, Germs and Steel"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, Guns, Germs and Steel"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, Guns, Germs and Steel"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, Guns, Germs and Steel"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, Guns, Germs and Steel"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, Guns, Germs and Steel"; }*/

        }

        private void button20_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_n.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "The Selfish Gene"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, The Selfish Gene"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, The Selfish Gene"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, The Selfish Gene"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, The Selfish Gene"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, The Selfish Gene"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, The Selfish Gene"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, The Selfish Gene"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, The Selfish Gene"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, The Selfish Gene"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, The Selfish Gene"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, The Selfish Gene"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel,The Selfish Gene"; }
            if (techartab_title.Text == "A Brief History") { techartab_title.Text = "A Brief History, The Selfish Gene"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, The Selfish Gene"; }*/

        }

        private void button18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Academic Books are only allowed inside the library.");
            teachertab_currentNumber += 1;
            teachertab_UpdateLabel();
            btn_o.Enabled = false;
            /*if (techartab_title.Text == "Details") { techartab_title.Text = "A Brief History"; }
            if (techartab_title.Text == "Chronicles") { techartab_title.Text = "Chronicles, A Brief History"; }
            if (techartab_title.Text == "Quantum") { techartab_title.Text = "Quantum, A Brief History"; }
            if (techartab_title.Text == "The Ethereal") { techartab_title.Text = "The Ethereal, A Brief History"; }
            if (techartab_title.Text == "Echoes") { techartab_title.Text = "Echoes, A Brief History"; }
            if (techartab_title.Text == "Aethrium") { techartab_title.Text = "Aethrium, A Brief History"; }
            if (techartab_title.Text == "Power of Habit") { techartab_title.Text = "Power of Habit, A Brief History"; }
            if (techartab_title.Text == "Power of Introvert") { techartab_title.Text = "Power of Introvert, A Brief History"; }
            if (techartab_title.Text == "Sapiens") { techartab_title.Text = "Sapiens, A Brief History"; }
            if (techartab_title.Text == "The Wright") { techartab_title.Text = "The Wright, A Brief History"; }
            if (techartab_title.Text == "Atomic Habits") { techartab_title.Text = "Atomic Habits, A Brief History"; }
            if (techartab_title.Text == "S-Scientefic Revolution") { techartab_title.Text = "S-Scientefic Revolution, A Brief History"; }
            if (techartab_title.Text == "Guns, Germs and Steel") { techartab_title.Text = "Guns, Germs and Steel, A Brief History"; }
            if (techartab_title.Text == "The Selfish Gene") { techartab_title.Text = "The Selfish Gene, A Brief History"; }
            if (techartab_title.Text == "The Social Contract") { techartab_title.Text = "The Social Contract, A Brief History"; }*/

        }

        private void label41_Click(object sender, EventArgs e)
        {
            teacher_tab_buttontrue();
            teachertab_currentNumber -= 2;
            techartab_title.Text = "Details";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM teacherinfo WHERE name ='" + textBox2.Text + "' AND employeId = '" + textBox1.Text + "' AND departmnt = '" + comboBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                label29.Text = DateTime.Now.ToString("yyyy-MM-dd"); // date

                

                
                string enteredName = textBox2.Text;

                if (!string.IsNullOrEmpty(enteredName))
                {
                    label31.Text = enteredName;
                }
                teacher_tab_buttontrue();
            }
            else
            {
                MessageBox.Show("Please enter the correct information before you borrow");
                EnableTextBoxes();
                buttonfalse();
            }
        }

        private void button17_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox1.Text) ||
    string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return; // Stop execution if any required field is empty
            }

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\GINES\\OneDrive\\ドキュメント\\teacher.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string queryCheck = "SELECT COUNT(*) FROM t_borrowerlist WHERE name = @Name AND employeId = @EmployeId";

                    using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                    {
                        connection.Open();
                        commandCheck.Parameters.AddWithValue("@Name", textBox2.Text);
                        commandCheck.Parameters.AddWithValue("@EmployeId", textBox1.Text);

                        int count = (int)commandCheck.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Hello " + textBox2.Text + ", you currently have 2 borrowed books.");
                            EnableTextBoxes();  // Adjust this based on your specific logic
                        }
                        else
                        {
                            // Data doesn't exist, proceed with the insert
                            string queryInsert = "INSERT INTO t_borrowerlist (name, employeID, department) VALUES (@Name, @EmployeID, @Department)";

                            using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@Name", textBox2.Text);
                                commandInsert.Parameters.AddWithValue("@EmployeID", textBox1.Text);
                                commandInsert.Parameters.AddWithValue("@Department", string.IsNullOrEmpty(comboBox1.Text) ? (object)DBNull.Value : (object)comboBox1.Text);
                                //commandInsert.Parameters.AddWithValue("@Section", string.IsNullOrEmpty(com_section.Text) ? (object)DBNull.Value : (object)com_section.Text);

                                // Check if the insertion was successful
                                int rowsAffected = commandInsert.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data inserted successfully.");
                                }
                                else
                                {
                                    MessageBox.Show("Data not inserted. Check if the information already exists.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_borrowbook_MouseEnter(object sender, EventArgs e)
        {
            
        }
    }
}
