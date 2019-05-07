using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Test
{
    class Profesor
    {
        #region attributes
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public Legajo Legajo { get; set; }
        public List<Materia> Materias { get; set; }
        public List<Examen> Examenes { get; set; }
        public List<Alumno> Rindiendo { get; set; }
        public Institucion Institucion { get; set; }

        #endregion

        public Profesor(string _nombre, string _apellido, Legajo _legajo, int _dni)
        {
            Nombre = _nombre;
            Apellido = _apellido;
            Legajo = _legajo;
            Dni = _dni;            
            Materias = new List<Materia>();
            Examenes = new List<Examen>();
            Rindiendo = new List<Alumno>();
        }

        public void asignarMateria(Materia _materia)
        {
            Materias.Add(_materia);
        }

        public void generarExamen(Materia _materia)
        {
            Console.WriteLine(Nombre + " está repartiendo examenes");

            int times = 3;
            while (times > 0)
            {
                Thread.Sleep(500);
                Console.Write(".");
                times--;
            }

            Console.WriteLine("");

            DateTime _fecha = DateTime.Today;
            foreach (Alumno al in _materia.Alumnos)
            {
                Console.WriteLine("---------");
                Examen _examen = new Examen(_materia, _fecha, this);
                _examen.Alumno = al;
                al.recibirExamen(_examen);
                Examenes.Add(_examen);
                Rindiendo.Add(al);
            }            
        }
        
        public void retirarExamenes()
        {
            Console.WriteLine(Nombre + " está pensando las notas");

            int times = 3;
            while (times > 0)
            {
                Thread.Sleep(500);
                Console.Write(".");
                times--;
            }
            Console.WriteLine("");

            foreach (Alumno al in Rindiendo)
            {
                System.Random r = new System.Random();
                al.rendirExamen((decimal)r.NextDouble() * 10);                
            }
            Rindiendo.Clear();
        }
        
        public void finalizarCursada(Materia _materia)
        {
            Console.WriteLine("El profesor " + Nombre + " está finalizando la cursada de la materia " + _materia.Nombre);
            _materia.finalizarMateria();
        }

        public string verDatos()
        {
            return "Nombre Profesor: " + Nombre + "; Apellido: " + Apellido + "; Dni: " + Dni + "; Legajo: " + Legajo.verLegajo();
        }        
    }    
}