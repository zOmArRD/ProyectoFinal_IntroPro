using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal_IntroPro.student
{
    public class Student
    {
        public string Nombre { get; set; }
        public List<Subject> Materias { get; set; }

        public Student(string nombre)
        {
            Nombre = nombre;
            Materias = new List<Subject>();
        }

        public void AgregarCalificacion(string nombreMateria, int periodo, double calificacion)
        {
            var materia = Materias.FirstOrDefault(m => m.Nombre == nombreMateria);
            if (materia == null)
            {
                materia = new Subject(nombreMateria);
                Materias.Add(materia);
            }

            materia.AgregarCalificacion(periodo, calificacion);
        }

        public double CalcularPromedioGeneral()
        {
            var promedios = Materias.Select(m => m.CalcularPromedio());
            var enumerable = promedios.ToList();
            return enumerable.Any() ? enumerable.Average() : 0;
        }
    }
}