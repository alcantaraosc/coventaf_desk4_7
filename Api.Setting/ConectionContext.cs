namespace Api.Setting
{
    public static class ConectionContext
    {
        public static string Server { get; set; } = "localhost";// "172.16.20.202";
        public static string User { get; set; } = "sa";
        public static string Password { get; set; } = "sql2017";
        public static string DataBase { get; set; } = "TIENDA";

        public static string GetConnectionStringSqlServer()
        {

            string connectionString = @"Data Source=" + Server + ";Initial Catalog=TIENDA;Integrated Security=true; user id=" + ConectionContext.User + "; password= " + ConectionContext.Password + "";
            return connectionString;
        }
    }
}
