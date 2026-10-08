using AprobacionPrestamos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobacionPrestamos.BLL.Manejadores
{
    public abstract class Aprobador
    {
        // Referencia al siguiente eslabón en la cadena
        protected Aprobador _siguienteAprobador;

        public void EstablecerSiguiente(Aprobador siguiente)
        {
            _siguienteAprobador = siguiente;
        }

        // Método que cada rol deberá implementar
        public abstract void ProcesarPrestamo(Prestamo prestamo);
    }
}
