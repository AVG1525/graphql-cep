using ApiCepCB.Model;
using RestEase;

namespace ApiCepCB.Services
{
    public interface IApiCepService
    {
        [Get("/file/apicep/{cep}.json")]
        Task<ApiCep> GetCep([Path] string cep);
    }
}
