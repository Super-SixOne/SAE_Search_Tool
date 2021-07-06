using SAE_Search_Tool_Client.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SAE_Search_Tool_Client.Models.DataAccess
{
    /// <summary>
    /// Class that provides functionality to access a database.
    /// </summary>
    
    class DbAccess
    {
        public bool IsConnected { get; private set; }
        public bool Connect(object sender, EventArgs e)
        {
            bool success = false;
            try
            {
                SqlConnection con = new SqlConnection("data source=.;database=Sample; integraded security=SSPI"); // data source=. = local server
                con.Open();
                IsConnected = true;
            }
            catch (Exception)
            {
                IsConnected = false;
            }

            return success;
        }
        /// SqlDataReader rdr = cmd.ExecuteReader();
            
        void FindOneWordOnDb(object sender, EventArgs e)
        {


        }

        public List<DataFromDB> SingleWordSearch()
        {
            string sql = string.Format("select Id, Path, Text from TABLE where to_tsvector(Text) @@ to_tsquery('{0}'); ",SearchWord);
            List<DataFromDB> ltemp = new List<DataFromDB>();

            try
            {
                DataTable t = sql.ExecuteReader();

                foreach (DataRow r in t.Rows)
                {
                    DataFromDB k = new DataFromDB();
                    k.IdData = long.Parse(r["idData"]?.ToString());
                    k.Path = r["Path"]?.ToString();
                    k.Text = r["Text"]?.ToString();

                    ltemp.Add(k);
                }
            }
            catch (Exception ex)
            {
                if (ErrorMessage != null)
                    ErrorMessage("Fehler in GetKFZList: " + ex.Message);
            }

            return ltemp;
        }
    }
}

