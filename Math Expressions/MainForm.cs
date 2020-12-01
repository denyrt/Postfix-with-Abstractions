using Core;
using Core.Contracts;
using Core.Lexemes;
using Core.Booleans;
using Core.Mathematics;
using Core.Matrices;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Globalization;

namespace Math_Expressions
{
    public partial class MainForm : Form
    {
        private List<IOperationLexeme<double>> _mathOperations;
        private MathLexemeParser _mathLexemeParser;

        private List<IOperationLexeme<bool>> _logicOperations;
        private LogicLexemeParser _logicLexemeParser;

        private List<IOperationLexeme<Matrix>> _matrixOperations;
        private MatrixLexemeParser _matrixLexemeParser;

        private Dictionary<string, double> _consts = new Dictionary<string, double>
        {
            { "pi", Math.PI },
            { "e", Math.E }
        };

        public MainForm()
        {
            InitializeComponent();
            InitMath();
            InitLogic();
            InitMatrix();        
        }

        private string ReplaceConsts(string str)
        {
            foreach (var pair in _consts)
                str = str.Replace(pair.Key, pair.Value.ToString("F", CultureInfo.InvariantCulture));

            return str;
        }

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
                new BinaryOperationLexeme<double>("+", 2, MathLexemeOperations.Add),
                new BinaryOperationLexeme<double>("-", 3, MathLexemeOperations.Minus),
                new UnaryOperationLexeme<double>("-", 4, MathLexemeOperations.Minus),
                new BinaryOperationLexeme<double>("*", 5, MathLexemeOperations.Multiply),
                new BinaryOperationLexeme<double>("/", 5, MathLexemeOperations.Divide),
                new BinaryOperationLexeme<double>("^", 6, MathLexemeOperations.Pow),
                new UnaryOperationLexeme<double>("cos", 7, MathLexemeOperations.Cos),
                new UnaryOperationLexeme<double>("sin", 7, MathLexemeOperations.Sin)
            };

            _mathOperations.Sort(new LexemeComparer<double>());
            _mathLexemeParser = new MathLexemeParser(_mathOperations);
        }        

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
                new BinaryOperationLexeme<bool>("\\/", 2, LogicLexemeOperations.Or),
                new BinaryOperationLexeme<bool>("/\\", 3, LogicLexemeOperations.And),                
                new UnaryOperationLexeme<bool>("!", 4, LogicLexemeOperations.Mirror),
            };

            _logicOperations.Sort(new LexemeComparer<bool>());
            _logicLexemeParser = new LogicLexemeParser(_logicOperations);
        }       

        private void InitMatrix()
        {
            var closeTagLexeme = new CloseTagLexeme<Matrix>(")", 1);
            var openTagLexeme = new OpenTagLexeme<Matrix>("(", 1);
            closeTagLexeme.OpenTag = openTagLexeme;
            openTagLexeme.CloseTag = closeTagLexeme;

            _matrixOperations = new List<IOperationLexeme<Matrix>>
            {
                openTagLexeme,
                closeTagLexeme,
                new BinaryOperationLexeme<Matrix>("+", 2, MatrixLexemeOperations.Add),
                new BinaryOperationLexeme<Matrix>("-", 3, MatrixLexemeOperations.Minus),
                new UnaryOperationLexeme<Matrix>("-", 3, MatrixLexemeOperations.Minus),
                new BinaryOperationLexeme<Matrix>("*", 4, MatrixLexemeOperations.Multiply),
                new UnaryOperationLexeme<Matrix>("inv", 5, MatrixLexemeOperations.Invariant)
            };

            _matrixOperations.Sort(new LexemeComparer<Matrix>());
            _matrixLexemeParser = new MatrixLexemeParser(_matrixOperations);
        }

        private void ButtonCalculateMath_Click(object sender, EventArgs e)
        {
            textBoxMathOutput.Clear();
            var text = ReplaceConsts(richTextBoxMathInput.Text.Replace(" ", null));            

            try
            {
                if (checkBoxUseParams.Checked && richTextBoxMathInput.Lines.Length > 1)
                {
                    foreach (var line in richTextBoxMathInput.Lines.Skip(1))
                    {
                        text = ReplaceConsts(richTextBoxMathInput.Lines[0].Replace(" ", null));
                        var parameters = line.Replace(" ", null).Split(';', StringSplitOptions.RemoveEmptyEntries);
                        var pairs = parameters.Select(param => 
                        {
                            var keyValueArr = param.Split('=');
                            return new KeyValuePair<string, string>(keyValueArr[0], keyValueArr[1]);
                        });

                        foreach (var pair in pairs) text = text.Replace(pair.Key, pair.Value);                        

                        var inputLemexes = _mathLexemeParser.Parse(text);
                        var exp = new PostfixExpression<double>(inputLemexes);
                        var result = exp.Calculate();
                        var value = result.Value;
                        textBoxMathOutput.Text += value.ToString(CultureInfo.InvariantCulture) + Environment.NewLine;
                    }                    
                }

                else
                {
                    var inputLemexes = _mathLexemeParser.Parse(text);
                    var exp = new PostfixExpression<double>(inputLemexes);
                    var result = exp.Calculate();
                    var value = result.Value;
                    textBoxMathOutput.Text = value.ToString(CultureInfo.InvariantCulture);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        
        private void button2_Click(object sender, EventArgs e)
        {
            var text = richTextBox2.Text.Replace(" ", null);

            try
            {
                var inputLemexes = _logicLexemeParser.Parse(text);
                var exp = new PostfixExpression<bool>(inputLemexes);
                var result = exp.Calculate();
                var value = result.Value;
                textBox2.Text = value ? "1" : "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var text = ReplaceConsts(richTextBox3.Text);

            try
            {               
                var inputLexemes = _matrixLexemeParser.Parse(text);                
                var exp = new PostfixExpression<Matrix>(inputLexemes);
                var result = exp.Calculate();
                var value = result.Value;
                textBox3.Text = value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckBoxUseParams_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxParameters.Enabled = checkBoxUseParams.Checked;
        }

        private void ButtonMathWithXCalculate_Click(object sender, EventArgs e)
        {

            
        }
    }
}