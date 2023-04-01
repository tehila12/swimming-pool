using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
  public class Subscribed_customersDal
    {
     
        //שליפת כל המנויים
        public static List<Subscribed_customers> GetAllSubscribed()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Subscribed_customers.ToList();
                    return t;
                }
            }

            catch
            {
                return null;

            }


        }

        //שליפת מנוי ע''פ קוד מנוי
        public static Subscribed_customers GetSubscribedById(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Subscribed_customers.FirstOrDefault(p => p.Subscription_id == id&&p.status=="מנוי");
                    return t;
                }
            }

            catch
            {
                return null;

            }


        }

        //שליפת מנוי ע''פ קוד לקוח
        public static Subscribed_customers GetSubsByCustId(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Subscribed_customers.FirstOrDefault(p => p.cust_id == id);
                    return t;
                }
            }

            catch
            {
                return null;

            }


        }


        public static customers GetLast()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.ToList();
                    var cust = t[t.Count - 1];
                    return cust;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }



        //public static int GetSubsIdByName(string first, string last)
        //{
        //    try
        //    {

        //        using (Swimming_PoolEntities db = new Swimming_PoolEntities())
        //        {
        //            var t = db.customers.FirstOrDefault(u => u.first_name == first && u.last_name == last);
        //            return t.cust_id;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        return 0;
        //    }
        //}



        



        //הוספת מנוי

        public static bool AddNewSubs(Subscribed_customers e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.Subscribed_customers.Add(e);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }



        //מחיקת מנוי

        public static bool RemoveSubs(int subid)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var e = db.Subscribed_customers.FirstOrDefault(p => p.Subscription_id==subid);
                    db.Subscribed_customers.Remove(e);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        //עדכון מנוי חוץ מסוג מנוי ותאריך התחלה- זה בפונקציה נפרדת
        public static bool UpdateSub(Subscribed_customers sub)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var theSub = db.Subscribed_customers.FirstOrDefault(p => p.Subscription_id == sub.Subscription_id);
                   
                    theSub.sum_of_entries=sub.sum_of_entries;   
                    theSub.status=sub.status;   
                   
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


    }
}
