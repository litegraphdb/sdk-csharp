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
    /// Interface for vector methods.
    /// </summary>
    public interface IVectorMethods
    {
        /// <summary>
        /// Create a vector.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Vector.</returns>
        Task<VectorMetadata> Create(VectorMetadata vector, CancellationToken token = default);

        /// <summary>
        /// Create multiple vectors.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="vectors">Vectors.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Vectors.</returns>
        Task<List<VectorMetadata>> CreateMany(
            Guid tenantGuid,
            List<VectorMetadata> vectors,
            CancellationToken token = default);

        /// <summary>
        /// Read vectors.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="order">Enumeration order.</param>
        /// <param name="skip">Number of records to skip.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Vectors.</returns>
        Task<List<VectorMetadata>> ReadMany(
            Guid tenantGuid,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0,
            CancellationToken token = default);

        /// <summary>
        /// Read a vector by GUID.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Vector.</returns>
        Task<VectorMetadata> ReadByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default);

        /// <summary>
        /// Read vectors by GUIDs.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guids">GUIDs.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>List.</returns>
        Task<List<VectorMetadata>> ReadByGuids(Guid tenantGuid, List<Guid> guids, CancellationToken token = default);

        /// <summary>
        /// Update a vector.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Vector.</returns>
        Task<VectorMetadata> Update(VectorMetadata vector, CancellationToken token = default);

        /// <summary>
        /// Delete a vector.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">GUID.</param>
        /// <param name="token">Cancellation token.</param>
        Task DeleteByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default);

        /// <summary>
        /// Delete vectors.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guids">GUIDs.</param>
        /// <param name="token">Cancellation token.</param>
        Task DeleteMany(Guid tenantGuid, List<Guid> guids, CancellationToken token = default);

        /// <summary>
        /// Check if a vector exists by GUID.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>True if exists.</returns>
        Task<bool> ExistsByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default);

        /// <summary>
        /// Search vectors.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID.</param>
        /// <param name="searchReq">Search request.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Vector search result.</returns>
        Task<List<VectorSearchResult>> SearchVectors(
            Guid tenantGuid,
            Guid? graphGuid, 
            VectorSearchRequest searchReq, 
            CancellationToken token = default);

        /// <summary>
        /// Enumerate.
        /// </summary>
        /// <param name="query">Enumeration query.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Enumeration result.</returns>
        Task<EnumerationResult<VectorMetadata>> Enumerate(EnumerationQuery query, CancellationToken token = default);
    }
}