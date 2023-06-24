/*
 * Created by Rider
 *
 * User: zOmArRD
 * Date: 23/6/2023
 *
 * Copyright © 2023 <dev@zomarrd.me> - All Rights Reserved.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProyectoFinal_IntroPro.student;

namespace ProyectoFinal_IntroPro
{
    internal static class Program
    {
        private static List<Student> _students = new List<Student>();

        private static void Main()
        {
            var salir = false;

            while (!salir)
            {
                Menu();

                var opcion = ReadIntegerBetween(1, 7);

                switch (opcion)
                {
                    case 1: // Agregar estudiantes al sistema
                        AgregarEstudiantes();
                        break;
                    case 2: // Calcular promedio general
                        CalcularPromedioGeneral();
                        break;
                    case 3: // Calcular promedio por estudiante
                        CalcularPromedioPorEstudiante();
                        break;
                    case 4: // Mostrar todos los estudiantes
                        MostrarEstudiantes();
                        break;
                    case 5: // Exportar los datos (EXPERIMENTAL)
                        ExportData();
                        break;
                    case 6: // Importar los datos (EXPERIMENTAL)
                        ImportData();
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
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Bienvenido al sistema de gestión de estudiantes");
            Console.WriteLine("-----------------------------------------------");

            Console.ResetColor();

            Console.WriteLine("1. Agregar estudiantes al sistema");
            Console.WriteLine("2. Calcular promedio general");
            Console.WriteLine("3. Calcular promedio por estudiante");
            Console.WriteLine("4. Mostrar todos los estudiantes");
            Console.WriteLine("5. Exportar los datos (EXPERIMENTAL)");
            Console.WriteLine("6. Importar los datos (EXPERIMENTAL)");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("7. Salir del sistema");

            Console.ResetColor();

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

        private static void AgregarEstudiantes()
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            var nombre = Console.ReadLine();

            var student = new Student(nombre);
            foreach (var materia in Subject.MateriasPredeterminadas)
            {
                Console.Clear();
                Console.WriteLine("\nIngresar calificaciones para la materia: " + materia);

                for (var i = 1; i <= 4; i++)
                {
                    Console.Write("Calificación para el periodo {0}: ", i);
                    var calificacion = ReadDoubleBetween(0, 100);
                    student.AgregarCalificacion(materia, i, calificacion);
                }
            }

            _students.Add(student);
            Console.WriteLine("\nEstudiante agregado correctamente.");
        }

        private static double ReadDoubleBetween(double min, double max)
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out var number) && number >= min && number <= max)
                {
                    return number;
                }

                Console.Write("Por favor, ingrese un número entre {0} y {1}: ", min, max);
            }
        }

        private static void CalcularPromedioGeneral()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados en el sistema.");
                return;
            }

            Console.Clear();
            Console.WriteLine("\nPromedio General:");

            foreach (var student in _students)
            {
                Console.WriteLine("\n");
                Console.WriteLine("-------------------------");
                Console.WriteLine("\nEstudiante: " + student.Nombre);
                Console.WriteLine("-------------------------");
                foreach (var materia in student.Materias)
                {
                    var promedioMateria = materia.CalcularPromedio();
                    var condicionMateria = materia.CalcularCondicion();

                    Console.WriteLine("Materia: " + materia.Nombre);
                    Console.WriteLine("Promedio: " + promedioMateria);
                    Console.WriteLine("Condición: " + condicionMateria);
                    Console.WriteLine();
                }

                var promedioGeneral = student.CalcularPromedioGeneral();
                Console.WriteLine("Promedio General: " + promedioGeneral);
            }
        }

        private static void CalcularPromedioPorEstudiante()
        {
            Console.Clear();
            if (_students.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados en el sistema.");
                return;
            }

            Console.WriteLine("Estudiantes registrados en el sistema:");
            MostrarNombresEstudiantes();

            Console.Write("Selecciona un estudiante (1-{0}): ", _students.Count);
            var indiceEstudiante = ReadIntegerBetween(1, _students.Count) - 1;

            var student = _students[indiceEstudiante];

            Console.WriteLine("\nEstudiante: " + student.Nombre);
            Console.WriteLine("-------------------------");

            foreach (var materia in student.Materias)
            {
                Console.WriteLine("Materia: " + materia.Nombre);
                materia.MostrarCalificaciones();
                Console.WriteLine("Promedio: " + materia.CalcularPromedio());
                Console.WriteLine("Condición: " + materia.CalcularCondicion());
                Console.WriteLine();
            }

            Console.WriteLine("Promedio General: " + student.CalcularPromedioGeneral());
        }

        public static void MostrarNombresEstudiantes()
        {
            for (var i = 0; i < _students.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, _students[i].Nombre);
            }
        }

        private static void MostrarEstudiantes()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados en el sistema.");
                return;
            }

            Console.WriteLine("\nListado de Estudiantes:");

            foreach (var student in _students)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Estudiante: " + student.Nombre);
                Console.WriteLine();

                foreach (var materia in student.Materias)
                {
                    Console.WriteLine("Materia: " + materia.Nombre);
                    materia.MostrarCalificaciones();
                    Console.WriteLine("Promedio: " + materia.CalcularPromedio());
                    Console.WriteLine("Condición: " + materia.CalcularCondicion());
                    Console.WriteLine();
                }

                Console.WriteLine("Promedio General: " + student.CalcularPromedioGeneral());
                Console.WriteLine("-------------------------");
            }

            var promedioGeneral = _students.Average(student => student.CalcularPromedioGeneral());
            Console.WriteLine("\nPromedio General de todos los estudiantes: " + promedioGeneral);
        }

        private static string GetExportFilePath()
        {
            Console.Write("Ingrese el nombre del archivo de exportación: ");
            var fileName = Console.ReadLine();
            return fileName + ".json";
        }

        private static void ExportData()
        {
            var filePath = GetExportFilePath();

            try
            {
                using (var file = File.CreateText(filePath))
                {
                    var serializer = new JsonSerializer
                    {
                        Formatting = Formatting.Indented
                    };
                    serializer.Serialize(file, _students);
                }

                Console.WriteLine("Datos exportados correctamente en el archivo: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al exportar los datos: " + ex.Message);
            }
        }

        private static void ImportData()
        {
            Console.Write("Ingrese el nombre del archivo de importación: ");
            var filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("El archivo especificado no existe.");
                return;
            }

            try
            {
                var json = File.ReadAllText(filePath);
                _students = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
                Console.WriteLine("Datos importados correctamente desde el archivo: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al importar los datos: " + ex.Message);
            }
        }
    }
}