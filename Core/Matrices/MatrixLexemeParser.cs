using Core.Contracts;
using Core.Lexemes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Matrices
{
    public class MatrixLexemeParser
    {
        public List<IOperationLexeme<Matrix>> OperationLexemes { get; set; }

        public MatrixLexemeParser()
        {
            OperationLexemes = new List<IOperationLexeme<Matrix>>();
        }

        public MatrixLexemeParser(IEnumerable<IOperationLexeme<Matrix>> operations)
        {
            OperationLexemes = new List<IOperationLexeme<Matrix>>(operations);
        }

        public IEnumerable<ILexeme<Matrix>> Parse(string inputString)
        {
            var lexemes = new List<ILexeme<Matrix>>();
            var index = 0;

            while (index <= inputString.Length - 1)
            {                
                if (char.IsWhiteSpace(inputString[index]))
                {
                    ++index;
                    continue;
                }

                ILexeme<Matrix> lexeme = null;

                foreach (var operationLexeme in OperationLexemes)
                {
                    if (operationLexeme.Key.Length > inputString.Length - index)
                        continue;

                    var stringLexeme = inputString.Substring(index);

                    if (stringLexeme.StartsWith(operationLexeme.Key))
                    {
                        lexeme = operationLexeme;

                        var last = lexemes.LastOrDefault();
                        if (last == null
                            || ((last is IBinaryOperationLexeme<Matrix> || last is IOpenTagLexeme<Matrix>)
                            && (lexeme is IBinaryOperationLexeme<Matrix>)))
                        {
                            var sameUnary = OperationLexemes.FirstOrDefault(op => op.Key == operationLexeme.Key && op is IUnaryOperationLexeme<Matrix>);
                            if (sameUnary != null)
                            {
                                lexeme = sameUnary;
                            }
                        }

                        index += operationLexeme.Key.Length;
                        break;
                    }
                }

                if (lexeme == null && inputString[index] == '[')
                {
                    var end = inputString.IndexOf(']', index);

                    if (end != -1)
                    {
                        var matrixString = inputString.Substring(index + 1, end - index - 1);
                        var stringRows = matrixString.Split(';', StringSplitOptions.RemoveEmptyEntries);
                        var regex = new Regex(@"\s+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        var columnCount = regex.Replace(stringRows.FirstOrDefault(), " ").Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

                        var matrix = new Matrix(stringRows.Length, columnCount);

                        for (int r = 0; r < stringRows.Length; ++r)
                        {
                            var stringRow = regex.Replace(stringRows[r], " ");
                            var cols = stringRow.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                            if (cols.Length != columnCount)
                            {
                                throw new InvalidOperationException("Invalid input.");
                            }

                            for (int c = 0; c < cols.Length; ++c)
                            {
                                if (!double.TryParse(cols[c], NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
                                    throw new InvalidOperationException("Invalid input.");

                                matrix[r, c] = value;
                            }
                        }

                        lexeme = new OperantLexeme<Matrix>(matrix);
                        index = end + 1;
                    }
                }

                if (lexeme != null)
                {
                    lexemes.Add(lexeme);
                }
                else
                {
                    throw new Exception("Incorrent syntax.");
                }
            }

            return lexemes;
        }
    }
}