using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SoftCalculator
{
    public partial class MainWindow : Window
    {
        private string currentInput = "0";
        private string previousInput = "";
        private string operation = "";
        private bool newInput = true;
        private bool operationPending = false;

        public MainWindow()
        {
            InitializeComponent();
            Display.Text = currentInput;
        }

        private void AnimateButton(Button button)
        {
            button.RenderTransform = new ScaleTransform();
            Storyboard animation = (Storyboard)FindResource("SoftClickAnimation");
            animation.Begin(button);
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            AnimateButton((Button)sender);

            Button button = (Button)sender;
            string number = button.Content.ToString();

            if (currentInput == "0" || newInput)
            {
                currentInput = number;
                newInput = false;
                operationPending = false;
            }
            else
            {
                currentInput += number;
            }

            Display.Text = currentInput;
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            AnimateButton((Button)sender);

            if (!currentInput.Contains("."))
            {
                if (newInput)
                {
                    currentInput = "0.";
                    newInput = false;
                }
                else
                {
                    currentInput += ".";
                }
                Display.Text = currentInput;
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            AnimateButton((Button)sender);

            Button button = (Button)sender;
            string newOperation = button.Content.ToString();

            if (!operationPending)
            {
                if (!string.IsNullOrEmpty(operation))
                {
                    Calculate();
                }
                else
                {
                    previousInput = currentInput;
                }
            }

            operation = newOperation;
            newInput = true;
            operationPending = true;
            HistoryText.Text = $"{previousInput} {operation}";
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            AnimateButton((Button)sender);

            if (!string.IsNullOrEmpty(operation) && !operationPending)
            {
                Calculate();
                operation = "";
                HistoryText.Text = "";
            }
        }

        private void Calculate()
        {
            try
            {
                double prev = double.Parse(previousInput);
                double current = double.Parse(currentInput);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = prev + current;
                        break;
                    case "-":
                        result = prev - current;
                        break;
                    case "×":
                        result = prev * current;
                        break;
                    case "/":
                        if (current != 0)
                            result = prev / current;
                        else
                            currentInput = "Ошибка";
                        break;
                }

                if (currentInput != "Ошибка")
                {
                    previousInput = result.ToString();
                    currentInput = result.ToString();
                    Display.Text = currentInput;
                }
                else
                {
                    Display.Text = currentInput;
                }

                newInput = true;
            }
            catch
            {
                currentInput = "Ошибка";
                Display.Text = currentInput;
                newInput = true;
            }
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            AnimateButton((Button)sender);

            if (double.TryParse(currentInput, out double number) && number >= 0)
            {
                currentInput = Math.Sqrt(number).ToString();
                Display.Text = currentInput;
                newInput = true;
            }
            else
            {
                currentInput = "Ошибка";
                Display.Text = currentInput;
                newInput = true;
            }
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            AnimateButton((Button)sender);

            if (currentInput.Length > 1)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                Display.Text = currentInput;
            }
            else
            {
                currentInput = "0";
                Display.Text = currentInput;
                newInput = true;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            AnimateButton((Button)sender);

            currentInput = "0";
            previousInput = "";
            operation = "";
            newInput = true;
            operationPending = false;
            Display.Text = currentInput;
            HistoryText.Text = "";
        }
    }
}