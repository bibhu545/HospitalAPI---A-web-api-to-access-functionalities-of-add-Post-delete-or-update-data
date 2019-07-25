using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace DataAccess
{
    public class DataAccessClass
    {
        public List<Hospital> GetAllHospitalsFromDB()
        {
            using (var context = new assignmentEntities())
            {
                return context.hospitals.Select(x => new Hospital()
                {
                    hospitalid = x.hospitalid,
                    userid = x.userid,
                    address = x.address,
                    email = x.email,
                    hospitalname = x.hospitalname,
                    phone1 = x.phone1,
                    phone2 = x.phone2,
                    isprimary = x.isprimary
                }).ToList();
            }
        }
        public List<Hospital> GetHospitalsFromDB(int userid)
        {
            using (var context = new assignmentEntities())
            {
                return context.hospitals.Where(x => x.userid == userid).Select(x => new Hospital() {
                    hospitalid = x.hospitalid,
                    userid = x.userid,
                    address = x.address,
                    email = x.email,
                    hospitalname = x.hospitalname,
                    phone1 = x.phone1,
                    phone2 = x.phone2,
                    isprimary = x.isprimary
                }).ToList();
            }
        }
        public Hospital GetHospitalDetailsFromDB(int userid, int hospitalid)
        {
            using (var context = new assignmentEntities())
            {
                hospitals h = context.hospitals.FirstOrDefault(x => x.userid == userid && x.hospitalid == hospitalid);
                return new Hospital()
                {
                    hospitalid = h.hospitalid,
                    userid = h.userid,
                    address = h.address,
                    email = h.email,
                    hospitalname = h.hospitalname,
                    phone1 = h.phone1,
                    phone2 = h.phone2,
                    isprimary = h.isprimary
                };
            }
        }
        public int AddHospitalToDB(Hospital hospital)
        {
            using (var context = new assignmentEntities())
            {
                context.hospitals.Add(new hospitals() {
                    userid = hospital.userid,
                    address = hospital.address,
                    email = hospital.email,
                    hospitalname = hospital.hospitalname,
                    phone1 = hospital.phone1,
                    phone2 = hospital.phone2,
                    isprimary = hospital.isprimary
                });
                return context.SaveChanges();
            }
        }
        public int UpdateHospitalToDB(Hospital hospital)
        {
            using (var context = new assignmentEntities())
            {
                var updatedHospital = context.hospitals.FirstOrDefault(x => x.userid == hospital.userid && x.hospitalid == hospital.hospitalid);
                if (updatedHospital != null)
                {
                    updatedHospital.address = hospital.address;
                    updatedHospital.email = hospital.email;
                    updatedHospital.hospitalname = hospital.hospitalname;
                    updatedHospital.phone1 = hospital.phone1;
                    updatedHospital.phone2 = hospital.phone2;
                    updatedHospital.isprimary = hospital.isprimary;
                    return context.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
        }
        public int DeleteHospitalFromDB(int userid, int hospitalid)
        {
            using (var context = new assignmentEntities())
            {
                var deletedHospital = context.hospitals.FirstOrDefault(x => x.userid == userid && x.hospitalid == hospitalid);
                if (deletedHospital != null)
                {
                    context.hospitals.Remove(deletedHospital);
                    return context.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
