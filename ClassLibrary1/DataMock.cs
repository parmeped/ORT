using System;
using System.Collections.Generic;
using System.Text;

        
namespace Domain
{
    [Serializable]
    public static class DataMock
    {
        public static List<Alumno> Alumnos { get; set; }
        public static IEnumerable<Profesor> Profesores { get; private set; }
        public static IEnumerable<Materia> Materias { get; private set; }
        public static Institucion ORT { get; private set; }
        public static IEnumerable<Examen> Examenes { get; private set; }

        public static void Init()
        {
            ORT = new Institucion("ORT");

            Legajo b1 = new Legajo("P", 300);
            Legajo b2 = new Legajo("P", 400);
            Legajo b3 = new Legajo("P", 500);
            Legajo b4 = new Legajo("P", 600);
            Legajo b5 = new Legajo("P", 700);
            Legajo a1 = new Legajo("A", 1500);
            Legajo a2 = new Legajo("A", 4560);
            Legajo a3 = new Legajo("A", 2345);
            Legajo a4 = new Legajo("A", 43);
            Legajo a5 = new Legajo("A", 8905);

            Alumno al1 = ORT.inscribirAlumno("Juancito", "Perez", a1, 3525652);
            Alumno al2 = ORT.inscribirAlumno("Pepe", "tutu", a2, 35465134);
            Alumno al3 = ORT.inscribirAlumno("Loci", "Joci", a3, 45672434);
            Alumno al4 = ORT.inscribirAlumno("Cracinto", "Chein", a4, 43567234);
            Alumno al5 = ORT.inscribirAlumno("Mercedes", "Lopez", a5, 34562356);
            

            Profesor p1 = ORT.inscribirProfesor("Marcela", "Coiner", b1, 45562356);
            Profesor p2 = ORT.inscribirProfesor("Perito", "Jackuer", b2, 84134545);
            Profesor p3 = ORT.inscribirProfesor("Courni", "Cuerjt", b3, 1234567);
            Profesor p4 = ORT.inscribirProfesor("Retkea", "Neurot", b4, 46724);
            Profesor p5 = ORT.inscribirProfesor("Sarea", "Lemih", b5, 45645);
            

            Aula au1 = new Aula("001");
            Aula au2 = new Aula("002");

            List<Alumno> alus1 = new List<Alumno>();
            alus1.Add(al1);
            alus1.Add(al2);
            alus1.Add(al3);

            List<Alumno> alus2 = new List<Alumno>();
            alus2.Add(al3);
            alus2.Add(al5);
            alus2.Add(al2);
            alus2.Add(al4);

            List<Alumno> alus3 = new List<Alumno>();
            alus3.Add(al2);
            alus3.Add(al4);
            alus3.Add(al1);

            Materia m1 = new Materia(au1, alus1, 1, "Matematicas");            
            Materia m2 = new Materia(au2, alus2, 2, "Química");
            Materia m3 = new Materia(au1, alus3, 3, "Youtubers");

            p1.asignarMateria(m1);
            p2.asignarMateria(m2);
            p3.asignarMateria(m3);
            p4.asignarMateria(m1);
            p5.asignarMateria(m2);
            p1.asignarMateria(m2);

            p1.generarExamen(m1);
            p1.retirarExamenes();

            p2.generarExamen(m2);
            p2.retirarExamenes();

            p3.generarExamen(m3);
            p3.retirarExamenes();


            Materias = new[] { m1, m2, m3 };
            Profesores = ORT.Profesores;
            Alumnos = ORT.Alumnos;
        }

        public static void Add(Alumno al)
        {
            Alumnos.Add(al);
        }

        public static void GenerarExamen(Profesor profesor, Materia materia)
        {
            profesor.generarExamen(materia);
        }
    }
}
