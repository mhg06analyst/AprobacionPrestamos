using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobacionPrestamos.Domain
{
    public class Prestamo
    {
        public Cliente ClienteSolicitante { get; set; }
        public decimal Monto { get; set; }

        // Atributo booleano solicitado para confirmar la aprobación[cite: 46]
        public bool EstaAprobado { get; set; }

        // Guardaremos quién lo aprobó para mostrarlo por consola[cite: 46]
        public string AprobadoPor { get; set; }

        public Prestamo(Cliente cliente, decimal monto)
        {
            ClienteSolicitante = cliente;
            Monto = monto;
            EstaAprobado = false;
            AprobadoPor = "Pendiente";
        }
    }
}
