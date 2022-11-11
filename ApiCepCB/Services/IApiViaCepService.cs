using ApiCepCB.Model;
using RestEase;

using ApiCepCB.GraphQL.Type;

namespace ApiCepCB.Services
{
    public interface IApiViaCepService
    {
        [Get("/ws/{cep}/json/")]
        Task<ViaCep> GetCep([Path] string cep);
    }
}
