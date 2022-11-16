/*
*	<copyright file="ArtigoTestes.cs"
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>nu-no</author>
*   <date>01/05/2022 15:32:32</date>
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
    /// Created on: 01/05/2022 15:32:32
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ArtigoTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ArtigoTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region Inserir artigo
        // Obter o status code 200 (Artigo inserido)
        [Theory]
        [InlineData("/api/Artigo/")]
        public async Task AdicionarArtigo(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Artigo artigo = new() { 
                IdCodigo = 1, 
                NrArtigo = 11, 
                IdUtilizador = 4, 
                Nome = "Princípio da colaboração com os particulares", 
                Dias = 1, 
                Meses = 2, 
                Anos = 1, 
                Ferias = false, 
                DiasNaoUteis = true };
            JsonContent content = JsonContent.Create(artigo);
            url += $"{artigo.IdCodigo}/{artigo.NrArtigo}/{artigo.IdUtilizador}";

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Alterar artigo
        // Obter um status code 204 (Artigo alterado)
        [Theory]
        [InlineData("/api/Artigo?idCod=1&nrArtigo=11&idUtilizador=4")]
        public async Task AlterarArtigo(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Artigo artigo = new() { 
                IdCodigo = 1, 
                NrArtigo = 11, 
                IdUtilizador = 4, 
                Nome = "Ateração para o teste", 
                Dias = 1, 
                Meses = 2, 
                Anos = 1, 
                Ferias = false, 
                DiasNaoUteis = true };
            JsonContent content = JsonContent.Create(artigo);

            // Act
            var response = await client.PutAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Eliminar artigo
        // Obter um status code 204 (Artigo apagado)
        [Theory]
        [InlineData("/api/Artigo/1/11/4")]
        public async Task EliminarArtigo(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        #endregion

        #region Consultar artigos (by UserID)
        // Obter um status code 200 (artigos consultados)
        [Theory]
        [InlineData("/api/Artigo/1")]
        public async Task ObterArtigo(string url)
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

        #region Consultar artigos por código processual (by UserID)
        // Obter um status code 200 (artigos consultados)
        [Theory]
        [InlineData("/api/Artigo/1/2")]
        public async Task ObterArtigoByCode(string url)
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
