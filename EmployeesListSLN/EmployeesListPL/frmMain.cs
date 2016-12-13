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
    //*******************************************************************
    //****************** Created by kobi keren **************************
    //******************     on 13/12/2016     **************************
    //*******************************************************************

    public partial class frmMain : Form
    {
        EmployeesListBLManager blManager = new EmployeesListBLManager();

        public frmMain()
        {
            InitializeComponent();
        }

        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idInt;
            string idStr = cmbId.SelectedValue.ToString();
            if (int.TryParse(idStr, out idInt))
            {
                Employee employee = blManager.GetEmployeeById(idInt);
                lblFirstName.Text = employee.FirstName;
                lblLastName.Text = employee.LastName;
                lblGender.Text = employee.Gender;
                lblSalary.Text = employee.Salary;
            }
        }

        private void GetData()
        {
            DataTable dt = blManager.GetAllEmployees();
            dataGridView1.DataSource = dt;
            cmbId.DataSource = dt;
            cmbId.DisplayMember = "Id";
            cmbId.ValueMember = "Id";
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd1 = new frmAdd();
            frmAdd1.ShowDialog();
            GetData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lblFirstName.Text == "")
            {
                MessageBox.Show("Employee was not selected", "Message");
                return;
            }
            Employee employee = new Employee();
            employee.Id = int.Parse(cmbId.SelectedValue.ToString());
            employee.FirstName = lblFirstName.Text;
            employee.LastName = lblLastName.Text;
            employee.Gender = lblGender.Text;
            employee.Salary = lblSalary.Text;
            frmEdit frmEdit1 = new frmEdit(employee);
            frmEdit1.ShowDialog();
            GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblFirstName.Text == "")
            {
                MessageBox.Show("Employee was not selected", "Message");
                return;
            }
            if (blManager.IsDeleteNotAllowed())
            {
                MessageBox.Show("You cannot delete the only record in the table","Message");
                return;
            }
            Employee employee = new Employee();
            employee.Id = int.Parse(cmbId.SelectedValue.ToString());
            employee.FirstName = lblFirstName.Text;
            employee.LastName = lblLastName.Text;
            employee.Gender = lblGender.Text;
            employee.Salary = lblSalary.Text;
            string message = "The following employee will be deleted:\n\n";
            message += "Id : " + employee.Id.ToString() + "\n";
            message += "First name : " + employee.FirstName + "\n";
            message += "Last name : " + employee.LastName + "\n";
            message += "Gender : " + employee.Gender + "\n";
            message += "Salary : " + employee.Salary + "\n";
            message += "\nAre you sure?";
            DialogResult dialogResult = MessageBox.Show
                (message, "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                blManager.DeleteEmployee(employee.Id);
                GetData();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
