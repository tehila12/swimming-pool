using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{

   public class RentalsBLL
    {
         //  החזרת כל ההשכרות
        public static List<Rentals_Dto> GetAllRentals()
        {
            try
            {
                return Rentals_Dto.toDTO_List(RentalsDal.GetAllRentals());
            }
            catch(Exception e)
            {
                throw;
            }
        }


        //הוספת משכיר
        public static bool AddRent(int cust_id, DateTime start_date, DateTime end_date, int price,string Payment_status,string status)
        {
            try
            {
                Rentals_Dto r = new Rentals_Dto(cust_id, start_date, end_date, price, Payment_status,status);
                return RentalsDal.AddNewRental(Rentals_Dto.toRentalsTBL(r));
            }
            catch(Exception e)
            {
                throw;
            }
        }


        public static bool UpdateStatus(int id, string s)
        {
            try
            {
                return RentalsDal.UpdateStatus(id, s);
            }
            catch (Exception e)
            {
                throw;
            }
        }




        //public bool RemoveRent(int rentID)
        //{
        //    try
        //    {
        //        return RentalsDal.RemoveRental(rentID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
           
        //}

        //שליפת מחיר השכרה
        public static int getRentPrice()

        {
            try
            {
                return RentalsDal.getRentPrice();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        //שליפת שמות משכירים
        public static List<string> getRentalsName()
        {
            try
            {
                return RentalsDal.getRentalName();
            }
            catch (Exception e)
            {
                throw;
            }
        }



    }
}
