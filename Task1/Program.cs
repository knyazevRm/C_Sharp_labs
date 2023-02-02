/*
 * №18
 * Составить программу поиска минимального элемента,
 * расположенного под главной диагональю, и максимального элемента,
 * расположенного над главной диагональю заданной вещественной матрицы А(n×n).
 *
 * Create a program to search for the minimum element,
 * located under the main diagonal, and the maximum element,
 * located above the main diagonal of a given real matrix A(n×n).
 */

using System;

namespace ConsoleApplication
{
    class Element
    {
        private double value;

        public double Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        
        private int indexI;

        public int IndexI
        {
            get
            {
                return this.indexI;
            }
            set
            {
                this.indexI = value;
            }
        }
        
        private int indexJ;

        public int IndexJ
        {
            get
            {
                return this.indexJ;
            }
            set
            {
                this.indexJ = value;
            }
        }

        public Element(double value, int i, int j)
        {
            this.value = value;
            this.indexI = i;
            this.indexJ = j;
        }
    }
    
    class SearchMinAndMaxElemInMatrix
 {  
     static double[][] pathFileDataToMatrixDouble(string path)
     {  
         double[][] matrix;
         using (StreamReader reader = new StreamReader(@path))
         {
             double[] firstRow = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x=>Double.Parse(x.Replace(".", ","))).ToArray();
             int size = firstRow.Length;
             matrix = new double[size][];
             matrix[0] = firstRow;
             for (int i = 1; i < size; i++)
             {
                 matrix[i] = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x=>Double.Parse(x.Replace(".", ","))).ToArray();
             
             }
         }
         
         return matrix;
     }

     static void PrintMatrix(string header, double[][] matrix)
     {
         Console.WriteLine(header);
         for (int i = 0; i < matrix.Length; i++)
         {
             for (int j = 0; j < matrix[0].Length; j++)
             {
                 Console.Write("\t" + matrix[i][j]);
             }
             Console.WriteLine();
         }
     }
    
     // Function return array of two elem, that stored value and elements indexes.
     // The search is performed in one pass through the matrix.
     // The first array element is min elem of elements, that located under the main diagonal.
     // If there are several min elements, then the last one is returned.
     // The second array element is max elem of elements, that located above the main diagonal.
     // If there are several max elements, then the last one is returned.
     static Element[] getMinAndMaxElemInMatrix(double[][] matrix)
     {  
         double minElemUnderMain = Double.MaxValue;
         int minIndexI = -1;
         int minIndexJ = -1;
         double maxElemAboveMain = Double.MinValue;
         int maxIndexI = -1;
         int maxIndexJ = -1;
         double epsilon = 0.00001;

         for (int i = 0; i < matrix.Length; i++)
         {
             for (int j = 0; j < matrix[0].Length; j++)
             {
                 if (i > j)
                 {
                     if (matrix[i][j] < minElemUnderMain || Math.Abs(matrix[i][j] - minElemUnderMain) < epsilon)
                     {
                         minElemUnderMain = matrix[i][j];
                         minIndexI = i;
                         minIndexJ = j;
                     }
                 }

                 if (i < j)
                 {
                     if (matrix[i][j] > maxElemAboveMain || Math.Abs(matrix[i][j] - maxElemAboveMain) < epsilon)
                     {
                         maxElemAboveMain = matrix[i][j];
                         maxIndexI = i;
                         maxIndexJ = j;
                     }
                 }
             }
         }
         
         Element[] result = {new Element(minElemUnderMain, minIndexI, minIndexJ),
             new Element(maxElemAboveMain, maxIndexI, maxIndexJ)};
         return result;
     }

     static void Main()
     {
         string path = "/Users/romanknazev/Desktop/IT/Task1/Task1/data/matrix2.txt";
         double[][] matrix = pathFileDataToMatrixDouble(path);
         PrintMatrix("Initial matrix", matrix);
         Element[] result = getMinAndMaxElemInMatrix(matrix);
         Console.WriteLine("The minimum element located under the main diagonal: value = " + result[0].Value + " i = " + result[0].IndexI + " j = " + result[0].IndexJ + ".");
         Console.WriteLine("The maximum element located above the main diagonal: value = " + result[1].Value + " i = " + result[1].IndexI + " j = " + result[1].IndexJ + ".");
     }
 }
}