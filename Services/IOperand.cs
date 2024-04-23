namespace Calculator.Services
{
    public interface IOperand
    {
        public double Accept(IOperator visitor);
    }
}
