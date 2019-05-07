using System.Collections.Generic;

namespace Test
{
    class Aula
    {
        private List<Materia> materias;
        private string ubicacion;

        public Aula (string _ubicacion)
        {            
            Ubicacion = _ubicacion;
            materias = new List<Materia>();
        }

        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public List<Materia> Materias { get => materias; set => materias = value; }
    }
}