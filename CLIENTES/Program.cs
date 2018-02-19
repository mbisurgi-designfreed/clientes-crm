using CLIENTES.data;
using CLIENTES.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIENTES
{
    class Program
    {
        public Program()
        {

        }

        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WindowWidth = 150;

            program.Menu();
        }

        private void Menu()
        {
            int opcion;

            Console.WriteLine("SINCRONIZACION CLIENTES");
            Console.WriteLine("1 - SINCRONIZAR CLIENTES");
            Console.WriteLine("2 - ACTUALIZAR ESTADO CLIENTES");
            Console.WriteLine("3 - VER PORCENTAJE DE IIBB");
            opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                Console.WriteLine("\n");
                SincronizarClientes();
            }

            if (opcion == 2)
            {
                Console.WriteLine("\n");
                ActualizarEstadoClientes();
            }

            if (opcion == 3)
            {
                Console.WriteLine("\n");
                VerPorcentajeIIBB();
            }
        }

        private void SincronizarClientes()
        {
            Console.WriteLine("SINCRONIZAR CLIENTES TANGO-CRM\n");
            Console.WriteLine("Iniciando proceso...\n");

            try
            {
                Console.WriteLine("Clientes procesados:");

                ClienteDao clienteDao = new ClienteDao();
                ClienteTangoDao clienteTangoDao = new ClienteTangoDao();
                List<Cliente> clientes = clienteDao.getClientes(false);

                int proxNumeroInterno = clienteTangoDao.ObtenerUltimoNroInterno();
                int proxIdDireccionEntrega = clienteTangoDao.ObtenerUltimoIdDireccionEntrega();

                proxNumeroInterno++;
                proxIdDireccionEntrega++;

                foreach (Cliente cli in clientes)
                {
                    ClienteTango cliTgo = new ClienteTango();

                    cliTgo.COD_CLIENT = Convert.ToString(cli.clienteId);
                    cliTgo.COD_PROVIN = "01";
                    cliTgo.COD_ZONA = "1";
                    cliTgo.COND_VTA = ObtenerCondicionVenta(cli.condicionVenta);
                    cliTgo.CUIT = ObtenerCuit(cli);
                    cliTgo.DIR_COM = ObtenerDomicilio(cli);
                    cliTgo.DOMICILIO = cliTgo.DIR_COM;
                    cliTgo.FECHA_ALTA = DateTime.Now.Date;
                    cliTgo.II_D = "N";
                    cliTgo.II_L = "N";
                    cliTgo.IVA_D = ObtenerDiscriminaIva(cli.condicionIva);
                    cliTgo.IVA_L = "S";
                    cliTgo.NOM_COM = cli.razonSocial;
                    cliTgo.RAZON_SOCI = cliTgo.NOM_COM;
                    cliTgo.SOBRE_II = "N";
                    cliTgo.SOBRE_IVA = "N";
                    cliTgo.TELEFONO_1 = cli.telefono;
                    cliTgo.TIPO_DOC = ObtenerTipoDocumento(cli.condicionIva);
                    cliTgo.COD_GVA14 = cliTgo.COD_CLIENT;
                    cliTgo.ID_CATEGORIA_IVA = ObtenerCondicionIva(cli.condicionIva);
                    cliTgo.ID_GVA14 = Convert.ToInt32(proxNumeroInterno);
                    cliTgo.COD_GVA18 = cliTgo.COD_PROVIN;
                    cliTgo.COD_GVA05 = cliTgo.COD_ZONA;

                    Console.WriteLine("Codigo".PadRight(14, ' ') + "Razon Social".PadRight(50, ' ') + "Cuit".PadRight(14, ' '));
                    Console.WriteLine(cli.ToString());

                    clienteTangoDao.addClienteTango(cli.clienteId, cliTgo, proxIdDireccionEntrega);

                    proxNumeroInterno++;
                    proxIdDireccionEntrega++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            Console.WriteLine("\n\n");
            Menu();
        }

        private void ActualizarEstadoClientes()
        {
            Console.WriteLine("ACTUALIZAR ESTADO CLIENTES TANGO-CRM\n");
            Console.WriteLine("Iniciando proceso...\n");

            try
            {
                Console.WriteLine("Procesando clientes");

                ClienteDao clienteDao = new ClienteDao();
                ClienteTangoDao clienteTangoDao = new ClienteTangoDao();
                List<Cliente> clientesCrm = clienteDao.getClientes(false);
                List<string> clientesTango = clienteTangoDao.getCodigosClientesTango();

                foreach (Cliente cli in clientesCrm)
                {
                    if (clientesTango.Contains(Convert.ToString(cli.clienteId)))
                    {
                        cli.sincronizado = true;
                    }
                }

                clienteDao.actualizarEstado(clientesCrm);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            Console.WriteLine("\n\n");
            Menu();
        }

        private void VerPorcentajeIIBB()
        {
            Console.WriteLine("VER PORCENTAJE ALICUOTA DE IIBB\n");

            try
            {
                ClienteTangoDao clientaTangoDao = new ClienteTangoDao();

                Console.WriteLine("Cliente");
                string clienteId = Console.ReadLine();

                ClienteTango cliente = clientaTangoDao.ObtenerPorcentajeIIBB(clienteId);

                if (cliente != null)
                {
                    Console.WriteLine("Razon Social: " + cliente.RAZON_SOCI);
                    Console.WriteLine("Alicuota: " + cliente.PERCEPCION);
                }
                else
                {
                    Console.WriteLine("Codigo de cliente inexistente.");
                }
           
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            Console.WriteLine("\n\n");
            Menu();
        }

        private int ObtenerCondicionVenta(CondicionVenta condicionVenta)
        {
            int condicionVentaId = 0;

            if (condicionVenta.dias == 0)
            {
                condicionVentaId = 1;
            }

            if (condicionVenta.dias > 0)
            {
                condicionVentaId = 2;
            }

            return condicionVentaId;
        }

        private int ObtenerCondicionIva(CondicionIva condicionIva)
        {
            int condicionIvaId = 0;

            if (condicionIva.sigla.Trim().Equals("RI"))
            {
                condicionIvaId = 1;
            }

            if (condicionIva.sigla.Trim().Equals("CF"))
            {
                condicionIvaId = 2;
            }

            if (condicionIva.sigla.Trim().Equals("RS"))
            {
                condicionIvaId = 4;
            }

            if (condicionIva.sigla.Trim().Equals("EX"))
            {
                condicionIvaId = 5;
            }

            return condicionIvaId;
        }

        private string ObtenerDiscriminaIva(CondicionIva condicionIva)
        {
            string discrimina = "N";

            if (condicionIva.sigla.Trim().Equals("RI"))
            {
                discrimina = "S";
            }

            return discrimina;
        }

        private int ObtenerTipoDocumento(CondicionIva condicionIva)
        {
            int tipoDocumento = 0;

            if (condicionIva.sigla.Trim().Equals("RI") || condicionIva.sigla.Trim().Equals("RS") || condicionIva.sigla.Trim().Equals("EX"))
            {
                tipoDocumento = 80;
            }

            if (condicionIva.sigla.Trim().Equals("CF"))
            {
                tipoDocumento = 99;
            }

            return tipoDocumento;
        }

        private string ObtenerCuit(Cliente cliente)
        {
            string cuit = "";
            string resultado = "";

            if (cliente.condicionIva.sigla.Trim().Equals("RI") || cliente.condicionIva.sigla.Trim().Equals("RS"))
            {
                cuit = cliente.cuit;

                if (cuit.Length == 13)
                {
                    resultado = cuit;
                }

                if (cuit.Length == 11)
                {
                    string cuit1 = cuit.Substring(0, 2);
                    string cuit2 = cuit.Substring(2, 8);
                    string cuit3 = cuit.Substring(10, 1);

                    resultado = cuit1 + "-" + cuit2 + "-" + cuit3;
                }
            }

            return resultado;
        }

        private string ObtenerDomicilio(Cliente cliente)
        {
            string domicilio = cliente.altura + " " + cliente.calle;

            if (domicilio.Length > 30)
            {
                domicilio = domicilio.Remove(30);
            }

            return domicilio;
        }
    }
}
