using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TabMe.BAL;
using TabMe.ViewModel;

namespace TabMe.API.Controllers
{
    public class RoomController : ApiController
    {
        // GET api/values
        public ReturnResult Get()
        {
            var rooms = RoomBAL.GetAll();
            return rooms;
        }

        // GET api/values/5
        public ReturnResult Get(int id)
        {
            var rooms = RoomBAL.GetById(id);
            return rooms;
        }
    }
}
