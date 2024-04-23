using Calculator.Model;
using Calculator.Services;

namespace Calculator.OperationMethod
{
    public class Multiplication : IOperator
    {
        public double visit(Operation operationNode)
        {
            double result = 1;
            if (operationNode.Value != null)
            {
                result *= this.visit(operationNode.Value);
            }
            if (operationNode.currentLevelValue != 0)
                result *= operationNode.currentLevelValue;
            return result;
        }

        public double visit(ValueList valueList)
        {
            double result = 1;
            foreach (var value in valueList.getValues())
            {
                result *= value;
            }
            return result;
        }
    }
}
