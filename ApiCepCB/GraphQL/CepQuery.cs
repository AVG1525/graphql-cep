using ApiCepCB.GraphQL.Type;
using ApiCepCB.Services;
using GraphQL.Types;
using Newtonsoft.Json;

namespace ApiCepCB.GraphQL
{
    public class CepQuery : ObjectGraphType
    {
        public CepQuery(IApiViaCepService _apiViaCepService)
        {
            Field<CepType>("getCep", arguments: new QueryArguments(
            new QueryArgument<IdGraphType> { Name = "cep" }
            ), resolve: context =>
            {   
                var cep = context.GetArgument<string>("cep");
                
                var teste = JsonConvert.SerializeObject((_apiViaCepService.GetCep(cep).Result));

                return JsonConvert.DeserializeObject<CepType>(teste);
            });
        }
    }
}
