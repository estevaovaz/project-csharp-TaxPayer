using Exercicio_TaxPayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exercicio_TaxPayer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write("Tax payer #" + i + "data: ");
                Console.Write("Individual or Company (i/c)? ");
                char c = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual Income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if(c  == 'i')
                {
                    Console.Write("Health Expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Number of Employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                    Console.WriteLine();
                }
            }

            double sum = 0.0;
            Console.WriteLine();
            Console.Write("TAXAS PAID: ");
            Console.WriteLine();
            foreach (TaxPayer tax in list)
            {
                double tp = tax.Tax();
                Console.WriteLine(tax.Name + ": " + " $ " + tp.ToString("F2", CultureInfo.InvariantCulture));
                sum += tp;
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
