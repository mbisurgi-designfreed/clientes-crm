using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIENTES.model
{
    public class Cliente
    {
        public int clienteId { get; set; }
        public string razonSocial { get; set; }
        public string telefono { get; set; }
        public string calle { get; set; }
        public string altura { get; set; }
        public string cuit { get; set; }
        public CondicionIva condicionIva { get; set; }
        public CondicionVenta condicionVenta { get; set; }
        public bool sincronizado { get; set; }

        public override string ToString()
        {
            return Convert.ToString(clienteId).PadRight(14, ' ') + razonSocial.PadRight(50, ' ') + cuit.PadRight(14, ' ');
        }
    }
}
