using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class rentals_detailsDal
    {

        //שליפת כל פרטי השכרות
        public static List<rentals_details> GetAllRentals_details()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.rentals_details.ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }



      

        public static List<DateTime> GetAllFreeDates(DateTime date)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<DateTime> allDates = new List<DateTime>();

                    var fexist = db.rentals_details.FirstOrDefault(p => p.date == date);
                    if (fexist == null)
                        allDates.Add(date);
                    for (int i = 0; i < 4 * 12; i++)
                    {
                        date = date.AddDays(7);
                        var exist = db.rentals_details.FirstOrDefault(p => p.date == date);
                        if (exist == null)
                            allDates.Add(date);

                    }
                    return allDates;

                }
            }
            catch
            {
                return null;
            }
                
        }

        //שליפת כניסות ע''פ מספר השכרה

        public static List<rentals_details> GetRentDetailByReId(int id)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.rentals_details.Where(p => p.rent_id == id).ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת פרטי השכרה

        public static bool AddRentalDetails(rentals_details Rent)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.rentals_details.Add(Rent);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        //שליפת פרטי השכרה נוכחית
        public static rentals_details GetCurrentRentDetails()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {

                    var rentDetails = db.rentals_details.FirstOrDefault(p => p.date == DateTime.Now);
                    return rentDetails;
                }
            }
            catch
            {
                return null;
            }

        }


        //מחיקת פרטי השכרה

        public static bool RemoveRentalDetails(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {

                    var e = db.rentals_details.FirstOrDefault(p => p.RentalDetails_id == id);
                    if (e != null)
                    {
                        db.rentals_details.Remove(e);
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

        //החזרת קוד לקוח האחרון שהתווסף
        public static int LastRentId()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Rentals.ToList();
                    var cust = t[t.Count - 1];
                    return cust.rent_id;
                }
            }
            catch
            {
                return -1;
            }
        }


        //שליפת שמות המשכירים- לפרטי השכרה
        public static List<string> getRentalDetName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> RentalDetNames = new List<string>();

                    var rental = db.rentals_details.ToList();
                    foreach (var c in rental)
                    {
                        var rent=db.Rentals.FirstOrDefault(p=>p.rent_id==c.rent_id);
                        var cust = db.customers.FirstOrDefault(p => rent.cust_id == p.cust_id);
                        if (cust != null)
                            RentalDetNames.Add(cust.first_name + " " + cust.last_name);
                    }
                    return RentalDetNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
