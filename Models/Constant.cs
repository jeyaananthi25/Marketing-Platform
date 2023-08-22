namespace MarketingApp.Models
{
    public class Constant
    {
        public static class Procedure
        {
            public const string ConnectionString = "Server=zdb-dev-02.zoiftspl.com;Initial Catalog=Trainee;Persist Security Info=False;User ID=trainee-usr;Password=WeAreAmazing#2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=1200;";
            public const string AddUser = "saranya.sp_GetAccountDetails";
            public const string GetLogin = "saranya.sp_GetUserLogin";
            public const string GetPersonalInfo = "GetPersonalInfo";
        }
    }
}
