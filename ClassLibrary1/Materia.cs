using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    [Serializable]
    public class Materia
    {
        public Aula Aula { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public Materia(Aula _aula, List<Alumno> _alumnos, int _codigo, string _nombre)
        {
            Aula = _aula;
            Alumnos = _alumnos;
            Codigo = _codigo;
            _aula.Materias.Add(this);
            Nombre = _nombre;
            foreach (Alumno _alumno in Alumnos)
            {                
                _alumno.inscribirMateria(this);             
            }
        }

        public void finalizarMateria()
        {
            foreach (Alumno _alumno in Alumnos)
            {
                _alumno.removerMateria(this);
            }
            Alumnos.Clear();
        }

        public string verMateria()
        {
            return "Nombre Materia: " + Nombre + "; Codigo Materia: " + Codigo + "; Aula Materia: " + Aula.Ubicacion;
        }

        public void listarAlumnos()
        {
            if(!Alumnos.Any())
            {
                Console.WriteLine("No hay alumnos enlistados en la materia!");
            }
            else
            {
                int cont = 1;
                foreach (Alumno _alumno in Alumnos)
                {
                    Console.WriteLine(cont + ". Alumno: " + _alumno.Nombre);
                    cont++;
                }
            }
        }

        public void listarPromedios()
        {
            if (!Alumnos.Any())
            {
                Console.WriteLine("No hay alumnos enlistados en la materia!");
            }
            else
            {
                int cont = 1;
                foreach (Alumno _alumno in Alumnos)
                {
                    Console.Write(cont + ". ");
                    _alumno.verDatos();
                    cont++;
                }
            }
        }
    }
}