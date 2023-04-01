using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
 
     public class OpenDaysBLL
    {

        public static List<Open_Days_Dto> GetAllOpenDays()
        {
            try
            {
                return Open_Days_Dto.toDTO_List(OpenDateDal.GetAllOpenDays());
            }
            catch(Exception e)
            {
                throw;
            }
        }




        public static bool AddOpen( int shift_id, string day, string gender, string status)
        {
            try
            {
              Open_Days_Dto o = new Open_Days_Dto(shift_id, day, gender, status);
                return OpenDateDal.AddNewOpen(Open_Days_Dto.toOpenDTBL(o));
            }
           catch(Exception e)
            {
                throw;
            }

        }

        //מחיקת יום פתיחה
        public static bool RemoveOpen(int openId)
        {
            try
            {
                return OpenDateDal.RemoveOpen(openId);
                   
            }
            catch(Exception e)
            {
                throw;
            }
        }

        //החזרת ימי פתיחה לפי יום מסוים
        public static List<Open_Days_Dto> GetOpenByDay(string day)
        {
            try
            {
                return Open_Days_Dto.toDTO_List(OpenDateDal.GetOpenDay(day));
            }
            catch(Exception e)
            {
                throw;
            }
        }



        
        //עדכון יום פתיחה
        public static bool UpdateOpenDay(Open_Days_Dto c)
        {
            try
            {
                return OpenDateDal.UpdateOpenDay(Open_Days_Dto.toOpenDTBL(c));
            }
            catch
            {
                return false;
            }

        }


        
    }
}
