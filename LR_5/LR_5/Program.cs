using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*Написать рекурсивную функцию для вычисления корня уравнения на некотором отрезке.Функция, реализуемая в задании, обязана выполнять проверку передаваемых параметров и генерировать исключение в случае ошибочных данных со спецификацией throw().Функция принимает в качестве параметров отрезок [xн, xк], на котором предположительно находится корень, коэффициенты уравнения а, b, с и точность e. Нечётные номера вариантов используют метод половинного деления, чётные – метод хорд. 
В главной функции происходит запрос данных у пользователя и вызов функции, генерирующей исключения. Обработка всех перехватываемых исключений и выдача соответствующих сообщений также производится в главной функции.
Результаты работы представить в виде отчёта с построением математической модели и полного набора тестовых данных.Продемонстрировать работающую программу на предложенном наборе.
*/

    /*  a*x+b=sqrt(logc(x))  */
namespace LR_5
{
   
    class Program
    {
         public static double a, b, c, xn, xe, eps;


        static void Main(string[] args)
        {
            Console.WriteLine("Введите a: ");
             a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите b: ");
             b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите c: ");
             c = int.Parse(Console.ReadLine());
            if (c <= 0)
            {
                throw new Exception("Аргумент С в этом уравненении не может быть меньше или равен нулю");
                
            }
            Console.WriteLine("Введите xn: ");
             xn = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите xe: ");
             xe = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите e: ");
             eps = double.Parse(Console.ReadLine());
            Console.WriteLine("Ответ: ");
            Console.Write(Hordes(xn,xe));
            Console.ReadLine();
        }


        public static double function(double x)
        {

            double n = a * x + b;
            return (Math.Sqrt(Math.Log(x, c))) - n;
            
        }

        public static double Hordes(double x0, double x1)
        {
            x0 = x1 - (x1 - x0) * function(x1) / (function(x1) - function(x0));
            x1 = x0 - (x0 - x1) * function(x0) / (function(x0) - function(x1));

            if (Math.Abs(x1 - x0) > eps)
            {
                return Hordes(x0, x1);
            }
            else 
            return x1;
                 

            //while (Math.Abs(x1 - x0) > eps)
            //{
            //    x0 = x1 - (x1 - x0) * function(x1) / (function(x1) - function(x0));
            //    x1 = x0 - (x0 - x1) * function(x0) / (function(x0) - function(x1));
            //    Console.WriteLine(x1);
            //}

        }

    }
}
