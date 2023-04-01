using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
     public class OpenDateDal
    {
        //שליפת כל פרטי כניסה
        public static List<open_days> GetAllOpenDays()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.open_days.ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }




        //שליפת פרטי פתיחה על פי יום מסוים
        public static List<open_days> GetOpenDay(string day)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.open_days.Where(p=>p.day==day).ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

  

        //הוספת פתיחה
        public static bool AddNewOpen(open_days o)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.open_days.Add(o);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        //מחיקת פתיחה


        public static bool RemoveOpen(int open_id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var o = db.open_days.FirstOrDefault(p => p.open_id == open_id);
                    if(o!=null)
                    {
                        db.open_days.Remove(o);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                    
                }
            }
            catch
            {
                return false;
            }

        }

        //עדכון יום פתיחה
        public static bool UpdateOpenDay(open_days c)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.open_days.FirstOrDefault(p => p.open_id == c.open_id);
                    t.day = c.day;
                    t.shift_id = c.shift_id;
                    t.gender = c.gender;
                    t.status=c.status;  
                 
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
