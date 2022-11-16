/*
*	<copyright file="TipoProcesso.cs"
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>nu-no</author>
*   <date>03/05/2022 01:09:29</date>
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
    /// Created on: 03/05/2022 01:09:29
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class TipoProcessoTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TipoProcessoTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region Criar tipo de processo (by UserID)
        // Obter o status code 200 (TipoProcesso inserido)
        [Theory]
        [InlineData("/api/TipoProcesso/1")]
        public async Task AdicionarTipoProcesso(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            TipoProcesso tipoProcesso = new()
            {
                Id = 0,
                IdUtilizador = 1,
                Nome = "Tipo processo para teste",
                IdTema = 120,
            };
            JsonContent content = JsonContent.Create(tipoProcesso);

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Editar tipo de processo (by UserID)
        // Obter um status code 204 (Artigo alterado)
        [Theory]
        [InlineData("/api/TipoProcesso/1/121")]
        public async Task AlterarTipoProcesso(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            TipoProcesso tipoProcesso = new()
            {
                Id = 0,   
                IdUtilizador = 1,
                Nome = "Tema para teste alterado",
                IdTema = 120,
            };
            JsonContent content = JsonContent.Create(tipoProcesso);

            // Act
            var response = await client.PutAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion
    }
}
