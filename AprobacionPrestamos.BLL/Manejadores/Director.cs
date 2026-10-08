using AprobacionPrestamos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobacionPrestamos.BLL.Manejadores
{
    public class Director : Aprobador
    {
        public override void ProcesarPrestamo(Prestamo prestamo)
        {
            // Regla: Superiores a $1.000.000 lo aprueba el director[cite: 46]
            if (prestamo.Monto > 1000000)
            {
                prestamo.EstaAprobado = true;
                prestamo.AprobadoPor = "Director";
            }
            // Como es el último eslabón, no hay un else llamando a un _siguienteAprobador.
        }
    }
}
