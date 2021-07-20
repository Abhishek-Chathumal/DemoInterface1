using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DemoInterface1
{ 
    class Database
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        public void opencon()
        {
            con.Open();
        }
        public void closecon()
        {
            con.Close();
        }
        public Database()
        {
            con = new SqlConnection("Server=tcp:malshi.database.windows.net,1433;Initial Catalog=MalshiRent;Persist Security Info=False;User ID=malshi;Password=Bawa@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public int save_update_delete(string q)
        {

            opencon();
            cmd = new SqlCommand(q, con);
            int i = cmd.ExecuteNonQuery();
            closecon();
            return i;
        }
        public DataTable getData(string a)
        {
            opencon();
            da = new SqlDataAdapter(a, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            closecon();
            return dt;
        }
    }
}
