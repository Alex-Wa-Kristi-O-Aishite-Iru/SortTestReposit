using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _000
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            double[] AMas = new double[100];
            Console.Write("Initial mas:\n");
            for (int i = 0; i < AMas.Length; i++) AMas[i] = Convert.ToDouble(String.Format("{0: 0.##}", rand.NextDouble()*100));

            foreach (double i in AMas) Console.Write(i + "_");
            Console.WriteLine("\n");

            Sort(AMas);
            Console.Write("Sort mas:\n");
            foreach (double i in AMas) Console.Write(i + "_");
            Console.WriteLine();
            Console.ReadKey();
        }

        static void Sort(double[] A)
        {
            double[] B = new double[A.Length];
            int N = 0;
            int phase = 0;

            for (int i = 1; i < A.Length; i *= 2, phase = (phase + 1) % 2)
            {
                bool flag = true;
                for (int k = 0; flag;)
                {
                    if(k < A.Length - A.Length % (2 * i))
                    {
                        for (int x = k, y = k + i; (x - k) < i && (y - k - i) < i;)
                        {

                            if (phase == 0) Swap(A, B, ref i, ref k, ref x, ref y, ref N, "First");
                            else Swap(B, A, ref i, ref k, ref x, ref y, ref N, "First");
                        }
                    }
                    
                    if (k >= A.Length - A.Length % (2 * i))
                    {
                        if (k >= A.Length - A.Length % (2 * i) && k < A.Length)
                        {
                            if (A.Length % (2 * i) > i)
                            {
                                for (int x = k, y = k + i; (x - k) < i && (y - k - i) < A.Length % (2 * i) - i;)
                                {
                                    if (phase == 0) Swap(A, B, ref i, ref k, ref x, ref y, ref N, "Remain");//
                                    else Swap(B, A, ref i, ref k, ref x, ref y, ref N, "Remain");
                                }
                            }
                            else
                            {
                                for (int t = k; N < A.Length; t++, N++)
                                {
                                    if (phase == 0) B[N] = A[t];
                                    else A[N] = B[t];
                                }
                            }
                        }
                        flag = false; 
                    }
                    k += 2 * i;
                }
                N = 0;
            }
            if(phase == 1)
            {
                for (int i = 0; i < A.Length; i++) A[i] = B[i];
            }
        }  
        
        static void Swap(double[] A, double[] B, ref int _i, ref int _k, ref int _x, ref int _y, ref int _N, string way)
        {
            if (A[_x] < A[_y])
            {
                B[_N] = A[_x];
                _N++; _x++;
            }
            else if (A[_x] > A[_y])
            {
                B[_N] = A[_y];
                _N++; _y++;
            }
            else
            {
                B[_N] = A[_x];
                B[_N + 1] = A[_y];
                _x++; _y++; _N += 2;
            }

            switch (way)
            {
                case "First":
                    if ((_x - _k) == _i && (_y - _k - _i) != _i)
                    {
                        while ((_y - _k - _i) != _i)
                        {
                            B[_N] = A[_y];
                            _N++; _y++;
                        }
                    }
                    else if ((_x - _k) != _i && (_y - _k - _i) == _i)
                    {
                        while ((_x - _k) != _i)
                        {
                            B[_N] = A[_x];
                            _N++; _x++;
                        }
                    }
                    break;
                case "Remain":
                    if ((_x - _k) == _i && (_y - _k - _i) != A.Length % (2 * _i) - _i)
                    {
                        while ((_y - _k - _i) != A.Length % (2 * _i) - _i)
                        {
                            B[_N] = A[_y];
                            _N++; _y++;
                        }
                    }
                    else if ((_x - _k) != _i && (_y - _k - _i) == A.Length % (2 * _i) - _i)
                    {
                        while ((_x - _k) != _i)
                        {
                            B[_N] = A[_x];
                            _N++; _x++;
                        }
                    }
                    break;
            }
        }
    }
}
