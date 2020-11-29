
namespace Math_Expressions
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxMathInput = new System.Windows.Forms.RichTextBox();
            this.textBoxMathOutput = new System.Windows.Forms.TextBox();
            this.buttonCalculateMath = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMathCalculator = new System.Windows.Forms.TabPage();
            this.checkBoxUseParams = new System.Windows.Forms.CheckBox();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageBooleanCalculator = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPageMatrixCalc = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxMathWithXOutput = new System.Windows.Forms.TextBox();
            this.buttonMathWithXCalculate = new System.Windows.Forms.Button();
            this.richTextBoxMathWithXInput = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageMathCalculator.SuspendLayout();
            this.groupBoxParameters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageBooleanCalculator.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageMatrixCalc.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxMathInput
            // 
            this.richTextBoxMathInput.BackColor = System.Drawing.Color.White;
            this.richTextBoxMathInput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxMathInput.ForeColor = System.Drawing.Color.Black;
            this.richTextBoxMathInput.Location = new System.Drawing.Point(8, 6);
            this.richTextBoxMathInput.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBoxMathInput.Name = "richTextBoxMathInput";
            this.richTextBoxMathInput.Size = new System.Drawing.Size(778, 131);
            this.richTextBoxMathInput.TabIndex = 0;
            this.richTextBoxMathInput.Text = "1+2";
            // 
            // textBoxMathOutput
            // 
            this.textBoxMathOutput.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxMathOutput.Location = new System.Drawing.Point(10, 181);
            this.textBoxMathOutput.Multiline = true;
            this.textBoxMathOutput.Name = "textBoxMathOutput";
            this.textBoxMathOutput.ReadOnly = true;
            this.textBoxMathOutput.Size = new System.Drawing.Size(776, 70);
            this.textBoxMathOutput.TabIndex = 1;
            // 
            // buttonCalculateMath
            // 
            this.buttonCalculateMath.Location = new System.Drawing.Point(341, 146);
            this.buttonCalculateMath.Name = "buttonCalculateMath";
            this.buttonCalculateMath.Size = new System.Drawing.Size(94, 29);
            this.buttonCalculateMath.TabIndex = 2;
            this.buttonCalculateMath.Text = "=";
            this.buttonCalculateMath.UseVisualStyleBackColor = true;
            this.buttonCalculateMath.Click += new System.EventHandler(this.ButtonCalculateMath_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMathCalculator);
            this.tabControl1.Controls.Add(this.tabPageBooleanCalculator);
            this.tabControl1.Controls.Add(this.tabPageMatrixCalc);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageMathCalculator
            // 
            this.tabPageMathCalculator.Controls.Add(this.checkBoxUseParams);
            this.tabPageMathCalculator.Controls.Add(this.groupBoxParameters);
            this.tabPageMathCalculator.Controls.Add(this.groupBox1);
            this.tabPageMathCalculator.Controls.Add(this.richTextBoxMathInput);
            this.tabPageMathCalculator.Controls.Add(this.textBoxMathOutput);
            this.tabPageMathCalculator.Controls.Add(this.buttonCalculateMath);
            this.tabPageMathCalculator.Location = new System.Drawing.Point(4, 29);
            this.tabPageMathCalculator.Name = "tabPageMathCalculator";
            this.tabPageMathCalculator.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMathCalculator.Size = new System.Drawing.Size(792, 417);
            this.tabPageMathCalculator.TabIndex = 0;
            this.tabPageMathCalculator.Text = "Math Calculator";
            this.tabPageMathCalculator.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseParams
            // 
            this.checkBoxUseParams.AutoSize = true;
            this.checkBoxUseParams.Location = new System.Drawing.Point(641, 149);
            this.checkBoxUseParams.Name = "checkBoxUseParams";
            this.checkBoxUseParams.Size = new System.Drawing.Size(134, 24);
            this.checkBoxUseParams.TabIndex = 0;
            this.checkBoxUseParams.Text = "Use parameters";
            this.checkBoxUseParams.UseVisualStyleBackColor = true;
            this.checkBoxUseParams.CheckedChanged += new System.EventHandler(this.CheckBoxUseParams_CheckedChanged);
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.label6);
            this.groupBoxParameters.Controls.Add(this.label7);
            this.groupBoxParameters.Controls.Add(this.label5);
            this.groupBoxParameters.Controls.Add(this.label4);
            this.groupBoxParameters.Enabled = false;
            this.groupBoxParameters.Location = new System.Drawing.Point(264, 257);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(520, 157);
            this.groupBoxParameters.TabIndex = 4;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Exmaple with Parameters";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(291, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 36);
            this.label6.TabIndex = 3;
            this.label6.Text = "4.4\r\n0.5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(221, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "Output:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(68, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 54);
            this.label5.TabIndex = 1;
            this.label5.Text = "2*a+b\r\na = 2.2; b = 0\r\na = 1; b = -1.5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Input:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(8, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 157);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allowed Operations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 126);
            this.label1.TabIndex = 0;
            this.label1.Text = "+\r\n-\r\n*\r\n/\r\n^\r\ncos([expression])\r\nsin([expression])";
            // 
            // tabPageBooleanCalculator
            // 
            this.tabPageBooleanCalculator.Controls.Add(this.groupBox2);
            this.tabPageBooleanCalculator.Controls.Add(this.richTextBox2);
            this.tabPageBooleanCalculator.Controls.Add(this.textBox2);
            this.tabPageBooleanCalculator.Controls.Add(this.button2);
            this.tabPageBooleanCalculator.Location = new System.Drawing.Point(4, 29);
            this.tabPageBooleanCalculator.Name = "tabPageBooleanCalculator";
            this.tabPageBooleanCalculator.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBooleanCalculator.Size = new System.Drawing.Size(792, 417);
            this.tabPageBooleanCalculator.TabIndex = 1;
            this.tabPageBooleanCalculator.Text = "Boolean Calculator";
            this.tabPageBooleanCalculator.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(7, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 196);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allowed Operations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 66);
            this.label2.TabIndex = 0;
            this.label2.Text = "/\\ - logic AND\r\n\\/ - logic OR\r\n! - mirror value";
            this.label2.UseMnemonic = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.White;
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox2.ForeColor = System.Drawing.Color.Black;
            this.richTextBox2.Location = new System.Drawing.Point(7, 5);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(778, 131);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "1 /\\ 0";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(9, 177);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(776, 34);
            this.textBox2.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "=";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPageMatrixCalc
            // 
            this.tabPageMatrixCalc.Controls.Add(this.groupBox3);
            this.tabPageMatrixCalc.Controls.Add(this.textBox3);
            this.tabPageMatrixCalc.Controls.Add(this.button3);
            this.tabPageMatrixCalc.Controls.Add(this.richTextBox3);
            this.tabPageMatrixCalc.Location = new System.Drawing.Point(4, 29);
            this.tabPageMatrixCalc.Name = "tabPageMatrixCalc";
            this.tabPageMatrixCalc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMatrixCalc.Size = new System.Drawing.Size(792, 417);
            this.tabPageMatrixCalc.TabIndex = 2;
            this.tabPageMatrixCalc.Text = "Matrix Calculator";
            this.tabPageMatrixCalc.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(8, 276);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(778, 133);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Allowed Operations";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(15, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 88);
            this.label3.TabIndex = 0;
            this.label3.Text = "+\r\n-\r\n*\r\ninv([matrix])";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(8, 179);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(776, 91);
            this.textBox3.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(339, 144);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "=";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.White;
            this.richTextBox3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox3.ForeColor = System.Drawing.Color.Black;
            this.richTextBox3.Location = new System.Drawing.Point(8, 6);
            this.richTextBox3.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(778, 131);
            this.richTextBox3.TabIndex = 1;
            this.richTextBox3.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.textBoxMathWithXOutput);
            this.tabPage1.Controls.Add(this.buttonMathWithXCalculate);
            this.tabPage1.Controls.Add(this.richTextBoxMathWithXInput);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 417);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(8, 300);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(776, 109);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(443, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 3;
            this.label11.Text = "5x^2 + 25";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(443, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "5*(x^2+5)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(306, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "Output Example:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(314, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Input Example:";
            // 
            // textBoxMathWithXOutput
            // 
            this.textBoxMathWithXOutput.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxMathWithXOutput.Location = new System.Drawing.Point(8, 224);
            this.textBoxMathWithXOutput.Multiline = true;
            this.textBoxMathWithXOutput.Name = "textBoxMathWithXOutput";
            this.textBoxMathWithXOutput.ReadOnly = true;
            this.textBoxMathWithXOutput.Size = new System.Drawing.Size(776, 70);
            this.textBoxMathWithXOutput.TabIndex = 3;
            // 
            // buttonMathWithXCalculate
            // 
            this.buttonMathWithXCalculate.Location = new System.Drawing.Point(340, 190);
            this.buttonMathWithXCalculate.Name = "buttonMathWithXCalculate";
            this.buttonMathWithXCalculate.Size = new System.Drawing.Size(94, 29);
            this.buttonMathWithXCalculate.TabIndex = 4;
            this.buttonMathWithXCalculate.Text = "=";
            this.buttonMathWithXCalculate.UseVisualStyleBackColor = true;
            this.buttonMathWithXCalculate.Click += new System.EventHandler(this.ButtonMathWithXCalculate_Click);
            // 
            // richTextBoxMathWithXInput
            // 
            this.richTextBoxMathWithXInput.Location = new System.Drawing.Point(8, 6);
            this.richTextBoxMathWithXInput.Name = "richTextBoxMathWithXInput";
            this.richTextBoxMathWithXInput.Size = new System.Drawing.Size(776, 179);
            this.richTextBoxMathWithXInput.TabIndex = 0;
            this.richTextBoxMathWithXInput.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Postfix with Abstractions";
            this.tabControl1.ResumeLayout(false);
            this.tabPageMathCalculator.ResumeLayout(false);
            this.tabPageMathCalculator.PerformLayout();
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageBooleanCalculator.ResumeLayout(false);
            this.tabPageBooleanCalculator.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageMatrixCalc.ResumeLayout(false);
            this.tabPageMatrixCalc.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMathInput;
        private System.Windows.Forms.TextBox textBoxMathOutput;
        private System.Windows.Forms.Button buttonCalculateMath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMathCalculator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPageBooleanCalculator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPageMatrixCalc;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.CheckBox checkBoxUseParams;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBoxMathWithXInput;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxMathWithXOutput;
        private System.Windows.Forms.Button buttonMathWithXCalculate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}

