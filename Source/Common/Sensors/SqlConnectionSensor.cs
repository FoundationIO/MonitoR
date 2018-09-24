using MonitoR.Common.Infrastructure;
using MonitoR.Common.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using MonitoR.Common.Utilities;
using System.Collections.Generic;

namespace MonitoR.Common.Sensors
{
    public class SqlConnectionSensor : BaseSensor
    {
        public SqlConnectionSensor()
        {
            SensorType = SensorType.SqlConnection;
        }

        public SqlServerType DatabaseType { get; set; }

        public string DatabaseName { get; set; }

        public string DatabaseServer { get; set; }

        public string DatabaseUserName { get; set; }

        public string DatabasePassword { get; set; }

        public bool RunCustomSql { get; set; }

        public string CustomSql { get; set; }

        public bool DatabaseUseIntegratedLogin { get; set; }

        public int DatabaseCommandTimeout { get; set; }

        public override ReturnValue Execute(IAppConfig appConfig, ILog log)
        {
            var isConnected = false;
            try
            {
                var conn = GetConnection();

                try
                {
                    conn.Open();
                    if (RunCustomSql)
                    {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = CustomSql;
                        cmd.CommandTimeout = DatabaseCommandTimeout;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    conn = null;
                }
                finally
                {
                    if (conn?.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

                isConnected = true;
            }
            catch (Exception e)
            {
                log.Error(e, "Error when validating the sql connection ");
                isConnected = false;
            }

            if (isConnected)
                return ReturnValue.False($"Sql connection to {DatabaseServer} of type {DatabaseType} failed");
            else
                return ReturnValue.True();
        }

        public virtual string GetConnectionString()
        {
            var connectionStr = string.Empty;

            switch (DatabaseType)
            {
                case SqlServerType.MSSql:
                    {
                        if (DatabaseUseIntegratedLogin)
                            connectionStr = $"Integrated Security=true;Server={DatabaseServer};Initial Catalog={DatabaseName};Persist Security Info=True;MultipleActiveResultSets =False;Application Name=ServiceMonitor;";
                        else
                            connectionStr = $"Server={DatabaseServer};Initial Catalog={DatabaseName};Persist Security Info=True;User ID={DatabaseUserName};Password={DatabasePassword};MultipleActiveResultSets=False;Application Name=ServiceMonitor;";
                        break;
                    }

                case SqlServerType.MySql:
                    {
                        if (DatabaseUseIntegratedLogin)
                            connectionStr = $"IntegratedSecurity=yes;Server={DatabaseServer};Database={DatabaseName};";
                        else
                            connectionStr = $"Server={DatabaseServer};Database={DatabaseName};Uid={DatabaseUserName};Pwd={DatabasePassword};";
                        break;
                    }

                case SqlServerType.Postgres:
                    {
                        if (DatabaseUseIntegratedLogin)
                            connectionStr = $"Integrated Security=true;Server={DatabaseServer};Initial Catalog={DatabaseName};Persist Security Info=True;MultipleActiveResultSets =False;Application Name=ServiceMonitor;";
                        else
                            connectionStr = $"Server={DatabaseServer};Initial Catalog={DatabaseName};Persist Security Info=True;User ID={DatabaseUserName};Password={DatabasePassword};MultipleActiveResultSets=False;Application Name=ServiceMonitor;";
                        break;
                    }

                default:
                    {
                        throw new NotSupportedException($"Unable to get Configuration string, Unknown Database type specified in the configuration {DatabaseType}");
                    }
            }

            return connectionStr;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = GetConnectionString();

            switch (DatabaseType)
            {
                case SqlServerType.MSSql:
                    {
                        return new SqlConnection(connectionString);
                    }

                case SqlServerType.MySql:
                    {
                        return new MySqlConnection(GetConnectionString());
                    }

                case SqlServerType.Postgres:
                    {
                        return new NpgsqlConnection(GetConnectionString());
                    }

                default:
                    {
                        throw new NotSupportedException($"Unable to get Migration Process Factory, Unknown Database type specified in the configuration {DatabaseType}");
                    }
            }
        }

        public override ReturnValue IsValid(List<ISensor> allSensors)
        {
            var result = base.IsValid(allSensors);

            if (result?.Result != true)
                return result;

            if (DatabaseType == SqlServerType.None )
                return ReturnValue.False("Select a proper Server type");

            if (String.IsNullOrEmpty(DatabaseName))
                return ReturnValue.False("Database Name should not be empty");

            if (String.IsNullOrEmpty(DatabaseServer))
                return ReturnValue.False("Database Server should not be empty");

            if (!DatabaseUseIntegratedLogin)
            {
                if (String.IsNullOrEmpty(DatabaseUserName))
                    return ReturnValue.False("Database username should not be empty");

                if (String.IsNullOrEmpty(DatabasePassword))
                    return ReturnValue.False("Database password should not be empty");
            }

            if(RunCustomSql && String.IsNullOrEmpty(CustomSql))
                return ReturnValue.False("Sql should not be empty");

            if (DatabaseCommandTimeout < 0)
                return ReturnValue.False("Database Command Timeout not be less than 0");

            return ReturnValue.True();
        }
    }
}
