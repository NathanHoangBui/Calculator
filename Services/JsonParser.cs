using Calculator.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Calculator.Services
{
    public class JsonParser
    {
        LinkedList<Operation> operations;
        public JsonParser()
        {
            operations = new LinkedList<Operation>();
        }

        public LinkedList<Operation> ParseJson(JsonObject mathsObject)
        {
            ParseObject(mathsObject);
            return this.operations;
        }

        public void ParseObject(JsonObject operationObject)
        {
            Operation operation = new Operation();

            if (operationObject.ContainsKey("Value"))
            {
                //Parse Value to ValueList
                List<double> valueList = JsonConvert.DeserializeObject<List<double>>(operationObject["Value"].ToString());  
                ValueList values = new ValueList(valueList);
                operation.Value = values;
            }
            if (operationObject.ContainsKey("@ID"))
            {
                //Parse Operation to Operation
                operation.ID = Convert.ToString(operationObject["@ID"]);
                operation.currentLevelValue = 0;
            }
            if (operation.ID != null)
                operations.AddLast(operation);

            if(operationObject.ContainsKey("Operation"))
            {
                ParseObject((JsonObject)operationObject["Operation"]);
            }
        }
    }
}
