using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
     public class SubsTypeBLL
    {
        //שליפת  כל סוגי המנויים
        public static List<Subscription_Type_Dto> GetAllSubsType()
        {
            try
            {
                return Subscription_Type_Dto.toDTO_List(SubscriptionTypeDAL.GetAllSubsType());
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //שליפת שם סוג מנוי
        public static List<string> GetSubTypeById()
        {
            try
            {
                return SubscriptionTypeDAL.GetSubTypeById();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //עדכון סוג מנוי
        public static bool UpdateSubType(int Subs_id,string type, int Num_of_entrances, int price, string status)
        {
            Subscription_Type_Dto t = new Subscription_Type_Dto(Subs_id, type, Num_of_entrances, price, status);
            return SubscriptionTypeDAL.UpdateSubsType(Subscription_Type_Dto.toSubsTypeTBL(t));
        }
           
        //הוספת סוג מנוי
        public static bool AddSubType(string type, int Num_of_entrances, int price, string status)
        {
            try
            {
                Subscription_Type_Dto t = new Subscription_Type_Dto(type, Num_of_entrances, price, status);
                return SubscriptionTypeDAL.AddNewSubsType(Subscription_Type_Dto.toSubsTypeTBL(t));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        
       


        //מחיקת סוג מנוי
        public static bool RemoveSubType(int typeId)
        {
            try
            {
                return SubscriptionTypeDAL.RemoveSubsType(typeId);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        //החזרת מספר כניסות למנוי
        public static int SumEnter(int type)
        {
            try
            {
                return SubscriptionTypeDAL.SumEnterDal(type);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
