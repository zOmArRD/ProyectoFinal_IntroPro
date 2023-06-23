using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal_IntroPro
{
    public class Estudiante
    {
        public string Nombre { get; }
        private readonly Dictionary<string, double> _calificaciones;

        public Estudiante(string nombre)
        {
            Nombre = nombre;
            _calificaciones = new Dictionary<string, double>();
        }

        public void AgregarCalificacion(string materia, double calificacion)
        {
            _calificaciones.Add(materia, calificacion);
        }

        public double CalcularPromedio()
        {
            if (_calificaciones.Count == 0)
            {
                return 0;
            }

            var sumaCalificaciones = _calificaciones.Values.Sum();

            return sumaCalificaciones / _calificaciones.Count;
        }

        public void MostrarDatos()
        {
            foreach (var kvp in _calificaciones)
            {
                Console.WriteLine("Materia: {0}\tCalificación: {1}", kvp.Key, kvp.Value);
            }
        }

        public void MostrarCalificaciones()
        {
            Console.WriteLine("Materia\t\tCalificación");
            Console.WriteLine("------------------------");

            foreach (var kvp in _calificaciones)
            {
                Console.WriteLine("{0}\t\t{1}", kvp.Key, kvp.Value);
            }
        }
    }
}