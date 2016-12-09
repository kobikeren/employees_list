using EmployeesListDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesListBLL
{
    public class EmployeesListBLManager
    {
        EmployeesListDAManager daManager = new EmployeesListDAManager();

        public bool IsDeleteNotAllowed()
        {
            DataTable dt = daManager.GetAllEmployees();

            return dt.Rows.Count <= 1;            
        }

        public DataTable GetAllEmployees()
        {
            return daManager.GetAllEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            DataTable dt = daManager.GetEmployeeById(id);
            Employee employee = new Employee();
            foreach (DataRow i in dt.Rows)
            {
                employee.Id = (int)i["Id"];
                employee.FirstName = i["FirstName"].ToString();
                employee.LastName = i["LastName"].ToString();
                employee.Gender = i["Gender"].ToString();
                employee.Salary = i["Salary"].ToString();
            }

            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            daManager.AddEmployee(employee.FirstName, employee.LastName,
                employee.Gender, employee.Salary);
        }

        public void EditEmployee(Employee employee)
        {
            daManager.EditEmployee(employee.Id, employee.FirstName, employee.LastName,
                employee.Gender, employee.Salary);
        }

        public void DeleteEmployee(int id)
        {
            daManager.DeleteEmployee(id);
        }
    }
}
