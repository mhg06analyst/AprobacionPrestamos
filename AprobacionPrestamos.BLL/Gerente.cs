using AprobacionPrestamos.BLL.Manejadores;
using AprobacionPrestamos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobacionPrestamos.BLL
{
    public class Gerente : Aprobador
    {
        public override void ProcesarPrestamo(Prestamo prestamo)
        {
            // Regla: Entre $500.000 y $1.000.000 lo aprueba el gerente[cite: 46]
            if (prestamo.Monto > 500000 && prestamo.Monto <= 1000000)
            {
                prestamo.EstaAprobado = true;
                prestamo.AprobadoPor = "Gerente";
            }
            else if (_siguienteAprobador != null)
            {
                _siguienteAprobador.ProcesarPrestamo(prestamo);
            }
        }
    }
}
