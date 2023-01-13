using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.IO;

namespace Poc.Claims.IntegrationTests
{
    public class BaseTests : IDisposable
    {
        protected readonly string ConnectionString = @"Server=.;Database=ClaimsPocIntegrationTest;Trusted_Connection=true";

        public BaseTests()
        {
            using SqlConnection sqlConnection = new SqlConnection(@"Server=.;Database=master;Trusted_Connection=true;TrustServerCertificate=True");
            var server = new Server(new ServerConnection(sqlConnection));
            server.ConnectionContext
                .ExecuteNonQuery(
                    File.ReadAllText(@"../../../../DBCreationScript.txt")
                        .Replace("ClaimsPoc", "ClaimsPocIntegrationTest"));
        }

        public void Dispose()
        {
            using SqlConnection sqlConnection = new SqlConnection(@"Server=.;Database=master;Trusted_Connection=true;TrustServerCertificate=True");
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
    }
}
