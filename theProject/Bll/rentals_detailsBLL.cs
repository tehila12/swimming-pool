using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;

namespace Bll
{
    public class rentals_detailsBLL
    {
        //הצגת כל פרטי ההשכרות
        public static List<rentals_detailsDto> GetAllRentDetails()
        {
            try
            {
                return rentals_detailsDto.toDTO_List(rentals_detailsDal.GetAllRentals_details());

            }
            catch (Exception e)
            {
                throw;
            }



        }

        //כניסת משכיר
        public static bool rentEnter(int id)
        {
            try
            {
              return rentals_detailsBLL.rentEnter(id);  
            }
            catch (Exception e)
            {
                throw;
            }

        }

        //הצגת פרטי השכרה לפי קוד השכרה
        public static List<rentals_detailsDto> GetRentDetByReId(int id)
        {
            try
            {
                return rentals_detailsDto.toDTO_List(rentals_detailsDal.GetRentDetailByReId(id));

            }
            catch (Exception e)
            {
                throw;
            }



        }
        //שליפת כל תאריכי ההשכרה הפנויים
        //public static List<DateTime> freeDates()
        //{
        //    try
        //    {
        //        return rentals_detailsDal.freeDates();

        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }


        //}





        //שליפת כל תאריכי ההשכרה הפנויים
        public static List<DateTime> freeDates()
        {
            try
            {
                string[] dayArr = { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי" };
                int day = (int)DateTime.Now.DayOfWeek;
                var rentDay=BusinessDetailsDal.GetRentDay();
                var rentDayIndex = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (rentDay == dayArr[i])
                    {
                        rentDayIndex = i;
                        break;
                    }

                }

                DateTime date = DateTime.Today;
                if (day != rentDayIndex)
                {
                    if (day < rentDayIndex)
                        date = date.AddDays(rentDayIndex - day);
                    else
                    {
                        var sub = day - rentDayIndex;
                        date = date.AddDays(7 - sub);
                    }


                }

              var allDates = rentals_detailsDal.GetAllFreeDates(date);
                return allDates;    



            }
            catch (Exception e)
            {
                throw;
            }


        }




        //הוספת פרטי השכרה
        public static bool AddRentDetails(List<DateTime> c)
        {

            try
            {
                var rentId = rentals_detailsDal.LastRentId();
                foreach (DateTime item in c)
                {
                    
                    rentals_detailsDto rent = new rentals_detailsDto(rentId, item, "פעיל");
                    rentals_detailsDal.AddRentalDetails(rentals_detailsDto.toRentalDetailsTBL(rent));
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        //מחיקת פרטי השכרה
        public static bool RemoveRentDetails(int id)
        {

            try
            {
                return rentals_detailsDal.RemoveRentalDetails(id);
            }
            catch
            {
                throw;
            }
        }
        //הצגת שמות השכרות
        public static List<string> getRentalDetName()
        {

            try
            {
                return rentals_detailsDal.getRentalDetName();
            }
            catch
            {
                throw;
            }
        }

    }
}
