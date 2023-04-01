using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    /* פונקציות:

     2. מחיקה
     4.  עדכון*/

    public class WorkShiftTypeBLL
    {
        //1. החזרת כל סוגי המשמרות
        public static List<Work_ShiftType_Dto> GetAllWorkSType()
        {
            try
            {
                return Work_ShiftType_Dto.toDTO_List(WorkShiftTypeDAL.GetAllWorkShiftType());

            }
            catch (Exception e)
            {
                throw;
            }
        }

        //2. הוספה
        public static bool AddWorkSType(string name, TimeSpan start_hour, TimeSpan end_hour)
        {
            try
            {
                Work_ShiftType_Dto w = new Work_ShiftType_Dto(name, start_hour, end_hour);
                return WorkShiftTypeDAL.AddNewWorkShType(Work_ShiftType_Dto.toWorkShTypeTBL(w));
            }
            catch (Exception e)
            {
                throw;
            }
        }


        //3. מחיקה
        public static bool RemoveWSType(int shiftTypeID)
        {
            try
            {
                return WorkShiftTypeDAL.RemoveWorkShiType(shiftTypeID);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        //עדכון סוג משמרת
        public static bool UpdateWorkShiType(Work_ShiftType_Dto wst)
        {
            try
            {
                return WorkShiftTypeDAL.UpdateWorkShiType(Work_ShiftType_Dto.toWorkShTypeTBL(wst));
            }
            catch (Exception e)
            {
                throw;
            }
        }



        public static List<string> getShiftName()
        {
            try
            {
                return WorkShiftTypeDAL.getShiftName();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
