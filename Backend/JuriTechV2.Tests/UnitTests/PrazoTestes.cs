/*
*	<copyright file="PrazoTestes.cs"
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>nu-no</author>
*   <date>03/05/2022 18:31:21</date>
*	<description></description>
**/
using JuriTechV2.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;


namespace JuriTechV2.Tests.UnitTests
{
    /// <summary>
    /// Purpose:
    /// Created by: nu-no
    /// Created on: 03/05/2022 18:31:21
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class PrazoTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PrazoTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region Criar prazo (by UserID)
        // Obter o status code 200 (Prazo inserido)
        [Theory]
        [InlineData("/api/Prazo/1/parametros/3/7/986%2F22.8T8ACB/3/2022-05-03")]
        public async Task AdicionarPrazo(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Prazo prazo = new()
            {
                IdPrazoCodigo = 3,
                IdUtilizador = 1,
                NrProcesso = "986/22.8T8ACB",
                DataInicial = "2022-05-03",
                DataFinal = "2023-10-02",
                NrArtigo = 7,
                IdCodigo = 3,
            };
            JsonContent content = JsonContent.Create(prazo);
            url += $"{prazo.IdUtilizador}/parametros/{prazo.IdCodigo}/{prazo.NrArtigo}/986%2F22.8T8ACB/{prazo.IdPrazoCodigo}/{prazo.DataInicial}";

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Eliminar prazo
        // Obter um status code 204 (Prazo apagado)
        [Theory]
        [InlineData("/api/Prazo/1/986%2F22.8T8ACB/3")]
        public async Task Eliminarprazo(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Consultar prazos (by UserID)
        // Obter um status code 200 (Prazo consultados)
        [Theory]
        [InlineData("/api/Prazo/1/parametros/true/0")]
        public async Task ObterPrazo(string url)
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

        #region Consultar prazos por nº processo (by UserID)
        // Obter um status code 200 (Prazos consultados)
        [Theory]
        [InlineData("/api/Prazo/1/986%2F22.8T8ACB")]
        public async Task ObterPrazoByProcesso(string url)
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
