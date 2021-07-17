using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DemoInterface1
{
    class MaintenanceRepair : Repair
    {
        string nxtCheck;
        Database db = new Database();


        public MaintenanceRepair(string id,string date,string location,int cost,string details,string next)
        {
            RepairID = id;
            repairDate = date;
            repairLocation = location;
            repairCost = cost;
            repairDetails = details;
            nxtCheck = next;
        }
        public MaintenanceRepair()
        { }
        public override int addRepair(string vehicle)
        {
            string query = "insert into Maintenance_Repair values ('" + vehicle + "','" + RepairID + "','" + repairDate + "','" + repairLocation + "','" + repairDetails + "','" + repairCost + "','" + nxtCheck + "')";
            int i = db.save_update_delete(query);
            return i;
        }
        public override DataTable viewRepair()
        {
            string query = "exec view_maintenance";
            DataTable dt = new DataTable();
            dt = db.getData(query);
            return dt;
        }
        public override DataTable viewRepair(string id)
        {
                string query = "select * from Maintenance_Repair where main_RID = '" + id + "'";
                DataTable dt = new DataTable();
                dt = db.getData(query);
                return dt;         
        }
        public DataTable viewRepairVehicle(string vehicle)
        {
            string query = "exec view_maintenanceVehicle '"+vehicle+"'";
            DataTable dt = new DataTable();
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewRepairDate(string date)
        {
            string query = "exec view_maintenanceDate '" + date + "'";
            DataTable dt = new DataTable();
            dt = db.getData(query);
            return dt;
        }
        public override int updateRepair(string vid)
        {
            string query = "update Maintenance_Repair set V_ID = '"+vid+ "',repairDate = '" + repairDate+ "',repairLocation='" + repairLocation+ "',repiarDetails='" + repairDetails + "',repairCost='" + repairCost+ "',nxtCheck ='" + nxtCheck+"' where main_RID='"+RepairID+"'";
            int i = db.save_update_delete(query);
            return i;
        }
        public override int deleteRepair(string id)
        {
            string query = "delete from Maintenance_Repair where main_RID = '" + id + "'";
            int i = db.save_update_delete(query);
            return i;
        }
    }
}
