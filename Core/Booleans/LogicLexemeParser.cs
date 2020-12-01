using Core.Lexemes;
using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.Booleans
{
    public class LogicLexemeParser
    {
        public List<IOperationLexeme<bool>> OperationLexemes { get; }

        public LogicLexemeParser()
        {
            OperationLexemes = new List<IOperationLexeme<bool>>();            
        }

        public LogicLexemeParser(IEnumerable<IOperationLexeme<bool>> operations)
        {
            OperationLexemes = new List<IOperationLexeme<bool>>(operations);            
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

                        var last = lexemes.LastOrDefault();
                        if (last == null
                            || ((last is IBinaryOperationLexeme<bool> || last is IOpenTagLexeme<bool>)
                            && (lexeme is IBinaryOperationLexeme<bool>)))
                        {
                            var sameUnary = OperationLexemes.FirstOrDefault(op => op.Key == operationLexeme.Key && op is IUnaryOperationLexeme<bool>);
                            if (sameUnary != null)
                            {
                                lexeme = sameUnary;
                            }
                        }

                        index += operationLexeme.Key.Length;
                        break;
                    }
                }

                if (lexeme == null)
                {
                    var regex = new Regex(@"^(1|0)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    var result = regex.Match(inputString.Substring(index))?.Value;

                    if (string.IsNullOrEmpty(result))
                        throw new Exception("Syntax error.");
                    
                    var value = Convert.ToBoolean(int.Parse(result));
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
