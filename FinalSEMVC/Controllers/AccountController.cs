using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalSEMVC.Models;

namespace FinalSEMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        //Get: Account
        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=(local)\\SQLEXPRESS; database=Login;integrated security = SSPI;";
            ;
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from users where Username ='" + acc.Name + "' and Password ='" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("error");
            }


        }
    }
}