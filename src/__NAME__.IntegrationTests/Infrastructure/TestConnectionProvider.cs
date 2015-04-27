﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Crux.Core.Extensions;
using Crux.Domain.Persistence;

namespace __NAME__.IntegrationTests.Infrastructure
{
    public class TestConnectionProvider : IDbConnectionProvider
    {
        private const string DEFAULT_DB_SERVER = "(local)";
        private const string DEFAULT_DB_NAME = "__NAME__";

        private readonly string _connectionStringKey;

        public TestConnectionProvider(string connectionStringKey)
        {
            _connectionStringKey = connectionStringKey;
        }

        public IDbConnection GetConnection()
        {
            var connection = new SqlConnection(GetConnectionString());
            connection.Open();
            return connection;
        }

        public string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[_connectionStringKey];

            if (connectionString == null) {
                throw new ArgumentException("Invalid connection string {0}".ToFormat(_connectionStringKey));
            }

            return ReplaceTokens(connectionString.ConnectionString);
        }

        private string ReplaceTokens(string connectionString)
        {
            return connectionString
                .Replace("#{db.server}", GetDbServer())
                .Replace("#{db.name}", GetDbName());
        }

        private string GetDbServer()
        {
            return GetEnvOrDefault("DATABASE_SERVER", DEFAULT_DB_SERVER);
        }

        private string GetDbName()
        {
            return GetEnvOrDefault("DATABASE_NAME", DEFAULT_DB_NAME);
        }

        private string GetEnvOrDefault(string envVarName, string defaultValue)
        {
            var envVar = Environment.GetEnvironmentVariable(envVarName);
            return String.IsNullOrEmpty(envVar) ? defaultValue : envVar;
        }
    }
}
