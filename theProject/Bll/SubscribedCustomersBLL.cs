using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
   


    public class SubscribedCustomersBLL
    {
        //הצגת כל המנויים
        public static List<Subscribed_customersDto> GetAllSubs()
        {
            try
            {
                return Subscribed_customersDto.toDTO_List(Subscribed_customersDal.GetAllSubscribed());
            }

            catch (Exception e)
            {
                throw;
            }
        }



        ////החזרת מנוי לפי שם 
        //public static Subscribed_customersDto GetSubsByName(string first, string last)
        //{
        //    try
        //    {
        //        var subid = Subscribed_customersDal.GetSubsIdByName(first, last);
        //        return GetSubsById(subid);
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        public static int SumOfSubs()
        {
            try
            {
                return GetAllSubs().Count;
            }
            catch (Exception e)
            {
                throw;
            }
        }




        //הוספת מנוי חדש
        public static bool AddSubs( int Subscription_type,int sum_of_entries,string status)
        {
            try
            {
                var cust_id = Subscribed_customersDal.GetLast().cust_id;
                Subscribed_customersDto s = new Subscribed_customersDto(cust_id, Subscription_type,sum_of_entries,status);
                return Subscribed_customersDal.AddNewSubs(Subscribed_customersDto.toSubCustTBL(s));

            }
            catch (Exception e)
            {
                throw;
            }
        }


        //הוספת מנוי - לקוח קיים
        public static bool AddUpdateSub(int custId,int Subscription_type, int sum_of_entries, string status)
        {
            try
            {
                var cust_id = custId;
                Subscribed_customersDto s = new Subscribed_customersDto(cust_id, Subscription_type, sum_of_entries, status);
                return Subscribed_customersDal.AddNewSubs(Subscribed_customersDto.toSubCustTBL(s));

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static bool RemoveSubs(int subID)
        {
            try
            {
                return Subscribed_customersDal.RemoveSubs(subID);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //שליפת מנוי לפי קוד מנוי
        public static Subscribed_customersDto GetSubsById(int subId)
        {
            try
            {
                return Subscribed_customersDto.toSubCustDTO(Subscribed_customersDal.GetSubscribedById(subId));
            }
            catch (Exception e)
            {
                throw;
            }
        }


        //שליפת מנוי לפי קוד לקוח
        public static Subscribed_customersDto GetSubsByCustId(int subId)
        {
            try
            {
                return Subscribed_customersDto.toSubCustDTO(Subscribed_customersDal.GetSubsByCustId(subId));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //עדכון מנוי- מספר כניסות וסטטוס
        public static bool UpdateSub(Subscribed_customersDto sub)
        {
            try
            {
                return Subscribed_customersDal.UpdateSub(Subscribed_customersDto.toSubCustTBL(sub));
            }
            catch (Exception e)
            {
                throw;
            }
        }

       
    }
}
