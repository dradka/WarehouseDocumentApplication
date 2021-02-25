using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseDocumentApplication.Utils
{
    public class NumberTextBox : TextBox
    {
        private readonly string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        private readonly string groupSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
        public int DecimalCount { get; set; }
        private bool textChanging = false;
        public NumberTextBox()
        {
            KeyPress += new KeyPressEventHandler(TextBoxWithMask_KeyPress);
            TextChanged += new EventHandler(TextBoxWithMask_TextChanged);
            KeyDown += new KeyEventHandler(TextBoxWithMask_KeyDown);
        }

        private void TextBoxWithMask_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t != null)
            {
                if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && t.SelectionLength > 0
                    && t.SelectionStart <= t.Text.IndexOf(decimalSeparator)
                    && t.SelectionStart + t.SelectionLength < t.Text.Length
                    && t.SelectionStart + t.SelectionLength > t.Text.IndexOf(decimalSeparator))              
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    return;
                }
                if (e.KeyCode == Keys.Back && t.SelectionStart > 0
                    && t.Text.Substring(t.SelectionStart - 1, 1) == decimalSeparator)
                {
                    t.SelectionStart--;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    return;
                }
                if (e.KeyCode == Keys.Delete && t.SelectionStart < t.Text.Length
                    && t.Text.Substring(t.SelectionStart, 1) == decimalSeparator)
                {
                    t.SelectionStart++;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    return;
                }
                if (e.KeyCode == Keys.Back && t.SelectionStart > 0
                    && t.Text.Substring(t.SelectionStart - 1, 1) == groupSeparator)
                {
                    t.SelectionStart--;
                    return;
                }
                if (e.KeyCode == Keys.Delete && t.SelectionStart < t.Text.Length
                    && (t.Text.Substring(t.SelectionStart, 1) == groupSeparator))
                {
                    t.SelectionStart++;
                    return;
                }
            }
        }

        private void TextBoxWithMask_TextChanged(object sender, EventArgs e)
        {
            if (!textChanging)
            {
                textChanging = true;
                TextBox t = sender as TextBox;
                string text = t.Text.Replace(groupSeparator, string.Empty);
                if (t != null)
                {
                    string textValue = string.IsNullOrEmpty(text) ? "0" : text;
                    int cursorPosition = DigitOrDecimalSeparatorCount(t.Text.Substring(0, t.SelectionStart));
                    if (DecimalCount == 0 && int.TryParse(textValue, out int result))
                    {
                        t.Text = result.ToString("n0").Trim();
                    }
                    else if (DecimalCount > 0 && decimal.TryParse(textValue, out decimal result2))
                    {
                        t.Text = result2.ToString("n" + DecimalCount).Trim();
                    }

                    t.SelectionStart = positionOfDigitOrDecimalSeparator(t.Text, cursorPosition);
                }
                textChanging = false;
            }
        }

        private void TextBoxWithMask_KeyPress(object sender, KeyPressEventArgs e)
        {
            textChanging = true;
            TextBox t = sender as TextBox;
            if (t != null)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                    && (e.KeyChar.ToString() != decimalSeparator))
                {
                    e.Handled = true;
                    return;
                }
                if (char.IsDigit(e.KeyChar))
                {
                    if (e.KeyChar == '0' && t.SelectionStart == 0 && t.SelectionLength < t.Text.Length)
                    {
                        if(DecimalCount == 0 || (DecimalCount > 0 
                            && t.SelectionLength < t.Text.IndexOf(decimalSeparator)))
                        {
                            t.Text = t.Text.Substring(t.SelectionLength);
                            t.SelectionStart = 0;
                            e.Handled = true;
                            return;
                        }    
                    }
                    if(DecimalCount == 0)
                    {
                        if(t.Text == "0")
                        {
                            int selectionStart = t.SelectionStart;
                            t.Text = e.KeyChar.ToString();
                            t.SelectionStart = selectionStart + 1;
                            e.Handled = true;
                            return;
                        }
                    }
                    if (DecimalCount > 0)
                    {
                        if (t.SelectionStart == t.Text.Length)
                        {
                            e.Handled = true;
                            return;
                        }
                        if (t.SelectionLength == 0)
                        {
                            if (t.SelectionStart == 0 && t.Text.Substring(0, t.Text.IndexOf(decimalSeparator)) == "0")
                            {
                                int selectionStart = t.SelectionStart;
                                t.Text = e.KeyChar.ToString() + t.Text.Substring(t.Text.IndexOf(decimalSeparator));
                                t.SelectionStart = selectionStart + 1;
                                e.Handled = true;
                                return;
                            }
                            if (t.SelectionStart > t.Text.IndexOf(decimalSeparator)
                                && t.SelectionStart < t.Text.Length && t.Text.Substring(t.SelectionStart, 1) == "0")
                            {
                                int selectionStart = t.SelectionStart;
                                t.Text = t.Text.Substring(0, t.SelectionStart) +
                                    e.KeyChar.ToString() + t.Text.Substring(t.SelectionStart + 1);
                                t.SelectionStart = selectionStart + 1;
                                e.Handled = true;
                                return;
                            }
                        }
                        else if(t.SelectionStart <= t.Text.IndexOf(decimalSeparator) 
                                && t.SelectionStart + t.SelectionLength < t.Text.Length
                                && t.SelectionStart + t.SelectionLength > t.Text.IndexOf(decimalSeparator))
                        {
                            e.Handled = true;
                            return;
                        }
                    }                  
                }
                if (e.KeyChar.ToString() == decimalSeparator)
                {
                    if (DecimalCount == 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (t.Text.Substring(t.SelectionStart, 1) == decimalSeparator)
                    {
                        t.SelectionStart++;
                        e.Handled = true;
                        return;
                    }
                    if (t.Text.IndexOf(decimalSeparator) > -1)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            textChanging = false;
        }

        private int positionOfDigitOrDecimalSeparator(string text, int index)
        {
            int counter = 0;
            int position = -1;
            for (int i = 0; i < text.Length && position == -1; i++)
            {
                if (char.IsDigit(text[i]) || text[i].ToString() == decimalSeparator)
                {
                    if (counter == index)
                        position = i;
                    counter++;
                }
            }
            if (counter == index)
                return text.Length;
            return position;
        }

        private int DigitOrDecimalSeparatorCount(string text)
        {
            int counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]) || text[i].ToString() == decimalSeparator)
                    counter++;
            }
            return counter;
        }


    }
}
