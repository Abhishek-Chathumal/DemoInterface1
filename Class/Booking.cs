using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DemoInterface1.MVVM.View
{
    class Booking
    {
        string bookingID;
        string bookingDate;
        string lendDate;
        string returnDate;
        int advAmount;
        Database db = new Database();
        DataTable dt = new DataTable();

        public Booking(string bookingID, string bookingDate, string lendDate,string returnDate,int advAmount)
        {
            this.bookingID = bookingID;
            this.bookingDate = bookingDate;
            this.lendDate = lendDate;
            this.returnDate = returnDate;
            this.advAmount = advAmount;
        }
        public Booking()
        {
        }
        public int addBooking(string cid,string vid)
        {
            string query1 = "insert into Booking values ('" + bookingID + "','" + bookingDate + "','" + lendDate + "','" + returnDate + "','" + advAmount + "')";
            string query2 = "insert into Customer_Booking values ('"+bookingID+"','"+cid+"','"+vid+"')";
            int i =db.save_update_delete(query1);
            int j = db.save_update_delete(query2);
            if (i == 1 && j == 1)
                return i;
            else
                return 0;
        }
        public int updateBooking(string cid, string vid)
        {
            string query1 = "update Booking set bookingDate='"+bookingDate+"',lendDate='"+lendDate+"',returnDate='"+returnDate+"',advAmount='"+advAmount+"' where bookingID='"+bookingID+"'";
            string query2 = "update Customer_Booking set C_ID='"+cid+"',V_No='"+vid+"' where B_ID='"+bookingID+"'";
            string query3 = "update vehicle set bookingStatus='1' where plateNUmber='"+vid+"'";
            int i = db.save_update_delete(query1);
            int j = db.save_update_delete(query2);
            db.save_update_delete(query3);
            if (i == 1 && j == 1)
                return i;
            else
                return 0;
        }
        public int deleteBooking(string bid,string cid, string vid)
        {
            string query2 = "delete from Customer_Booking where B_ID ='" + bid + "'";
            string query1 = "delete from Booking where bookingID ='" + bid+"'";            
            string query3 = "update vehicle set bookingStatus = '0' where plateNumber = '" + vid + "'";
            int i = db.save_update_delete(query2);
            int j = db.save_update_delete(query1);
            db.save_update_delete(query3);
            if (i == 1 && j == 1)
                return i;
            else
                return 0;
        }

        public DataTable viewBooking()
        {
            string query = "select * from booking";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewBookingForm()
        {
            string query = "exec viewBookings";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewBillForm(string bid)
        {
            string query = "exec billForm '"+bid+"'";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewBookingID(string bid)
        {
            string query = "select * from booking where bookingID='"+bid+"'";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewCustomerBooking(string bid)
        {
            string query = "select * from Customer_Booking where B_ID='" + bid + "'";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewBookingVehicle(string vid)
        {
            string query = "exec viewBookingsVehicle  '" + vid + "'";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewBookingCustomer(string cno)
        {
            string query = "exec viewBookingsCustomer '" + cno + "'";
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewBookingDate(string date)
        {
            string query = "exec viewBookingsDate '" + date + "'";
            dt = db.getData(query);
            return dt;
        }
    }
}
