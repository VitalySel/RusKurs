using System;
using System.Collections.Generic;
using System.Text;

namespace RusKurs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Численные методы многомерной оптимизации.");
            Console.WriteLine();

            Console.WriteLine("1. Метод случайного поиска ");
            Console.WriteLine("Найти безусловный минимум функции f(x,y) = x^2 + y^2. ");
            Console.WriteLine();
            Logic a = new Logic();
            a.randomSearchMethod();

            Console.WriteLine();
            Console.WriteLine("2. Симплексный метод ");
            Console.WriteLine("Вычислить оптиму при заданных ограничениях и целевой функции. ");
            Console.WriteLine();

            SimplexMethod b = new SimplexMethod();
            b.mySimplex();

            Console.ReadKey();
            
        }
    }
}
