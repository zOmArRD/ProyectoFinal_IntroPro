using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal_IntroPro
{
    internal class Program
    {
        private static readonly List<Estudiante> Estudiantes = new List<Estudiante>();

        private static void Main(string[] args)
        {
            var salir = false;

            while (!salir)
            {
                Console.Clear();
                MostrarMenu();

                var opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        CalcularPromedioGeneral();
                        break;
                    case "2":
                        CalcularPromedioPorEstudiante();
                        break;
                    case "3":
                        MostrarTodosLosDatos();
                        break;
                    case "4":
                        MostrarCondicionCalificaciones();
                        break;
                    case "5":
                        MostrarCalificacionesEnFilasYColumnas();
                        break;
                    case "6":
                        AgregarEstudiante();
                        break;
                    case "7":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, elige una opción válida del menú.");
                        break;
                }

                Console.WriteLine("\nPulsa cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("*******************");
            Console.WriteLine("CALCULADORA DE CALIFICACIONES");
            Console.WriteLine("*******************");
            Console.WriteLine("1. Calcular promedio general");
            Console.WriteLine("2. Calcular promedio por estudiante");
            Console.WriteLine("3. Mostrar todos los datos");
            Console.WriteLine("4. Mostrar condición de calificaciones con el promedio general");
            Console.WriteLine("5. Mostrar todas las calificaciones con los nombres de los estudiantes");
            Console.WriteLine("6. Agregar estudiante");
            Console.WriteLine("7. Salir");
            Console.Write("\nElige una opción: ");
        }

        private static double CalcularPromedioGeneral()
        {
            if (Estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return 0;
            }

            var sumaCalificaciones = Estudiantes.Sum(estudiante => estudiante.CalcularPromedio());

            var promedioGeneral = sumaCalificaciones / Estudiantes.Count;

            Console.WriteLine("Promedio general: " + promedioGeneral.ToString("0.00"));

            return promedioGeneral;
        }

        private static void CalcularPromedioPorEstudiante()
        {
            if (Estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            Console.WriteLine("Estudiantes:");
            MostrarNombresEstudiantes();

            Console.Write("Selecciona un estudiante (1-{0}): ", Estudiantes.Count);
            var indiceEstudiante = LeerEnteroEntre(1, Estudiantes.Count) - 1;

            var estudianteSeleccionado = Estudiantes[indiceEstudiante];
            var promedioEstudiante = estudianteSeleccionado.CalcularPromedio();

            Console.WriteLine("\nPromedio del estudiante {0}: {1:0.00}", estudianteSeleccionado.Nombre,
                promedioEstudiante);
        }

        private static void MostrarTodosLosDatos()
        {
            if (Estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            Console.WriteLine("Estudiantes:");
            MostrarNombresEstudiantes();

            Console.Write("Selecciona un estudiante (1-{0}): ", Estudiantes.Count);
            var indiceEstudiante = LeerEnteroEntre(1, Estudiantes.Count) - 1;

            var estudianteSeleccionado = Estudiantes[indiceEstudiante];
            Console.WriteLine("\nDatos del estudiante {0}:", estudianteSeleccionado.Nombre);
            estudianteSeleccionado.MostrarDatos();
        }

        private static void MostrarCondicionCalificaciones()
        {
            if (Estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            Console.WriteLine("Estudiantes:");
            MostrarNombresEstudiantes();

            Console.Write("Selecciona un estudiante (1-{0}): ", Estudiantes.Count);
            var indiceEstudiante = LeerEnteroEntre(1, Estudiantes.Count) - 1;

            var estudianteSeleccionado = Estudiantes[indiceEstudiante];
            var promedioGeneral = CalcularPromedioGeneral();

            Console.WriteLine("\nCondición de calificaciones para el estudiante {0}:", estudianteSeleccionado.Nombre);

            Console.WriteLine(
                estudianteSeleccionado.CalcularPromedio() >= promedioGeneral
                    ? "El estudiante {0} tiene un promedio por encima del promedio general."
                    : "El estudiante {0} tiene un promedio por debajo del promedio general.",
                estudianteSeleccionado.Nombre);
        }

        private static void MostrarCalificacionesEnFilasYColumnas()
        {
            if (Estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            Console.WriteLine("Estudiantes:");
            MostrarNombresEstudiantes();

            Console.Write("Selecciona un estudiante (1-{0}): ", Estudiantes.Count);
            var indiceEstudiante = LeerEnteroEntre(1, Estudiantes.Count) - 1;

            var estudianteSeleccionado = Estudiantes[indiceEstudiante];
            Console.WriteLine("\nCalificaciones del estudiante {0}:", estudianteSeleccionado.Nombre);
            estudianteSeleccionado.MostrarCalificaciones();
        }

        private static void AgregarEstudiante()
        {
            Console.Write("Ingrese el número de estudiantes a agregar: ");
            var numeroEstudiantes = LeerEnteroPositivo();

            for (var i = 0; i < numeroEstudiantes; i++)
            {
                Console.WriteLine("\nEstudiante {0}:", i + 1);
                Console.Write("Nombre: ");
                var nombre = Console.ReadLine();

                var estudiante = new Estudiante(nombre);

                Console.Write("Ingrese el número de materias: ");
                var numeroMaterias = LeerEnteroPositivo();

                for (var j = 0; j < numeroMaterias; j++)
                {
                    Console.WriteLine("\nMateria {0}:", j + 1);
                    Console.Write("Nombre de la materia: ");
                    var nombreMateria = Console.ReadLine();

                    Console.Write("Calificación: ");
                    var calificacion = LeerDoubleEntre(0, 100);

                    estudiante.AgregarCalificacion(nombreMateria, calificacion);
                }

                Estudiantes.Add(estudiante);
            }

            Console.WriteLine("\nEstudiantes agregados correctamente.");
        }

        private static void MostrarNombresEstudiantes()
        {
            for (var i = 0; i < Estudiantes.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Estudiantes[i].Nombre);
            }
        }

        private static int LeerEnteroEntre(int min, int max)
        {
            int numero;

            while (!int.TryParse(Console.ReadLine(), out numero) || numero < min || numero > max)
            {
                Console.Write("Entrada inválida. Ingrese un número entre {0} y {1}: ", min, max);
            }

            return numero;
        }

        private static int LeerEnteroPositivo()
        {
            int numero;

            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0)
            {
                Console.Write("Entrada inválida. Ingrese un número entero positivo: ");
            }

            return numero;
        }

        private static double LeerDoubleEntre(double min, double max)
        {
            double numero;

            while (!double.TryParse(Console.ReadLine(), out numero) || numero < min || numero > max)
            {
                Console.Write("Entrada inválida. Ingrese un número entre {0} y {1}: ", min, max);
            }

            return numero;
        }
    }
}