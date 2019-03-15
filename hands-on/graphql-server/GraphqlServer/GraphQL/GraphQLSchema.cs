using GraphQL.Types;

namespace GraphqlServer.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(Query query)
        {
            Query = query;
            Mutation = new Mutation();
        }
    }
}
