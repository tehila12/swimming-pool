using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    public class OtherEnterBll
    {
        public static List<OtherEnterDto> GetAllEnter()
        {
            try
            {
                return OtherEnterDto.toDTO_List(OtherEnterDal.GetAllOtherEnter());
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public static List<OtherEnterDto> GetAllEnterByDate(DateTime d)

        {
            try
            {
                return OtherEnterDto.toDTO_List(OtherEnterDal.GetAllEnterByDate(d));
            }

            catch (Exception e)
            {
                throw;
            }
        }




        //הוספת כניסה
        public static bool AddNewEnter(OtherEnterDto o)
        {
            try
            {
                return OtherEnterDal.AddNewEnter(OtherEnterDto.toTBL(o));
            }
            catch (Exception e)
            {
                throw;
            }
        }



        //מחיקת כניסה
        public static bool RemoveEnter(int EnterId)
        {
            try
            {
                return OtherEnterDal.RemoveEnter(EnterId);
            }
            catch
            {
                throw;
            }
        }



        //שליפת כל שמות המשמרות לתצוגה בטבלת כניסות
       public static List<string> getOtherShiftsName()
        {
            try
            {
                return OtherEnterDal.getOtherShiftsName();
            }
            catch
            {
                throw;
            }
        }

    }
}
