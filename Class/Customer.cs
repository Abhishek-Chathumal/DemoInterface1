using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DemoInterface1
{
    class Customer
    {
        string fName;
        string lName;
        string NIC;
        string cusEmail;
        string cusHomeAd;
        int cusHomeTel;
        int cusMobileTel;
        string cusProfession;
        string cusWorkingAd;
        int cusWorkiTel;
        string cusKinName;
        string cusKinAd;
        int cusKinTel;
        string cusPhoto;

        Database db = new Database();
        DataTable dt = new DataTable();

        public Customer(string fName,string lName,string NIC,string cusEmail,string cusHomeAd,int cusHomeTel,int cusMobileTel,string cusProfession,string cusWorkingAd,int cusWorkiTel,string cusKinName, string cusKinAd,int cusKinTel,string cusPhoto)
        {
            this. fName = fName;
            this. lName = lName;
            this. NIC = NIC;
            this. cusEmail = cusEmail;
            this. cusHomeAd= cusHomeAd;
            this. cusHomeTel= cusHomeTel;
            this. cusMobileTel= cusMobileTel;
            this. cusProfession= cusProfession;
            this. cusWorkingAd= cusWorkingAd;
            this. cusWorkiTel= cusWorkiTel;
            this. cusKinName= cusKinName;
            this. cusKinAd= cusKinAd;
            this. cusKinTel= cusKinTel;
            this.cusPhoto = cusPhoto;
        }

        public Customer()
        { }

        public int addCustomer()
        {
            string query1 = "insert into Customer values ('" + NIC + "','" + fName + "','" + lName + "','" + cusHomeAd + "','" + cusWorkingAd + "','" + cusMobileTel + "','" + cusHomeTel + "','" + cusWorkiTel + "','" + cusEmail + "','" + cusProfession + "','"+cusPhoto+"')";
            string query2 = "insert into Customer_Kin values ('" + NIC + "','" + cusKinName + "','" + cusKinAd + "','" + cusKinTel + "')";
            int i = db.save_update_delete(query1);
            int j = db.save_update_delete(query2);
            if (i == 1 && j == 1)
                return i;
            else
                return 0;
        }
        public DataTable viewCustomer()
        {
            string query = "exec viewCustomer";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewCustomer(string id)
        {
            string query = "select * from Customer where cNIC= '"+id+"'";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewCustomerNIC(string nic)
        {
            string query = "exec viewCustomerNIC '" + nic + "'";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewCustomerName(string name)
        {
            string query = "exec viewCustomerName '" + name + "'";
            dt = db.getData(query);
            return dt;
        }
        public int getCustomerCount()
        {
            dt = db.getData("select count(cNIC) from Customer");
            int count = Int32.Parse(dt.Rows[0][0].ToString());
            return count;
        }
        public int updateCustomer ()
        {
            string query1 = " update Customer set  cus_FName = '" +fName+ "', cus_LName='" + lName + "', cEmail='" + cusEmail + "', residentAd='" + cusHomeAd + "', homeTel='" + cusHomeTel + "', mobileTel='" +cusMobileTel+ "', cProffession='" + cusProfession + "', workAd='" + cusWorkingAd + "', workTel='" + cusWorkiTel + "', cusPhoto='"+cusPhoto+"' where cNIC = '" + NIC + "'";
            string query2 = " update Customer_Kin set kName='" +cusKinName+ "' , kAddress = '" + cusKinAd + "' , kContact = '" + cusKinTel + "' where  CusID = '" + NIC + "'";

            int x = db.save_update_delete(query1);
            int y = db.save_update_delete(query2);
            if (x == 1 && y == 1)
                return x;
            else
                return 0;

        }
        public int deleteCustomer(string id)
        {
            string a = " Delete from Customer where cNIC = '" + id + "'";
            string b = "Delete from Customer_Kin where CusID= '" + id + "'";
            int i = db.save_update_delete(b);
            int j = db.save_update_delete(a);
            if (i == 1 && j == 1)
                return i;
            else
                return 0;
        }
    }
}
