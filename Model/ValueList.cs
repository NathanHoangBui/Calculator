using Calculator.Services;

namespace Calculator.Model
{
    public class ValueList : IOperand
    {
        private List<double> values;

        public ValueList()
        {
            values = new List<double>();
        }
        
        public ValueList(List<double> values)
        {
            this.values = values;
        }

        public double Accept(IOperator visitor)
        {
            return visitor.visit(this);
        }

        // getter and setter
        public List<double> getValues()
        {
            return values;
        }
        public void setValues(List<double> values)
        {
            this.values = values;
        }


        //public void accept(Operator visitor)
        //{
        //    visitor.visit(this);
        //}
    }
}
