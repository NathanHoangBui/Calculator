using Calculator.Model;
using Calculator.Services;

namespace Calculator.OperationMethod
{
    public class Addition : IOperator
    {
        public double visit(Operation operationNode)
        {
            double result = 0;
            if (operationNode.Value != null)
            {
                result += this.visit(operationNode.Value);
            }
            result += operationNode.currentLevelValue;
            return result;
        }

        public double visit(ValueList valueList)
        {
            // Add all the element in valueList
            double result = 0;
            foreach (var value in valueList.getValues())
            {
                result += value;
            }
            return result;
        }
    }
}
