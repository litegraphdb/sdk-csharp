namespace LiteGraph.Sdk.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ExpressionTree;
    using LiteGraph;

    /// <summary>
    /// Interface for graph methods.
    /// </summary>
    public interface IGraphMethods
    {
        /// <summary>
        /// Create a graph.
        /// </summary>
        /// <param name="graph">Graph.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Graph.</returns>
        Task<Graph> Create(Graph graph, CancellationToken token = default);

        /// <summary>
        /// Read graphs.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="order">Enumeration order.</param>
        /// <param name="skip">The number of records to skip.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Graphs.</returns>
        Task<List<Graph>> ReadMany(
            Guid tenantGuid,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0,
            CancellationToken token = default);

        /// <summary>
        /// Read a graph by GUID.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Graph.</returns>
        Task<Graph> ReadByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default);

        /// <summary>
        /// Read graphs by GUIDs.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guids">GUIDs.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>List.</returns>
        Task<List<Graph>> ReadByGuids(Guid tenantGuid, List<Guid> guids, CancellationToken token = default);

        /// <summary>
        /// Update a graph.
        /// </summary>
        /// <param name="graph">Graph.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Graph.</returns>
        Task<Graph> Update(Graph graph, CancellationToken token = default);

        /// <summary>
        /// Delete a graph.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">GUID.</param>
        /// <param name="force">True to forcefully delete associated data.</param>
        /// <param name="token">Cancellation token.</param>
        Task DeleteByGuid(Guid tenantGuid, Guid guid, bool force = false, CancellationToken token = default);

        /// <summary>
        /// Check if a graph exists by GUID.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>True if exists.</returns>
        Task<bool> ExistsByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default);

        /// <summary>
        /// Search graphs.
        /// </summary>
        /// <param name="req">Search request.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Search result.</returns>
        Task<SearchResult> Search(SearchRequest req, CancellationToken token = default);

        /// <summary>
        /// Read first.
        /// </summary>
        /// <param name="req">Search request.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Graph.</returns>
        Task<Graph> ReadFirst(SearchRequest req, CancellationToken token = default);

        /// <summary>
        /// Enumerate.
        /// </summary>
        /// <param name="query">Enumeration query.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Enumeration result.</returns>
        Task<EnumerationResult<Graph>> Enumerate(EnumerationQuery query, CancellationToken token = default);

        /// <summary>
        /// Retrieve graph statistics.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">Graph GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Graph statistics.</returns>
        Task<GraphStatistics> GetStatistics(Guid tenantGuid, Guid guid, CancellationToken token = default);

        /// <summary>
        /// Retrieve graph statistics.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <returns>Dictionary of graph statistics.</returns>
        /// <param name="token">Cancellation token.</param>
        Task<Dictionary<Guid, GraphStatistics>> GetStatistics(Guid tenantGuid, CancellationToken token = default);
    }
}