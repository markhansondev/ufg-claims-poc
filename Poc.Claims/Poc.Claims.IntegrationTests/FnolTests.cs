using System;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Poc.Claims.Services;
using Shouldly;
using Xunit;

namespace Poc.Claims.IntegrationTests
{
    public class FnolTests : IDisposable
    {
        readonly string connectionString = @"Server=.;Database=master;Trusted_Connection=true;TrustServerCertificate=True";
        private readonly FnolService _fnolService;

        public FnolTests()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            var server = new Server(new ServerConnection(sqlConnection));
            server.ConnectionContext
                .ExecuteNonQuery(
                    File.ReadAllText(@"../../../../DBCreationScript.txt")
                        .Replace("[ClaimsPoc]", "[ClaimsPocIntegrationTest]"));

            _fnolService = new FnolService(@"Server=.;Database=ClaimsPocIntegrationTest;Trusted_Connection=true");
        }

        public void Dispose()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            var server = new Server(new ServerConnection(sqlConnection));
            server.ConnectionContext
                .ExecuteNonQuery(@"USE [master]
                    GO
                    --drop existing connections to the database
                    alter database [ClaimsPocIntegrationTest] set single_user with rollback immediate
                    GO
                    DROP DATABASE IF EXISTS [ClaimsPocIntegrationTest]
                    GO");
        }

        [Fact]
        public void Can_create_and_get_an_fnol()
        {
            //setup
            var fnolDto = new FnolDto()
            {
                claimant_name = "claimant 1",
                is_ready_to_be_completed = true,
                line_liability_amount = 123,
                line_type = "line type 1"
            };

            //execute
            var fnol = _fnolService.CreateFnol(fnolDto);
            var getFnolDto = _fnolService.GetFnol(fnol.Id);

            //verify
            fnolDto.id = 10;
            getFnolDto.ShouldBeEquivalentTo(fnolDto);
        }
    }
}
