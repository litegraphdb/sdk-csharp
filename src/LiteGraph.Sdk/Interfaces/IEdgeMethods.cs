﻿namespace LiteGraph.Sdk.Interfaces
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
    /// Interface for edge methods.
    /// </summary>
    public interface IEdgeMethods
    {
        /// <summary>
        /// Create an edge between two nodes.
        /// </summary>
        /// <param name="edge">Edge.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Edge.</returns>
        Task<Edge> Create(Edge edge, CancellationToken token = default);

        /// <summary>
        /// Create multiple edges.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="edges">Edges.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Edges.</returns>
        Task<List<Edge>> CreateMany(Guid tenantGuid, Guid graphGuid, List<Edge> edges, CancellationToken token = default);

        /// <summary>
        /// Read edges.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="order">Enumeration order.</param>
        /// <param name="skip">The number of records to skip.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Edges.</returns>
        Task<List<Edge>> ReadMany(
            Guid tenantGuid,
            Guid graphGuid,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0,
            CancellationToken token = default);

        /// <summary>
        /// Read edge.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="edgeGuid">Edge GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Edge.</returns>
        Task<Edge> ReadByGuid(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, CancellationToken token = default);


        /// <summary>
        /// Get edges connected to or initiated from a given node.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="nodeGuid">Node GUID.</param>
        /// <param name="labels">Labels.</param>
        /// <param name="tags">Tags upon which to filter edges.</param>
        /// <param name="edgeFilter">
        /// Edge filter expression for Data JSON body.
        /// Expression left terms must follow the form of Sqlite JSON paths.
        /// For example, to retrieve the 'Name' property, use '$.Name', OperatorEnum.Equals, '[name here]'.</param>
        /// <param name="order">Enumeration order.</param>
        /// <param name="skip">The number of records to skip.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Edges.</returns>
        Task<List<Edge>> ReadNodeEdges(
            Guid tenantGuid,
            Guid graphGuid,
            Guid nodeGuid,
            List<string> labels = null,
            NameValueCollection tags = null,
            Expr edgeFilter = null,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0,
            CancellationToken token = default);

        /// <summary>
        /// Get edges from a given node.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="nodeGuid">Node GUID.</param>
        /// <param name="order">Enumeration order.</param>
        /// <param name="skip">The number of records to skip.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Edges.</returns>
        Task<List<Edge>> ReadEdgesFromNode(
            Guid tenantGuid,
            Guid graphGuid,
            Guid nodeGuid,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0,
            CancellationToken token = default);

        /// <summary>
        /// Get edges to a given node.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="nodeGuid">Node GUID.</param>
        /// <param name="order">Enumeration order.</param>
        /// <param name="skip">The number of records to skip.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Edges.</returns>
        Task<List<Edge>> ReadEdgesToNode(
            Guid tenantGuid,
            Guid graphGuid,
            Guid nodeGuid,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0,
            CancellationToken token = default);

        /// <summary>
        /// Get edges between two neighboring nodes.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="fromNodeGuid">From node GUID.</param>
        /// <param name="toNodeGuid">To node GUID.</param>
        /// <param name="order">Enumeration order.</param>
        /// <param name="skip">The number of records to skip.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Edges.</returns>
        Task<List<Edge>> ReadEdgesBetweenNodes(
            Guid tenantGuid,
            Guid graphGuid,
            Guid fromNodeGuid,
            Guid toNodeGuid,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0,
            CancellationToken token = default);

        /// <summary>
        /// Update edge.
        /// </summary>
        /// <param name="edge">Edge.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Edge.</returns>
        Task<Edge> Update(Edge edge, CancellationToken token = default);

        /// <summary>
        /// Delete edge.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="edgeGuid">Edge GUID.</param>
        /// <param name="token">Cancellation token.</param>
        Task DeleteByGuid(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, CancellationToken token = default);

        /// <summary>
        /// Delete all edges associated with a given node.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="nodeGuid">Node GUID.</param>
        /// <param name="token">Cancellation token.</param>
        Task DeleteNodeEdges(Guid tenantGuid, Guid graphGuid, Guid nodeGuid, CancellationToken token = default);

        /// <summary>
        /// Delete multiple edges from a graph.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="edgeGuids">Edge GUIDs.</param>
        /// <param name="token">Cancellation token.</param>
        Task DeleteMany(Guid tenantGuid, Guid graphGuid, List<Guid> edgeGuids, CancellationToken token = default);

        /// <summary>
        /// Check if an edge exists by GUID.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="edgeGuid">Edge GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>True if exists.</returns>
        Task<bool> ExistsByGuid(Guid tenantGuid, Guid graphGuid, Guid edgeGuid, CancellationToken token = default);

        /// <summary>
        /// Search edges.
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
        /// <returns>Edge.</returns>
        Task<Edge> ReadFirst(SearchRequest req, CancellationToken token = default);
    }
}