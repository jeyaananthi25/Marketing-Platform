using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Constant = MarketingApp.Models.Constant;
using MarketingApp.ViewModel;
using MarketingApp.Models;
namespace MarketingApp.Controllers
{
    public class LoginController : Controller
    {
            public static IConfiguration? _configuration;
            //string _con;
            public LoginController(IConfiguration configuration)
            {
                _configuration = configuration;
                //_con = _configuration.GetConnectionString("con");
            }
            public static DataTable GetDataTable(string Procedure, SqlParameter[] sqlParameters)
            {
                //string ConnectionString = "Server=zdb-dev-02.zoiftspl.com;Initial Catalog=Trainee;Persist Security Info=False;User ID=trainee-usr;Password=WeAreAmazing#2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=1200;";
                SqlConnection sqlConnection = new SqlConnection(Constant.Procedure.ConnectionString);
                SqlCommand sqlcommand = new SqlCommand(Procedure, sqlConnection);
                sqlcommand.CommandType = CommandType.StoredProcedure;
                if (sqlParameters != null)
                    sqlcommand.Parameters.AddRange(sqlParameters);

                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            public static DataSet GetDataSet(string Procedure, SqlParameter[] sqlParameters)
            {
                //string _conString = "Server=zdb-dev-02.zoiftspl.com;Initial Catalog=Trainee;Persist Security Info=False;User ID=trainee-usr;Password=WeAreAmazing#2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=1200;";
                SqlConnection sqlConnection = new SqlConnection(Constant.Procedure.ConnectionString);
                SqlCommand sqlcommand = new SqlCommand(Procedure, sqlConnection);
                sqlcommand.CommandType = CommandType.StoredProcedure;
                if (sqlParameters != null)
                    sqlcommand.Parameters.AddRange(sqlParameters);

                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
                sqlDataAdapter.Fill(dataSet);
                return dataSet;
            }
            public IActionResult Signin()
            {
                return View();
            }
            public IActionResult CreateAccount()
            {
                MarketingViewModel marketingViewModel = new MarketingViewModel();
                return View(marketingViewModel);
            }
            [HttpPost]
            public JsonResult InsertUserDetails(MarketingViewModel marketingViewModel)
            {
                Jsonresponse jsonresponse = new Jsonresponse();
                SqlParameter[] objParam = new SqlParameter[6];
                objParam[0] = new SqlParameter("@UserID", marketingViewModel.CreateAccount.AccountID);
                objParam[1] = new SqlParameter("@UserName", marketingViewModel.CreateAccount.Username);
                objParam[2] = new SqlParameter("@Email", marketingViewModel.CreateAccount.EmailID);
                objParam[3] = new SqlParameter("@Mobile", marketingViewModel.CreateAccount.Mobile);
                objParam[4] = new SqlParameter("@Password", marketingViewModel.CreateAccount.Password);
                objParam[5] = new SqlParameter("@ConfirmPassword", marketingViewModel.CreateAccount.ConfirmPassword);
                var dataTable = GetDataTable(Constant.Procedure.AddUser, objParam);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    jsonresponse.Status = Convert.ToString(dataTable.Rows[0]["Status"]);
                    jsonresponse.Message = Convert.ToString(dataTable.Rows[0]["Message"]);
                }


                return Json(jsonresponse);
            }

            [HttpPost]
            public Jsonresponse UserLogin(string email)
            {
                Jsonresponse jsonresponse = new Jsonresponse();
                SqlParameter[] objParam = new SqlParameter[1];
                objParam[0] = new SqlParameter("@Email", email);
                var dataTable = GetDataTable(Constant.Procedure.GetLogin, objParam);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    jsonresponse.Status = Convert.ToString(dataTable.Rows[0]["Status"]);
                    jsonresponse.Message = Convert.ToString(dataTable.Rows[0]["Message"]);
                }

                return jsonresponse;
            }
        
    }
}
