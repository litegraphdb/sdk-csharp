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
    /// Interface for label methods.
    /// </summary>
    public interface ILabelMethods
    {
        /// <summary>
        /// Create a label.
        /// </summary>
        /// <param name="label">Label.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Label.</returns>
        Task<LabelMetadata> Create(LabelMetadata label, CancellationToken token = default);

        /// <summary>
        /// Create multiple labels.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="labels">Labels.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Labels.</returns>
        Task<List<LabelMetadata>> CreateMany(Guid tenantGuid, List<LabelMetadata> labels, CancellationToken token = default);

        /// <summary>
        /// Read labels.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="graphGuid">Graph GUID (optional filter).</param>
        /// <param name="nodeGuid">Node GUID (optional filter).</param>
        /// <param name="edgeGuid">Edge GUID (optional filter).</param>
        /// <param name="order">Enumeration order.</param>
        /// <param name="skip">Number of records to skip.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Labels.</returns>
        Task<List<LabelMetadata>> ReadMany(
            Guid tenantGuid,
            Guid? graphGuid = null,
            Guid? nodeGuid = null,
            Guid? edgeGuid = null,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0,
            CancellationToken token = default);

        /// <summary>
        /// Read a label by GUID.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Label.</returns>
        Task<LabelMetadata> ReadByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default);

        /// <summary>
        /// Read labels by GUIDs.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guids">GUIDs.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>List.</returns>
        Task<List<LabelMetadata>> ReadByGuids(Guid tenantGuid, List<Guid> guids, CancellationToken token = default);

        /// <summary>
        /// Update a label.
        /// </summary>
        /// <param name="label">Label.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Label.</returns>
        Task<LabelMetadata> Update(LabelMetadata label, CancellationToken token = default);

        /// <summary>
        /// Delete a label.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">GUID.</param>
        /// <param name="token">Cancellation token.</param>
        Task DeleteByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default);

        /// <summary>
        /// Delete labels.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guids">GUIDs.</param>
        /// <param name="token">Cancellation token.</param>
        Task DeleteMany(Guid tenantGuid, List<Guid> guids, CancellationToken token = default);

        /// <summary>
        /// Check if a label exists by GUID.
        /// </summary>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="guid">GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>True if exists.</returns>
        Task<bool> ExistsByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default);

        /// <summary>
        /// Enumerate.
        /// </summary>
        /// <param name="query">Enumeration query.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Enumeration result.</returns>
        Task<EnumerationResult<LabelMetadata>> Enumerate(EnumerationRequest query, CancellationToken token = default);
    }
}