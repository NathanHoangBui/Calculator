namespace Calculator.Model
{
    public class Maths
    {
        public Operation Operation { get; set; }

        public Maths(Operation operation)
        {
            Operation = operation;
        }

        public Maths()
        {

        }
    }
}
