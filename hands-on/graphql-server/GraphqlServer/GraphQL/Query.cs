using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlServer.GraphQL
{
    public class Query : ObjectGraphType
    {
        public Query()
        {
            string appVer = "1.0";
            Field<StringGraphType>("versao", resolve: (ctx) => appVer);
        }
    }
}
