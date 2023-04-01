using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CustEnterDAL
    {

        //שליפת כל הכניסות
        public static List<Customers_enter> GetAllEnter()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Customers_enter.ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }


        //החזרת כניסה לפי קוד כניסה
        public static Customers_enter GetSubEntByEntId(int enter)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Customers_enter.FirstOrDefault(p => p.enter_id == enter);
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }



        //הוספת כניסת מנוי

        public static int AddNewEnter(Customers_enter e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var sub = db.Subscribed_customers.FirstOrDefault(p => p.Subscription_id == e.Subscription_id);

                    if (sub.sum_of_entries == 1) /*אם נשאר כניסה אחת*/
                    {
                        sub.sum_of_entries--; /*הורדת מספר הכניסות*/
                        sub.status = "לא פעיל"; /*הפיכת ססטוס ללא פעיל*/
                       
                        var cust = db.customers.FirstOrDefault(o => o.cust_id == sub.cust_id);
                        var rent = db.Rentals.FirstOrDefault(r => r.cust_id == cust.cust_id);
                        if (rent==null)
                        {
                            cust.archive = "לא פעיל";
                        }
                           
                        db.Customers_enter.Add(e);
                        db.SaveChanges();
                        return 0;
                    }
                    else
                    {
                        sub.sum_of_entries--;
                        db.Customers_enter.Add(e);
                        db.SaveChanges();
                        return 1;
                    }


                }
            }
            catch
            {
                return 0;
            }

        }


        //כניסת משכיר
        public static bool AddRentEnter()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var rentDetails = db.rentals_details.FirstOrDefault(p => p.date == DateTime.Today);

                    var r = db.Rentals.FirstOrDefault(p => p.rent_id == rentDetails.rent_id);
                    if (rentDetails != null)
                    {
                        rentDetails.status = "לא פעיל";
                        if (rentDetails.date == r.end_date)
                            r.status = "לא פעיל";
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
        //מחיקת כניסה

        public static bool RemoveEnter(int EnterId)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {

                    var e = db.Customers_enter.FirstOrDefault(p => p.enter_id == EnterId);
                    if (e != null)
                    {
                        db.Customers_enter.Remove(e);
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

        //החזרת היום פתיחה הנוכחי

        public static open_days GetcurrentOpenDay()
        {
            string[] days = { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי", "שבת" };
            int day = (int)DateTime.Now.DayOfWeek;
            string today = days[day];
            TimeSpan time = DateTime.Now.TimeOfDay;

            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var openDays = db.open_days.Where(p => p.day == today).ToList();
                    var shifts = db.work_shift_type.Where(p => p.start_hour <= time && p.end_hour > time).ToList();

                    foreach (var s in shifts)
                    {
                        var shiftId = s.shift_id;
                        var obj = openDays.FirstOrDefault(p => p.shift_id == shiftId);
                        if (obj != null)
                            return obj;
                    }
                    return null;

                }
            }
            catch
            {
                return null;
            }
        }



        //שליפת שמות המנויים
        public static List<string> getEnterSubsName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> SubsNames = new List<string>();

                    var enter = db.Customers_enter.ToList();
                    foreach (var c in enter)
                    {
                        var sub = db.Subscribed_customers.FirstOrDefault(p => c.Subscription_id == p.Subscription_id);
                        if (sub != null)
                        {
                            var subId = sub.cust_id;
                            var custName = db.customers.FirstOrDefault(p => p.cust_id == subId);
                            if (custName != null)
                            {
                                string name = custName.first_name + " " + custName.last_name;
                                SubsNames.Add(name);
                            }

                        }

                    }
                    return SubsNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }




        //שליפת שמות המשמרות
        public static List<string> getShiftsName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> ShiftNames = new List<string>();

                    var enter = db.Customers_enter.ToList();
                    foreach (var c in enter)
                    {
                        var sub = db.work_shift_type.FirstOrDefault(p => p.shift_id == c.work_shift_id);

                        string name = sub.name;
                        ShiftNames.Add(name);

                    }
                    return ShiftNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
