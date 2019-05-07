using System;

namespace Domain
{
    [Serializable]
    public class Legajo
    {
        public string Tipo { get; set; }
        public int Numero { get; set; }

        public Legajo (string _tipo, int _numero)
        {
            Tipo = _tipo;
            Numero = _numero;
        }

        public string verLegajo()
        {
            return Tipo + '-' + Numero; 
        }

    }
}