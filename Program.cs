using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal_IntroPro
{
    internal static class Program
    {
        private static void Main()
        {
            var salir = false;

            while (!salir)
            {
                Menu();

                var opcion = ReadIntegerBetween(1, 7);

                switch (opcion)
                {
                    case 1:
                        //AgregarEstudiantes();
                        break;
                    case 2:
                        //CalcularPromedioGeneral();
                        break;
                    case 3:
                        //CalcularPromedioPorEstudiante();
                        break;
                    case 4:
                        //MostrarEstudiantes();
                        break;
                    case 5:
                        //ExportarDatos();
                        break;
                    case 6:
                        //ImportarDatos();
                        break;
                    case 7:
                        salir = true;
                        Console.WriteLine("\nGracias por usar el sistema de gestión de estudiantes.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void Menu()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Bienvenido al sistema de gestión de estudiantes");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("1. Agregar estudiantes al sistema");
            Console.WriteLine("2. Calcular promedio general");
            Console.WriteLine("3. Calcular promedio por estudiante");
            Console.WriteLine("4. Mostrar todos los estudiantes");
            Console.WriteLine("5. Exportar los datos (EXPERIMENTAL)");
            Console.WriteLine("6. Importar los datos (EXPERIMENTAL)");
            Console.WriteLine("7. Salir del sistema");
            Console.Write("\nPor favor, ingrese una opción: ");
        }

        private static int ReadIntegerBetween(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var number) && number >= min && number <= max)
                {
                    return number;
                }

                Console.Write("Por favor, ingrese un número entre {0} y {1}: ", min, max);
            }
        }
    }
}