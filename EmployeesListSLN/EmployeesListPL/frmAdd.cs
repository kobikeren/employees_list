using EmployeesListBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesListPL
{
    public partial class frmAdd : Form
    {
        EmployeesListBLManager blManager = new EmployeesListBLManager();

        public frmAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter first name", "Message");
                txtFirstName.Focus();
                return;
            }
            if (txtLastName.Text == "")
            {
                MessageBox.Show("Please enter last name", "Message");
                txtLastName.Focus();
                return;
            }
            if (txtGender.Text.ToLower() != "male" && txtGender.Text.ToLower() != "female")
            {
                MessageBox.Show("Please enter male or female for gender", "Message");
                txtGender.Focus();
                txtGender.SelectAll();
                return;
            }
            int x;
            if (!int.TryParse(txtSalary.Text, out x))
            {
                MessageBox.Show("Please enter a number for salary", "Message");
                txtSalary.Focus();
                txtSalary.SelectAll();
                return;
            }

            Employee employee = new Employee();
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.Gender = txtGender.Text;
            employee.Salary = txtSalary.Text;
            blManager.AddEmployee(employee);
            txtFirstName.Clear();
            txtLastName.Clear();
            txtGender.Clear();
            txtSalary.Clear();

            txtFirstName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
