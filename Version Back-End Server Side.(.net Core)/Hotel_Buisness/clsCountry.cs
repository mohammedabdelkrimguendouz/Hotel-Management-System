
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_DataAccess;

namespace Hotel_Buisness
{
    public class clsCountry
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
       
        public CountryDTO countryDTO
        {
            get { return new CountryDTO(this.ID, this.CountryName); }
        }

        private clsCountry(CountryDTO countryDTO)
        {
            this.ID = countryDTO.ID;
            this.CountryName = countryDTO.CountryName;
        }

        public static clsCountry Find(int ID)
        {
             
           CountryDTO countryDTO=clsCountryData.GetCountryInfoByID(ID);

            if (countryDTO!=null)

               return new clsCountry(countryDTO);
            else
                return null;

        }

        public static clsCountry Find(string CountryName)
        {
            CountryDTO countryDTO = clsCountryData.GetCountryInfoByName(CountryName);

            if (countryDTO != null)

                return new clsCountry(countryDTO);
            else
                return null;


        }

        static public List<CountryDTO> GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

    }
}
