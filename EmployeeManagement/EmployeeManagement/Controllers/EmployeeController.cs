using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EmployeeManagement.Models;
namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        string connectionString = @"Data Source = DESKTOP-DK5A96M; Initial Catalog = EmployeeManagement; Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblEmployee = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Employee",sqlCon);
                sqlDa.Fill(dtblEmployee);
            }
            return View(dtblEmployee);
        }
        // GET: EmployeeController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmployeeModel());
        }
        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Employee VALUES(@name,@email,@address,@department,@designation,@dob,@gender,@doj,@salary,@status,@country)";
                SqlCommand sqlCmd = new SqlCommand(query,sqlCon);
                sqlCmd.Parameters.AddWithValue("@name", employeeModel.name);
                sqlCmd.Parameters.AddWithValue("@email", employeeModel.email);
                sqlCmd.Parameters.AddWithValue("@address", employeeModel.address);
                sqlCmd.Parameters.AddWithValue("@department", employeeModel.department);
                sqlCmd.Parameters.AddWithValue("@designation", employeeModel.designation);
                sqlCmd.Parameters.AddWithValue("@dob", employeeModel.dob);
                sqlCmd.Parameters.AddWithValue("@gender", employeeModel.gender);
                sqlCmd.Parameters.AddWithValue("@doj", employeeModel.doj);
                sqlCmd.Parameters.AddWithValue("@salary", employeeModel.salary);
                sqlCmd.Parameters.AddWithValue("@status", employeeModel.status);
                sqlCmd.Parameters.AddWithValue("@country", employeeModel.country);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            DataTable dtblEmployee = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Employee Where employeeId = @employeeId";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@employeeId",id);
                sqlDa.Fill(dtblEmployee);
            }
            if(dtblEmployee.Rows.Count == 1)
            {
                employeeModel.employeeId = Convert.ToInt32(dtblEmployee.Rows[0][0].ToString());
                employeeModel.name = dtblEmployee.Rows[0][1].ToString();
                employeeModel.email = dtblEmployee.Rows[0][2].ToString();
                employeeModel.address = dtblEmployee.Rows[0][3].ToString();
                employeeModel.department = dtblEmployee.Rows[0][4].ToString();
                employeeModel.designation = dtblEmployee.Rows[0][5].ToString();
                employeeModel.dob = dtblEmployee.Rows[0][6].ToString();
                employeeModel.gender = dtblEmployee.Rows[0][7].ToString();
                employeeModel.doj = dtblEmployee.Rows[0][8].ToString();
                employeeModel.salary = Convert.ToInt32(dtblEmployee.Rows[0][9].ToString());
                employeeModel.status = dtblEmployee.Rows[0][10].ToString();
                employeeModel.country = dtblEmployee.Rows[0][11].ToString();
                //sqlCmd.ExecuteNonQuery();
                return View(employeeModel);
            }
            else 
            return RedirectToAction("Index");
        }
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Employee SET name = @name, email=@email,address=@address,department=@department,designation=@designation,dob=@dob,gender=@gender,doj=@doj,salary=@salary,status=@status,country=@country WHere employeeId = @employeeId";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@employeeId", employeeModel.employeeId);
                sqlCmd.Parameters.AddWithValue("@name", employeeModel.name);
                sqlCmd.Parameters.AddWithValue("@email", employeeModel.email);
                sqlCmd.Parameters.AddWithValue("@address", employeeModel.address);
                sqlCmd.Parameters.AddWithValue("@department", employeeModel.department);
                sqlCmd.Parameters.AddWithValue("@designation", employeeModel.designation);
                sqlCmd.Parameters.AddWithValue("@dob", employeeModel.dob);
                sqlCmd.Parameters.AddWithValue("@gender", employeeModel.gender);
                sqlCmd.Parameters.AddWithValue("@doj", employeeModel.doj);
                sqlCmd.Parameters.AddWithValue("@salary", employeeModel.salary);
                sqlCmd.Parameters.AddWithValue("@status", employeeModel.status);
                sqlCmd.Parameters.AddWithValue("@country", employeeModel.country);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");

        }
        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Employee WHere employeeId = @employeeId";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@employeeId", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
