using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
{
    internal class Matrix
    {
        private List<List<int>> LMatrix;
        public Matrix(int x = 1, int y = 1)
        {
            LMatrix = new List<List<int>>();
            for (int i = 0; i < x; i++)
            {
                LMatrix.Add(Enumerable.Repeat(0, y).ToList());
            }
        }
        public void Input()
        {
            int row, col, temp1;
            string x, y, temp;
            while (true)
            {
                Console.Write("Enter number of rows: ");
                x = Console.ReadLine();
                if (int.TryParse(x, out row) && row > 0)
                    break;
                Console.WriteLine("Error Valid Number.");
            }
            while (true)
            {
                Console.Write("Enter number of columns: ");
                y = Console.ReadLine();
                if (int.TryParse(y, out col) && col > 0)
                    break;
                Console.WriteLine("Error valid Number.");
            }
            LMatrix = new List<List<int>>();
            for (int i = 0; i < row; i++)
            {
                LMatrix.Add(Enumerable.Repeat(0, col).ToList());
            }
            for (int i = 0;i < LMatrix.Count;i++)
            {
                for (int j = 0; j < LMatrix[i].Count;j++)
                {
                    do
                    {
                        Console.Write("Enter element row {0} column {1}: ", i + 1, j + 1);
                        temp = Console.ReadLine();
                        if (!int.TryParse(temp, out temp1))
                            Console.WriteLine("Error valid Number.");
                    } while (!int.TryParse(temp, out temp1));
                    LMatrix[i][j] = temp1;
                }
            }
        }
        public void Output()
        {
            Console.WriteLine("Your matrix is:");
            for (int i = 0; i < LMatrix.Count;i++)
            {
                for (int j = 0; j < LMatrix[i].Count; j++)
                    Console.Write(LMatrix[i][j] + " ");
                Console.WriteLine();
            }
        }
        public List<(int row, int column)> SearchXNumber(int X = 0)
        {
            List<(int row, int column)> result = new List<(int row, int column)>(); 
            for (int i = 0; i < LMatrix.Count; i++)
            {
                for (int j = 0; j < LMatrix[i].Count; j++)
                {
                    if (LMatrix[i][j] == X)
                        result.Add((i + 1, j + 1));
                }
            }
            return result;
        }

        private bool isPrimeNum(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
        public void PrintPrimeNum()
        {
            Console.Write("List of Prime Numbers in Matrix: ");
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < LMatrix.Count; i++)
            {
                for (int j = 0; j < LMatrix[i].Count; j++)
                    if (isPrimeNum(LMatrix[i][j]))
                        if (!result.Contains(LMatrix[i][j]))
                            result.Add(LMatrix[i][j]);
            }
            if (result.Count == 0)
                Console.WriteLine("None");
            else
                Console.WriteLine(string.Join(", ", result.ToArray()));
        }
        public void PrintRowMostPrimeNum()
        {
            Console.Write("Row with most prime number: ");
            int num, max = 0;
            List<int> result = new List<int>();
            for (int i = 0; i < LMatrix.Count;  ++i)
            {
                num = 0;
                for (int j = 0; j < LMatrix[i].Count; ++j)
                {
                    if (isPrimeNum(LMatrix[i][j]))
                        num++;
                }
                if (num > max)
                {
                    result.Clear();
                    result.Add(i + 1);
                    max = num;
                }
                else if (num == max)
                    result.Add((int) i + 1);
            }
            if (max == 0)
                Console.WriteLine("None");
            else
                Console.WriteLine(string.Join (", ", result.ToArray()));
        }

    }
    public class B3
    {
        public void Run()
        {
            Matrix matrix = new Matrix();
            string temp;
            int X;
            matrix.Input();
            matrix.Output();
            while (true)
            {
                Console.Write("Enter a number to search in matrix: ");
                temp = Console.ReadLine();
                if (int.TryParse(temp, out X))
                    break;
                Console.WriteLine("Error valid Number.");
            }
            Console.Write($"{X} is at: ");
            List<(int row, int col)> result = matrix.SearchXNumber(X);
            if (result.Count == 0)
                Console.WriteLine("NULL");
            else
            {
                for (int i  = 0; i < result.Count; ++i)
                {
                    Console.Write($"({result[i].row}, {result[i].col})");
                    if (i == result.Count - 1)
                    {
                        Console.WriteLine();
                        break;
                    }
                    Console.Write(", ");
                }
            }
                matrix.PrintPrimeNum();
            matrix.PrintRowMostPrimeNum();
        }
    }
}
