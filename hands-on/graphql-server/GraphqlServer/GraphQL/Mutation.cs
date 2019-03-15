using GraphQL.Types;
using GraphqlServer.GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlServer
{
    public class Mutation: ObjectGraphType
    {

        public Mutation()
        {
            Field<Pessoa>("updatePessoa", resolve: (ctx) => {
                Pessoa.Up();

                return new Pessoa();
            }
            );
        }

    }
}
