using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DemoInterface1
{
    class ModelPricing
    {
        string pID;
        string vType;
        int vYear;
        string vMake;
        string vModel;
        int longRent;
        int shortRent;
        float extraMilageCost;
        Database db = new Database();
        DataTable dt = new DataTable();

        public ModelPricing()
        {
        }
        public ModelPricing(string pID,string vType,int vYear,string vMake,string vModel,int shortRent,int longRent,float extraMilageCost)
        {
            this.pID = pID;
            this.vType = vType;
            this.vYear = vYear;
            this.vMake = vMake;
            this.vModel = vModel;
            this.shortRent = shortRent;
            this.longRent = longRent;
            this.extraMilageCost = extraMilageCost;
        }

        public DataTable viewPricing()
        {            
            dt = db.getData("exec view_pricing");
            return dt;
        }

        public DataTable viewPricing(string modelID)
        {
            dt = db.getData("exec view_pricing_id '"+modelID+"'");
            return dt;
        }

        public int addPricing()
        {
            int i = db.save_update_delete("insert into Pricing values ('" + pID + "','" + vType + "','" + vYear + "','" + vMake + "','" + vModel + "','" + shortRent + "','" + longRent + "','" + extraMilageCost + "')");
            return i;
        }
        public int updatePricing()
        {
            int i = db.save_update_delete("update Pricing set vType='" + vType + "', vYear ='" + vYear + "', vMake = '" + vMake + "',vModel = '" + vModel + "',shortRent = '" + shortRent + "',longRent = '" + longRent + "',extraMilageCost='" + extraMilageCost + "' where pID='" + pID + "'");
            return i;
        }
        public int deletePricing(string pid)
        {
            int i = db.save_update_delete("delete from Pricing where pID = '" + pid + "'");
            return i;
        }

    }

   
}
