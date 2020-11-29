using Core.Contracts;
using Core.Lexemes;
using System;

namespace Core.Mathematics
{
    public static class MathLexemeOperations
    {
        public static IOperantLexeme<double> Add(IOperantLexeme<double> left, IOperantLexeme<double> rigth)
        {
            return new OperantLexeme<double>(left.Value + rigth.Value);
        }

        public static IOperantLexeme<double> Minus(IOperantLexeme<double> lexeme)
        {            
            return new OperantLexeme<double>(-lexeme.Value);
        }

        public static IOperantLexeme<double> Multiply(IOperantLexeme<double> left, IOperantLexeme<double> rigth)
        {
            return new OperantLexeme<double>(left.Value * rigth.Value);
        }

        public static IOperantLexeme<double> Divide(IOperantLexeme<double> left, IOperantLexeme<double> rigth)
        {
            return new OperantLexeme<double>(left.Value / rigth.Value);
        }

        public static IOperantLexeme<double> Pow(IOperantLexeme<double> left, IOperantLexeme<double> rigth)
        {
            return new OperantLexeme<double>(Math.Pow(left.Value, rigth.Value));
        }

        public static IOperantLexeme<double> Cos(IOperantLexeme<double> operant)
        {
            return new OperantLexeme<double>(Math.Cos(operant.Value));
        }

        public static IOperantLexeme<double> Sin(IOperantLexeme<double> operant)
        {
            return new OperantLexeme<double>(Math.Sin(operant.Value));
        }
    }
}
