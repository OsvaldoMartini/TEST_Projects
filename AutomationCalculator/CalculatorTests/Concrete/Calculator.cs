using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace CalculatorTests
{
    public class Calculator : IDisposable
    {
        public enum CalculatorMenu
        {
            View,
            Edit,
            Help
        }

        public Calculator()
        {
            _calculatorProcess = Process.Start("Calc.exe");

            int ct = 0;
            do
            {
                _calculatorAutomationElement = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Calculator"));
                ++ct;
                Thread.Sleep(100);
            } 
            while (_calculatorAutomationElement == null && ct < 50);

            if (_calculatorAutomationElement == null)
            {
                throw new InvalidOperationException("Calculator must be running");
            }

            _resultTextBoxAutomationElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "150"));

            if (_resultTextBoxAutomationElement == null)
            {
                throw new InvalidOperationException("Could not find result box");
            }

            GetInvokePattern(GetFunctionButton(Functions.Clear)).Invoke();
        }

        public void OpenMenu(CalculatorMenu menu)
        {
            ExpandCollapsePattern expPattern = FindMenu(menu);
            expPattern.Expand();
        }

        public void CloseMenu(CalculatorMenu menu)
        {
            ExpandCollapsePattern expPattern = FindMenu(menu);
            expPattern.Collapse();
        }

        public void ExecuteMenuByName(string menuName)
        {
            AutomationElement menuElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, menuName));
            if (menuElement == null)
            {
                return;
            }

            InvokePattern invokePattern = menuElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (invokePattern != null)
            {
                invokePattern.Invoke();
            }
        }

        public void Dispose()
        {
            _calculatorProcess.CloseMainWindow();
            _calculatorProcess.Dispose();
        }

        public object Result
        {
            get
            {
                return _resultTextBoxAutomationElement.GetCurrentPropertyValue(AutomationElement.NameProperty);
            }
            set
            {
                string stringRep = value.ToString();

                for (int index = 0; index < stringRep.Length; index++)
                {
                    int leftDigit = int.Parse(stringRep[index].ToString());

                    GetInvokePattern(GetDigitButton(leftDigit)).Invoke();
                }
            }
        }

        public void Evaluate()
        {
            InvokeFunction(Functions.Equals);
        }

        public void Clear()
        {
            InvokeFunction(Functions.Clear);
        }

        public void InvokeFunction(string functionName)
        {
            GetInvokePattern(GetFunctionButton(functionName)).Invoke();
        }

        public InvokePattern GetInvokePattern(AutomationElement element)
        {
            return element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        }

        public AutomationElement GetFunctionButton(string functionName)
        {
            AutomationElement functionButton = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, functionName));

            if (functionButton == null)
            {
                throw new InvalidOperationException("No function button found with name: " + functionName);
            }

            return functionButton;
        }

        public AutomationElement GetDigitButton(int number)
        {
            if ((number < 0) || (number > 9))
            {
                throw new InvalidOperationException("mumber must be a digit 0-9");
            }

            AutomationElement buttonElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, number.ToString()));

            if (buttonElement == null)
            {
                throw new InvalidOperationException("Could not find button corresponding to digit" + number);
            }

            return buttonElement;
        }

        private ExpandCollapsePattern FindMenu(CalculatorMenu menu)
        {
            AutomationElement menuElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, menu.ToString()));
            ExpandCollapsePattern expPattern = menuElement.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            return expPattern;
        }

        private AutomationElement _calculatorAutomationElement;
        private AutomationElement _resultTextBoxAutomationElement;
        private Process _calculatorProcess;                
    }
}
