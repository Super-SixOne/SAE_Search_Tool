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
        protected void SQLTest(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=.;database=Sample; integraded security=SSPI"); // data source=. = local server
            SqlCommand cmd = new SqlCommand("Select * from Yoink", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            con.Close();
        }      
    }
}

