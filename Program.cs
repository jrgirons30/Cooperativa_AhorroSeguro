using System;

namespace Practica_Cooperativa_AhorroSeguro
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal saldoCajero = 10000.00m;
            int pinCorrecto = 1234;
            bool autenticado = false;
            bool ejecutarPrograma = true;

            while (ejecutarPrograma)
            {
                Console.Clear();
                Console.WriteLine("COOPERATIVA AHORRO SEGURO");
                Console.WriteLine();
                Console.WriteLine("1. Ejercicio 1: Cajero Automatico");
                Console.WriteLine("2. Ejercicio 2: Simulador de Prestamo");
                Console.WriteLine("3. Salir");
                Console.WriteLine();
                Console.Write("Seleccione una opcion (1-3): ");

                string opcionMenu = Console.ReadLine() ?? "";

                switch (opcionMenu)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("CAJERO AUTOMATICO");
                        Console.WriteLine();

                        if (!autenticado)
                        {
                            int intentos = 3;
                            while (intentos > 0)
                            {
                                Console.Write($"Ingrese su PIN de 4 digitos (Intentos restantes {intentos}): ");
                                string entradaPin = Console.ReadLine() ?? "";
                                int pinIngresado = 0;

                                if (int.TryParse(entradaPin, out pinIngresado) && pinIngresado == pinCorrecto)
                                {
                                    autenticado = true;
                                    Console.WriteLine("PIN Correcto. Accediendo al sistema...");
                                    break;
                                }
                                else
                                {
                                    intentos--;
                                    Console.WriteLine("PIN incorrecto.");
                                }
                            }

                            if (!autenticado)
                            {
                                Console.WriteLine("\nHa superado el numero maximo de intentos. Regresando al menu...");
                                Console.WriteLine("Presione una tecla para continuar...");
                                Console.ReadKey();
                                break;
                            }
                        }

                        bool enCajero = true;
                        while (enCajero)
                        {
                            Console.Clear();
                            Console.WriteLine("CAJERO AUTOMATICO");
                            Console.WriteLine("MENU");
                            Console.WriteLine();
                            Console.WriteLine("1. Consultar saldo");
                            Console.WriteLine("2. Depositar dinero");
                            Console.WriteLine("3. Retirar dinero");
                            Console.WriteLine("4. Volver al Menu Principal");
                            Console.WriteLine();
                            Console.Write("Seleccione una opcion: ");

                            string opCajero = Console.ReadLine() ?? "";

                            switch (opCajero)
                            {
                                case "1":
                                    Console.WriteLine($"\nSaldo actual: RD$ {saldoCajero:N2}");
                                    break;

                                case "2":
                                    Console.Write("\nIngrese el monto a depositar: RD$ ");
                                    decimal deposito = 0;
                                    if (decimal.TryParse(Console.ReadLine() ?? "", out deposito) && deposito > 0)
                                    {
                                        saldoCajero += deposito;
                                        Console.WriteLine($"Deposito exitoso. Nuevo saldo: RD$ {saldoCajero:N2}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Monto invalido.");
                                    }
                                    break;

                                case "3":
                                    Console.Write("\nIngrese el monto a retirar (multiplos de 100): RD$ ");
                                    decimal retiro = 0;
                                    if (decimal.TryParse(Console.ReadLine() ?? "", out retiro) && retiro > 0)
                                    {
                                        if (retiro % 100 != 0)
                                        {
                                            Console.WriteLine("Error: El monto a retirar debe ser multiplo de 100.");
                                        }
                                        else if (retiro > saldoCajero)
                                        {
                                            Console.WriteLine("Error: Saldo insuficiente.");
                                        }
                                        else
                                        {
                                            saldoCajero -= retiro;
                                            Console.WriteLine($"Retiro exitoso. Nuevo saldo: RD$ {saldoCajero:N2}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Monto invalido.");
                                    }
                                    break;

                                case "4":
                                    enCajero = false;
                                    continue;

                                default:
                                    Console.WriteLine("Opcion invalida.");
                                    break;
                            }

                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        string respSimulador = "S";

                        while (respSimulador.ToUpper() == "S")
                        {
                            Console.Clear();
                            Console.WriteLine("SIMULADOR DE PRESTAMO");
                            Console.WriteLine();

                            decimal monto = 0;
                            int plazo = 0;
                            char categoria = ' ';
                            decimal tasaAnual = 0;

                            while (true)
                            {
                                Console.Write("Ingrese el monto del prestamo (5000 a 500000): ");
                                if (decimal.TryParse(Console.ReadLine() ?? "", out monto) && monto >= 5000 && monto <= 500000)
                                {
                                    break;
                                }
                                Console.WriteLine("Monto fuera del rango permitido. Intente de nuevo.");
                            }

                            while (true)
                            {
                                Console.Write("Ingrese el plazo en meses (6 a 60): ");
                                if (int.TryParse(Console.ReadLine() ?? "", out plazo) && plazo >= 6 && plazo <= 60)
                                {
                                    break;
                                }
                                Console.WriteLine("Plazo fuera del rango permitido. Intente de nuevo.");
                            }

                            while (true)
                            {
                                Console.Write("Ingrese la categoria del socio (A, B o C): ");
                                string textoCat = Console.ReadLine() ?? "";
                                if (!string.IsNullOrEmpty(textoCat))
                                {
                                    categoria = char.ToUpper(textoCat.Trim()[0]);
                                    if (categoria == 'A')
                                    {
                                        tasaAnual = 0.12m;
                                        break;
                                    }
                                    else if (categoria == 'B')
                                    {
                                        tasaAnual = 0.15m;
                                        break;
                                    }
                                    else if (categoria == 'C')
                                    {
                                        tasaAnual = 0.18m;
                                        break;
                                    }
                                }
                                Console.WriteLine("Categoria no valida. Debe ser A, B o C.");
                            }

                            decimal tasaMensual = tasaAnual / 12.0m;
                            double i = (double)tasaMensual;
                            double n = (double)plazo;
                            double potencia = Math.Pow(1 + i, n);

                            decimal cuota = 0;
                            if (potencia > 1)
                            {
                                cuota = monto * (tasaMensual * (decimal)potencia) / (decimal)(potencia - 1);
                            }

                            Console.WriteLine();
                            Console.WriteLine($"Monto Solicitado: RD$ {monto:N2}");
                            Console.WriteLine($"Plazo: {plazo} meses");
                            Console.WriteLine($"Tasa Anual: {tasaAnual * 100}%");
                            Console.WriteLine($"Cuota Fija Mensual: RD$ {cuota:N2}");
                            Console.WriteLine();
                            Console.WriteLine("Presione una tecla para generar la tabla de amortizacion...");
                            Console.ReadKey();

                            Console.Clear();
                            Console.WriteLine("TABLA DE AMORTIZACION");
                            Console.WriteLine();
                            Console.WriteLine("Mes\tCuota\t\tInteres\t\tAbono Capital\tSaldo");

                            decimal saldoPendiente = monto;
                            decimal totalInteres = 0;
                            decimal totalCapital = 0;

                            for (int mes = 1; mes <= plazo; mes++)
                            {
                                decimal interesMes = saldoPendiente * tasaMensual;
                                decimal abonoCapital = cuota - interesMes;

                                if (mes == plazo)
                                {
                                    abonoCapital = saldoPendiente;
                                    cuota = abonoCapital + interesMes;
                                }

                                saldoPendiente -= abonoCapital;
                                totalInteres += interesMes;
                                totalCapital += abonoCapital;

                                Console.WriteLine($"{mes}\t{cuota:N2}\t{interesMes:N2}\t{abonoCapital:N2}\t\t{saldoPendiente:N2}");
                            }

                            Console.WriteLine();
                            Console.WriteLine($"Total Capital Pagado: RD$ {totalCapital:N2}");
                            Console.WriteLine($"Total Interes Pagado: RD$ {totalInteres:N2}");
                            Console.WriteLine($"Total General Pagado: RD$ {totalCapital + totalInteres:N2}");
                            Console.WriteLine();

                            Console.Write("¿Desea simular otro prestamo? (S/N): ");
                            string resp = Console.ReadLine() ?? "";
                            if (!string.IsNullOrEmpty(resp))
                            {
                                respSimulador = resp.Trim().Substring(0, 1);
                            }
                            else
                            {
                                respSimulador = "N";
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nSaliendo de la aplicacion. ¡Hasta luego!");
                        ejecutarPrograma = false;
                        break;

                    default:
                        Console.WriteLine("\nOpcion no valida. Intente de nuevo.");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}