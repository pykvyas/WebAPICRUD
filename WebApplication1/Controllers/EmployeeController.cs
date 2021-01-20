using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {

        public HttpResponseMessage Get()
        {
            string query = @"select EmployeeId,EmployeeName,EmployeeName,DateOfJoining,PhotoFileName from dbo.Employee";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        
        public string Post(Employee emp)
        {
            try
            {
                string query = @"insert into dbo.Employee values 
                (
                    '" + emp.EmployeeName + @"'
                    ,'" + emp.DepartmentName + @"'
                    ,'" + emp.DateOfJoining + @"'
                    ,'" + emp.PhotoFileName + @"'
                )";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception ex)
            {

                return "Failed adding";
            }
        }

        public string Put(Employee emp)
        {
            try
            {
                string query = @"update dbo.Employee set EmployeeName=
                '" + emp.EmployeeName + @"'
                where EmployeeId=" + emp.EmployeeId + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception ex)
            {

                return "Failed adding";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Employee where EmployeeId=
                " + id + @"";


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception ex)
            {

                return "Failed to delete!!";
            }
        }
    }
}
