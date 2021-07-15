using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DemoInterface1.MVVM.View
{
    class AccidentRepair : Repair
    {
        int repairClaim;
        int reapirDuration;
        Database db = new Database();

        public AccidentRepair(string id, string date, string location, int cost, string details, int claim,int duration)
        {
            RepairID = id;
            repairDate = date;
            repairLocation = location;
            repairCost = cost;
            repairDetails = details;
            repairClaim = claim;
            reapirDuration = duration;
        }
        public AccidentRepair()
        { }

        public override int addRepair(string vehicle)
        {
            string query = "insert into Accident_Repair values ('" + vehicle+"','"+RepairID+"','"+repairDate+"','"+repairLocation+"','"+repairDetails+"','"+repairCost+"','"+repairClaim+"','"+reapirDuration+"')";
            int i = db.save_update_delete(query);
            return i;
        }
        public override DataTable viewRepair()
        {
            string query = "exec view_accidents";
            DataTable dt = new DataTable();
            dt = db.getData(query);
            return dt;
        }
        public override DataTable viewRepair(string id)
        {
            string query = "select * from Accident_Repair where acc_RID = '" + id + "'";
            DataTable dt = new DataTable();
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewRepairVehicle(string vehicle)
        {
            string query = "exec view_accidentVehicle '" + vehicle + "'";
            DataTable dt = new DataTable();
            dt = db.getData(query);
            return dt;
        }
        public DataTable viewRepairDate(string date)
        {
            string query = "exec view_accidentDate '" + date + "'";
            DataTable dt = new DataTable();
            dt = db.getData(query);
            return dt;
        }
        public override int updateRepair(string vid)
        {
            string query = "update Accident_Repair set Vno = '" + vid + "',repairDate = '" + repairDate + "',repairLocation='" + repairLocation + "',repiarDetails='" + repairDetails + "',repairCost='" + repairCost + "',repairClaim ='" + repairClaim + "',repairDuration = '" + reapirDuration+"' where acc_RID='" + RepairID + "'";
            int i = db.save_update_delete(query);
            return i;
        }
        public override int deleteRepair(string id)
        {
            string query = "delete from Accident_Repair where acc_RID = '" + id + "'";
            int i = db.save_update_delete(query);
            return i;
        }
    }
}
