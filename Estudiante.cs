using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal_IntroPro
{
    public class Estudiante
    {
        public string Nombre { get; private set; }
        private readonly Dictionary<string, List<double>> _calificacionesPorMateria;

        public Estudiante(string nombre)
        {
            Nombre = nombre;
            _calificacionesPorMateria = new Dictionary<string, List<double>>();
        }

        public void AgregarCalificacion(string materia, double calificacion)
        {
            if (_calificacionesPorMateria.TryGetValue(materia, out var value))
            {
                value.Add(calificacion);
            }
            else
            {
                _calificacionesPorMateria[materia] = new List<double> { calificacion };
            }
        }

        public Dictionary<string, List<double>> ObtenerCalificacionesPorMateria()
        {
            return _calificacionesPorMateria;
        }

        public Dictionary<string, double> CalcularPromedioPorMateria()
        {
            var promedios = new Dictionary<string, double>();

            foreach (var kvp in _calificacionesPorMateria)
            {
                var materia = kvp.Key;
                var calificaciones = kvp.Value;
                var promedio = calificaciones.Average();

                promedios[materia] = promedio;
            }

            return promedios;
        }
    }
}