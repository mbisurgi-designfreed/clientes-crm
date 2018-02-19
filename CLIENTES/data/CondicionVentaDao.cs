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
    public class CondicionVentaDao: Conexion
    {
        public CondicionVenta getCondicionVenta(int condicionVentaId)
        {
            using (connection = new SqlConnection(connectionStringCrm))
            {
                CondicionVenta con = new CondicionVenta();

                query = "Select CondicionVentaID, CondicionVentaNombre, Dias From CondicionesVenta Where CondicionVentaID = @CondicionVentaID";

                command = new SqlCommand(query, connection);

                SqlParameter paramCondicionVentaId = new SqlParameter();
                paramCondicionVentaId.ParameterName = "@CondicionVentaID";
                paramCondicionVentaId.SqlDbType = SqlDbType.Int;
                paramCondicionVentaId.SqlValue = condicionVentaId;

                command.Parameters.Add(paramCondicionVentaId);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        con.condicionVentaId = Convert.ToInt32(reader["CondicionVentaID"]);
                        con.condicionVentaNombre = Convert.ToString(reader["CondicionVentaNombre"]);
                        con.dias = Convert.ToInt32(reader["Dias"]);
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
