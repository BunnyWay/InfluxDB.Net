using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InfluxDB.Net.Contracts;
using InfluxDB.Net.Enums;
using InfluxDB.Net.Infrastructure.Configuration;
using InfluxDB.Net.Infrastructure.Influx;
using InfluxDB.Net.Models;

namespace InfluxDB.Net.Client
{
    internal class InfluxDbClientAutoVersion : IInfluxDbClient
    {
        private readonly Task<IInfluxDbClient> _influxDbClient;

        public InfluxDbClientAutoVersion(InfluxDbClientConfiguration influxDbClientConfiguration)
        {
            _influxDbClient = ResolveVersion(influxDbClientConfiguration);
        }

        #region Database

        public async Task<InfluxDbApiResponse> CreateDatabase(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, Database database, CancellationToken cancellationToken = default)
        {
            return await (await _influxDbClient).CreateDatabase(errorHandlers, database, cancellationToken);
        }

        public async Task<InfluxDbApiResponse> DropDatabase(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name, CancellationToken cancellationToken = default)
        {
            return await (await _influxDbClient).DropDatabase(errorHandlers, name, cancellationToken);
        }

        public async Task<InfluxDbApiResponse> ShowDatabases(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, CancellationToken cancellationToken = default)
        {
            return await (await _influxDbClient).ShowDatabases(errorHandlers, cancellationToken);
        }

        #endregion Database

        #region Basic Querying

        public async Task<InfluxDbApiWriteResponse> Write(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, WriteRequest request, string timePrecision, CancellationToken cancellationToken = default)
        {
            return await (await _influxDbClient).Write(errorHandlers, request, timePrecision, cancellationToken);
        }

        public async Task<InfluxDbApiResponse> Query(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name, string query, CancellationToken cancellationToken = default)
        {
            return await (await _influxDbClient).Query(errorHandlers, name, query, cancellationToken);
        }

        public async Task<InfluxDbApiResponse> Query(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name, List<string> queries, CancellationToken cancellationToken = default)
        {
            return await (await _influxDbClient).Query(errorHandlers, name, queries, cancellationToken);
        }

        #endregion Basic Querying

        #region Continuous Queries

        public async Task<InfluxDbApiResponse> GetContinuousQueries(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database)
        {
            return await (await _influxDbClient).GetContinuousQueries(errorHandlers, database);
        }

        public async Task<InfluxDbApiResponse> DeleteContinuousQuery(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, int id)
        {
            return await (await _influxDbClient).DeleteContinuousQuery(errorHandlers, database, id);
        }

        #endregion Continuous Queries

        #region Series

        public async Task<InfluxDbApiResponse> DropSeries(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string name, CancellationToken cancellationToken = default)
        {
            return await (await _influxDbClient).DropSeries(errorHandlers, database, name, cancellationToken);
        }

        #endregion Series

        #region Clustering

        public async Task<InfluxDbApiResponse> CreateClusterAdmin(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, User user)
        {
            return await (await _influxDbClient).CreateClusterAdmin(errorHandlers, user);
        }

        public async Task<InfluxDbApiResponse> DeleteClusterAdmin(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name)
        {
            return await (await _influxDbClient).DeleteClusterAdmin(errorHandlers, name);
        }

        public async Task<InfluxDbApiResponse> DescribeClusterAdmins(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await (await _influxDbClient).DescribeClusterAdmins(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> UpdateClusterAdmin(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, User user, string name)
        {
            return await (await _influxDbClient).UpdateClusterAdmin(errorHandlers, user, name);
        }

        #endregion Clustering

        #region Sharding

        public async Task<InfluxDbApiResponse> GetShardSpaces(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await (await _influxDbClient).GetShardSpaces(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> DropShardSpace(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string name)
        {
            return await (await _influxDbClient).DropShardSpace(errorHandlers, database, name);
        }

        public async Task<InfluxDbApiResponse> CreateShardSpace(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, ShardSpace shardSpace)
        {
            return await (await _influxDbClient).CreateShardSpace(errorHandlers, database, shardSpace);
        }

        #endregion Sharding

        #region Users

        public async Task<InfluxDbApiResponse> CreateDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, User user)
        {
            return await (await _influxDbClient).CreateDatabaseUser(errorHandlers, database, user);
        }

        public async Task<InfluxDbApiResponse> DeleteDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string name)
        {
            return await (await _influxDbClient).DeleteDatabaseUser(errorHandlers, database, name);
        }

        public async Task<InfluxDbApiResponse> DescribeDatabaseUsers(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database)
        {
            return await (await _influxDbClient).DescribeDatabaseUsers(errorHandlers, database);
        }

        public async Task<InfluxDbApiResponse> UpdateDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, User user, string name)
        {
            return await (await _influxDbClient).UpdateDatabaseUser(errorHandlers, database, user, name);
        }

        public async Task<InfluxDbApiResponse> AuthenticateDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string user, string password)
        {
            return await (await _influxDbClient).AuthenticateDatabaseUser(errorHandlers, database, user, password);
        }

        #endregion Users

        #region Other

        public async Task<InfluxDbApiResponse> Ping(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, CancellationToken cancellationToken = default)
        {
            return await (await _influxDbClient).Ping(errorHandlers, cancellationToken);
        }

        public async Task<InfluxDbApiResponse> ForceRaftCompaction(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await (await _influxDbClient).ForceRaftCompaction(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> Interfaces(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await (await _influxDbClient).Interfaces(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> Sync(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await (await _influxDbClient).Sync(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> ListServers(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers)
        {
            return await (await _influxDbClient).ListServers(errorHandlers);
        }

        public async Task<InfluxDbApiResponse> RemoveServers(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, int id)
        {
            return await (await _influxDbClient).RemoveServers(errorHandlers, id);
        }

        public async Task<InfluxDbApiResponse> AlterRetentionPolicy(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string policyName, string dbName, string duration, int replication, CancellationToken cancellationToken = default)
        {
            return await (await _influxDbClient).AlterRetentionPolicy(errorHandlers, policyName, dbName, duration, replication, cancellationToken);
        }

        public IFormatter GetFormatter()
        {
            // This looks like it may deadlock. It can, but at least it's outside the DI path.
            return _influxDbClient.Result.GetFormatter();
        }

        public InfluxVersion GetVersion()
        {
            // This looks like it may deadlock. It can, but at least it's outside the DI path.
            return _influxDbClient.Result.GetVersion();
        }

        async Task<IInfluxDbClient> ResolveVersion(InfluxDbClientConfiguration influxDbClientConfiguration)
        {
            var client = new InfluxDbClientBase(influxDbClientConfiguration);
            var errorHandlers = new List<ApiResponseErrorHandlingDelegate>();

            //NOTE: Only performs ping when the client is connected. (Do not use multiple connections with the "Client Auto Version" setting.)
            var result = await client.Ping(errorHandlers);
            var databaseVersion = result.Body;

            if (databaseVersion.StartsWith("1.1."))
            {
                return new InfluxDbClientV013x(influxDbClientConfiguration);
            }
            else if (databaseVersion.StartsWith("0.13."))
            {
                return new InfluxDbClientV013x(influxDbClientConfiguration);
            }
            else if (databaseVersion.StartsWith("0.12."))
            {
                return new InfluxDbClientV012x(influxDbClientConfiguration);
            }
            else if (databaseVersion.StartsWith("0.11."))
            {
                return new InfluxDbClientV011x(influxDbClientConfiguration);
            }
            else if (databaseVersion.StartsWith("0.10."))
            {
                return new InfluxDbClientV010x(influxDbClientConfiguration);
            }
            else if (databaseVersion.StartsWith("0.9."))
            {
                switch (databaseVersion)
                {
                    case "0.9.2":
                        return new InfluxDbClientV092(influxDbClientConfiguration);
                    case "0.9.5":
                        return new InfluxDbClientV092(influxDbClientConfiguration);
                    case "0.9.6":
                        return new InfluxDbClientV092(influxDbClientConfiguration);
                }
            }

            return new InfluxDbClientV0x(influxDbClientConfiguration);
        }

        #endregion Other
    }
}