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
    public class ClienteDao: Conexion
    {
        public List<Cliente> getClientes(bool sincronizado)
        {
            using (connection = new SqlConnection(connectionStringCrm))
            {
                List<Cliente> listado = new List<Cliente>();

                query = "Select ClienteID, RazonSocial, Telefono, Calle, Altura, CondicionIvaID, Cuit, CondicionVentaID From Clientes Where Sincronizado = @Sincronizado";

                command = new SqlCommand(query, connection);

                SqlParameter paramSincronizado = new SqlParameter();
                paramSincronizado.ParameterName = "@Sincronizado";
                paramSincronizado.SqlDbType = SqlDbType.Bit;
                paramSincronizado.SqlValue = sincronizado;

                command.Parameters.Add(paramSincronizado);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cli = new Cliente();

                        CondicionIvaDao ivaDao = new CondicionIvaDao();
                        CondicionVentaDao vtaDao = new CondicionVentaDao();

                        cli.clienteId = Convert.ToInt32(reader["ClienteID"]);
                        cli.razonSocial = Convert.ToString(reader["RazonSocial"]);
                        if (reader["Telefono"] == DBNull.Value)
                        {
                            cli.telefono = "";
                        }
                        else
                        {
                            cli.telefono = Convert.ToString(reader["Telefono"]);
                        }
                        cli.calle = Convert.ToString(reader["Calle"]);
                        cli.altura = Convert.ToString(reader["Altura"]);
                        if (reader["Cuit"] == DBNull.Value)
                        {
                            cli.cuit = "";
                        }
                        else
                        {
                            cli.cuit = Convert.ToString(reader["Cuit"]);
                        }
                        cli.condicionIva = ivaDao.getCondicionIva(Convert.ToInt32(reader["CondicionIvaID"]));
                        cli.condicionVenta = vtaDao.getCondicionVenta(Convert.ToInt32(reader["CondicionVentaID"]));

                        listado.Add(cli);
                    }

                    return listado;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<string> getCodigosClienteCrm()
        {
            using (connection = new SqlConnection(connectionStringCrm))
            {
                List<string> listado = new List<string>();

                query = "Select ClienteID From Clientes";

                command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listado.Add(Convert.ToString(reader["ClienteID"]));
                    }

                    return listado;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void actualizarEstado(int clienteId, SqlTransaction sqlTransaction)
        {
            using (connection = new SqlConnection(connectionStringCrm))
            {
                query = "Update Clientes Set Sincronizado = 'true' Where ClienteID = @ClienteID";

                command = new SqlCommand(query, connection);

                SqlParameter paramClienteId = new SqlParameter();
                paramClienteId.ParameterName = "@ClienteID";
                paramClienteId.SqlDbType = SqlDbType.NVarChar;
                paramClienteId.SqlValue = clienteId;

                command.Parameters.Add(paramClienteId);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public void actualizarEstado(List<Cliente> clientes)
        {
            using (connection = new SqlConnection(connectionStringCrm))
            {
                query = "Update Clientes Set Sincronizado = @Sincronizado Where ClienteID = @ClienteID";

                SqlTransaction sqlTransaction;

                connection.Open();
                sqlTransaction = connection.BeginTransaction();

                command = new SqlCommand(query, connection);
                command.Transaction = sqlTransaction;

                command.Parameters.Add(new SqlParameter("ClienteID", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("Sincronizado", SqlDbType.Bit));

                try
                {
                    foreach (Cliente cli in clientes)
                    {
                        command.Parameters["ClienteID"].Value = cli.clienteId;
                        command.Parameters["Sincronizado"].Value = cli.sincronizado;

                        command.ExecuteNonQuery();
                    }

                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
