using System;
using System.Data;

namespace DemoInterface1.MVVM.View
{
    class Vehicle
    {
        string plateNumber;
        string vColor;
        string vType;
        string transmission;
        int engineCapacity;
        string fuelType;
        int noOfPassengers;
        // int bookingStatus;
        string vPhoto;
        string licenseStartDate;
        string licenseExpiryDate;
        string insExpiryDate;
        string insStartDate;
        string lendingDate;
        int monthlyPay;
        string wName;
        string wAddress;
        int wContact;

        Database db = new Database();
        DataTable dt = new DataTable();

        public Vehicle()
        {
        }
        public Vehicle(string plateNumber, string vType, string vColor, string vPhoto, string transmission, int engineCapacity, int noOfPassengers, string licenseStartDate, string licenseExpiryDate, string insExpiryDate, string insStartDate, string fuelType, string lendingDate, int monthlyPay, string wName, string wAddress, int wContact)
        {
            this.plateNumber = plateNumber;
            this.vType = vType;
            this.vColor = vColor;
            this.vPhoto = vPhoto;
            this.transmission = transmission;
            this.engineCapacity = engineCapacity;
            this.noOfPassengers = noOfPassengers;
            this.licenseStartDate = licenseStartDate;
            this.licenseExpiryDate = licenseExpiryDate;
            this.insExpiryDate = insExpiryDate;
            this.insStartDate = insStartDate;
            this.fuelType = fuelType;
            //this.bookingStatus = false;
            this.lendingDate = lendingDate;
            this.monthlyPay = monthlyPay;
            this.wName = wName;
            this.wAddress = wAddress;
            this.wContact = wContact;
        }

        public int addVehicle(string modelID, string insID, string ownerID)
        {
            string query = "insert into Vehicle ( plateNumber,modelID,vColor,vType,transmission,engineCapacity,fuelType,noOfPassengers,vPhoto,licenseStartDate,licenseExpiryDate,I_ID,InsStartDate,InsExpiryDate,O_ID,lendingDate,monthlyPay,wName,wAddress,wContact) values ('" + plateNumber + "','" + modelID + "','" + vColor + "','" + vType + "','" + transmission + "','" + engineCapacity + "','" + fuelType + "','" + noOfPassengers + "','" + vPhoto + "','" + licenseStartDate + "','" + licenseExpiryDate + "','" + insID + "','" + insStartDate + "','" + insExpiryDate + "','" + ownerID + "','" + lendingDate + "','" + monthlyPay + "','" + wName + "','" + wAddress + "','" + wContact + "')";
            int i = db.save_update_delete(query);
            return i;
        }
        public DataTable viewVehicle()
        {
            dt = db.getData("exec view_vehicle");
            return dt;
        }
        public DataTable viewVehicle(string plate)
        {
            dt = db.getData("exec view_vehicleNo '" + plate + "'");
            return dt;
        }
        public DataTable viewAvaiableVehicle()
        {
            dt = db.getData("exec view_availableVehicle");
            return dt;
        }
        public DataTable viewVehicleCategory(string category)
        {
            dt = db.getData("exec view_vehicleCategory '" + category + "'");
            return dt;
        }
        public DataTable viewVehicleMake(string make)
        {
            dt = db.getData("exec view_vehicleMake '" + make + "'");
            return dt;
        }
        public DataTable viewVehicleFuel(string fuel)
        {
            dt = db.getData("exec view_vehicleFuel '" + fuel + "'");
            return dt;
        }
        public DataTable viewVehicleTrans(string trans)
        {
            dt = db.getData("exec view_vehicleTrans '" + trans + "'");
            return dt;
        }
        public int updateVehicle(string modelID, string insID, string oID)
        {
            string query = "update Vehicle set modelID = '" + modelID + "',vColor ='" + vColor + "',vType = '" + vType + "',transmission = '" + transmission + "',engineCapacity = '" + engineCapacity + "',fuelType = '" + fuelType + "',noOfPassengers = '" + noOfPassengers + "',vPhoto = '" + vPhoto + "',licenseStartDate = '" + licenseStartDate + "',licenseExpiryDate = '" + licenseExpiryDate + "',I_ID = '" + insID + "',InsStartDate = '" + insStartDate + "',InsExpiryDate = '" + insExpiryDate + "',O_ID = '" + oID + "',lendingDate = '" + lendingDate + "',monthlyPay = '" + monthlyPay + "',wName = '" + wName + "',wAddress = '" + wAddress + "',wContact = '" + wContact + "' where plateNumber = '" + plateNumber + "'";
            int i = db.save_update_delete(query);
            return i;
        }
        public int deleteVehicle(string plate)
        {
            string query = "delete from Vehicle where plateNumber = '" + plate + "'";
            int i = db.save_update_delete(query);
            return i;
        }
        public int getTotalVehicleCount()
        {
            dt = db.getData("select count(plateNumber) from Vehicle");
            int count = Int32.Parse(dt.Rows[0][0].ToString());
            return count;

        }
        public int getAvaialableVehicleCount()
        {
            dt = db.getData("select count(plateNumber) from Vehicle where bookingStatus='0'");
            int count = Int32.Parse(dt.Rows[0][0].ToString());
            return count;
        }
        public int getSedans()
        {
            dt = db.getData("select count(plateNumber) from Vehicle where vType='Sedan'");
            int count = Int32.Parse(dt.Rows[0][0].ToString());
            return count;
        }
        public int getHatchback()
        {
            dt = db.getData("select count(plateNumber) from Vehicle where vType='HatchBack'");
            int count = Int32.Parse(dt.Rows[0][0].ToString());
            return count;
        }
        public int getSUV()
        {
            dt = db.getData("select count(plateNumber) from Vehicle where vType='SUV'");
            int count = Int32.Parse(dt.Rows[0][0].ToString());
            return count;
        }
        public int getMinivan()
        {
            dt = db.getData("select count(plateNumber) from Vehicle where vType='Minivan'");
            int count = Int32.Parse(dt.Rows[0][0].ToString());
            return count;
        }
        public int getVan()
        {
            dt = db.getData("select count(plateNumber) from Vehicle where vType='Van'");
            int count = Int32.Parse(dt.Rows[0][0].ToString());
            return count;
        }
    }

}
