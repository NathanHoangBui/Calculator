using Calculator.Model;
using Calculator.OperationMethod;
using System.Text.Json.Nodes;

namespace Calculator.Services
{
    public class CalculateServices
    {
        private JsonParser jsonParser;
        private LinkedList<Operation> operations;
        
        public CalculateServices()
        {
            jsonParser = new JsonParser();
        }

        public double ProcessRequest(JsonObject inputData)
        {
            if (inputData.ContainsKey("Maths"))
            {
                JsonObject mathsObject = (JsonObject)inputData["Maths"];

                // Parser JSON 
                LinkedList<Operation> parsedData = jsonParser.ParseJson(mathsObject);
                // Calculate The Values of parsedData
                LinkedListNode<Operation> CurrentNode = parsedData.Last;
                // Traverse the linked list from end to start and calculate the values
                while (CurrentNode != null)
                {
                    double CurrentNodeResult = 0;
                    switch(CurrentNode.Value.ID)
                    {
                        case "Plus":
                            CurrentNodeResult = CurrentNode.Value.Accept(new Addition());
                            break;
                        case "Subtraction":
                            CurrentNodeResult = CurrentNode.Value.Accept(new Subtraction());
                            break;
                        case "Multiplication":
                            CurrentNodeResult = CurrentNode.Value.Accept(new Multiplication());
                            break;
                        case "Division":
                            CurrentNodeResult = CurrentNode.Value.Accept(new Division());
                            break;
                        default:
                            break;
                    }   
                    if (CurrentNode.Previous != null)
                    {
                        CurrentNode.Previous.Value.currentLevelValue = CurrentNodeResult;
                        CurrentNode = CurrentNode.Previous;
                    }
                    else
                    {
                        return CurrentNodeResult;
                    }

                }
            }
            return 0.0;
        }
    }
}
