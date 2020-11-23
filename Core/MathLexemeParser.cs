using Core.Contracts;
using Core.Lexemes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Core
{
    public class MathLexemeParser
    {
        public List<IOperationLexeme<double>> OperationLexemes { get; }

        public Dictionary<IOperationLexeme<double>, IEnumerable<IOperationLexeme<double>>> LexemesRelations { get; }

        public MathLexemeParser()
        {
            OperationLexemes = new List<IOperationLexeme<double>>();
            LexemesRelations = new Dictionary<IOperationLexeme<double>, IEnumerable<IOperationLexeme<double>>>();
        }

        public MathLexemeParser(IEnumerable<IOperationLexeme<double>> operations)
        {
            OperationLexemes = new List<IOperationLexeme<double>>(operations);
            LexemesRelations = new Dictionary<IOperationLexeme<double>, IEnumerable<IOperationLexeme<double>>>();
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
                    var regex = new Regex(@"^(\d)+(,?(\d)+)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);                    
                    var result = regex.Match(inputString.Substring(index))?.Value;

                    if (string.IsNullOrEmpty(result))
                        throw new Exception("Syntax error.");

                    var value = double.Parse(result);
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
