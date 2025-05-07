using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DVLD_DataAccess;

namespace Hotel_DataAccess
{
    public class clsSettingData
    {
        public static float GetFoodPrice()
        {
            float FoodPrice = 0.0f;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetFoodPrice", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;


                        SqlParameter outputIdParam = new SqlParameter("@FoodPrice", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        FoodPrice = Convert.ToSingle(outputIdParam.Value);

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", System.Diagnostics.EventLogEntryType.Error);
                FoodPrice = 0.0f;
            }
            return FoodPrice;
        }
    }
}
