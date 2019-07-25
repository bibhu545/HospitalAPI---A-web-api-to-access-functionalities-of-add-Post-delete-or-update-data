using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataModels;
using BusinessLayer;

namespace HospitalAPI.Controllers
{
    public class HospitalController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new BusinessClass().GetAllHospitals());
        }
        public HttpResponseMessage Get(int id)
        {
            List<Hospital> hospitals = new BusinessClass().GetHospitals(id);
            if (hospitals.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, hospitals);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "No hospitals added by user");
            }
        }
        public HttpResponseMessage Get(int userid, int hospitalid)
        {
            Hospital hospital = new BusinessClass().GetHospitalDetails(userid, hospitalid);
            if (hospital != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, hospital);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "No hospitals added by user");
            }
        }

        public HttpResponseMessage Post(Hospital hospital)
        {
            try
            {
                int created = new BusinessClass().AddHospital(hospital);
                if(created > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "New hospital added for user with userid: " + hospital.userid);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Some error occured. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Some error occured. Please try again later. " + ex.Message);
            }
        }
        public HttpResponseMessage Put(Hospital hospital)
        {
            try
            {
                int updated = new BusinessClass().UpdateHospital(hospital);
                if (updated > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Hospital details updated.");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is no change to update or Selected hospital is invalid for user.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Some error occured. Please try again later. " + ex.Message);
            }
        }
        public HttpResponseMessage Delete(int userid, int hospitalid)
        {
            try
            {
                int deleted = new BusinessClass().DeleteHospital(userid, hospitalid);
                if (deleted > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Hospital Deleted.");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Selected hospital is invalid for user.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Some error occured. Please try again later. " + ex.Message);
            }
        }

    }
}
