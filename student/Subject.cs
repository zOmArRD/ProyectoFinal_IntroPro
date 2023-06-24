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
using System.Linq;

namespace ProyectoFinal_IntroPro.student
{
    public class Subject
    {
        public string Nombre { get; set; }
        public Dictionary<int, List<double>> Calificaciones { get; set; }

        public static readonly List<string> MateriasPredeterminadas =
            new List<string> { "Matemáticas", "Español", "Química" };

        public Subject(string nombre)
        {
            Nombre = nombre;
            Calificaciones = new Dictionary<int, List<double>>();
        }

        public void AgregarCalificacion(int periodo, double calificacion)
        {
            if (Calificaciones.ContainsKey(periodo))
            {
                Calificaciones[periodo].Add(calificacion);
            }
            else
            {
                Calificaciones[periodo] = new List<double> { calificacion };
            }
        }

        public void MostrarCalificaciones()
        {
            foreach (var periodo in Calificaciones)
            {
                Console.WriteLine("Período {0}: {1}", periodo.Key, string.Join(", ", periodo.Value));
            }
        }

        public double CalcularPromedio()
        {
            var promediosPeriodos = Calificaciones.Values.Select(CalcularPromedioPeriodo);
            var enumerable = promediosPeriodos.ToList();
            return enumerable.Any() ? enumerable.Average() : 0;
        }

        private double CalcularPromedioPeriodo(List<double> calificaciones)
        {
            return calificaciones.Any() ? calificaciones.Average() : 0;
        }

        /**
         * Calcula la condición de la materia.
         */
        public string CalcularCondicion()
        {
            var promedio = CalcularPromedio();
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
    }
}