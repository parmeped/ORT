using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{   
    [Serializable]
    class Institucion
    {        
        public string Nombre { get; set; }
        public List<Materia> Materias { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<Profesor> Profesores { get; set; }
        public List<Examen> Examenes { get; set; }

        public Institucion (string _nombre)
        {
            Nombre = _nombre;
            Materias = new List<Materia>();
            Alumnos = new List<Alumno>();
            Profesores = new List<Profesor>();
            Examenes = new List<Examen>();
        }

        public Profesor inscribirProfesor(string _nombre, string _apellido, Legajo _legajo, int _dni)
        {
            Profesor _profesor = new Profesor(_nombre, _apellido, _legajo, _dni);
            _profesor.Institucion = this;
            Profesores.Add(_profesor);
            return _profesor;
        }

        public Alumno inscribirAlumno(string _nombre, string _apellido, Legajo _legajo, int _dni)
        {
            Alumno _alumno = new Alumno(_nombre, _apellido, _legajo, _dni);
            _alumno.Institucion = this;
            Alumnos.Add(_alumno);
            return _alumno;
        }

        public void listarProfesores()
        {
            foreach (Profesor _profesor in Profesores)
            {
                Console.WriteLine(_profesor.verDatos());
                List<Materia> _materias = _profesor.Materias;                
                if (!_materias.Any())
                {
                    Console.WriteLine("El profesor no tiene materias asignadas!");
                } 
                else
                {
                    foreach (Materia mat in _materias)
                    {
                        Console.WriteLine("La materia " + mat.Nombre + " se dicta en el aula " + mat.Aula.Ubicacion);
                    }
                }

            }
        }

        public void listarAlumnos()
        {
            foreach (Alumno _alumno in Alumnos)
            {
                _alumno.verDatos();
            }
        }
    }


}
