using System;
using System.Collections.Generic;

namespace Domain
{
    [Serializable]
    public class Alumno
    {
        public List<Examen> Examenes { get; set; }
        public List<Materia> Materias { get; set; }
        public Legajo Legajo { get; set; }
        public int Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public decimal Promedio { get; set; }
        public Examen Rindiendo { get; set; }
        public Institucion Institucion { get; set; }
        public String ApellidoNombre { get; set; }

        public Alumno (string _nombre, string _apellido, Legajo _legajo, int _dni)
        {
            Nombre = _nombre;
            Apellido = _apellido;
            Legajo = _legajo;
            Dni = _dni;            
            Promedio = 0;
            Examenes = new List<Examen>();
            Materias = new List<Materia>();
            ApellidoNombre = _apellido + " " + _nombre;
            Rindiendo = null;
        }

        public void inscribirMateria(Materia _materia)
        {
            Materias.Add(_materia);
        }

        public void rendirExamen(decimal _nota)
        {
            Console.WriteLine(Nombre + " está recibiendo su nota!");
            Rindiendo.Nota = _nota;
            Examenes.Add(Rindiendo);
            calcularPromedio();
            Rindiendo = null;
            if (_nota > 8)
            {
                Console.WriteLine(Nombre + " ha sido super efectivo!!");
            } 
            else if (_nota > 4)
            {
                Console.WriteLine(Nombre + " no ha sido muy efectivo...");
            }
            else
            {
                Console.WriteLine("A " + Nombre + " le han destrozado el upíte..");
            }
        }

        public void recibirExamen(Examen _examen)
        {
            Console.WriteLine(Nombre + " ha recibido un examen y se prepara para rendirlo!");
            Rindiendo = _examen;
        }        

        public decimal promedioEnFechas(System.DateTime desde, System.DateTime hasta)
        {
            decimal notas      = 0;
            int cantExamenes = 0;

            foreach (Examen _examen in Examenes)
            {
                if (_examen.Fecha > desde && _examen.Fecha < hasta)
                {
                    notas += _examen.Nota;
                    cantExamenes++;
                }                
            }
            if (cantExamenes > 0)
            {
                return notas / cantExamenes;
            }
            else
            {
                return 0;
            }
        }
        
        public void calcularPromedio()
        {
            decimal notas      = 0;
            int cantExamenes = 0;

            foreach (Examen _examen in Examenes)
            {
                notas += _examen.Nota;
                cantExamenes++;
            }
            if (cantExamenes > 0)
            {
                Promedio = Math.Round(notas / cantExamenes,2);
            }           
        }

        public void removerMateria(Materia _materia)
        {
            Materias.Remove(_materia);
        }

        public void mostrarMaterias()
        {
            int count = 1;
            foreach (Materia _materia in Materias)
            {
                Console.WriteLine(count + ": " + _materia.verMateria());
                count++;
            }
        }
        
        public void verDatos()
        {
            Console.WriteLine("Nombre Alumno: " + Nombre + "; Apellido: " + Apellido + "; Dni: " + Dni + "; Legajo: " + Legajo.verLegajo() + "; Promedio: " + Promedio);
            verExamenes();
        }

        public void verExamenes()
        {
            foreach (Examen ex in Examenes)
            {
                Console.WriteLine("Datos Examen ::: Fecha: " + ex.Fecha + ". Materia: " + ex.Materia.Nombre + ". Nota: " + ex.Nota);
            }
        }        
    }
}
