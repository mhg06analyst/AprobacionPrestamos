using AprobacionPrestamos.BLL.Manejadores;
using AprobacionPrestamos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobacionPrestamos.BLL
{
    public class PrestamoService
    {
        private Aprobador _cadenaAprobacion;

        public PrestamoService()
        {
            // 1. Instanciamos todos los roles
            Aprobador ejecutivo = new EjecutivoCuenta();
            Aprobador lider = new Lider();
            Aprobador gerente = new Gerente();
            Aprobador director = new Director();

            // 2. Configuramos el orden exacto de la cadena de responsabilidad
            ejecutivo.EstablecerSiguiente(lider);
            lider.EstablecerSiguiente(gerente);
            gerente.EstablecerSiguiente(director);

            // 3. Establecemos quién es el primer punto de contacto
            _cadenaAprobacion = ejecutivo;
        }

        // Método público que llamará la UI
        public void SolicitarAprobacion(Prestamo prestamo)
        {
            // Le pasamos el préstamo al primer eslabón, la cadena hace el resto
            _cadenaAprobacion.ProcesarPrestamo(prestamo);
        }
    }
}

