using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIENTES.model
{
    public class ClienteTango
    {
        //Codigo de cliente
        public string COD_CLIENT { get; set; }
        //Codigo de provincia
        public string COD_PROVIN { get; set; }
        //Codigo de zona
        public string COD_ZONA { get; set; }
        //Codigo de condicion de venta
        public int COND_VTA { get; set; }
        //Cuit (Formato 00-00000000-0)
        public string CUIT { get; set; }
        //Direccion comercial
        public string DIR_COM { get; set; }
        //Domicilio
        public string DOMICILIO { get; set; }
        //Fecha de alta
        public DateTime FECHA_ALTA { get; set; }
        //Discrimina impuestos internos (N)
        public string II_D { get; set; }
        //Liquida impuestos internos (N)
        public string II_L { get; set; }
        //Discrimina iva (N)
        public string IVA_D { get; set; }
        //Liquida iva (N)
        public string IVA_L { get; set; }
        //Nombre comercial
        public string NOM_COM { get; set; }
        //Razon social
        public string RAZON_SOCI { get; set; }
        //Percepcion impuestos internos (N)
        public string SOBRE_II { get; set; }
        //Percepcion iva (N)
        public string SOBRE_IVA { get; set; }
        //Telefono
        public string TELEFONO_1 { get; set; }
        //Tipo de documento (80 = CUIT, 96 = DNI, 99 = CF)
        public int TIPO_DOC { get; set; }
        //Codigo de cliente interno
        public string COD_GVA14 { get; set; }
        //Codigo de categoria de iva (1 = RI, 2 = CF, 3 = NR, 4 = RS, 5 = EX)
        public int ID_CATEGORIA_IVA { get; set; }
        //Codigo autonumerico de cliente
        public int ID_GVA14 { get; set; }
        //Codigo de provincia interno
        public string COD_GVA18 { get; set; }
        //Codigo de zona interno
        public string COD_GVA05 { get; set; }
        //Percepcion
        public double PERCEPCION { get; set; }
    }
}
