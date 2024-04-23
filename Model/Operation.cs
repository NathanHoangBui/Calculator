using Calculator.Services;

namespace Calculator.Model
{
    public class Operation : IOperand
    {
        public string ID { get; set; }
        public ValueList Value { get; set; }
        public double currentLevelValue { get; set; }

        public Operation(string ID, ValueList Value, double currentLevelValue)
        {
            this.ID = ID;
            this.Value = Value;
       
            this.currentLevelValue = currentLevelValue;
        }
        // Empty Constructor 
        public Operation()
        {

        }

        public double Accept(IOperator visitor)
        {
            return visitor.visit(this);
        }

        // Getter and Setter
        public string GetID()
        {
            return ID;
        }
        public void SetID(string ID)
        {
            this.ID = ID;
        }
        public ValueList GetValue()
        {
            return Value;
        }
        public double GetCurrentLevelValue()
        {
            return currentLevelValue;
        }
        public void SetCurrentLevelValue(double currentLevelValue)
        {
            this.currentLevelValue = currentLevelValue;
        }
        public void SetValue(ValueList Value)
        {
            this.Value = Value;
        }


    }
}
