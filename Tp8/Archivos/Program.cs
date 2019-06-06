using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Declaro la variable de nuevo empleado
            Empleado NuevoEmpleado;

            ////Creo variables auxiliares
            int dia, mes, año;
            Empleado.EstadoCivil Est;
            Empleado.Género Gen;
            Empleado.Cargos Car;
            int cont = 0;
            double total = 0;

            ////Arrays con datos requeridos
            string[] Apellidos = new string[] { "Pérez", "Gomez", "Abduzcan" };
            string[] NombresMasc = new string[] { "Juan", "Jorge", "Pedro" };
            string[] NombresFem = new string[] { "Ana", "María", "Juana" };

            ////Creo el objeto aleatorio
            Random rdn = new Random();

            ////Creo la lista de empleados
            List<Empleado> ListaDeEmpleados = new List<Empleado>();

            ////Datos para la carga
            for (int i = 0; i < 20; i++)
            {
                ////Tomo 3 numeros aleatorios para la fecha de nacimiento
                dia = rdn.Next(1, 31);
                mes = rdn.Next(1, 13);
                año = rdn.Next(1970, 1990);

                ////Creo una variable DateTime a la cual le inserto los valores obtenidos
                DateTime FechaNac = new DateTime(año, mes, dia);

                ////Repito el proceso para la fecha de ingreso
                dia = rdn.Next(1, 31);
                mes = rdn.Next(1, 13);
                año = rdn.Next(2000, 2020);

                ////Fecha de ingreso
                DateTime FechaIng = new DateTime(año, mes, dia);

                ////Defino el Estado civil, el genero y el cargo
                Est = (Empleado.EstadoCivil)rdn.Next(0, 4);
                Gen = (Empleado.Género)rdn.Next(0, 2);
                Car = (Empleado.Cargos)rdn.Next(0, 5);

                ////Dependiendo si es Hombre o Mujer se le asigna un nombre apropiado
                if (Gen == Empleado.Género.Masculino)
                {
                    NuevoEmpleado = new Empleado(NombresMasc[rdn.Next(0, 3)], Apellidos[rdn.Next(0, 3)], FechaNac, Est, Gen, FechaIng, rdn.Next(10000, 20000), Car);
                }
                else
                {
                    NuevoEmpleado = new Empleado(NombresFem[rdn.Next(0, 3)], Apellidos[rdn.Next(0, 3)], FechaNac, Est, Gen, FechaIng, rdn.Next(10000, 20000), Car);
                }

                ////Agrego al nuevo empleado a la lista
                ListaDeEmpleados.Add(NuevoEmpleado);
            }
            ////Muestro los empleados en la lista
            foreach (Empleado empleado in ListaDeEmpleados)
            {
                empleado.MostrarEmpleados2();
                Console.Write("\n");
                Console.WriteLine("La edad es: {0}", empleado.CalculoEdad());
                Console.Write("\n");
                Console.WriteLine("La antiguedad es: {0}", empleado.CalculoAntiguedad());
                Console.Write("\n");
                empleado.Jubilacion();
                Console.Write("\n");
                Console.WriteLine("El salario del empleado es: ${0}", empleado.CalculoSalario());
                Console.Write("\n");
                total = total + empleado.CalculoSalario();
                Console.ReadKey();
                cont = cont + 1;
            }
            Console.Write("\n");
            Console.WriteLine("La empresa tiene {0} empleados.", cont);
            Console.Write("\n");
            Console.WriteLine("La empresa gasta ${0} en salarios.", total);
            Console.ReadKey();

            ////Creo un archivo .csv
            string path = @"DatosEmpleados.csv";
            StreamWriter writer = new StreamWriter(path);
            ////Escribo en el archivo los campos a llenar
            writer.Write("Nombre;");
            writer.Write("Apellido;");
            writer.Write("Género;");
            writer.Write("Fecha de nacimiento;");
            writer.Write("Salario;");
            ////Escribo en el archivo los datos de los empleados
           

        }
    }
}
