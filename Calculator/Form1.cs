using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region buttons
        private void AddOne(object sender, EventArgs e)
        {
            textBox1.Text += "1"; 
        }

        private void AddTwo(object sender, EventArgs e)
        {
            textBox1.Text += "2"; 
        }

        private void AddThree(object sender, EventArgs e)
        {
            textBox1.Text += "3"; 
        }

        private void AddFour(object sender, EventArgs e)
        {
            textBox1.Text += "4"; 
        }

        private void AddFive(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void AddSix(object sender, EventArgs e)
        {
            textBox1.Text += "6"; 
        }

        private void AddSeven(object sender, EventArgs e)
        {
            textBox1.Text += "7"; 
        }

        private void AddEight(object sender, EventArgs e)
        {
            textBox1.Text += "8"; 
        }

        private void AddNine(object sender, EventArgs e)
        {
            textBox1.Text += "9"; 
        }

        private void AddZero(object sender, EventArgs e)
        {
            textBox1.Text += "0"; 
        }

        private void AddLeftParenthesis(object sender, EventArgs e)
        {
            textBox1.Text += "("; 
        }

        private void AddRightParenthesis(object sender, EventArgs e)
        {
            textBox1.Text += ")"; 
        }
        #region Plus,Minus,Multiply,Substract
        private void AddPlus(object sender, EventArgs e)
        {
            textBox1.Text += "+";

            if (CheckNextSymbol(textBox1.Text) == true)
            {
                textBox1.Text = RemoveDuplicate(textBox1.Text);
            }
        }

        private void AddMinus(object sender, EventArgs e)
        {
            textBox1.Text += "-";

            if (CheckNextSymbol(textBox1.Text) == true)
            {
                textBox1.Text = RemoveDuplicate(textBox1.Text);    
            }
        }

        private void AddMultiply(object sender, EventArgs e)
        {
            textBox1.Text += "*";

            if (CheckNextSymbol(textBox1.Text) == true)
            {
                textBox1.Text = RemoveDuplicate(textBox1.Text);
            }
        }

        private void AddSubstract(object sender, EventArgs e)
        {
            textBox1.Text += "/";

            if (CheckNextSymbol(textBox1.Text) == true)
            {
                textBox1.Text = RemoveDuplicate(textBox1.Text);
            }
        }
        #endregion
        #endregion

        private void Clear(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty; 
        }

        private void Eaqual(object sender, EventArgs e)
        {
            StringAnalyze analyze = new StringAnalyze(textBox1.Text);
            textBox1.Text = analyze.GetResult(); 
        }

        private bool CheckNextSymbol(string value)
        {
            for(int i = 0; i < value.Length - 1; i++)
            {
                if (value[i].CompareTo(value[i + 1]) == 0)
                {
                    return true; 
                }
            }
            return false; 
        }

        private static string RemoveDuplicate(string value)
        {
            var charValue = value.ToString();
            List<char> symbols = new List<char>();
            symbols.AddRange(charValue);

            for (int i = 0; i < symbols.Count - 1; i++)
            {
                if (symbols[i] == symbols[i + 1])
                {
                    symbols.Remove(symbols[i + 1]);
                }
            }

            return new string(symbols.ToArray());
        }
    }
}
