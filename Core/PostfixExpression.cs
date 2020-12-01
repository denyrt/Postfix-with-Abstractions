using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class PostfixExpression<T> where T : struct
    {
        private readonly List<ILexeme<T>> _inputLexemes;       

        public PostfixExpression(IEnumerable<ILexeme<T>> inputLexemes)
        {
            if (inputLexemes is null)
                throw new ArgumentNullException(nameof(inputLexemes), "Value was null.");
           
            _inputLexemes = inputLexemes.ToList();            
        }

        public Queue<ILexeme<T>> GetPostfixLexemes()
        {            
            var postfixLexemes = new Queue<ILexeme<T>>();
            var tmpOperatios = new Stack<IOperationLexeme<T>>();            

            foreach (var lexeme in _inputLexemes)
            {
                if (lexeme is IOperantLexeme<T> operant)
                {
                    postfixLexemes.Enqueue(operant);                    
                }
                else if (lexeme is IOpenTagLexeme<T> openTag)
                {
                    tmpOperatios.Push(openTag);
                }
                else if (lexeme is ICloseTagLexeme<T> closeTag)
                {
                    IOperationLexeme<T> current;

                    while ((current = tmpOperatios.Pop()) != closeTag.OpenTag)
                    {
                        postfixLexemes.Enqueue(current);                        
                    }                    
                }
                else if (lexeme is IOperationLexeme<T> operation)
                {
                    while (tmpOperatios.Count > 0)
                    {
                        var firstOperation = tmpOperatios.Pop();

                        if (firstOperation.Priority >= operation.Priority)
                        {
                            postfixLexemes.Enqueue(firstOperation);
                        }
                        else
                        {
                            tmpOperatios.Push(firstOperation);
                            break;                            
                        }
                    }
                    tmpOperatios.Push(operation);
                }
                else
                {

                }
            }

            while (tmpOperatios.Count > 0)
            {
                postfixLexemes.Enqueue(tmpOperatios.Pop());                
            }
            
            return postfixLexemes;            
        }

        public IOperantLexeme<T> Calculate()
        {
            var postfix = GetPostfixLexemes();
            var stackResult = new Stack<IOperantLexeme<T>>();

            var str = string.Join("", postfix.Select(lex => lex is IOperantLexeme<T> op ? op.Value.ToString() : (lex as IOperationLexeme<T>).Key).ToArray());

            while (postfix.Count > 0)
            {
                var lexeme = postfix.Dequeue();

                if (lexeme is IOperantLexeme<T> operant)
                {
                    stackResult.Push(operant);
                }
                else if (lexeme is IBinaryOperationLexeme<T> binaryOperation)
                {
                    var rigth = stackResult.Pop();
                    var left = stackResult.Pop();

                    var result = binaryOperation.Function(left, rigth);                    
                    stackResult.Push(result);
                }
                else if (lexeme is IUnaryOperationLexeme<T> unaryOperation)
                {
                    var value = stackResult.Pop();                    

                    var result = unaryOperation.Function(value);
                    stackResult.Push(result);
                }                
            }            

            return stackResult.FirstOrDefault();
        }
    }
}
