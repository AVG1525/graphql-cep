using ApiCepCB.Model;
using GraphQL.Types;

namespace ApiCepCB.GraphQL.Type
{
    public class CepType : ObjectGraphType<ViaCep>
    {
        public CepType()
        {
            Field(x => x.Cep);
            Field(x => x.Bairro);
            Field(x => x.Logradouro);
            Field(x => x.UF);
            Field(x => x.Localidade);
        }
    }
}
