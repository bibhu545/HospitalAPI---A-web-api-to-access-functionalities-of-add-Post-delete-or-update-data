using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModels;

namespace BusinessLayer
{
    public class BusinessClass
    {
        public List<Hospital> GetAllHospitals()
        {
            return new DataAccessClass().GetAllHospitalsFromDB();
        }
        public List<Hospital> GetHospitals(int userid)
        {
            return new DataAccessClass().GetHospitalsFromDB(userid);
        }
        public Hospital GetHospitalDetails(int userid, int hospitalid)
        {
            return new DataAccessClass().GetHospitalDetailsFromDB(userid, hospitalid);
        }
        public int AddHospital(Hospital hospital)
        {
            return new DataAccessClass().AddHospitalToDB(hospital);
        }
        public int UpdateHospital(Hospital hospital)
        {
            return new DataAccessClass().UpdateHospitalToDB(hospital);
        }
        public int DeleteHospital(int userid, int hospitalid)
        {
            return new DataAccessClass().DeleteHospitalFromDB(userid, hospitalid);
        }

    }
}
