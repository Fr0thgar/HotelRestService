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
    public class GuestController : ApiController
    {
        // GET: api/Guest
        public IEnumerable<Guest> Get()
        {
            ManageGuest mngGuest = new ManageGuest();
            return mngGuest.GetAllGuest();
            //return new Guest[] { "value1", "value2" };
        }

        // GET: api/Guest/5
        public Guest Get(int id)
        {
            ManageGuest mngGuest = new ManageGuest();
            return mngGuest.GetGuestFromId(id);
        }

        // POST: api/Guest
        public void Post([FromBody]Guest value)
        {
            ManageGuest mngGuest = new ManageGuest();
            mngGuest.CreateGuest(value);
        }

        // PUT: api/Guest/5
        public void Put(int id, [FromBody]Guest value)
        {
            ManageGuest mngGuest = new ManageGuest();
            mngGuest.UpdateGuest(value, id);
        }

        // DELETE: api/Guest/5
        public void Delete(int id)
        {
            ManageGuest mngGuest = new ManageGuest();
            mngGuest.DeleteGuest(id);
        }
    }
}
