using System;
using System.Linq;

namespace WpfCalculatorApp
{
    internal class RequaredMethods
    {
        public MainWindow MainWindow { get; set; }
        private static MainWindow _mainWindow;

        public RequaredMethods(MainWindow mainWindow)
            => _mainWindow = mainWindow;

        public void NumberBtnClick(object element)
        {
            _mainWindow.tmpSaver = _mainWindow.tmpSaver.Equals("0") ? $"{element}" : _mainWindow.tmpSaver + element;

            _mainWindow.MainInput2.Text = _mainWindow.tmpSaver.Length >= 11 
                ? _mainWindow.tmpSaver.Substring(_mainWindow.tmpSaver.Length - 11)
                : _mainWindow.tmpSaver;
        }

        public void AddOperator(string element)
        {
            if (!_mainWindow.tmpSaver.EndsWith(" "))
                _mainWindow.tmpSaver += element;

            _mainWindow.MainInput2.Text = _mainWindow.tmpSaver.Length >= 11
                 ? _mainWindow.tmpSaver.Substring(_mainWindow.tmpSaver.Length - 11)
                 : _mainWindow.MainInput2.Text = _mainWindow.tmpSaver;
        }

        public void Clear()
        {
            if (_mainWindow.tmpSaver != "0")
            {
                if (!_mainWindow.tmpSaver.EndsWith(" "))
                    _mainWindow.tmpSaver = _mainWindow.tmpSaver.Remove(_mainWindow.tmpSaver.Length - 1, 1).Length != 0
                        ? _mainWindow.tmpSaver.Remove(_mainWindow.tmpSaver.Length - 1, 1)
                        : "0";

                else if (_mainWindow.tmpSaver[_mainWindow.tmpSaver.Length - 1] == ' ' && 
                            _mainWindow.tmpSaver[_mainWindow.tmpSaver.Length - 3] == ' ')
                                _mainWindow.tmpSaver = _mainWindow.tmpSaver.Remove(_mainWindow.tmpSaver.Length - 3, 3);

                _mainWindow.MainInput2.Text = _mainWindow.tmpSaver.Length >= 11
                 ? _mainWindow.tmpSaver.Substring(_mainWindow.tmpSaver.Length - 11)
                 : _mainWindow.tmpSaver;
            }
        }

        public void Calculate()
        {
            string[] allElements = _mainWindow.tmpSaver.Split(' ');
            decimal result = decimal.Parse(allElements[0]);

            if (!allElements.Contains("/") && !allElements.Contains("*") && !allElements.Contains("%"))
            {
                for (int i = 2; i < allElements.Length; i += 2)
                {
                    switch (allElements[i - 1])
                    {
                        case "+":
                            result += decimal.Parse(allElements[i]);
                                break;

                        case "-":
                            result -= decimal.Parse(allElements[i]);
                                break;

                        default: 
                            break;
                    }
                }
            }

            else if (!(allElements.Contains("-") && allElements.Contains("+")))
            {
                for (int i = 2; i < allElements.Length; i += 2)
                {
                    switch (allElements[i - 1])
                    {
                        case "/":
                            result /= decimal.Parse(allElements[i]);
                                break;

                        case "*":
                            result *= decimal.Parse(allElements[i]);
                                break;

                        case "%":
                            result %= decimal.Parse(allElements[i]);
                                break;

                        default: 
                            break;
                    }
                }
            }

            else 
            {
                int i = 2;
                while (i < allElements.Length)
                {
                    if (allElements[i - 1] == "*" || allElements[i - 1] == "/" || allElements[i - 1] == "%")
                    {
                        switch (allElements[i - 1])
                        {
                            case "*":
                                allElements[i - 2] = (decimal.Parse(allElements[i - 2]) * decimal.Parse(allElements[i])).ToString();
                                break;

                            case "/":
                                if (allElements[i] == "0")
                                {
                                    _mainWindow.MainInput2.Text = "ERROR";
                                    _mainWindow.tmpSaver = "0";
                                    return;
                                }
                                allElements[i - 2] = (decimal.Parse(allElements[i - 2]) / decimal.Parse(allElements[i])).ToString();
                                break;

                            case "%":
                                allElements[i - 2] = (decimal.Parse(allElements[i - 2]) % decimal.Parse(allElements[i])).ToString();
                                break;

                            default: 
                                break;
                        }

                        for (int j = i + 1; j < allElements.Length; j++)
                        {
                            allElements[j - 2] = allElements[j];
                        }

                        Array.Resize(ref allElements, allElements.Length - 2);
                    }
                    else i += 2;
                }

                for (i = 2; i < allElements.Length; i += 2)
                {
                    switch (allElements[i - 1])
                    {
                        case "+":
                            result += decimal.Parse(allElements[i]);
                                break;

                        case "-":
                            result -= decimal.Parse(allElements[i]);
                                break;

                        default: break;
                    }
                }
            }

            _mainWindow.MainInput1.Text = _mainWindow.tmpSaver;
            _mainWindow.MainInput2.Text = result.ToString();
            _mainWindow.tmpSaver = result.ToString();
        }
    }
}