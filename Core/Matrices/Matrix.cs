using System;
using System.Globalization;
using System.Text;

namespace Core.Matrices
{
    public struct Matrix
    {
        public double[,] Arr { get; }

        public int Rows => Arr.GetUpperBound(0) + 1;

        public int Columns => Arr.GetUpperBound(1) + 1;

        public Matrix(int rows, int columns)
        {
            if (rows < 1)
                throw new ArgumentException("Row count cannot be lesser than 1.", nameof(rows));

            if (columns < 1)
                throw new ArgumentException("Column count cannot be lesser than 1.", nameof(columns));
            
            Arr = new double[rows, columns];
        }

        public double this[int r, int c]
        {
            get => Arr[r, c];
            set => Arr[r, c] = value;
        }

        public override string ToString() => this.ToString(4);

        public string ToString(int accuracy)
        {
            var sb = new StringBuilder("[ ");

            for (int r = 0; r < Rows; ++r)
            {
                for (int c = 0; c < Columns; ++c)
                {
                    var value = this[r, c].ToString($"F{accuracy}", CultureInfo.InvariantCulture);
                    sb.Append($"{value} ");
                }

                if (r != Rows - 1) sb.Append("; ");
            }

            sb.Append(']');
            return sb.ToString();
        }

        public double CalculateMinor(int r, int c)
        {
            return CreateMatrixWithoutRow(CreateMatrixWithoutColumn(this, c), r)
                .Determinate();
        }        

        public double Determinate()
        {
            if (Rows != Columns)
                throw new InvalidOperationException("Determinate can be calculated only in a square matrix.");

            if (Rows == 1)
                return this[0, 0];

            if (Rows == 2)
            {
                return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
            }

            if (Rows == 3)
            {
                return this[0, 0] * this[1, 1] * this[2, 2]
                     + this[0, 1] * this[1, 2] * this[2, 0]
                     + this[0, 2] * this[1, 0] * this[2, 1]
                     - this[0, 2] * this[1, 1] * this[2, 0]
                     - this[0, 0] * this[1, 2] * this[2, 1]
                     - this[0, 1] * this[1, 0] * this[2, 2];
            }

            double result = 0;

            for (int r = 0; r < Columns; ++r)
            {
                var minor = CalculateMinor(r, 0);
                result += (r % 2 == 1 ? -1 : 1) * this[r, 0] * minor;
            }

            return result;
        }

        public static Matrix InvariantMatrix(in Matrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
                return default;

            var determinate = matrix.Determinate();
            var result = new Matrix(matrix.Rows, matrix.Columns);

            for (int r = 0; r < matrix.Rows; ++r)
            {
                for (int c = 0; c < matrix.Columns; ++c)
                {                    
                    result[r, c] = ((r + c) % 2 == 1 ? -1 : 1) *
                        matrix.CalculateMinor(r, c) / determinate;
                }
            }
            
            return CreateTransposeMatrix(result);
        }

        public static Matrix CreateTransposeMatrix(in Matrix matrix)
        {
            var result = new Matrix(matrix.Columns, matrix.Rows);

            for (int r = 0; r < matrix.Rows; ++r)
            {
                for (int c = 0; c < matrix.Columns; ++c)
                {
                    result[c, r] = matrix[r, c];
                }
            }

            return result;
        }

        public static Matrix Add(in Matrix left, in Matrix rigth)
        {
            if (left.Rows != rigth.Rows || left.Columns != rigth.Columns)
                throw new InvalidOperationException("Count of rows and columns both matrices must be the same.");

            var result = new Matrix(left.Rows, left.Columns);

            for (int r = 0; r < result.Rows; ++r)
            {
                for (int c = 0; c < result.Columns; ++c)
                {
                    result.Arr[r, c] = left.Arr[r, c] + rigth.Arr[r, c];
                }
            }

            return result;
        }

        public static Matrix Minus(in Matrix left, in Matrix rigth)
        {
            if (left.Rows != rigth.Rows || left.Columns != rigth.Columns)
                throw new InvalidOperationException("Count of rows and columns both matrices must be the same.");

            var result = new Matrix(left.Rows, left.Columns);

            for (int r = 0; r < result.Rows; ++r)
            {
                for (int c = 0; c < result.Columns; ++c)
                {
                    result.Arr[r, c] = left.Arr[r, c] - rigth.Arr[r, c];
                }
            }
            
            return result;
        }

        public static Matrix Multiply(in Matrix left, in Matrix rigth)
        {
            if (left.Columns != rigth.Rows)
                throw new InvalidOperationException("Count of columns left matrix and count of rows rigth matrix must be the same.");

            var result = new Matrix(left.Rows, rigth.Columns);

            for (int r = 0; r < left.Rows; ++r)
            {
                for (int c = 0; c < rigth.Columns; ++c)
                {
                    result.Arr[r, c] = 0;

                    for (int i = 0; i < left.Columns; ++i)
                    {
                        result.Arr[r, c] += left.Arr[r, i] * rigth.Arr[i, c];
                    }
                }
            }

            return result;
        }

        public static Matrix Multiply(in Matrix matrix, double value)
        {            
            var result = new Matrix(matrix.Rows, matrix.Columns);

            for (int r = 0; r < matrix.Rows; ++r)
            {
                for (int c = 0; c < matrix.Columns; ++c)
                {
                    result[r, c] = matrix[r, c] * value;
                }
            }

            return result;
        }

        public static Matrix CreateMatrixWithoutRow(in Matrix matrix, int rowIndex)
        {
            if (matrix.Rows == 1 && matrix.Columns == 1)
                throw new ArgumentException("", nameof(matrix));

            if (rowIndex < 0)
                throw new ArgumentException("", nameof(rowIndex));

            var result = new Matrix(matrix.Rows - 1, matrix.Columns);

            for (int r = 0; r < matrix.Rows; ++r)
            {
                if (r == rowIndex)
                    continue;

                for (int c = 0; c < matrix.Columns; ++c)
                {
                    var row = r > rowIndex ? r - 1 : r;
                    result[row, c] = matrix[r, c];
                }
            }

            return result;
        }

        public static Matrix CreateMatrixWithoutColumn(in Matrix matrix, int columnIndex)
        {
            if (matrix.Rows == 1 && matrix.Columns == 1)
                throw new ArgumentException("", nameof(matrix));

            if (columnIndex < 0)
                throw new ArgumentException("", nameof(columnIndex));

            var result = new Matrix(matrix.Rows, matrix.Columns - 1);

            for (int r = 0; r < matrix.Rows; ++r)
            {                
                for (int c = 0; c < matrix.Columns; ++c)
                {
                    if (c == columnIndex)
                        continue;

                    var column = c > columnIndex ? c - 1 : c;
                    result[r, column] = matrix[r, c];
                }
            }

            return result;
        }
    }
}
