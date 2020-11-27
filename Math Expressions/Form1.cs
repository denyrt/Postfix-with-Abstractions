using Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Core.Contracts;
using Core.Lexemes;

namespace Math_Expressions
{
    public partial class Form1 : Form
    {
        private List<IOperationLexeme<double>> _mathOperations;
        private MathLexemeParser _mathLexemeParser;

        private List<IOperationLexeme<bool>> _logicOperations;
        private LogicLexemeParser _logicLexemeParser;

        public Form1()
        {
            InitializeComponent();
            InitMath();
            InitLogic();
        }

        #region Math Operations

        private void InitMath()
        {
            var closeTagLexeme = new CloseTagLexeme<double>(")", 1);
            var openTagLexeme = new OpenTagLexeme<double>("(", 1);
            closeTagLexeme.OpenTag = openTagLexeme;
            openTagLexeme.CloseTag = closeTagLexeme;

            _mathOperations = new List<IOperationLexeme<double>>
            {
                openTagLexeme,
                closeTagLexeme,
                new BinaryOperationLexeme<double>("+", 2, Add),
                new UnaryOperationLexeme<double>("-", 3, Minus),
                new BinaryOperationLexeme<double>("*", 4, Multiply),
                new BinaryOperationLexeme<double>("/", 4, Divide),
                new BinaryOperationLexeme<double>("^", 6, Pow),
                new UnaryOperationLexeme<double>("cos", 7, Cos),
                new UnaryOperationLexeme<double>("sin", 7, Sin)
            };

            _mathOperations.Sort(new LexemeComparer<double>());

            _mathLexemeParser = new MathLexemeParser(_mathOperations);
        }

        private IOperantLexeme<double> Add(IOperantLexeme<double> left, IOperantLexeme<double> rigth)
        {
            return new OperantLexeme<double>(left.Value + rigth.Value);
        }

        private IOperantLexeme<double> Minus(IOperantLexeme<double> lexeme)
        {
            return new OperantLexeme<double>(-lexeme.Value);
        }

        private IOperantLexeme<double> Multiply(IOperantLexeme<double> left, IOperantLexeme<double> rigth)
        {
            return new OperantLexeme<double>(left.Value * rigth.Value);
        }

        private IOperantLexeme<double> Divide(IOperantLexeme<double> left, IOperantLexeme<double> rigth)
        {
            return new OperantLexeme<double>(left.Value / rigth.Value);
        }

        private IOperantLexeme<double> Pow(IOperantLexeme<double> left, IOperantLexeme<double> rigth)
        {
            return new OperantLexeme<double>(Math.Pow(left.Value, rigth.Value));
        }

        private IOperantLexeme<double> Cos(IOperantLexeme<double> operant)
        {
            return new OperantLexeme<double>(Math.Cos(operant.Value));
        }

        private IOperantLexeme<double> Sin(IOperantLexeme<double> operant)
        {
            return new OperantLexeme<double>(Math.Sin(operant.Value));
        }

        #endregion

        #region Logic Operations

        private void InitLogic()
        {
            var closeTagLexeme = new CloseTagLexeme<bool>(")", 1);
            var openTagLexeme = new OpenTagLexeme<bool>("(", 1);
            closeTagLexeme.OpenTag = openTagLexeme;
            openTagLexeme.CloseTag = closeTagLexeme;

            _logicOperations = new List<IOperationLexeme<bool>>
            {
                openTagLexeme,
                closeTagLexeme,
                new BinaryOperationLexeme<bool>("||", 2, Or),
                new BinaryOperationLexeme<bool>("&&", 3, And),                
                new UnaryOperationLexeme<bool>("!", 4, Mirror),
            };

            _logicOperations.Sort(new LexemeComparer<bool>());
            _logicLexemeParser = new LogicLexemeParser(_logicOperations);
        }

        private IOperantLexeme<bool> And(IOperantLexeme<bool> left, IOperantLexeme<bool> right)
        {
            return new OperantLexeme<bool>(left.Value && right.Value);
        }

        private IOperantLexeme<bool> Or(IOperantLexeme<bool> left, IOperantLexeme<bool> right)
        {
            return new OperantLexeme<bool>(left.Value || right.Value);
        }

        private IOperantLexeme<bool> Mirror(IOperantLexeme<bool> value)
        {
            return new OperantLexeme<bool>(!value.Value);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var text = richTextBox1.Text.Replace(" ", null);

            try
            {
                var inputLemexes = _mathLexemeParser.Parse(text);
                var exp = new PostfixExpression<double>(inputLemexes, 
                    _mathOperations.FirstOrDefault(operation => operation.Key == "+") as IBinaryOperationLexeme<double>);
                var result = exp.Calculate();
                var value = result.Value;
                textBox1.Text = value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = richTextBox2.Text.Replace(" ", null);

            try
            {
                var inputLemexes = _logicLexemeParser.Parse(text);
                var exp = new PostfixExpression<bool>(inputLemexes,
                    _logicOperations.FirstOrDefault(operation => operation.Key == "&&") as IBinaryOperationLexeme<bool>);
                var result = exp.Calculate();
                var value = result.Value;
                textBox2.Text = value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
