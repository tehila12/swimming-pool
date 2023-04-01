using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class RentalsDal
    {
        //שליפת כל  ההשכרות - כלליות
        public static List<Rentals> GetAllRentals()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Rentals.ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת השכרה על פי מספר השכרה
        public static Rentals GetRentalByRent(int RentId)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Rentals.FirstOrDefault(u => u.rent_id == RentId);
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת  השכרה על פי לקוח
        public static List<Rentals> GetRentalByCust(int custid)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Rentals.Where(u => u.cust_id == custid).ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

     
        //הוספת השכרה - כללית

        public static bool AddNewRental(Rentals e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.Rentals.Add(e);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        //עדכון סטטוס ללא פעיל
        public static bool UpdateStatus(int id, string status)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {

                    var c = db.Rentals.FirstOrDefault(p => p.rent_id== id);
                    c.Payment_status = status;
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }

        }

        //מחיקת השכרה
        public static bool RemoveRental(int rentId)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var e = db.Rentals.FirstOrDefault(p => p.rent_id == rentId);
                    if(e!= null)
                    {
                        db.Rentals.Remove(e);
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


        public static int getRentPrice()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var price = db.BusinessDetails.First(p=>p.rentPrice!=0);
                    return (int)price.rentPrice;
                }
            }
            catch
            {
                return 0;
            }

        }



        //שליפת שמות משכירים
        public static List<string> getRentalName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> RentalNames = new List<string>();

                    var rental = db.Rentals.ToList();
                    foreach (var c in rental)
                    {
                        var cust = db.customers.FirstOrDefault(p => c.cust_id == p.cust_id);
                        if (cust != null)
                            RentalNames.Add(cust.first_name+" "+cust.last_name);
                    }
                    return RentalNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
