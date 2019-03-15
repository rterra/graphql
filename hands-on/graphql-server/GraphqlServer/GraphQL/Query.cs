using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlServer.GraphQL
{
    public class PessoaDTO
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string endereco { get; set; }

        public string campointerno { get; set; }
    }

    public class NovaPessoa : ObjectGraphType<PessoaDTO>
    {
        public NovaPessoa()
        {
            Name = "TipoPessoa";
            Description = "Minha Descricao";

            Field(p => p.nome);
            Field(p => p.sobrenome);
            Field<StringGraphType>("nomecompleto",
                resolve: (ctx) => ctx.Source.nome + ' ' + ctx.Source.sobrenome

                );
            Field(p => p.endereco);

        }

    }

    public class CV : ObjectGraphType
    {
        public CV() {
            Field<IdGraphType>("id", resolve: (ctx) => "dddd-ffff-ffff-ffff-fff" );
            Field<StringGraphType>("texto", resolve: (ctx) => "corpo do cv");
        }
    }
        public class Pessoa : ObjectGraphType
    {
        public static int count = 0;
        private string id = "";


        public static void Up() { count++;  }
        public Pessoa(string id)
        {
            this.id = id;
        }
        public Pessoa()
        {
            Field<IdGraphType>("id", resolve: (ctx) => "dddd-ffff-ffff-ffff-fff");
            Field<StringGraphType>("name", resolve: (ctx) => "João da Silva " + (count));
            Field<ListGraphType<CV>>("cv",
                 resolve: (ctx) => 
                 new CV[0]
                );
        }
    }

    public class Query : ObjectGraphType
    {
        static object MeuResolver(ResolveFieldContext<object> obj)
        {
            return "2.0";
        }

        static object PessoaResolver(ResolveFieldContext<object> obj)
        {

            string id = obj.GetArgument<string>("id");
            return new Pessoa(id);
        }

        public Query()
        {
            string appVer = "1.0";
            Field<NonNullGraphType<StringGraphType>>("versao",
                description: "O campo versão define a versão da nossa API",
                resolve: MeuResolver);

            Field<Pessoa>("pessoa",
                arguments: new QueryArguments {
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                },
                resolve: PessoaResolver);

            Field<ListGraphType<Pessoa>>("pessoas",
                arguments: new QueryArguments {
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                },
                resolve: (ctx) => {
                    var l = new Pessoa[] {
                        new Pessoa(),
                        new Pessoa()
                    };
                    return l;
                });

            Field<NovaPessoa>("novapessoa", resolve: (ctx) => new PessoaDTO
            {
                nome = "Maria",
                sobrenome = "da Silva",
                endereco = "sua sem numero"
            });
        }


    }
}
