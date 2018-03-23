using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using CalculatorTests.Abstract;
using CalculatorTests.Interfaces;

namespace CalculatorTests
{
    internal static class ExpressionTree
    {
        internal static IOperand CreateTree(Stream stream)
        {
            XDocument doc = XDocument.Load(stream);
            return CreateOperend(doc.Root);
        }

        private static IOperand CreateOperend(XElement operandElement)
        {
            XAttribute type = operandElement.Attribute("Type");

            IOperand operand = null;

            switch (type.Value)
            {
                case "NumberOperator":
                    operand = new NumberOperator(int.Parse(operandElement.Attribute("Value").Value));
                    break;

                default:
                    string qualifyingName = "CalculatorTests." + type.Value;
                    operand = Activator.CreateInstance(Type.GetType(qualifyingName)) as IOperand;

                    List<XNode> childNodes = new List<XNode>(operandElement.Nodes());

                    if (operand is BinaryOperator)
                    {
                        BinaryOperator binaryOperator = operand as BinaryOperator;
                        binaryOperator.Left = CreateOperend(childNodes[0] as XElement);
                        binaryOperator.Right = CreateOperend(childNodes[1] as XElement);
                    }
                    else if (operand is UnaryOperator)
                    {
                        UnaryOperator unaryOperator = operand as UnaryOperator;
                        unaryOperator.Operand = CreateOperend(childNodes[0] as XElement);
                    }
                    break;
            }

            return operand;
        }
    }
}
