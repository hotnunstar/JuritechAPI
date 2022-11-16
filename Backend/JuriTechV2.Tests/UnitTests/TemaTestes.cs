/*
*	<copyright file="JuriTechV2.Tests.UnitTests.cs" company="IPCA">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>nu-no</author>
*   <date>02/05/2022 23:55:04</date>
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
    /// Created on: 02/05/2022 23:55:04
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class TemaTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TemaTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region Inserir tema
        // Obter o status code 200 (Artigo inserido)
        [Theory]
        [InlineData("/api/Tema/1")]
        public async Task AdicionarTema(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Tema tema = new()
            {
                Id = 0,
                IdUtilizador = 1,
                Nome = "Tema para teste2",
            };
            JsonContent content = JsonContent.Create(tema);

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Alterar Tema
        // Obter um status code 204 (Artigo alterado)
        [Theory]
        [InlineData("/api/Tema/1/121")]
        public async Task AlterarTema(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Tema tema = new()
            {
                Id = 0,
                IdUtilizador = 1,
                Nome = "Tema para teste alterado",
            };
            JsonContent content = JsonContent.Create(tema);

            // Act
            var response = await client.PutAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Consultar temas existentes (by UserID)
        // Obter um status code 200 (temas consultados)
        [Theory]
        [InlineData("/api/Tema/1")]
        public async Task ObterTema(string url)
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
