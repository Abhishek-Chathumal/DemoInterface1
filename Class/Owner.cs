using System.Data;

namespace DemoInterface1.MVVM.View
{
    class Owner
    {
        string fName;
        string lName;
        string NIC;
        string homeAddress, offAddress;
        string email;
        int mobileContact, homeContact, offContact;
        string profession;
        string photo;
        Database db = new Database();

        public Owner(string fName, string lName, string NIC, string homeAddress, string offAddress, string email, int mobileContact, int homeContact, int offContact, string profession, string photo)
        {
            this.fName = fName;
            this.lName = lName;
            this.NIC = NIC;
            this.homeAddress = homeAddress;
            this.offAddress = offAddress;
            this.email = email;
            this.mobileContact = mobileContact;
            this.homeContact = homeContact;
            this.offContact = offContact;
            this.profession = profession;
            this.photo = photo;
        }

        public Owner()
        {

        }

        public int addOwner()
        {
            string query = "insert into Owner values ('" + NIC + "','" + fName + "','" + lName + "','" + homeAddress + "','" + homeContact + "','" + mobileContact + "','" + profession + "','" + offAddress + "','" + offContact + "','" + email + "','" + photo + "')";
            int i = db.save_update_delete(query);
            return i;
        }

        public DataTable viewOwner()
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec view_owners");
            return dt;
        }

        public DataTable viewOwner(string NIC)
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec view_owners_nic '" + NIC + "'");
            return dt;
        }

        public DataTable searchOwner(string name)
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec view_owners_name '" + name + "'");
            return dt;
        }


        public int updateOwner()
        {
            string query = "exec update_owner '" + NIC + "','" + fName + "','" + lName + "','" + homeAddress + "','" + homeContact + "','" + mobileContact + "','" + profession + "','" + offAddress + "','" + offContact + "','" + email + "','" + photo + "'";
            int i = db.save_update_delete(query);
            return i;
        }

        public int deleteOwner(string NIC)
        {
            string query = "delete from Owner where O_NIC = '" + NIC + "'";
            int i = db.save_update_delete(query);
            return i;
        }
    }

}
