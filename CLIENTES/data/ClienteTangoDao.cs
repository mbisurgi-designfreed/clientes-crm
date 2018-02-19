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
    public class ClienteTangoDao: Conexion
    {
        public List<string> getCodigosClientesTango()
        {
            using (connection = new SqlConnection(connectionStringTango))
            {
                List<string> listado = new List<string>();

                query = "Select COD_CLIENT From GVA14";

                command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listado.Add(Convert.ToString(reader["COD_CLIENT"]));
                    }

                    return listado;
                }
                catch (Exception ex)
                {  
                    throw ex;
                }
            }
        }
        
        public void addClienteTango(int clienteId, ClienteTango clienteTango, int idDireccionEntrega)
        {
            using (connection = new SqlConnection(connectionStringTango))
            {
                query = "Insert Into GVA14(COD_CLIENT, COD_PROVIN, COD_ZONA, COND_VTA, CUIT, DIR_COM, DOMICILIO, FECHA_ALTA, II_D, II_L, IVA_D, IVA_L, NOM_COM, RAZON_SOCI, SOBRE_II, SOBRE_IVA, TELEFONO_1, TIPO_DOC, COD_GVA14, ID_CATEGORIA_IVA, ID_GVA14, COD_GVA18, COD_GVA05) Values(@COD_CLIENT, @COD_PROVIN, @COD_ZONA, @COND_VTA, @CUIT, @DIR_COM, @DOMICILIO, @FECHA_ALTA, @II_D, @II_L, @IVA_D, @IVA_L, @NOM_COM, @RAZON_SOCI, @SOBRE_II, @SOBRE_IVA, @TELEFONO_1, @TIPO_DOC, @COD_GVA14, @ID_CATEGORIA_IVA, @ID_GVA14, @COD_GVA18, @COD_GVA05)";

                SqlTransaction sqlTransaction;

                connection.Open();
                sqlTransaction = connection.BeginTransaction();

                command = new SqlCommand(query, connection);
                command.Transaction = sqlTransaction;

                SqlParameter paramCOD_CLIENT = new SqlParameter();
                paramCOD_CLIENT.ParameterName = "@COD_CLIENT";
                paramCOD_CLIENT.SqlDbType = SqlDbType.NVarChar;
                paramCOD_CLIENT.Size = 50;
                paramCOD_CLIENT.SqlValue = clienteTango.COD_CLIENT;

                command.Parameters.Add(paramCOD_CLIENT);

                SqlParameter paramCOD_PROVIN = new SqlParameter();
                paramCOD_PROVIN.ParameterName = "@COD_PROVIN";
                paramCOD_PROVIN.SqlDbType = SqlDbType.NVarChar;
                paramCOD_PROVIN.Size = 50;
                paramCOD_PROVIN.SqlValue = clienteTango.COD_PROVIN;

                command.Parameters.Add(paramCOD_PROVIN);

                SqlParameter paramCOD_ZONA = new SqlParameter();
                paramCOD_ZONA.ParameterName = "@COD_ZONA";
                paramCOD_ZONA.SqlDbType = SqlDbType.NVarChar;
                paramCOD_ZONA.Size = 50;
                paramCOD_ZONA.SqlValue = clienteTango.COD_ZONA;

                command.Parameters.Add(paramCOD_ZONA);

                SqlParameter paramCOND_VTA = new SqlParameter();
                paramCOND_VTA.ParameterName = "@COND_VTA";
                paramCOND_VTA.SqlDbType = SqlDbType.Int;
                paramCOND_VTA.SqlValue = clienteTango.COND_VTA;

                command.Parameters.Add(paramCOND_VTA);

                SqlParameter paramCUIT = new SqlParameter();
                paramCUIT.ParameterName = "@CUIT";
                paramCUIT.SqlDbType = SqlDbType.NVarChar;
                paramCUIT.Size = 50;
                paramCUIT.SqlValue = clienteTango.CUIT;

                command.Parameters.Add(paramCUIT);

                SqlParameter paramDIR_COM = new SqlParameter();
                paramDIR_COM.ParameterName = "@DIR_COM";
                paramDIR_COM.SqlDbType = SqlDbType.NVarChar;
                paramDIR_COM.Size = 50;
                paramDIR_COM.SqlValue = clienteTango.DIR_COM;

                command.Parameters.Add(paramDIR_COM);

                SqlParameter paramDOMICILIO = new SqlParameter();
                paramDOMICILIO.ParameterName = "@DOMICILIO";
                paramDOMICILIO.SqlDbType = SqlDbType.NVarChar;
                paramDOMICILIO.Size = 50;
                paramDOMICILIO.SqlValue = clienteTango.DOMICILIO;

                command.Parameters.Add(paramDOMICILIO);

                SqlParameter paramFECHA_ALTA = new SqlParameter();
                paramFECHA_ALTA.ParameterName = "@FECHA_ALTA";
                paramFECHA_ALTA.SqlDbType = SqlDbType.DateTime;
                paramFECHA_ALTA.SqlValue = clienteTango.FECHA_ALTA;

                command.Parameters.Add(paramFECHA_ALTA);

                SqlParameter paramII_D = new SqlParameter();
                paramII_D.ParameterName = "@II_D";
                paramII_D.SqlDbType = SqlDbType.NVarChar;
                paramII_D.Size = 50;
                paramII_D.SqlValue = clienteTango.II_D;

                command.Parameters.Add(paramII_D);

                SqlParameter paramII_L = new SqlParameter();
                paramII_L.ParameterName = "@II_L";
                paramII_L.SqlDbType = SqlDbType.NVarChar;
                paramII_L.Size = 50;
                paramII_L.SqlValue = clienteTango.II_L;

                command.Parameters.Add(paramII_L);

                SqlParameter paramIVA_D = new SqlParameter();
                paramIVA_D.ParameterName = "@IVA_D";
                paramIVA_D.SqlDbType = SqlDbType.NVarChar;
                paramIVA_D.Size = 50;
                paramIVA_D.SqlValue = clienteTango.IVA_D;

                command.Parameters.Add(paramIVA_D);

                SqlParameter paramIVA_L = new SqlParameter();
                paramIVA_L.ParameterName = "@IVA_L";
                paramIVA_L.SqlDbType = SqlDbType.NVarChar;
                paramIVA_L.Size = 50;
                paramIVA_L.SqlValue = clienteTango.IVA_L;

                command.Parameters.Add(paramIVA_L);

                SqlParameter paramNOM_COM = new SqlParameter();
                paramNOM_COM.ParameterName = "@NOM_COM";
                paramNOM_COM.SqlDbType = SqlDbType.NVarChar;
                paramNOM_COM.Size = 50;
                paramNOM_COM.SqlValue = clienteTango.NOM_COM;

                command.Parameters.Add(paramNOM_COM);

                SqlParameter paramRAZON_SOCI = new SqlParameter();
                paramRAZON_SOCI.ParameterName = "@RAZON_SOCI";
                paramRAZON_SOCI.SqlDbType = SqlDbType.NVarChar;
                paramRAZON_SOCI.Size = 50;
                paramRAZON_SOCI.SqlValue = clienteTango.RAZON_SOCI;

                command.Parameters.Add(paramRAZON_SOCI);

                SqlParameter paramSOBRE_II = new SqlParameter();
                paramSOBRE_II.ParameterName = "@SOBRE_II";
                paramSOBRE_II.SqlDbType = SqlDbType.NVarChar;
                paramSOBRE_II.Size = 50;
                paramSOBRE_II.SqlValue = clienteTango.SOBRE_II;

                command.Parameters.Add(paramSOBRE_II);

                SqlParameter paramSOBRE_IVA = new SqlParameter();
                paramSOBRE_IVA.ParameterName = "@SOBRE_IVA";
                paramSOBRE_IVA.SqlDbType = SqlDbType.NVarChar;
                paramSOBRE_IVA.Size = 50;
                paramSOBRE_IVA.SqlValue = clienteTango.SOBRE_IVA;

                command.Parameters.Add(paramSOBRE_IVA);

                SqlParameter paramTELEFONO_1 = new SqlParameter();
                paramTELEFONO_1.ParameterName = "@TELEFONO_1";
                paramTELEFONO_1.SqlDbType = SqlDbType.NVarChar;
                paramTELEFONO_1.Size = 50;
                paramTELEFONO_1.SqlValue = clienteTango.TELEFONO_1;

                command.Parameters.Add(paramTELEFONO_1);

                SqlParameter paramTIPO_DOC = new SqlParameter();
                paramTIPO_DOC.ParameterName = "@TIPO_DOC";
                paramTIPO_DOC.SqlDbType = SqlDbType.Int;
                paramTIPO_DOC.SqlValue = clienteTango.TIPO_DOC;

                command.Parameters.Add(paramTIPO_DOC);

                SqlParameter paramCOD_GVA14 = new SqlParameter();
                paramCOD_GVA14.ParameterName = "@COD_GVA14";
                paramCOD_GVA14.SqlDbType = SqlDbType.NVarChar;
                paramCOD_GVA14.Size = 50;
                paramCOD_GVA14.SqlValue = clienteTango.COD_GVA14;

                command.Parameters.Add(paramCOD_GVA14);

                SqlParameter paramID_CATEGORIA_IVA = new SqlParameter();
                paramID_CATEGORIA_IVA.ParameterName = "@ID_CATEGORIA_IVA";
                paramID_CATEGORIA_IVA.SqlDbType = SqlDbType.Int;
                paramID_CATEGORIA_IVA.SqlValue = clienteTango.ID_CATEGORIA_IVA;

                command.Parameters.Add(paramID_CATEGORIA_IVA);

                SqlParameter paramID_GVA14 = new SqlParameter();
                paramID_GVA14.ParameterName = "@ID_GVA14";
                paramID_GVA14.SqlDbType = SqlDbType.Int;
                paramID_GVA14.SqlValue = clienteTango.ID_GVA14;

                command.Parameters.Add(paramID_GVA14);

                SqlParameter paramCOD_GVA18 = new SqlParameter();
                paramCOD_GVA18.ParameterName = "@COD_GVA18";
                paramCOD_GVA18.SqlDbType = SqlDbType.NVarChar;
                paramCOD_GVA18.Size = 50;
                paramCOD_GVA18.SqlValue = clienteTango.COD_GVA18;

                command.Parameters.Add(paramCOD_GVA18);

                SqlParameter paramCOD_GVA05 = new SqlParameter();
                paramCOD_GVA05.ParameterName = "@COD_GVA05";
                paramCOD_GVA05.SqlDbType = SqlDbType.NVarChar;
                paramCOD_GVA05.Size = 50;
                paramCOD_GVA05.SqlValue = clienteTango.COD_GVA05;

                command.Parameters.Add(paramCOD_GVA05);

                try
                {
                    command.ExecuteNonQuery();

                    AddDireccionClienteTango(clienteTango, connection, sqlTransaction, idDireccionEntrega);

                    ClienteDao clienteDao = new ClienteDao();
                    clienteDao.actualizarEstado(clienteId, sqlTransaction);

                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public void AddDireccionClienteTango(ClienteTango clienteTango, SqlConnection sqlConnection, SqlTransaction sqlTransaction, int idDireccionEntrega)
        {
            query = "Insert Into DIRECCION_ENTREGA(ID_DIRECCION_ENTREGA, COD_DIRECCION_ENTREGA, COD_CLIENTE, DIRECCION, COD_PROVINCIA, HABITUAL, TELEFONO1, HABILITADO) Values(@ID_DIRECCION_ENTREGA, @COD_DIRECCION_ENTREGA, @COD_CLIENTE, @DIRECCION, @COD_PROVINCIA, @HABITUAL, @TELEFONO1, @HABILITADO)";

            command = new SqlCommand(query, connection);
            command.Transaction = sqlTransaction;

            command.Parameters.Add(new SqlParameter("ID_DIRECCION_ENTREGA", SqlDbType.Int));
            command.Parameters.Add(new SqlParameter("COD_DIRECCION_ENTREGA", SqlDbType.NVarChar));
            command.Parameters.Add(new SqlParameter("COD_CLIENTE", SqlDbType.NVarChar));
            command.Parameters.Add(new SqlParameter("DIRECCION", SqlDbType.NVarChar));
            command.Parameters.Add(new SqlParameter("COD_PROVINCIA", SqlDbType.NVarChar));
            command.Parameters.Add(new SqlParameter("HABITUAL", SqlDbType.NVarChar));
            command.Parameters.Add(new SqlParameter("TELEFONO1", SqlDbType.NVarChar));
            command.Parameters.Add(new SqlParameter("HABILITADO", SqlDbType.NVarChar));

            try
            {
                command.Parameters["ID_DIRECCION_ENTREGA"].Value = idDireccionEntrega;
                command.Parameters["COD_DIRECCION_ENTREGA"].Value = "PRINCIPAL";
                command.Parameters["COD_CLIENTE"].Value = clienteTango.COD_CLIENT;
                command.Parameters["DIRECCION"].Value = clienteTango.DOMICILIO;
                command.Parameters["COD_PROVINCIA"].Value = clienteTango.COD_PROVIN;
                command.Parameters["HABITUAL"].Value = "S";
                command.Parameters["TELEFONO1"].Value = clienteTango.TELEFONO_1;
                command.Parameters["HABILITADO"].Value = "S";

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw ex;
            }  
        }

        public int ObtenerUltimoNroInterno()
        {
            using (connection = new SqlConnection(connectionStringTango))
            {
                query = "Select Top 1 ID_GVA14 From GVA14 Order By ID_GVA14 Desc";

                command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["ID_GVA14"]);
                    }

                    return 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int ObtenerUltimoIdDireccionEntrega()
        {
            using (connection = new SqlConnection(connectionStringTango))
            {
                query = "Select Top 1 ID_DIRECCION_ENTREGA From DIRECCION_ENTREGA Order By ID_DIRECCION_ENTREGA Desc";

                command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["ID_DIRECCION_ENTREGA"]);
                    }

                    return 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ClienteTango ObtenerPorcentajeIIBB(string clienteId)
        {
            using (connection = new SqlConnection(connectionStringTango))
            {
                ClienteTango cliente = new ClienteTango();

                query = "Select ali.PORCENTAJE, cli.RAZON_SOCI From DIRECCION_ENTREGA dir Inner Join GVA41 ali On ali.COD_ALICUO = dir.ALI_FIJ_IB Inner Join GVA14 cli On cli.COD_GVA14 = dir.COD_CLIENTE Where dir.COD_CLIENTE = @COD_CLIENTE";

                command = new SqlCommand(query, connection);

                SqlParameter paramCOD_CLIENTE = new SqlParameter();
                paramCOD_CLIENTE.ParameterName = "@COD_CLIENTE";
                paramCOD_CLIENTE.SqlDbType = SqlDbType.NVarChar;
                paramCOD_CLIENTE.Size = 50;
                paramCOD_CLIENTE.SqlValue = clienteId;

                command.Parameters.Add(paramCOD_CLIENTE);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        cliente.PERCEPCION = Convert.ToDouble(reader["PORCENTAJE"]);
                        cliente.RAZON_SOCI = Convert.ToString(reader["RAZON_SOCI"]);
                    }

                    return cliente;
                }
                catch (Exception ex)
                {  
                    throw ex;
                }
            }
        }
    }
}
