using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterface1
{ 
    class Bill
    {
        string billID;
        string billDate;
        int extraCost;
        string payMethod;
        Database db = new Database();

        public Bill(string id,string date,int cost,string method)
        {
            billID = id;
            billDate = date;
            extraCost = cost;
            payMethod = method;
        }
        public Bill()
        {

        }
        public int addBill(string bookID, string vid)
        {
            string query = "insert into billing values ('" + bookID + "','" + billID + "','" + billDate + "','" + extraCost + "','" + payMethod + "')";
            string query2 = "update vehicle set bookingStatus = '0' where plateNumber = '" + vid + "'";
            int i = db.save_update_delete(query);
            return i;

        }
    }
}
