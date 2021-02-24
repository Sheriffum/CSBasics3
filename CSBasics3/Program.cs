using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace CSBasics3
{
    class Program
    {

        // Умовистов Андрей
        //1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры;
        //б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса;
        static void Main(string[] args)
        {

            Helpers.Header("Комплексные числа");

            var z1 = new Complex(1, 2);
            var z2 = new Complex(3, 4);

            var z3 = Complex.Sum(z1, z2);
            Console.WriteLine($"Сумма {z1} и {z2} равна {z3}");

            var z4 = Complex.Sub(z1, z2);
            Console.WriteLine($"Разность {z1} и {z2} равна {z4}");

            var z5 = Complex.Mult(z1, z2);
            Console.WriteLine($"Произведение {z1} и {z2} равно {z5}");

            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();
        }


       
    }

    // a + bi
    public class Complex
    {
        int a;
        int b;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public override string ToString()
        {
            if (b == 0)
                return a.ToString();
            else if (b < 0)
                return $"{a} - {-b}i";
            else
                return $"{a} + {b}i";
        }

        /// <summary>
        /// Сумма комплексных чисел
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        public static Complex Sum(Complex z1, Complex z2)
        {
            return new Complex(z1.a + z2.a, z1.b + z2.b);
        }

        /// <summary>
        /// Разность комплексных чисел
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        public static Complex Sub(Complex z1, Complex z2)
        {
            return new Complex(z1.a - z2.a, z1.b - z2.b);
        }

        /// <summary>
        /// Произведение комплексных чисел
        /// </summary>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        public static Complex Mult(Complex z1, Complex z2)
        {
            return new Complex(z1.a * z2.a - z1.b * z2.b, z1.b * z2.a + z1.a * z2.b);
            // a+bi и  c+di
            // Умножение (ac - bd) + (bc + ad)i}.
        }

    }
}
