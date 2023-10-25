using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Гаус_численные_методы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество переменных");
            int count = int.Parse(Console.ReadLine());
            double[,] mass = new double[count,count+1];
            Console.WriteLine("Введите коэффицент по строчкам");
            int a = 0; int b = 0;
            double opr = 1;
            while (a < count)//заполнение массива
            {
                Console.WriteLine($"Введите {a + 1} строчку состоящую из {count + 1} Элементов");
                while (b < count + 1)
                {
                    mass[a, b] = double.Parse(Console.ReadLine());
                    b++;
                }
                a++;
                b = 0;
            }
            for (int i = 0;i<count;i++)//вывод массива
            {
                for (int j = 0; j <= count; j++)
                {
                    Console.Write(mass[i,j]+" ");
                }
                Console.WriteLine();
            }
            double sum = 0;
            a = 0;b = 0;
            double[,] mass2 = new double[count, count+2];
            while (a < count)// приведение массива в удобную для вычисления форму
            {
                while (b < count + 1)
                {
                    mass2[a, b] = mass[a, b];
                    sum += mass[a,b];
                    b++;
                }
                mass2[a,count+1] = sum;
                a++;
                b = 0;sum = 0;
            }
            a = 0; int c = 0,d = 0;
            double[,] mass3 = new double[count, count+2];//решение системы уравнений
            while(d < count)//этап
            {
                opr *= mass2[d, d];//определитель
                while (b < count + 2)//элементы
                {
                    mass3[d, b] = mass2[d, b] / mass2[d, d];
                    b++;
                }
                sum = 0;
                while (c < count + 1)//нахождение суммы переменных
                {
                    sum += mass3[d, c];
                    c++;
                }
                if (Math.Round(sum, 3) != Math.Round(mass3[d, count + 1], 3))//проверка подсчетов
                {
                    break;
                }
                b = 0;c = 0;
                while (a < count)//строки
                {
                    if(a != d)
                    {
                        while(b < count + 2)//элементы
                        {
                            mass3[a,b] = mass2[a, b] - (mass3[d, b]*mass2[a,d]);
                            b++;
                        }
                        sum = 0;
                        while (c < count+1)//нахождение суммы переменных
                        {
                            sum += mass3[a, c];
                            c++;
                        }
                        if (Math.Round(sum, 3) != Math.Round(mass3[a, count + 1], 3))//проверка подсчетов
                        {
                            break;
                        }
                    }
                    a++;b = 0;c = 0;
                }
                for (int i = 0; i < count; i++)//введение вспомогательного массива
                {
                    for (int j = 0; j < count + 2; j++)
                    {
                        mass2[i,j] = mass3[i,j];
                    }
                    
                }
                
                d++; a = 0; b = 0; c = 0;
            }
            a = 0; b = 0;c= 0;sum = 0;
            //нахождение обратной матрицы
            int count2 = count * 2;
            double[,] massOb = new double[count,count2+2];
            for (int i = 0; i < count; i++)//заполнение первой части матрицы
            {
                for (int j = 0; j < count ; j++)
                {
                    massOb[i, j] = mass[i, j];
                    
                }

            }
            for (int i = 0; i < count; i++)//заполнение обратной части матрицы
            {
                for (int j = count; j < count2; j++)
                {
                    if(i == j-count)
                        massOb[i, j] = 1;
                    else
                        massOb[i, j] = 0;
                }

            }
            for (int i = 0; i < count; i++)//заполнение суммы строк матрицы
            {
                for (int j = 0; j < count2; j++)
                {
                    sum += massOb[i, j];

                }
                massOb[i, count2] = sum;
                sum = 0;
            }
            double[,] massOb2 = new double[count, count2 + 2];
            for (int i = 0; i < count; i++)//введение вспомогательного массива
            {
                for (int j = 0; j < count2 + 1; j++)
                {
                    massOb2[i, j] = massOb[i, j];
                }

            }
            a = 0; b = 0; c = 0; d = 0;
            while (d < count)//этап
            {
                while (b <= count2)//элементы
                {
                    massOb[d, b] = massOb2[d, b] / massOb2[d, d];
                    b++;
                }
                sum = 0;
                while (c < count2)//нахождение суммы переменных
                {
                    sum += massOb[d, c];
                    c++;
                }
                if (Math.Round(sum, 3) != Math.Round(massOb[d, count2], 3))//проверка подсчетов
                {
                    break;
                }
                b = 0; c = 0;
                while (a < count)//строки
                {
                    if (a != d)
                    {
                        while (b <= count2)//элементы
                        {
                            massOb[a, b] = massOb2[a, b] - (massOb[d, b] * massOb2[a, d]);
                            b++;
                        }
                        sum = 0;
                        while (c < count2)//нахождение суммы переменных
                        {
                            sum += massOb[a, c];
                            c++;
                        }
                        if (Math.Round(sum, 3) != Math.Round(massOb[a, count2], 3))//проверка подсчетов
                        {
                            break;
                        }
                    }
                    a++; b = 0; c = 0;
                }
                for (int i = 0; i < count; i++)//введение вспомогательного массива
                {
                    for (int j = 0; j < count2 + 1; j++)
                    {
                        massOb2[i, j] = massOb[i, j];
                    }

                }

                d++; a = 0; b = 0; c = 0;
            }


            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count+2; j++)
                {
                    if (j == count)//выделение невязок
                        Console.Write("X"+ (i+1) + " = " + Math.Round(mass3[i, j], 3) + "  ");
                    else
                        Console.Write(Math.Round(mass3[i, j],3)+"  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Определитель = " + Math.Round(opr, 3));
            Console.WriteLine();
            Console.WriteLine("Обратная матрица");
            Console.WriteLine();
            for (int i = 0; i < count; i++)//вывод массива обратной матрицы
            {
                for (int j = count; j < count2; j++)
                {
                    Console.Write(massOb[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
