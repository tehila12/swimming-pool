using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bll;
using Dto;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BusinessDetailsController : ApiController
    {
        // GET: api/BusinessDetails
        public List<BusinessDetailsDto> Get()
        {
            return BusinessDetailsBll.GetAllDetails();
        }

        
        // PUT: api/BusinessDetails/5
        public bool Put(BusinessDetailsDto b)
        {
            return BusinessDetailsBll.UpdateDetails(b.BusinessName,b.address,b.rentDay,b.rentPrice,b.RentStartHour,b.RentEndHour);
        }

        // DELETE: api/BusinessDetails/5
        public void Delete(int id)
        {
        }
    }
}
