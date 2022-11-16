/*
*	<copyright file="ProcessoTestes.cs"
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>nu-no</author>
*   <date>01/05/2022 17:37:30</date>
*	<description></description>
**/
using JuriTechV2.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;


namespace JuriTechV2.Tests.UnitTests
{
    /// <summary>
    /// Purpose:
    /// Created by: nu-no
    /// Created on: 01/05/2022 17:37:30
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ProcessoTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ProcessoTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region Criar Processo (by UserID)
        // Obter o status code 200 (Processo inserido)
        [Theory]
        [InlineData("/api/Processo/1")]
        public async Task AdicionarProcesso(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Processo processo = new() {
                NrProcesso = "986/22.8T8ACB",
                IdTipo = 1,
                IdUtilizador = 1,
                Valor = 5028.40M,
                Nome = "Processo teste",
                Notas = "Processo teste",
                DataEntrada = "2022-06-05",
                Estado = true };
            
            JsonContent content = JsonContent.Create(processo);
            url += $"{processo.IdUtilizador}";

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Alterar Processo (by UserID)
        // Obter o status code 204 (Processo Alterado)
        [Theory]
        [InlineData("/api/Processo/1/986%2F22.8T8ACB")]
        public async Task AlterarProcesso(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Processo processo = new()
            {
                NrProcesso = "986/22.8T8ACB",
                IdTipo = 1,
                IdUtilizador = 1,
                Valor = 5028.40M,
                Nome = "Processo teste alterado",
                Notas = "Processo teste alterado",
                DataEntrada = "2022-04-20",
                Estado = true
            };

            JsonContent content = JsonContent.Create(processo);
            //url += $"{processo.IdUtilizador}/986%2F22.8T8ACB";

            // Act
            var response = await client.PutAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Consultar Processos (by UserID)
        // Obter um status code 200 (processos consultados)
        [Theory]
        [InlineData("/api/Processo/1")]
        public async Task ObterProcesso(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            Processo processo = new();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion
    }
}
