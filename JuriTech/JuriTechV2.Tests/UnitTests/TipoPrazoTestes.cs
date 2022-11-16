/*
*	<copyright file="JuriTechV2.Tests.UnitTests.cs" company="IPCA">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>nu-no</author>
*   <date>03/05/2022 00:37:59</date>
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
    /// Created on: 03/05/2022 00:37:59
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class TipoPrazoTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TipoPrazoTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region Consultar Tipos de prazo
        // Obter um status code 200 (artigos consultados)
        [Theory]
        [InlineData("/api/TipoPrazo")]
        public async Task ObterTipoPrazo(string url)
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
