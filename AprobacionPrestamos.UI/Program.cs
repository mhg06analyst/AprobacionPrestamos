using System;
using AprobacionPrestamos.BLL;
using AprobacionPrestamos.Domain;

namespace AprobacionPrestamos.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE APROBACIÓN DE PRÉSTAMOS (Chain of Responsibility) ===\n");

            // Instanciamos nuestro servicio que ya tiene la cadena configurada
            PrestamoService servicio = new PrestamoService();

            // Bucle infinito para cargar préstamos a mano hasta que escribas "salir"
            while (true)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.Write("Ingrese el nombre del cliente (o escriba 'salir' para terminar): ");
                string nombreCliente = Console.ReadLine();

                // Condición de salida
                if (nombreCliente.ToLower() == "salir")
                {
                    break;
                }

                Console.Write("Ingrese el monto del préstamo solicitado: $");
                string entradaMonto = Console.ReadLine();

                // Validamos que lo ingresado sea un número decimal válido
                if (decimal.TryParse(entradaMonto, out decimal monto))
                {
                    Console.WriteLine(); // Salto de línea estético

                    // Procesamos el préstamo con los datos ingresados a mano
                    ProcesarYMostrar(servicio, nombreCliente, monto);
                }
                else
                {
                    Console.WriteLine("\n[ERROR] El monto ingresado no es válido. Solo ingrese números.\n");
                }
            }

            Console.WriteLine("\nSaliendo del sistema... Presione cualquier tecla.");
            Console.ReadKey();
        }

        // Método auxiliar intacto para procesar y mostrar resultados
        static void ProcesarYMostrar(PrestamoService servicio, string nombreCliente, decimal monto)
        {
            // Creamos las entidades
            Cliente cliente = new Cliente { Nombre = nombreCliente };
            Prestamo prestamo = new Prestamo(cliente, monto);

            Console.WriteLine($"Solicitud de {cliente.Nombre} por un monto de ${monto:N2}");

            // Mandamos el préstamo al primer eslabón de la cadena
            servicio.SolicitarAprobacion(prestamo);

            // Mostramos por consola quién aprobó el crédito
            if (prestamo.EstaAprobado)
            {
                Console.WriteLine($"-> ESTADO: APROBADO por {prestamo.AprobadoPor}\n");
            }
            else
            {
                Console.WriteLine($"-> ESTADO: RECHAZADO\n");
            }
        }
    }
}