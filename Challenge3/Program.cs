using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
namespace Challenge3
{
    class Program
    {
        //Умовистов Андрей
        //3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
        //Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
        //Написать программу, демонстрирующую все разработанные элементы класса.

        //** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
        //ArgumentException("Знаменатель не может быть равен 0");
        //Добавить упрощение дробей.
        static void Main(string[] args)
        {

           
            Helpers.Header("Калькулятор Дробей");
            var f1 = EnterFraction("Первая дробь");
            var f2 = EnterFraction("Вторая дробь");
            //var f1 = new Fraction(4, -4);
            //var f2 = new Fraction(16, 4);

            var f3 = Fraction.Sum(f1, f2);
            Console.WriteLine($"Сумма дробей: {f3}"); ;

            var f4 = Fraction.Sub(f1, f2);
            Console.WriteLine($"Разность дробей: {f4}"); ;

            var f5 = Fraction.Mult(f1, f2);
            Console.WriteLine($"Произведение дробей: {f5}"); ;

            var f6 = Fraction.Div(f1, f2);
            Console.WriteLine($"Частное дробей: {f6}"); ;

            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();

        }

        private static Fraction EnterFraction(string fractionName)
        {
            Console.WriteLine(fractionName);
            var correct = false;
            var a1 = 0;
            var b1 = 0;
            do
            {
                Console.Write("Введите числитель: ");
                if (Int32.TryParse(Console.ReadLine(), out a1))
                {
                    correct = true;

                }
                else
                {
                    Helpers.Print("Введено не число! Повторите попытку");
                    correct = false;
                }

            } while (!correct);


            correct = false;
            do
            {
                try
                {
                    Console.Write("Введите Знаменатель: ");
                    if (Int32.TryParse(Console.ReadLine(), out b1))
                    {
                        if (b1 == 0)
                        {
                            throw new ArgumentException("Знаменатель не может быть равен 0");
                        }

                        correct = true;
                    }
                    else
                    {
                        Helpers.Print("Введено не число! Повторите попытку");
                        correct = false;
                    }
                }
                catch (Exception ex)
                {
                    correct = false;
                    Helpers.Print(ex.Message);

                }

            } while (!correct);

          
            return new Fraction(a1, b1);
        }
    }

    public class Fraction
    {
        int a;
        int b;

        public override string ToString()
        {
            return $"{a}/{b}";
        }

        public Fraction()
        {

        }

        public Fraction(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Сумма дробей
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static Fraction Sum(Fraction f1, Fraction f2)
        {
            var result = new Fraction(f1.a * f2.b + f2.a * f1.b, f1.b * f2.b);
            Simplification(ref result);
            return result;

        }

        /// <summary>
        /// Разность дробей
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static Fraction Sub(Fraction f1, Fraction f2)
        {
            var result = new Fraction(f1.a * f2.b - f2.a * f1.b, f1.b * f2.b);
            Simplification(ref result);
            return result;
        }

        /// <summary>
        /// Произведение дробей
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static Fraction Mult(Fraction f1, Fraction f2)
        {
            var result = new Fraction(f1.a * f2.a, f1.b * f2.b);
            Simplification(ref result);
            return result;
        }

        /// <summary>
        /// Деление дробей
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static Fraction Div(Fraction f1, Fraction f2)
        {
            var result = new Fraction(f1.a * f2.b, f1.b * f2.a);
            Simplification(ref result);
            return result;
        }

        /// <summary>
        /// Упрощение дроби
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static void Simplification(ref Fraction f)
        {
            // Убираем минус из знаменателя
            if (f.b < 0)
            {
                f.a = -f.a;
                f.b = -f.b;
            }

            // Находим минимальное по модулю из числителя и знаменателя
            var min = Math.Abs(f.a) < Math.Abs(f.b) ? Math.Abs(f.a) : Math.Abs(f.b);
            
            //не упрощается, возврат
            if (min == 1) return;


            for (int i = 2; i <= min; i++)
            {
                // Есть общий делитель у числителя и знаменателя, делим на него числитель и знаменатель
                if (f.a % i == 0 && f.b % i == 0)
                {
                    f.a = f.a / i;
                    f.b = f.b / i;
                    // Пытаемся упростить снова
                    Simplification(ref f);
                    
                }
            }
   


        }
    }

}
