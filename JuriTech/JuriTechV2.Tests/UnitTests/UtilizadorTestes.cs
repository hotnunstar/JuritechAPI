/*
*	<copyright file="UtilizadorTestes.cs"
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>nu-no</author>
*   <date>03/05/2022 00:43:26</date>
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
    /// Created on: 03/05/2022 00:43:26
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class UtilizadorTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UtilizadorTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region Sign UP
        // Testar acesso a uma api existente. O objetivo é obter status code 200 (acesso com sucesso)
        [Theory]
        [InlineData("/api/Utilizador")]
        public async Task CriarConta(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Utilizador utilizador = new() { Id = 0, Nome = "Oscar Ribeiro", Email = "oscar@juritech.pt", Password = "lesiplg13" };
            JsonContent content = JsonContent.Create(utilizador);

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Login
        [Theory]
        [InlineData("/api/Utilizador/oscar%40juritech.pt/lesiplg13")]
        public async Task Login(string url)
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

        #region Editar dados de utilizador
        // Testar a edição de um utilizador, por ID. O objetivo é obter status code 200 (ocorrência com sucesso)
        [Theory]
        [InlineData("/api/Utilizador/5")]
        public async Task EditarDados(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Utilizador utilizador = new() { Id = 0, Nome = "Nuno", Email = "nuno@juritech.pt", Password = "lesiplg13" };
            JsonContent content = JsonContent.Create(utilizador);

            // Act
            var response = await client.PutAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion
    }
}
