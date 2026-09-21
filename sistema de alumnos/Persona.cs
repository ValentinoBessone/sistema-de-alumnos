using System;

namespace sistema_de_alumnos
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int Documento { get; set; }

        public Persona(string nombre, int documento)
        {
            Nombre = nombre;
            Documento = documento;
        }
    }
}
