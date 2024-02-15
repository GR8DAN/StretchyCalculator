using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StretchyCalculator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool hasPeriod = false; //stops more than one period being typed
        bool newNumber = false; //flag new number entry
        ICalculatorEngine calculator = new Calculator();   //Does the math
        float operand1 = float.NaN;   //First number (A), using NaN to indicate empty
        float operand2 = float.NaN;   //Second number (B)
        float lastOperand = float.NaN;   //Store operand for equal presses
        string lastOperation = String.Empty;   //Store operation for equal presses
        Button operation = null; //Store currently selected operator
        //For error messages
        string errorMessageNaN = "Please enter a valid number.";
        string errorValue = "An error occurred, try a different value." + Environment.NewLine + "The error reported was: ";
        string errorTitle = "Calculation Error";

        //Limit MainWindow creation (Singleton)
        //store the one instance
        private static MainWindow instance;
        //Return the Window instance
        public static MainWindow Instance
        {
            get
            {
                return instance;
            }
            //no set can only get one instance
        }
        //The static constructor to set up instance
        static MainWindow()
        {
            instance = new MainWindow();
        }
        //Private constructor (actually does work to create window)
        private MainWindow()
        {
            InitializeComponent();
        }
        

        #region Some keyboard handling to restrict illegal chars (pasted chars handled in exception processing)
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for keyboard number.
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                // Check for keypad number.
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    // Check for backspace and period.
                    if (e.Key != Key.Back && e.Key != Key.OemPeriod)
                    {
                        // Mustn't be a valid key.
                        e.Handled = true;
                    }
                    else if (e.Key == Key.OemPeriod && hasPeriod)
                        // Only one period.
                        e.Handled = true;
                }
            }
             
            //If shift pressed, it's not a number.
            if (((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift))
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox1.Text.IndexOf(".") >= 0)
                hasPeriod = true;
            else
                hasPeriod = false;
        }
        #endregion

        #region Handle Button clicks
        //Called when an operator button clicked
        private void operation_Click(object sender, RoutedEventArgs e)
        {
            //only act if we have something to act on
            if (textBox1.Text.Length > 0)
            {
                //Grab button clicked (requested operation stored for when equals pressed to determine calc to perform)
                operation = (Button)sender;
                //current displayed value becomes first operand
                if (float.TryParse(textBox1.Text, out operand1))
                    //and we start accepting another number
                    newNumber = true;
                else
                    //bad number (probably pasted in), tell user
                    MessageBox.Show(errorMessageNaN, errorTitle,MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //see if minus button pressed (could be entering a negative number first)
                if(((string)((Button)sender).Content).Equals("-"))
                    textBox1.Text += "-";
            }
        }

        //Called when digit clicked
        private void number_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber)
            {
                //operation was pressed, start a new number
                textBox1.Text = String.Empty;
                newNumber = false;
            }
            //Called when a number button clicked
            textBox1.Text += (string)((Button)sender).Content;
        }

        //Called on period press
        private void period_Click(object sender, RoutedEventArgs e)
        {
            //Called when a period button clicked
            if(!hasPeriod)
                //only allow one period
                textBox1.Text += (string)((Button)sender).Content;
        }

        //Called on sqrt press
        private void sqrt_Click(object sender, RoutedEventArgs e)
        {
            //only act if we have something to act on
            if(textBox1.Text.Length>0)
                //currently displayed value becomes operand for sqrt
                if (float.TryParse(textBox1.Text, out operand1))
                    //perform the math
                    try
                    {
                        textBox1.Text = calculator.sqrt(operand1).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(errorValue + ex.Message, errorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                else
                    MessageBox.Show(errorMessageNaN, errorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //Called on equal button (show operation result)
        private void equals_Click(object sender, RoutedEventArgs e)
        {
            //need a operation to perform a calc
            if (operation != null)
                //current displayed value (if we have one) becomes 2nd operand
                if(textBox1.Text.Length>0)
                    //check it's a number (displays error message if not)
                    if (float.TryParse(textBox1.Text, out operand2))
                    {
                        //previously selected operation
                        string op = (string)operation.Content;
                        //Are they just pressing equals again, if so repeat previous action
                        if (op.Equals("="))
                        {
                            op = lastOperation;
                            operand1 = operand2;
                            operand2 = lastOperand;
                        }
                        //perform the math
                        try
                        {
                            //which operation
                            switch (op)
                            {
                                case "/":
                                    textBox1.Text = calculator.Divide(operand1, operand2).ToString();
                                    lastOperation = "/";
                                    break;
                                case "*":
                                    textBox1.Text = calculator.Multiply(operand1, operand2).ToString();
                                    lastOperation = "*";
                                    break;
                                case "-":
                                    textBox1.Text = calculator.Subtract(operand1, operand2).ToString();
                                    lastOperation = "-";
                                    break;
                                case "+":
                                    textBox1.Text = calculator.Add(operand1, operand2).ToString();
                                    lastOperation = "+";
                                    break;
                            }
                            //store state for next action incase equals pressed again
                            lastOperand=operand2;
                            //ready for new number
                            newNumber = true;
                            //equals was last pressed
                            operation = (Button)sender; 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(errorValue + ex.Message, errorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                        MessageBox.Show(errorMessageNaN, errorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            
        }
        #endregion
    }
}
