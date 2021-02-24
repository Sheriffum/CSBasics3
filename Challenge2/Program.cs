using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Challenge2
{
    class Program
    {
        // Умовистов Андрей
        // 2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
        // Требуется подсчитать сумму всех нечетных положительных чисел. 
        // Сами числа и сумму вывести на экран, используя tryParse;
        // б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
        // При возникновении ошибки вывести сообщение. Напишите соответствующую функцию;
        static void Main(string[] args)
        {

            Helpers.Header("Сумма положительных нечетных чисел");

            var enterNextNumber = true;
            var sum = 0;
            List<int> numbers = new List<int>();

            do
            {
                Console.WriteLine("Введите число (0 - для выхода):");
                if (Int32.TryParse(Console.ReadLine(), out int n))
                {
                    if (n > 0 && n % 2 == 1) {
                        sum += n;
                        numbers.Add(n);
                    }
                    if (n == 0) enterNextNumber = false;

                } else
                {
                    Helpers.Print("Вы ввели не число! Попробуйте еще раз. Введите 0 для выхода", ConsoleColor.Yellow);
                }
            } while (enterNextNumber);

            Helpers.Print("Положительные нечетные числа:", ConsoleColor.Green);
            foreach (var number in numbers)
            {
                Console.Write(number+"\t");
            }
            Console.WriteLine();
            Helpers.Print($"Сумма нечетных положительных чисел равна {sum}", ConsoleColor.Green);

            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();

        }
    }
}
