using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Laureto
{
    public partial class frmRegistration : Form
    {
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        private string _FullName;

        public frmRegistration()
        {
            InitializeComponent();
            
        }
        public long StudentNumber(string studNum)
        {
            if (Regex.IsMatch(studNum, @"^[0-9]{1,15}$"))
            {
                _StudentNo = long.Parse(studNum);
            }
            else
            {
                throw new FormatException("User must only enter an integer in the Student Number textbox!");
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            else
            {
                throw new FormatException("User must only enter an integer in the Contact Number textbox!");
            }
                

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") && Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") && Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @" ^$"))
            {
                _FullName = LastName + ", " + FirstName + " " + MiddleInitial;
            }
            else
            {
                throw new FormatException("User must only enter a string in the name textboxes!");
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
                throw new FormatException("User must only enter an integer in the age textbox!");
            }

            return _Age;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for(int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
            string[] GenderBender = new string[]
           {
                "Male",
                "Female"
           };
            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(GenderBender[i].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();

                txtLastName.Clear();
                txtFirstName.Clear();
                txtMiddleInitial.Clear();
                txtStudentNo.Clear();
                cbPrograms.SelectedIndex = -1;
                cbGender.SelectedIndex = -1;
                txtContactNo.Clear();
                txtAge.Clear();
                datePickerBirthday.ResetText();
                

            }
            catch(FormatException FE)
            {
                MessageBox.Show(FE.Message);
            }

        }

        private void cbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
