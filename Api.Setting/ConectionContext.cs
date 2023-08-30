namespace Api.Setting
{
    public static class ConectionContext
    {
        public static string Server { get; set; }  // Produccion: 172.16.20.11 Demo: 172.16.20.5
        public static string DataBase { get; set; }
        public static string User { get; set; } // produccion: coventaf Demo: appCoventaf
        public static string Password { get; set; } //produccion: Tienda2023.@* Demo: C3rv3g$@2023**  



        public static string GetConnectionSqlServer()
        {            
            string connectionString = @"Data Source=" + Server + ";Initial Catalog=TIENDA; user id=" + User + "; password= " + Password + "";
            return connectionString;
        }
    }
}
