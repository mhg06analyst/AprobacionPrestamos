using AprobacionPrestamos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobacionPrestamos.BLL.Manejadores
{
    public class EjecutivoCuenta : Aprobador
    {
        public override void ProcesarPrestamo(Prestamo prestamo)
        {
            // Regla: Si el monto no supera los $100.000 lo aprueba el ejecutivo
            if (prestamo.Monto <= 100000)
            {
                prestamo.EstaAprobado = true;
                prestamo.AprobadoPor = "Ejecutivo de Cuenta";
            }
            else if (_siguienteAprobador != null)
            {
                // Si lo supera, se lo pasa al siguiente en la cadena
                _siguienteAprobador.ProcesarPrestamo(prestamo);
            }
        }
    }
}

