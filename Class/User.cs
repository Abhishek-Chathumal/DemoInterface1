using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DemoInterface1
{
    class User
    {
        string utype;
        string uname;
        string pass;
        string email;
        Database db = new Database();
        DataTable dt = new DataTable();

        public User(string utype, string uname, string pass, string email)
        {
            this.utype = utype;
            this.uname = uname;
            this.pass = pass;
            this.email = email;
        }
        public User(string uname, string pass)
        {
            this.uname = uname;
            this.pass = pass;
        }
        public User(string uname)
        {
            this.uname = uname;
        }
        public User()
        {

        }

        public int addAccount()
        {
            string query = "insert into UserAcc values ('" + uname + "','" + pass + "','" + utype + "','" + email + "')";
            int i = db.save_update_delete(query);
            return i;
        }
        public DataTable checkUser(string user)
        {
            dt = db.getData("select * from UserAcc where Uname = '" + user + "'");
            return dt;
        }

        public int authorizeAccount()
        {
            string query = "select * from UserAcc where Uname='" + uname + "' and Upass='" + pass + "'";
            dt = db.getData(query);
            return dt.Rows.Count;
        }
        public string getUserType()
        {
            string query = "select * from UserAcc where Uname='" + uname + "' and Upass='" + pass + "'";
            dt = db.getData(query);
            string type = dt.Rows[0][2].ToString();
            return type;
        }
        public string getEmail()
        {
            string query = "select * from UserAcc where Uname='" + uname + "'";
            dt = db.getData(query);
            string email = dt.Rows[0][3].ToString();
            return email;
        }
        public int updatePassword(string newPass)
        {
            string query = "update UserAcc set Upass='"+newPass+"' where Uname='" + uname + "'";
            int i = db.save_update_delete(query);
            return i;
        }
        public int deleteAccount()
        {
            string query = "delete from UserAcc where Uname = '" + uname + "'";
            int i = db.save_update_delete(query);
            return i;
        }
       
    }
}
