using System;

namespace sistema_de_alumnos
{
    public class Profesor : Persona
    {
        public string Materia { get; set; }

        public Profesor(string nombre, int documento, string materia) : base(nombre, documento)
        {
            Materia = materia;
        }

        public override string ToString()
        {
            return "Prof. " + Nombre + " - Materia: " + Materia + " (Doc: " + Documento + ")";
        }
    }
}