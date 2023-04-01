using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    public class BusinessDetailsBll
    {
        //שליפת הפרטים
        public static List<BusinessDetailsDto> GetAllDetails()
        {
            try
            {

              return BusinessDetailsDto.toDTO_List( BusinessDetailsDal.GetAllDetails());

            }
            catch (Exception e)
            {
                return null;
            }
        }


        //עדכון פרטים
        public static bool UpdateDetails(string bussinesName,string address,string day,int price,TimeSpan start,TimeSpan end)
        {
            try
            {
                return BusinessDetailsDal.UpdateDetail(bussinesName, address, day, price, start, end);

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
