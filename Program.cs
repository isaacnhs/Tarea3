/* Tarea # 3 */

using System;
class Program
{
    static void Main(string[] args)
    {
        const int max_empleados = 100; 
        int cantidadEmpleados = 0; 
        int[] cedulas = new int[max_empleados];
        string[] nombres = new string[max_empleados];
        string[] tipos = new string[max_empleados];
        int[] salariosHora = new int[max_empleados];
        int[] cantidadesHoras = new int[max_empleados];
        float[] salariosNetos = new float[max_empleados];

        double porcAumento = 0.0;
        float salarioNeto = 0;

        int cantidadOperarios = 0;
        float acumuladoSalarioNetoOperarios = 0;
        int cantidadTecnicos = 0;
        float acumuladoSalarioNetoTecnicos = 0;
        int cantidadProfesionales = 0;
        float acumuladoSalarioNetoProfesionales = 0;

        bool seguirRegistrando = true;

        while (seguirRegistrando)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***Cálculo de planillas***");
            Console.WriteLine("");
            Console.WriteLine("1- Operario");
            Console.WriteLine("2- Técnico");
            Console.WriteLine("3- Profesional");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("¿Qué tipo de empleado desea seleccionar?: ");
            Console.WriteLine("");
            int opcion = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Digite el número de cédula del empleado: ");
            Console.WriteLine("");
            int cedula = int.Parse(Console.ReadLine());
            cedulas[cantidadEmpleados] = cedula;

            Console.WriteLine("");
            Console.WriteLine("Digite el nombre del empleado: ");
            Console.WriteLine("");
            string nombreEmpleado = Console.ReadLine();
            nombres[cantidadEmpleados] = nombreEmpleado;
            Console.WriteLine("");

            Console.WriteLine("Digite la cantidad de horas laboradas del empleado: ");
            Console.WriteLine("");
            int cantidadHoras = int.Parse(Console.ReadLine());
            cantidadesHoras[cantidadEmpleados] = cantidadHoras;
            Console.WriteLine("");

            Console.WriteLine("Digite el salario por hora del empleado: ");
            Console.WriteLine("");
            int salarioHora = int.Parse(Console.ReadLine());
            salariosHora[cantidadEmpleados] = salarioHora;
            Console.WriteLine("");

            switch (opcion)
            {
                case 1:
                    porcAumento = 0.15;
                    tipos[cantidadEmpleados] = "Operario";
                    cantidadOperarios++;
                    acumuladoSalarioNetoOperarios += salarioNeto;
                    break;
                case 2:
                    porcAumento = 0.10;
                    tipos[cantidadEmpleados] = "Técnico";
                    cantidadTecnicos++;
                    acumuladoSalarioNetoTecnicos += salarioNeto;
                    break;
                case 3:
                    porcAumento = 0.05;
                    tipos[cantidadEmpleados] = "Profesional";
                    cantidadProfesionales++;
                    acumuladoSalarioNetoProfesionales += salarioNeto;
                    break;
            }

            salariosNetos[cantidadEmpleados] = salarioNeto;

            for (int i = 0; i < cantidadEmpleados; i++)
            {
                Console.WriteLine($"El número de cédula del empleado es: .........{cedulas[i]}");
                Console.WriteLine("El nombre del empleado es: ...................{nombres[i]}");
                Console.WriteLine("El tipo de empleado es: ......................{0}", tipos[i]);
                Console.WriteLine("La cantidad de horas trabajadas son: .........{0}", cantidadesHoras[i]);
                Console.WriteLine("El salario por hora trabajada es: ............" + salariosHora[i] + " colones");
                Console.WriteLine("El salario ordinario es: ....................." + (cantidadesHoras[i] * salariosHora[i]) + " colones");
                Console.WriteLine("El aumento salarial es de: ..................." + ((cantidadesHoras[i] * salariosHora[i]) * porcAumento) + " colones");
                Console.WriteLine("El salario bruto es: ........................." + (cantidadesHoras[i] * salariosHora[i]) + " colones");
                Console.WriteLine("El porcentaje de deducción de la CCSS es del: " + 0.0917f * 100 + " %");
                Console.WriteLine("La deducción de la CCSS es de: ..............." + (0.0917f * (cantidadesHoras[i] * salariosHora[i])) + " colones");
                Console.WriteLine("El salario neto es de: ......................." + salariosNetos[i] + " colones");
            }

            Console.WriteLine("");
            Console.WriteLine("¿Desea registrar otro empleado? (Si / No): ");
            Console.WriteLine("");
            string respuesta = Console.ReadLine();
            seguirRegistrando = (respuesta.ToLower() == "si" || respuesta.ToLower() == "s");

            cantidadEmpleados++;
        }

        Console.WriteLine("");
        Console.WriteLine("Estadísticas:");
        Console.WriteLine("");
        Console.WriteLine("1) Cantidad Empleados Tipo Operarios: ............" + cantidadOperarios);
        Console.WriteLine("2) Acumulado Salario Neto para Operarios: ........" + acumuladoSalarioNetoOperarios);
        Console.WriteLine("3) Promedio Salario Neto para Operarios: ........." + (cantidadOperarios > 0 ? acumuladoSalarioNetoOperarios / cantidadOperarios : 0));
        Console.WriteLine("");
        Console.WriteLine("4) Cantidad Empleados Tipo Técnicos: ............." + cantidadTecnicos);
        Console.WriteLine("5) Acumulado Salario Neto para Técnicos: ........." + acumuladoSalarioNetoTecnicos);
        Console.WriteLine("6) Promedio Salario Neto para Técnicos: .........." + (cantidadTecnicos > 0 ? acumuladoSalarioNetoTecnicos / cantidadTecnicos : 0));
        Console.WriteLine("");
        Console.WriteLine("7) Cantidad Empleados Tipo Profesional: .........." + cantidadProfesionales);
        Console.WriteLine("8) Acumulado Salario Neto para Profesionales: ...." + acumuladoSalarioNetoProfesionales);
        Console.WriteLine("9) Promedio Salario Neto para Profesionales: ....." + (cantidadProfesionales > 0 ? acumuladoSalarioNetoProfesionales / cantidadProfesionales : 0));
    }

    static float CalcularSalarioNeto(int horas, int salarioHora, double porcentajeAumento)
    {
        float salarioOrdinario = horas * salarioHora;
        float aumentoSalarial = (float)(salarioOrdinario * porcentajeAumento);
        float salarioBruto = salarioOrdinario + aumentoSalarial;
        float deduccionCCSS = salarioBruto * 0.0917f;
        return salarioBruto - deduccionCCSS;
    }
}