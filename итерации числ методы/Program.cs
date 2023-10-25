using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace итерации_числ_методы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество переменных");
            int count = int.Parse(Console.ReadLine());
            double[,] mass = new double[count, count+1];
            Console.WriteLine("Введите коэффицент по строчкам");
            int a = 0; int b = 0;
            while (a < count)
            {
                Console.WriteLine($"Введите {a + 1} строчку состоящую из {count + 1} Элементов");
                while (b < count + 1)
                {
                    mass[a, b] = float.Parse(Console.ReadLine());
                    b++;
                }
                a++;
                b = 0;
            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count+1; j++)
                {
                    Console.Write(mass[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Введите погрешность");
            float e = float.Parse(Console.ReadLine());
            double[,] mass2 = new double[count, count + 1];
            a = 0; b = 0;
            while (a < count)
            {
                
                while (b < count+1)
                {
                    if(b == count)
                    {
                        mass2[a, b] = mass[a, b] / mass[a, a];
                    }
                    else
                    {
                        if (a == b)
                        {
                            mass2[a, b] = 0;
                        }
                        else
                        {
                            mass2[a, b] = -1 * mass[a, b] / mass[a, a];
                        }
                    }
                    
                    
                    b++;
                }
                a++;
                b = 0;
            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count + 1; j++)
                {
                    Console.Write(mass2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сходимость");
            double[,] massSum = new double[count, count + 1];
            a = 0; b = 0;
            double sum = 0;
            while(a < count)
            {
                while (b < count+1)
                {
                    massSum[a,b] = mass2[a, b] * mass2[a, b];
                    b++;
                }
                a++; 
                b = 0;
            }
            
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    sum += massSum[i, j];
                }
                
            }
            Console.WriteLine(sum);
            if (sum >= 1)
            {
                Console.WriteLine("Error");
            }
            a= 0;
            double[] massResh = new double[count];
            while (a < count)
            {
                massResh[a] = mass2[a, count];
                a++;
            }
            foreach (int i in massResh)
            {
                Console.Write(i + " ");
            }
            a = 0;
            double[] massResh2 = new double[count];
            while (a < count)
            {
                massResh2[a] = massResh[a]*massResh[a];
                a++;
            }
            foreach (int i in massResh2)
            {
                Console.Write(i + " ");
            }
            int go = 0;
            a = 0; b = 0;
            while (Math.Sqrt(massResh2.Sum()) >= e)
            {
                while(a < count)
                {
                    if (a == 0)
                    {
                        while (b < count + 1)
                        {
                            if (b == count)
                            {
                                massResh[a] += mass2[0, b];
                            }
                            else
                                massResh[a] += mass2[0, b] * massResh[b];
                            b++;
                        }
                    }
                    else 
                    {
                        while (b < count + 1)
                        {
                            if (b == count)
                            {
                                massResh[a] += mass2[0, b];
                            }
                            else
                                massResh[a-1] += mass2[0, b] * massResh[b];
                            b++;
                        }
                    }
                    
                    a++;
                    b = 0;
                }
                a = 0;
                while (a < count)
                {
                    massResh2[a] = massResh[a] * massResh[a];
                    a++;
                }

                go++;
            }
            Console.WriteLine(go);
            foreach(int i  in massResh)
            {
                Console.Write(i + " ");
            }

            Console.ReadKey();
        }
    }
}
