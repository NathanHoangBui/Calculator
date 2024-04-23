using Calculator.Model;
using Calculator.Services;

namespace Calculator.OperationMethod
{
    public class Subtraction : IOperator
    {
        public double visit(Operation operationNode)
        {
            if (operationNode.Value != null)
            {
                return this.visit(operationNode.Value) - operationNode.currentLevelValue;
            }
            return operationNode.currentLevelValue;
        }

        public double visit(ValueList valueList)
        {
            double result = 0;
            foreach (var value in valueList.getValues())
            {
                result -= value;
            }
            return result;
        }
    }
}
