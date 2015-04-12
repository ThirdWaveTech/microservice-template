using System;
using System.Configuration;
using Crux.Core.Extensions;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using __NAME__.Domain.Persistence;

namespace __NAME__.IntegrationTests.Infrastructure
{
    public class TestSessionFactoryConfig : SessionFactoryConfig
    {
        private const string DEFAULT_DB_SERVER = "(local)";
        private const string DEFAULT_DB_NAME = "__NAME__";

        private readonly string _connectionString;

        public TestSessionFactoryConfig(string connectionStringKey)
            : base(connectionStringKey)
        {
            _connectionString = GetConnectionString(connectionStringKey);
        }

        private string GetConnectionString(string key)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[key];

            if (connectionString == null) {
                throw new ArgumentException("Invalid connection string {0}".ToFormat(key));
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

        public override ISessionFactory CreateSessionFactory()
        {
            return CreateSessionFactory(typeof(SessionFactoryConfig).Assembly);
        }

        protected override IPersistenceConfigurer GetDatabaseConfiguration()
        {
            return MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString);
        }
    }
}
