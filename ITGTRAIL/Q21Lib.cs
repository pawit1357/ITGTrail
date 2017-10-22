using System;
using System.Collections.Generic;

namespace ITGTRAIL
{
    public class Q21Lib
    {
        /*
  * Task: find and print the number of cells in the largest region in the matrix
  */
        public static int GetNumberOfCellsInLargestRegion(int[,] matrix, int rows, int cols)
        {
            int max = Int32.MinValue;

            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        int value = TraverseRegionAndCount(matrix, rows, cols, row, col);
                        max = value > max ? value : max;
                    }
                }

            return max;
        }

        /*
         * spec:
         * a node is connected to 8 neighbors
         * left, right, up and down, also cross directions: 
         * left-top, right-top, left-bottom, right-bottom
         * if the location exists in the matrix for that [i][j]
         * 
         * Task: Visit all unvisited connected neighbors using a queue, 
         * mark the cell as visited by setting the value 0. 
         * 
         * design to use queue properly in the following: 
         * only add unvisited node to the queue, add to queue first, 
         * and then update the node as a visited one.
         * 
         * It is a BFS algorithm. 
         */
        private static int TraverseRegionAndCount(
            int[,] matrix,
            int rows,
            int cols,
            int startX,
            int startY)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(GetKeyNumber(startX, startY));
            matrix[startX, startY] = 0;

            IList<string> DebugInfo = new List<string>();

            int count = 0;
            while (queue.Count > 0)
            {
                int key = (int)queue.Dequeue();

                int visitingCellRow = key / 10;
                int visitingCellCol = key % 10;

                for (int row = -1; row <= 1; row++)
                {
                    for (int col = -1; col <= 1; col++)
                    {
                        int neighborRow = row + visitingCellRow;
                        int neighborCol = col + visitingCellCol;

                        if (BoundaryCheck(neighborRow, neighborCol, rows, cols) &&
                            matrix[neighborRow, neighborCol] == 1)
                        {
                            matrix[neighborRow, neighborCol] = 0;
                            queue.Enqueue(GetKeyNumber(neighborRow, neighborCol));
                        }
                    }
                }

                DebugInfo.Add(visitingCellRow + "-" + visitingCellCol);
                count++;
            }

            return count;
        }

        /*
         * check the boundary of matrix 
         */
        private static bool BoundaryCheck(int row, int col, int rows, int cols)
        {
            if ((row >= 0 && row < rows) && (col >= 0 && col < cols))
                return true;
            else
                return false;
        }

        /*
         * key should be unique, since 0 < n, m < 10, 
         * the mapping function 10 * row + col will uniquely define the key value 
         * for matrix[row, col], any row, col in the range of (0,10). 
         * In other words, key is a two-digit integer 
         * leftmost digit  - row, 
         * rightmost digit - col
         */
        private static int GetKeyNumber(int row, int col)
        {
            return 10 * row + col;
        }

    }
}
