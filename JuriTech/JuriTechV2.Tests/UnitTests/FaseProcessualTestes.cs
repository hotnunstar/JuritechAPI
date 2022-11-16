using JuriTechV2.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace JuriTechV2.Tests.UnitTests
{
    public class FaseProcessualTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public FaseProcessualTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region Criar Fase Processual (by UserID)
        // Obter o status code 200 (fase inserida)
        [Theory]
        [InlineData("/api/FaseProcessual/1/986%2F22.8T8ACB")]
        public async Task AdicionarFaseProcessual(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            FaseProcessual faseProcessual = new()
            {
                IdUtilizador = 1,
                IdEstado = 2,
                NrProcesso = "986/22.8T8ACB",
                DataEntrada = "02-03-2022",
                DataSaida = null,
                NrDias = null,
            };
            JsonContent content = JsonContent.Create(faseProcessual);
            //url += $"{faseProcessual.IdUtilizador}/986%2F22.8T8ACB";

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Editar Fase Processual
        // Testar a edição de uma Fase Processual
        [Theory]
        [InlineData("/api/FaseProcessual/")]
        public async Task EditarFaseProcessual(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            FaseProcessual faseProcessual = new()
            {
                IdUtilizador = 1,
                IdEstado = 2,
                NrProcesso = "986/22.8T8ACB",
                DataEntrada = "2022-03-02",
                DataSaida = "2022-04-02",
                NrDias = null,
            };
            JsonContent content = JsonContent.Create(faseProcessual);
            url += $"{faseProcessual.IdUtilizador}/986%2F22.8T8ACB/{faseProcessual.IdEstado}/{faseProcessual.DataEntrada}";

            // Act
            var response = await client.PutAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Consultar Fase Processual por nº processo (by UserID)
        // Obter um status code 200 (fases processuais consultadas)
        [Theory]
        [InlineData("/api/FaseProcessual/1/986%2F22.4T8ACB")]
        public async Task ObterFaseProcessualByNrProcesso(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Consultar Fase Processual por IdEstado (by UserID)
        // Obter um status code 200 (fases processuais consultadas)
        [Theory]
        [InlineData("/api/FaseProcessual/1/Parametros/false/true/1")]
        public async Task ObterFaseProcessualByIdEstado(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Consultar Fases processuais ativas (by UserID)
        // Obter um status code 200 (fases processuais consultadas)
        [Theory]
        [InlineData("/api/FaseProcessual/1/Parametros/true/false/0")]
        public async Task ObterFaseProcessualByAtivas(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Consultar Fases processuais inativas (by UserID)
        // Obter um status code 200 (fases processuais consultadas)
        [Theory]
        [InlineData("/api/FaseProcessual/1/Parametros/false/false/0")]
        public async Task ObterFaseProcessualByInativas(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion
    }
}


