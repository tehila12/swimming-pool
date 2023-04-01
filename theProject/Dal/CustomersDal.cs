using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CustomersDal
    {
        //שליפת כל הלקוחות הפעילים
        public static List<customers> GetAllCustomers()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.Where(p => p.archive == "פעיל").ToList();
                    return t;
                }
            }

            catch (Exception e)
            {
                return null;

            }


        }

        //שליפת כל לקוחות הארכיון

        public static List<customers> GetArchiveCustomers()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.Where(p => p.archive == "לא פעיל").ToList();
                    return t;
                }
            }

            catch (Exception e)
            {
                return null;

            }


        }
        //בדיקה האם הלקוח קיים
        public static customers ifExist(customers e)
        {

            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var exist=db.customers.FirstOrDefault(p=>p.first_name==e.first_name&&p.last_name==e.last_name&&p.birthdate==e.birthdate&&p.telephone==e.telephone);
                    if (exist != null)
                        return exist;
                    else
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }



        //הוספת לקוח
        public static bool AddNewCust(customers e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.customers.Add(e);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }


        //מחיקת לקוח
        public static bool RemoveCust(int custId)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var c = db.customers.FirstOrDefault(o => o.cust_id == custId);

                    if (c != null)
                    {
                        db.customers.Remove(c);
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

        //עדכון לקוח
        public static bool UpdateCust(customers c)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.FirstOrDefault(p => p.cust_id == c.cust_id);

                    t.first_name = c.first_name;
                    t.last_name = c.last_name;
                    t.telephone = c.telephone;
                    t.email = c.email;
                    t.gender = c.gender;
                    t.birthdate = c.birthdate;
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }

        }

        //שליפת כל הלקוחות - מנויים הפעילים
        public static List<customers> GetAllActiveSubs()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.Where(p => p.status == "מנוי").ToList();
                    List<customers> activeSubs = new List<customers>();

                    foreach (var c in t)
                    {
                        var s = db.Subscribed_customers.FirstOrDefault(p => p.cust_id == c.cust_id && p.status == "פעיל");
                        if (s != null)
                            activeSubs.Add(c);

                    }
                    return activeSubs;
                }
            }
            catch
            {

                return null;

            }

        }

        public static List<string> GetSubNamsById()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> subNames = new List<string>();
                   
                    var subs = db.Subscribed_customers.ToList();
                    foreach (var c in subs)
                    {
                        var customers = db.customers.FirstOrDefault(p=>c.cust_id==p.cust_id);
                        if(customers != null)
                            subNames.Add(customers.first_name+" "+customers.last_name);
                    }
                    return subNames;
                }
            }
            catch
            {
                return null;
            }
        }
       


        //שליפת המשכיר הפעיל ביום זה
        public static customers GetActiveRent()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    DateTime myDateTime = DateTime.Today;


                    var rentDetails = db.rentals_details.FirstOrDefault(p => p.date == myDateTime);
                    var rentObj = db.Rentals.FirstOrDefault(P => P.rent_id == rentDetails.rent_id);
                    var rentCust = db.customers.FirstOrDefault(p => p.cust_id == rentObj.cust_id);
                    if (rentCust != null)
                        return rentCust;
                    else
                        return null;
                }
            }
            catch
            {

                return null;

            }

        }

        //שליפת לקוח לפי קוד לקוח
        public static customers CustByID(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.FirstOrDefault(p => p.cust_id == id);
                    return t;
                }
            }

            catch
            {

                return null;

            }


        }


        //קוד לקוח משכיר האחרון שנוצר
        public static int LastRentId()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.ToList();
                    var cust = t[t.Count - 1];
                    return cust.cust_id;
                }
            }
            catch
            {
                return -1;
            }
        }


       //שליחה לארכיון
        public static bool sendToArchive(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var cust = db.customers.FirstOrDefault(p=>p.cust_id==id);
                    cust.archive = "לא פעיל";
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }
        }


        public static bool updateArchive(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var cust = db.customers.FirstOrDefault(p => p.cust_id == id);
                    cust.archive = "פעיל";
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
