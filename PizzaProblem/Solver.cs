using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProblem
{
    public class Solver : SolverBase<ProblemInput, ProblemOutput>
    {
        protected override ProblemOutput Solve(ProblemInput input)
        {
            ProblemOutput output = new ProblemOutput() { Slices = new List<Slice>() };
            Queue<MatrixCoordinate> queue = new Queue<MatrixCoordinate>();
            queue.Enqueue(new MatrixCoordinate(0, 0));
            while(queue.Count != 0)
            {
                var coor = queue.Dequeue();
                Slice slice =  GetSlice(coor, coor, input);
                if (slice != null)
                {
                    output.Slices.Add(slice);
                    queue.Enqueue(new MatrixCoordinate(slice.minRow, slice.maxCol));
                    queue.Enqueue(new MatrixCoordinate(slice.maxRow, slice.minCol));
                }
                else
                {
                    MatrixCoordinate item = new MatrixCoordinate(coor.Row + 1, coor.Column);
                    if (item.InMatrix(input.Cells))
                        queue.Enqueue(item);

                    MatrixCoordinate item1 = new MatrixCoordinate(coor.Row, coor.Column + 1);
                    if (item1.InMatrix(input.Cells))
                        queue.Enqueue(item1);
                }
            }
            return output;
        }

        private Slice GetSlice(MatrixCoordinate coor1, MatrixCoordinate coor2, ProblemInput input)
        {
            Queue<Slice> queue = new Queue<Slice>();
            queue.Enqueue(new Slice() { minRow = coor1.Row, minCol = coor1.Column, maxRow = coor2.Row, maxCol = coor2.Column });
            while (queue.Count != 0)
            {
                Slice slice = queue.Dequeue();
                if (IsSliceValid(slice, input))
                    return slice;

                if (slice.Size > input.MaxSliceSize)
                    return null;

                if (slice.maxRow + 1 < input.Rows)
                    queue.Enqueue(new Slice() { minRow = slice.minRow, minCol = slice.minCol, maxCol = slice.maxCol, maxRow = slice.maxRow + 1 });

                if (slice.maxCol+ 1 < input.Columns)
                    queue.Enqueue(new Slice() { minRow = slice.minRow, minCol = slice.minCol, maxCol = slice.maxCol + 1, maxRow = slice.maxRow});
            }

            return null;
        }

        private bool IsSliceValid(Slice slice, ProblemInput input)
        {
            var tCount = 0;
            var mCount = 0;
            if (slice.Size <= input.MaxSliceSize)
            {
                for (int row = slice.minRow; row <= slice.maxRow && row < input.Rows; row++)
                {
                    for (int col = slice.minCol; col < slice.maxCol && col < input.Columns; col++)
                    {
                        if(input.Cells[row, col] == Cell.M)
                        {
                            mCount++;
                        }
                        else
                        {
                            tCount++;
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            return tCount >= input.MinIngredients && mCount >= input.MinIngredients;
        }
    }
}
