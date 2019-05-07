using System;

namespace Domain
{
    [Serializable]
    public class Examen
    {

        public DateTime Fecha { get; set; }
        public decimal Nota { get; set; }
        public Materia Materia { get; set; }        
        public Profesor Profesor { get; set; }
        public Alumno Alumno { get; set; }

        public Examen(Materia _materia, System.DateTime _fecha, Profesor _profesor)
        {
            Materia = _materia;            
            Fecha = _fecha;
            Profesor = _profesor;
            Nota = 0;            
        }

    }
}