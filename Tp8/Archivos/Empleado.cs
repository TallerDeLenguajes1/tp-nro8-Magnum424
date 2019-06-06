using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Empleado
    {
        ////Enumeraciones
        public enum Cargos { Auxiliar, Administrativo, Ingeniero, Especialista, Investigador }
        public enum EstadoCivil { Solterx, Casadx, Viudx, Complicado }
        public enum Género { Masculino, Femenino }
        ////Datos de los empleados
        public string nombre;
        private string apellido;
        private DateTime fechaNac;
        private EstadoCivil estadoCivil;
        private Género género;
        private DateTime fechaIng;
        private double sueldoBasico;
        private Cargos cargo;
        ////Constructor de la estructura
        public Empleado(string nombre, string apellido, DateTime fechaNac, EstadoCivil estadoCivil, Género género, DateTime fechaIng, double sueldoBasico, Cargos cargo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNac = fechaNac;
            this.estadoCivil = estadoCivil;
            this.género = género;
            this.fechaIng = fechaIng;
            this.sueldoBasico = sueldoBasico;
            this.cargo = cargo;
        }
        ////Metodos par mostrar los datos de los empleados
        ///Una forma de mostrar los empleados(Toma un empleado en especifico)
        //public void MostrarEmpleados(DatosEmpleado Empleado)
        //{
        //    Console.WriteLine(Empleado.nombre);
        //    Console.WriteLine(Empleado.apellido);
        //    Console.WriteLine(Empleado.fechaNac.ToShortDateString());
        //    Console.WriteLine(Empleado.estadoCivil);
        //    Console.WriteLine(Empleado.género);
        //    Console.WriteLine(Empleado.fechaIng.ToShortDateString());
        //    Console.WriteLine(Empleado.sueldoBasico);
        //    Console.WriteLine(Empleado.cargo);
        //}
        ///Otra forma de mostrar los empleados(toma el empleado que está en la instancia actual)
        public void MostrarEmpleados2()
        {
            Console.WriteLine(this.nombre);
            Console.WriteLine(this.apellido);
            Console.WriteLine(this.fechaNac.ToShortDateString());
            Console.WriteLine(this.estadoCivil);
            Console.WriteLine(this.género);
            Console.WriteLine(this.fechaIng.ToShortDateString());
            Console.WriteLine(this.sueldoBasico);
            Console.WriteLine(this.cargo);
        }
        ////Calculo la edad
        public int CalculoEdad()
        {
            DateTime inicio = new DateTime(1, 1, 1);
            DateTime hoy = DateTime.Today;
            TimeSpan edad = (hoy - this.fechaNac);
            int años = (inicio + edad).Year;
            return años;
        }
        ////Calculo la antiguedad
        public int CalculoAntiguedad()
        {
            DateTime inicio = new DateTime(1, 1, 1);
            DateTime hoy = DateTime.Today;
            TimeSpan antiguedad = (hoy - this.fechaIng);
            int años = (inicio + antiguedad).Year;
            return años;
        }
        ////Años para jubilarse
        public void Jubilacion()
        {
            int jub;
            int edad = CalculoEdad();
            if (this.género == Género.Masculino)
            {
                jub = 65 - edad;
                Console.WriteLine("Los años que le quedan para jubilarse son: {0}", jub);
            }
            else
            {
                jub = 60 - edad;
                Console.WriteLine("Los años que le quedan para jubilarse son: {0}", jub);
            }
        }
        public double CalculoSalario()
        {
            double sal = this.sueldoBasico;
            double adi;
            Random rnd = new Random();
            int hijos = rnd.Next(0, 10);
            if (this.CalculoAntiguedad() < 20)
            {
                adi = sal + (this.sueldoBasico * 0.02) * this.CalculoAntiguedad();
            }
            else
            {
                adi = sal + (this.sueldoBasico * 0.25);
            }
            if (this.cargo == Cargos.Ingeniero || this.cargo == Cargos.Especialista)
            {
                adi = adi + (adi * 0.50);
            }
            if (this.estadoCivil == EstadoCivil.Casadx && hijos > 2)
            {
                adi = adi + 5000;
            }
            sal = sal + adi;
            return sal;
        }
        ////Archivo
        public void CargarArchivo(List<Empleado> lista, StreamWriter writer)
        {
            foreach (Empleado empleado in lista)
            {
                writer.Write($"{empleado.nombre};");
                writer.Write($"{empleado.apellido};");
                writer.Write($"{empleado.género};");
                writer.Write($"{empleado.fechaNac};");
                writer.Write($"{empleado.CalculoSalario()};\n");
            }
            writer.Close();
        }
    }
}
