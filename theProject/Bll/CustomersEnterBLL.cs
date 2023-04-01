using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    

    public class CustomersEnterBLL
    {

        //שליפת כל הכניסות
        public static List<Customers_enterDto> GetAllEnter()
        {
            try
            {
                return Customers_enterDto.toDTO_List(CustEnterDAL.GetAllEnter());
                
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static Open_Days_Dto GetCurrentOpenDays()
        {
            try
            {
                var c= Open_Days_Dto.toOpenDDTO(CustEnterDAL.GetcurrentOpenDay());
                if (c == null)
                    return null;
                else
                    return c;


            }
            catch (Exception e)
            {
                throw;
            }
        }

      

        //הוספת כניסת מנוי
        public static int AddEnter( int Subscription_id, int Shift_work)
        {
            try
            {
                Customers_enterDto enter = new Customers_enterDto( Subscription_id, Shift_work);
                return CustEnterDAL.AddNewEnter(Customers_enterDto.toCustomersEnterTBL(enter));
            }
            catch(Exception e)
            {

                throw;
            }
        }

        //כניסת משכיר
        public static bool AddRentEnter()
        {
            try
            {

                return CustEnterDAL.AddRentEnter();
            }
            catch (Exception e)
            {

                throw;
            }
        }




        //מחיקת כניסה
        public static bool RemoveEnter(int EnterID)
        {
            try
            {
               
                return CustEnterDAL.RemoveEnter(EnterID);
            }
            catch (Exception e)
            {

                throw;
            }
        }


      
        //כניסת מנוי לפי קוד כניסה
        public static Customers_enterDto GetSubEnterById(int enterId)
        {
            try
            {
                return Customers_enterDto.toCustomersEnterDTO(CustEnterDAL.GetSubEntByEntId(enterId));
            }
            catch (Exception e)
            {
                throw;

            }
        }

        //שליפת שמות המנויים לכניסה
       
        public static List<string> getEnterSubsName()
        {
            try
            {

               return CustEnterDAL.getEnterSubsName();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת שמות המשמרות לכניסה

        public static List<string> getEnterShiftName()
        {
            try
            {

                return CustEnterDAL.getShiftsName();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
