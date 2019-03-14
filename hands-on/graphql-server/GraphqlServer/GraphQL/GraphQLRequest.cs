using Newtonsoft.Json.Linq;

namespace GraphqlServer.GraphQL
{
    public class GraphQLRequest
    {
        public string Query { get; set; }
        public string OperationName { get; set; }
        public JObject Variables { get; set; } 
    }
}
