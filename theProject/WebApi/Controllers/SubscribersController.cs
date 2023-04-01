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
    public class SubscribersController : ApiController
    {
       
        
        //הצגת כל המנויים
        public List<Subscribed_customersDto> GetAllSubscribers()
        {
            var e = SubscribedCustomersBLL.GetAllSubs();
            return e;
        }

        //החזרת אובייקט מנוי לפי קוד מנוי
        public Subscribed_customersDto GetSubById(int id)
        {
            return SubscribedCustomersBLL.GetSubsById(id);
        }

        //החזרת אובייקט מנוי לפי קוד לקוח
        public Subscribed_customersDto GetSubByCustId(int id)
        {
            return SubscribedCustomersBLL.GetSubsByCustId(id);
        }

        //הוספת מנוי
        public bool PostSubDetails(int id,int id2)    
        {
           
            int subType =id;
            int sumOfEntries = id2;
            return SubscribedCustomersBLL.AddSubs(subType,sumOfEntries,"פעיל");
        }

        //הוספת מנוי קיים
        public bool UpdateSubDetails(int id, int id2,int id3)
        {
            int custId = id3;
            int subType = id;
            int sumOfEntries = id2;
            return SubscribedCustomersBLL.AddUpdateSub(custId, subType, sumOfEntries, "פעיל");
        }

        //מחיקת מנוי
        public bool DeleteSub(int Subscription_id)
        {
            return SubscribedCustomersBLL.RemoveSubs(Subscription_id);
        }

       
    }
}
