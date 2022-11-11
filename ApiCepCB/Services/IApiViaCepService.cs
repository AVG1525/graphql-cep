using ApiCepCB.Model;
using RestEase;

namespace ApiCepCB.Services
{
    public interface IApiViaCepService
    {
        [Get("/ws/{cep}/json/")]
        Task<ViaCep> GetCep([Path] string cep);
    }
}
