using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{

    public class CustomersBLL
    {



        //שליפת כל הלקוחות הפעילים
        public static List<customers_Dto> GetAllCust()
        {
            try
            {
                return customers_Dto.toDTO_List(CustomersDal.GetAllCustomers());

            }
            catch (Exception e)
            {
                throw;
            }



        }


        //שליפת כל לקוחות הארכיון

        public static List<customers_Dto> GetArchiveCustomers()
        {
            try
            {
                return customers_Dto.toDTO_List(CustomersDal.GetArchiveCustomers());
            }

            catch (Exception e)
            {
                return null;

            }


        }
        //שליפת המשכיר הפעיל כרגע
        public static customers_Dto GetActiveRentCust()
        {
            try
            {
                return customers_Dto.toCustDTO(CustomersDal.GetActiveRent());
            }
            catch (Exception e)
            {
                throw;
            }

        }

        //שליפת כל הלקוחות - מנויים הפעילים
        public static List<customers_Dto> GetAllActiveSubs()
        {
            try
            {
                return customers_Dto.toDTO_List(CustomersDal.GetAllActiveSubs());
            }
            catch
            {

                return null;

            }

        }

        //שליפת שמות לקוחות מנויים
        public static List<string> GetAllNames()
        {
            try
            {

                return CustomersDal.GetSubNamsById();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        //שליפת לקוח לפי קוד
        public static customers_Dto getCustById(int id)
        {
            try
            {

                return customers_Dto.toCustDTO(CustomersDal.CustByID(id));

            }
            catch (Exception e)
            {
                throw;
            }
        }



        //עדכון לקוח
        public static bool UpdateCust(customers_Dto c)
        {
            return CustomersDal.UpdateCust(customers_Dto.toCustTBL(c));
        }


        //בדיקה האם הלקוח קיים
        public static customers_Dto ifExist(customers_Dto c)
        {

            try
            {
                return customers_Dto.toCustDTO( CustomersDal.ifExist(customers_Dto.toCustTBL(c)));
            }
            catch
            {
                throw;
            }


        }
        //מנוי- הוספת לקוח
        public static int AddCust(customers_Dto c)
        {

            try
            {
                var exist = ifExist(c);//בדיקה האם הלקוח קיים במאגר
                if (exist != null)//הלקוח קיים
                {
                    if (exist.archive == "פעיל")
                        return -1;
                    else
                    {
                        updateArchive(exist.cust_id);
                        return exist.cust_id;
                    }
                         

                }
                else
                CustomersDal.AddNewCust(customers_Dto.toCustTBL(c));
                return 0;   
            }
            catch
            {
                throw;
            }
        }

        //שליפת מספר לקוחות
        public static int GetSumOfCust()
        {
            try
            {
                return customers_Dto.toDTO_List(CustomersDal.GetAllCustomers()).Count;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //מחיקת לקוח
        public static bool RemoveCustomer(int CustId)
        {
            try
            {
                return CustomersDal.RemoveCust(CustId);
            }
            catch
            {
                throw;
            }
        }

        //קוד השכרה האחרון שנוצר
        public static int LastRentId()
        {
            try
            {
                return CustomersDal.LastRentId();
            }
            catch
            {
                throw;
            }
        }

        public static bool sendToArchive(int id)
        {
            try
            {
                return CustomersDal.sendToArchive(id);
            }
            catch
            {
                throw;
            }
        }

        //עדכון סטטוס ארכיון
        public static bool updateArchive(int id)
        {
            try
            {
                return CustomersDal.updateArchive(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
