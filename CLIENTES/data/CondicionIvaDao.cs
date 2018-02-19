using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CLIENTES.model;

namespace CLIENTES.data
{
    public class CondicionIvaDao: Conexion
    {
        public CondicionIva getCondicionIva(int condicionIvaId)
        {
            using (connection = new SqlConnection(connectionStringCrm))
            {
                CondicionIva con = new CondicionIva();

                query = "Select CondicionIvaID, CondicionIvaNombre, Sigla From CondicionesIva Where CondicionIvaID = @CondicionIvaID";

                command = new SqlCommand(query, connection);

                SqlParameter paramCondicionIvaId = new SqlParameter();
                paramCondicionIvaId.ParameterName = "@CondicionIvaID";
                paramCondicionIvaId.SqlDbType = SqlDbType.Int;
                paramCondicionIvaId.SqlValue = condicionIvaId;

                command.Parameters.Add(paramCondicionIvaId);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        con.condicionIvaId = Convert.ToInt32(reader["CondicionIvaID"]);
                        con.condicionIvaNombre = Convert.ToString(reader["CondicionIvaNombre"]);
                        con.sigla = Convert.ToString(reader["Sigla"]);
                    }
                    else
                    {
                        con = null;
                    }

                    return con;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
