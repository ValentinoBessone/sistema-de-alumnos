using System;
using System.Collections.Generic;
using sistema_de_alumnos;

List<Alumno> listaAlumnos = new List<Alumno>();
int opcion = 0;

do
{
    Console.WriteLine("\n--- MENÚ SISTEMA DE ALUMNOS ---");
    Console.WriteLine("1. Agregar un alumno");
    Console.WriteLine("2. Listar todos los alumnos");
    Console.WriteLine("3. Buscar un alumno por legajo");
    Console.WriteLine("4. Mostrar el promedio general del curso");
    Console.WriteLine("5. Mostrar cuántos alumnos están aprobados");
    Console.WriteLine("6. Salir");
    Console.Write("Elija una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Por favor, ingrese un número válido.");
        continue;
    }

    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese documento: ");
            int documento = int.Parse(Console.ReadLine());

            Console.Write("Ingrese legajo: ");
            int legajo = int.Parse(Console.ReadLine());

            Alumno nuevoAlumno = new Alumno(nombre, documento, legajo);

            Console.Write("Ingrese Nota 1 (0 a 10): ");
            double n1 = double.Parse(Console.ReadLine());

            Console.Write("Ingrese Nota 2 (0 a 10): ");
            double n2 = double.Parse(Console.ReadLine());

            if (nuevoAlumno.CargarNotas(n1, n2))
            {
                listaAlumnos.Add(nuevoAlumno);
                Console.WriteLine("¡Alumno agregado con éxito!");
            }
            else
            {
                Console.WriteLine("Error: Notas inválidas. El alumno no fue guardado.");
            }
            break;

        case 2:
            if (listaAlumnos.Count == 0)
            {
                Console.WriteLine("No hay alumnos cargados.");
            }
            else
            {
                Console.WriteLine("\n--- LISTA DE ALUMNOS ---");
                foreach (var a in listaAlumnos)
                {
                    Console.WriteLine(a); // Usa el ToString()
                }
            }
            break;

        case 3:
            Console.Write("Ingrese el legajo a buscar: ");
            int legajoBuscar = int.Parse(Console.ReadLine());
            Alumno encontrado = null;

            foreach (var a in listaAlumnos)
            {
                if (a.Legajo == legajoBuscar)
                {
                    encontrado = a;
                    break;
                }
            }

            if (encontrado != null)
            {
                Console.WriteLine("Alumno encontrado: " + encontrado);
            }
            else
            {
                Console.WriteLine("El alumno con legajo " + legajoBuscar + " no existe.");
            }
            break;

        case 4:
            if (listaAlumnos.Count == 0)
            {
                Console.WriteLine("No hay alumnos para calcular el promedio general.");
            }
            else
            {
                double sumaPromedios = 0;
                foreach (var a in listaAlumnos)
                {
                    sumaPromedios += a.Promedio();
                }
                double promedioGeneral = sumaPromedios / listaAlumnos.Count;
                Console.WriteLine("El promedio general del curso es: " + promedioGeneral);
            }
            break;

        case 5:
            int aprobados = 0;
            foreach (var a in listaAlumnos)
            {
                if (a.EstaAprobado())
                {
                    aprobados++;
                }
            }
            Console.WriteLine("Cantidad de alumnos aprobados: " + aprobados);
            break;

        case 6:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción inexistente. Intente de nuevo.");
            break;
    }

} while (opcion != 6);

// Prueba de Polimorfismo
List<Persona> personasPrueba = new List<Persona>();
personasPrueba.Add(new Alumno("Ana Pérez", 40000000, 1234));
personasPrueba.Add(new Profesor("Marta Díaz", 20000000, "Programación"));

foreach (Persona p in personasPrueba)
{
    Console.WriteLine(p.Presentarse());
}