using System.Collections.Generic;
using System.Threading.Tasks;
using InfluxDB.Net.Client;
using InfluxDB.Net.Infrastructure.Influx;
using InfluxDB.Net.Models;
using InfluxDB.Net.Enums;
using System.Threading;

namespace InfluxDB.Net.Contracts
{
    internal interface IInfluxDbClient
    {
        #region Database

        Task<InfluxDbApiResponse> CreateDatabase(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, Database database, CancellationToken cancellationToken = default);

        Task<InfluxDbApiResponse> DropDatabase(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name, CancellationToken cancellationToken = default);

        Task<InfluxDbApiResponse> ShowDatabases(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, CancellationToken cancellationToken = default);

        #endregion Database

        #region Basic Querying

        Task<InfluxDbApiWriteResponse> Write(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, WriteRequest request, string timePrecision, CancellationToken cancellationToken = default);

        Task<InfluxDbApiResponse> Query(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name, string query, CancellationToken cancellationToken = default);

        Task<InfluxDbApiResponse> Query(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name, List<string> queries, CancellationToken cancellationToken = default);

        #endregion Basic Querying

        #region Continuous Queries

        Task<InfluxDbApiResponse> GetContinuousQueries(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database);

        Task<InfluxDbApiResponse> DeleteContinuousQuery(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, int id);

        #endregion Continuous Queries

        #region Series

        Task<InfluxDbApiResponse> DropSeries(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string name, CancellationToken cancellationToken = default);

        #endregion Series

        #region Clustering

        Task<InfluxDbApiResponse> CreateClusterAdmin(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, User user);

        Task<InfluxDbApiResponse> DeleteClusterAdmin(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string name);

        Task<InfluxDbApiResponse> DescribeClusterAdmins(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers);

        Task<InfluxDbApiResponse> UpdateClusterAdmin(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, User user, string name);

        #endregion Clustering

        #region Sharding

        Task<InfluxDbApiResponse> GetShardSpaces(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers);

        Task<InfluxDbApiResponse> DropShardSpace(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string name);

        Task<InfluxDbApiResponse> CreateShardSpace(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, ShardSpace shardSpace);

        #endregion Sharding

        #region Users

        Task<InfluxDbApiResponse> CreateDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, User user);

        Task<InfluxDbApiResponse> DeleteDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string name);

        Task<InfluxDbApiResponse> DescribeDatabaseUsers(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database);

        Task<InfluxDbApiResponse> UpdateDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, User user, string name);

        Task<InfluxDbApiResponse> AuthenticateDatabaseUser(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string database, string user, string password);

        #endregion Users

        #region Other

        Task<InfluxDbApiResponse> Ping(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, CancellationToken cancellationToken = default);

        Task<InfluxDbApiResponse> ForceRaftCompaction(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers);

        Task<InfluxDbApiResponse> Interfaces(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers);

        Task<InfluxDbApiResponse> Sync(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers);

        Task<InfluxDbApiResponse> ListServers(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers);

        Task<InfluxDbApiResponse> RemoveServers(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, int id);

        Task<InfluxDbApiResponse> AlterRetentionPolicy(IEnumerable<ApiResponseErrorHandlingDelegate> errorHandlers, string policyName, string dbName, string duration, int replication, CancellationToken cancellationToken = default);

        IFormatter GetFormatter();

        InfluxVersion GetVersion();

        #endregion Other
    }
}