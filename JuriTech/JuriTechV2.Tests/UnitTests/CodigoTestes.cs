/*
*	<copyright file="CodigoTestes.cs"
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>nu-no</author>
*   <date>01/05/2022 17:22:22</date>
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
    /// Created on: 01/05/2022 17:22:22
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class CodigoTestes : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public CodigoTestes(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        #region Consultar Codigos
        // Obter um status code 200 (artigos consultados)
        [Theory]
        [InlineData("/api/Codigo")]
        public async Task ObterCodigos(string url)
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
