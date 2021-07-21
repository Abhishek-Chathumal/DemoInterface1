using System.Data;

namespace DemoInterface1
{
    class Insurance
    {
        string insID;
        string insName;
        Database db = new Database();

        public Insurance()
        {
        }
        public Insurance(string insID, string insName)
        {
            this.insID = insID;
            this.insName = insName;
        }
        public DataTable viewInsurance()
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Insurance");
            return dt;
        }
        public DataTable viewInsurance(string insName)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Insurance where insName = '" + insName + "'");
            return dt;
        }
        public int addInsurance()
        {
            string query = "insert into insurance values ('" + insID + "','" + insName + "')";
            int i = db.save_update_delete(query);
            return i;
        }
        public int updateInsurance()
        {
            string query = "update insurance set insName='" + insName + "' where insID='" + insID + "'";
            int i = db.save_update_delete(query);
            return i;
        }
        public int deleteInsurance(string id)
        {
            string query = "delete from insurance where insID='" + id + "'";
            int i = db.save_update_delete(query);
            return i;
        }
    }
}
