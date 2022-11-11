using ApiCepCB.Facade.Interfaces;
using ApiCepCB.Services;

namespace ApiCepCB.Facade
{
    public class CepFacade : ICepFacade
    {
        private readonly IApiViaCepService _apiViaCep;

        public CepFacade(
            IApiViaCepService apiViaCep)
        {
            _apiViaCep = apiViaCep;
        }

        public Task GetCep(string cep)
        {
            return Task.CompletedTask;
        }
    }
}
