namespace Api.Setting
{
    public static class ConectionContext
    {
        public static string Server { get; set; } = "192.168.0.216"; //super:192.168.0.216 //tienda: "172.16.20.202";
        public static string User { get; set; } = "sa";
        public static string Password { get; set; } = "sql2017";
        public static string DataBase { get; set; } = "TIENDA";

        public static string GetConnectionStringSqlServer()
        {

            string connectionString = @"Data Source=" + Server + ";Initial Catalog=TIENDA; user id=" + ConectionContext.User + "; password= " + ConectionContext.Password + "";
            return connectionString;
        }
    }
}
