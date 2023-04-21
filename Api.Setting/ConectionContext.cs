namespace Api.Setting
{
    public static class ConectionContext
    {
        public static string Server { get; set; }  //super:192.168.0.245 : red cableado.super:192.168.0.216 : red wifi //tienda: "172.16.20.202";
        public static string DataBase { get; set; }
        public static string User { get; set; } 
        public static string Password { get; set; } 


        public static string GetConnectionSqlServer()
        {
            string connectionString = @"Data Source=" + Server + ";Initial Catalog=TIENDA; user id=" + User + "; password= " + Password + "";
            return connectionString;
        }
    }
}
