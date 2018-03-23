using System;
using CalculatorTests.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorUIAutomationTests
    {        
        [TestMethod]
        public void TypeRandomNumber()
        {
            using (Calculator calc = new Calculator())
            {
                int number = new Random().Next(100, 10000);
                string stringRep = number.ToString();
                calc.Result = stringRep;
                Assert.AreEqual(stringRep, calc.Result);
            }
        }

        [TestMethod]
        public void VerifyExpressionTrees()
        {
            string[] files = new[] 
            { 
                "CalculatorTests.Resources.SimpleNumberOperator.xml",
                "CalculatorTests.Resources.SimpleAdditionOperator.xml",
                "CalculatorTests.Resources.MixedOperators.xml"
            };

            using (Calculator calc = new Calculator())
            {
                foreach (string file in files)
                {
                    calc.Clear();
                    IOperand expression = LoadExpressionTreeFromFile(file);
                    Assert.AreEqual(expression.Evaluate(EvaluateOption.ActualEvaluate, calc), expression.Evaluate(EvaluateOption.UIEvaluate, calc));
                }
            }
        }

        [TestMethod]
        public void VerifyCopyPaste()
        {            
            using (Calculator calc = new Calculator())
            {
                string stringRep = new Random().Next(100, 10000).ToString();                
                calc.Result = stringRep;

                calc.OpenMenu(Calculator.CalculatorMenu.Edit);
                calc.ExecuteMenuByName("Copy");

                calc.Clear();

                calc.OpenMenu(Calculator.CalculatorMenu.Edit);
                calc.ExecuteMenuByName("Paste");

                Assert.AreEqual(stringRep, calc.Result);
            }
        }

        private IOperand LoadExpressionTreeFromFile(string resourceFileName)
        {            
            return ExpressionTree.CreateTree(this.GetType().Assembly.GetManifestResourceStream(resourceFileName));
        }
    }    
}
