using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesListDAL
{
    public class EmployeesListDAManager
    {
        SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["mycnstr"].ConnectionString);

        public DataTable GetAllEmployees()
        {
            SqlDataAdapter adp = new SqlDataAdapter("spGetAllEmployees", cn);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            return dt;
        }

        public DataTable GetEmployeeById(int id)
        {
            SqlDataAdapter adp = new SqlDataAdapter("spGetEmployeeById", cn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;            

            SqlParameter parameterId = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id
            };
            adp.SelectCommand.Parameters.Add(parameterId);

            DataTable dt=new DataTable();
            adp.Fill(dt);
                        
            return dt;
        }

        public void AddEmployee(string firstName, string lastName,
            string gender, string salary)
        {
            SqlCommand com = new SqlCommand("spAddEmployee", cn);
            com.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFirstName = new SqlParameter()
            {
                ParameterName = "@FirstName",
                Value = firstName
            };
            com.Parameters.Add(parameterFirstName);

            SqlParameter parameterLastName = new SqlParameter()
            {
                ParameterName = "@LastName",
                Value = lastName
            };
            com.Parameters.Add(parameterLastName);

            SqlParameter parameterGender = new SqlParameter()
            {
                ParameterName = "@Gender",
                Value = gender
            };
            com.Parameters.Add(parameterGender);

            SqlParameter parameterSalary = new SqlParameter()
            {
                ParameterName = "@Salary",
                Value = salary
            };
            com.Parameters.Add(parameterSalary);

            cn.Open();
            com.ExecuteNonQuery();
            cn.Close();
        }

        public void EditEmployee(int id, string firstName, string lastName,
            string gender, string salary)
        {
            SqlCommand com = new SqlCommand("spEditEmployee", cn);
            com.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterId = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id
            };
            com.Parameters.Add(parameterId);

            SqlParameter parameterFirstName = new SqlParameter()
            {
                ParameterName = "@FirstName",
                Value = firstName
            };
            com.Parameters.Add(parameterFirstName);

            SqlParameter parameterLastName = new SqlParameter()
            {
                ParameterName = "@LastName",
                Value = lastName
            };
            com.Parameters.Add(parameterLastName);

            SqlParameter parameterGender = new SqlParameter()
            {
                ParameterName = "@Gender",
                Value = gender
            };
            com.Parameters.Add(parameterGender);

            SqlParameter parameterSalary = new SqlParameter()
            {
                ParameterName = "@Salary",
                Value = salary
            };
            com.Parameters.Add(parameterSalary);

            cn.Open();
            com.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteEmployee(int id)
        {
            SqlCommand com = new SqlCommand("spDeleteEmployee", cn);
            com.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterId = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = id
            };
            com.Parameters.Add(parameterId);

            cn.Open();
            com.ExecuteNonQuery();
            cn.Close();
        }
    }
}
