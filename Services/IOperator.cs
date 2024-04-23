using Calculator.Model;

namespace Calculator.Services
{
    public interface IOperator
    {
        public double visit(Operation operationNode);
        public double visit(ValueList valueList);

    }
}
