using Core.Contracts;
using Core.Lexemes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class UnknownPostfixExpression
    {
        private readonly List<ILexeme<double>> _inputLexemes;

        public IBinaryOperationLexeme<double> DefaultOperation { get; } 

        public UnknownPostfixExpression(IEnumerable<ILexeme<double>> inputLexemes, IBinaryOperationLexeme<double> defaultOperation)
        {
            if (inputLexemes is null)
                throw new ArgumentNullException(nameof(inputLexemes), "Value was null.");

            if (defaultOperation is null)
                throw new ArgumentNullException(nameof(defaultOperation), "Value was null");

            DefaultOperation = defaultOperation;
            _inputLexemes = inputLexemes.ToList();            
        }

        public Queue<ILexeme<double>> GetPostfixLexemes()
        {            
            var postfixLexemes = new Queue<ILexeme<double>>();
            var tmpOperatios = new Stack<IOperationLexeme<double>>();

            foreach (var lexeme in _inputLexemes)
            {
                if (lexeme is IOperantLexeme<double> operant)
                {
                    postfixLexemes.Enqueue(operant);                    
                }
                else if (lexeme is IOpenTagLexeme<double> openTag)
                {
                    tmpOperatios.Push(openTag);
                }
                else if (lexeme is ICloseTagLexeme<double> closeTag)
                {
                    IOperationLexeme<double> current;

                    while ((current = tmpOperatios.Pop()) != closeTag.OpenTag)
                    {
                        postfixLexemes.Enqueue(current);                        
                    }                    
                }
                else if (lexeme is IOperationLexeme<double> operation)
                {
                    var firstOperation = tmpOperatios.FirstOrDefault();

                    if (firstOperation is null || operation.Priority > firstOperation.Priority)
                    {
                        tmpOperatios.Push(operation);
                    }
                    else
                    {
                        var op = tmpOperatios.Pop();
                        postfixLexemes.Enqueue(op);                        
                        tmpOperatios.Push(operation);
                    }
                }
                else
                {

                }
            }

            foreach (var op in tmpOperatios)
            {
                postfixLexemes.Enqueue(op);                
            }
            
            return postfixLexemes;            
        }

        public IEnumerable<ILexeme<double>> Calculate()
        {
            var postfix = GetPostfixLexemes();
            var stackResult = new Stack<IOperantLexeme<double>>();
            var unknownStack = new Stack<ILexeme<double>>();

            while (postfix.Count > 0)
            {
                var lexeme = postfix.Dequeue();

                if (lexeme is IOperantLexeme<double> operant)
                {
                    stackResult.Push(operant);
                }
                else if (lexeme is IBinaryOperationLexeme<double> binaryOperation)
                {
                    var rigth = stackResult.Pop();
                    var left = stackResult.Pop();

                    if ((left is IUnknownOperant<double> unknownLeft || rigth is IUnknownOperant<double> unknownRigth) 
                        && lexeme is IUnknownBinaryOperation<double> uBinaryOperation)
                    {
                        if (uBinaryOperation?.CanCalculateWithUnknown(left, rigth) == true)
                        {
                            var unknownResult = uBinaryOperation.FuncWithUnknown(left, rigth);
                            stackResult.Push(unknownResult);
                        }
                        else
                        {
                            unknownStack.Push(left);
                            unknownStack.Push(binaryOperation);
                            unknownStack.Push(rigth);
                        }

                        continue;
                    }            

                    var result = binaryOperation.Function(left, rigth);                    
                    stackResult.Push(result);
                }
                else if (lexeme is IUnaryOperationLexeme<double> unaryOperation)
                {
                    var value = stackResult.Pop();                    

                    var result = unaryOperation.Function(value);
                    stackResult.Push(result);
                }                
            }

            while (stackResult.Count > 1)
            {
                var rigth = stackResult.Pop();
                var left = stackResult.Pop();

                var result = DefaultOperation.Function(left, rigth);
                stackResult.Push(result);
            }

            return stackResult;
        }
    }
}
