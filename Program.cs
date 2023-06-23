using System;
using System.Collections.Generic;

namespace ProyectoFinal_IntroPro
{
    internal static class Program
    {
        private static readonly List<Estudiante> Estudiantes = new List<Estudiante>();

        private static void Main()
        {
            while (true)
            {
                MostrarMenu();
                var opcion = LeerEnteroEntre(1, 5);

                switch (opcion)
                {
                    case 1:
                        RegistrarEstudiante();
                        break;
                    case 2:
                        AgregarCalificacion();
                        break;
                    case 3:
                        MostrarTodosLosDatos();
                        break;
                    case 4:
                        MostrarCalificacionesEnFilasYColumnas();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        return;
                }

                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("*******************");
            Console.WriteLine("CALCULADORA DE CALIFICACIONES");
            Console.WriteLine("*******************");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Agregar calificación");
            Console.WriteLine("3. Mostrar todos los datos");
            Console.WriteLine("4. Mostrar calificaciones en filas y columnas");
            Console.WriteLine("5. Salir del programa");
            Console.Write("Selecciona una opción (1-5): ");
        }

        private static int LeerEnteroEntre(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var numero) && numero >= min && numero <= max)
                {
                    return numero;
                }
                
                Console.Write("Entrada inválida. Introduce un número entre {0} y {1}: ", min, max);
            }
        }

        private static void RegistrarEstudiante()
        {
            Console.Clear();
            Console.Write("Nombre del estudiante: ");
            var nombre = Console.ReadLine();

            Estudiantes.Add(new Estudiante(nombre));
            Console.WriteLine("Estudiante registrado exitosamente.");
        }

        private static void AgregarCalificacion()
        {
            Console.Clear();
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
            Console.WriteLine("\nMaterias:");
            MostrarMaterias();

            Console.Write("Selecciona una materia (1-{0}): ", Materias.Count);
            var indiceMateria = LeerEnteroEntre(1, Materias.Count) - 1;

            var materiaSeleccionada = Materias[indiceMateria];

            Console.Write("Calificación: ");
            var calificacion = LeerDouble();

            estudianteSeleccionado.AgregarCalificacion(materiaSeleccionada, calificacion);
            Console.WriteLine("Calificación agregada exitosamente.");
        }

        private static void MostrarTodosLosDatos()
        {
            Console.Clear();
            if (Estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            foreach (var estudiante in Estudiantes)
            {
                Console.WriteLine("ESTUDIANTE: {0}\n", estudiante.Nombre);
                Console.WriteLine("Materia\t\tCalificación\t\tCondición");
                Console.WriteLine("-------------------------------------------------------");

                var promedios = estudiante.CalcularPromedioPorMateria();

                foreach (var kvp in promedios)
                {
                    var materia = kvp.Key;
                    var promedio = kvp.Value;
                    var condicion = ObtenerCondicion(promedio);

                    Console.WriteLine("{0}\t\t{1:0.00}\t\t\t{2}", materia, promedio, condicion);
                }

                Console.WriteLine();
            }
        }

        private static void MostrarCalificacionesEnFilasYColumnas()
        {
            Console.Clear();
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

            var calificacionesPorMateria = estudianteSeleccionado.ObtenerCalificacionesPorMateria();

            foreach (var kvp in calificacionesPorMateria)
            {
                var materia = kvp.Key;
                var calificaciones = kvp.Value;

                Console.WriteLine("\nMateria: {0}", materia);
                Console.WriteLine("Calificaciones:");

                foreach (var calificacion in calificaciones)
                {
                    Console.WriteLine(calificacion);
                }
            }
        }

        private static void MostrarNombresEstudiantes()
        {
            for (var i = 0; i < Estudiantes.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Estudiantes[i].Nombre);
            }
        }

        private static void MostrarMaterias()
        {
            for (var i = 0; i < Materias.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Materias[i]);
            }
        }

        private static double LeerDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out var numero))
                {
                    return numero;
                }

                Console.Write("Entrada inválida. Introduce un número válido: ");
            }
        }

        private static string ObtenerCondicion(double promedio)
        {
            if (promedio >= 90)
            {
                return "Excelente";
            }
            else if (promedio >= 80)
            {
                return "Bueno";
            }
            else if (promedio >= 70)
            {
                return "Regular";
            }
            else
            {
                return "Reprobado";
            }
        }

        private static readonly List<string> Materias = new List<string>
            { "Matemáticas", "Ciencias", "Historia", "Idiomas" };
    }
}