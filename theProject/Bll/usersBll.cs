using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    public class usersBll
    {




        //שליפת כל המשתמשים
        public static List<usersDto> GetAllUsers()
        {
            try
            {
               return usersDto.toDTO_List(usersDal.GetAllUsers());
            }

            catch (Exception e)
            {
                return null;

            }


        }

        
        public static usersDto GetByPsd(string psd)
        {
            try
            {
                return usersDto.toDTO(usersDal.GetByPsd(psd));  
            }
            catch (Exception e)
            {
               throw;

            }
        }
        //הוספת משתמש
        public static bool AddUser(usersDto u)
        {
            try
            {
                return usersDal.AddUser(usersDto.toTBL(u));
            }

            catch (Exception e)
            {
                return false;

            }


        }




        //מחיקת משתמש
        public static bool DeleteUser(int id)
        {
            try
            {
                return usersDal.DeleteUser(id);
            }

            catch (Exception e)
            {
                return false;

            }


        }

        //עדכון פרטים
        public static bool UpdateUser(usersDto b)
        {
            try
            {

                return usersDal.UpdateUsers(usersDto.toTBL(b));

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
