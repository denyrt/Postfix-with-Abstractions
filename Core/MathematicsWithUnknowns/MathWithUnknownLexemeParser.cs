﻿using Core.Contracts;
using Core.Lexemes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.MathematicsWithUnknowns
{
    public class MathWithUnknownLexemeParser
    {
        public List<IOperationLexeme<double>> OperationLexemes { get; }

        public MathWithUnknownLexemeParser()
        {
            OperationLexemes = new List<IOperationLexeme<double>>();
        }

        public MathWithUnknownLexemeParser(IEnumerable<IOperationLexeme<double>> operations)
        {
            OperationLexemes = new List<IOperationLexeme<double>>(operations);
        }

        public IEnumerable<ILexeme<double>> Parse(string inputString)
        {
            var lexemes = new List<ILexeme<double>>();
            var index = 0;

            while (index <= inputString.Length - 1)
            {
                ILexeme<double> lexeme = null;

                foreach (var operationLexeme in OperationLexemes)
                {
                    if (operationLexeme.Key.Length > inputString.Length - index)
                        continue;

                    var stringLexeme = inputString.Substring(index);

                    if (stringLexeme.StartsWith(operationLexeme.Key))
                    {
                        lexeme = operationLexeme;
                        index += operationLexeme.Key.Length;
                        break;
                    }
                }

                if (lexeme == null)
                {
                    var regex = new Regex(@"^(\d)+(\.?(\d)+)?x", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    var result = regex.Match(inputString.Substring(index))?.Value;

                    if (!string.IsNullOrEmpty(result))
                    {
                        var numberPart = result.Substring(0, result.Length - 1);


                        if (double.TryParse(numberPart, out var koef))
                        {
                            lexeme = new UnknownLexeme(koef);
                        }
                        else
                        {
                            lexeme = new UnknownLexeme();
                        }

                        index += result.Length;
                    }                   
                }

                if (lexeme == null)
                {
                    var regex = new Regex(@"^(\d)+(\.?(\d)+)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    var result = regex.Match(inputString.Substring(index))?.Value;

                    if (string.IsNullOrEmpty(result))
                        throw new Exception("Syntax error.");

                    var value = double.Parse(result, CultureInfo.InvariantCulture);
                    lexeme = new OperantLexeme<double>(value);
                    index += result.Length;
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
