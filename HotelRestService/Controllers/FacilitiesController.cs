using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelModel;
using HotelRestService.DBUtil;

namespace HotelRestService.Controllers
{
    public class FacilitiesController : ApiController
    {
        // GET: api/Facilities
        public List<Facilities> Get()
        {
            ManageFacilities mngFacilities = new ManageFacilities();
            return mngFacilities.GetAllFacilities();
        }

        // GET: api/Facilities/5
        public Facilities Get(int id)
        {
            ManageFacilities mngFacilities = new ManageFacilities();
            return mngFacilities.GetFacilitiesFromId(id);
        }

        // POST: api/Facilities
        public void Post(Facilities value)
        {
            ManageFacilities mngFacilities = new ManageFacilities();
            mngFacilities.CreateFacility(value);
        }

        // PUT: api/Facilities/5
        public void Put(int id, Facilities value)
        {
            ManageFacilities mngFacilities = new ManageFacilities();
            mngFacilities.UpdateFacilities(value, id);
        }

        // DELETE: api/Facilities/5
        public void Delete(int id)
        {
            ManageFacilities mngFacilities = new ManageFacilities();
            mngFacilities.DeleteFacilities(id);
        }
    }
}
