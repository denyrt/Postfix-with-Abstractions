using Core.Lexemes;
using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Core
{
    public class LogicLexemeParser
    {
        public List<IOperationLexeme<bool>> OperationLexemes { get; }

        public Dictionary<IOperationLexeme<bool>, IEnumerable<IOperationLexeme<bool>>> LexemesRelations { get; }

        public LogicLexemeParser()
        {
            OperationLexemes = new List<IOperationLexeme<bool>>();
            LexemesRelations = new Dictionary<IOperationLexeme<bool>, IEnumerable<IOperationLexeme<bool>>>();
        }

        public LogicLexemeParser(IEnumerable<IOperationLexeme<bool>> operations)
        {
            OperationLexemes = new List<IOperationLexeme<bool>>(operations);
            LexemesRelations = new Dictionary<IOperationLexeme<bool>, IEnumerable<IOperationLexeme<bool>>>();
        }

        public IEnumerable<ILexeme<bool>> Parse(string inputString)
        {
            var lexemes = new List<ILexeme<bool>>();
            var index = 0;

            while (index <= inputString.Length - 1)
            {
                ILexeme<bool> lexeme = null;

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
                    var regex = new Regex(@"^(true|false)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    var result = regex.Match(inputString.Substring(index))?.Value;

                    if (string.IsNullOrEmpty(result))
                        throw new Exception("Syntax error.");
                    
                    var value = bool.Parse(result);
                    lexeme = new OperantLexeme<bool>(value);
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
