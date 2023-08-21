namespace Api.Setting
{
    public static class ConectionContext
    {
        public static string Server { get; set; }  //red cableado super:192.168.0.54. Red wifi Super :192.168.0.216. //tienda: "172.16.20.202";
        public static string DataBase { get; set; }
        public static string User { get; set; } //coventaf
        public static string Password { get; set; } //"Tienda2023.@*"



        public static string GetConnectionSqlServer()
        {
            string connectionString = @"Data Source=" + Server + ";Initial Catalog=TIENDA; user id=" + User + "; password= " + Password + "";
            return connectionString;
        }
    }
}
