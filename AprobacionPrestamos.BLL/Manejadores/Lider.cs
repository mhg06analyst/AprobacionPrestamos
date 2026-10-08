using AprobacionPrestamos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobacionPrestamos.BLL.Manejadores
{
    public class Lider : Aprobador
    {
        public override void ProcesarPrestamo(Prestamo prestamo)
        {
            // Regla: Entre $100.000 y $500.000 lo aprueba el líder[cite: 46]
            if (prestamo.Monto > 100000 && prestamo.Monto <= 500000)
            {
                prestamo.EstaAprobado = true;
                prestamo.AprobadoPor = "Líder Inmediato";
            }
            else if (_siguienteAprobador != null)
            {
                _siguienteAprobador.ProcesarPrestamo(prestamo);
            }
        }
    }
}
