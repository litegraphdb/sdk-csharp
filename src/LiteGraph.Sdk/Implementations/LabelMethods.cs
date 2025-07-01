namespace LiteGraph.Sdk.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using LiteGraph.Sdk.Interfaces;

    /// <summary>
    /// Label methods.
    /// </summary>
    public class LabelMethods : ILabelMethods
    {
        #region Public-Members

        #endregion

        #region Private-Members

        private LiteGraphSdk _Sdk = null;

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Label methods.
        /// </summary>
        /// <param name="sdk">LiteGraph SDK.</param>
        public LabelMethods(LiteGraphSdk sdk)
        {
            _Sdk = sdk ?? throw new ArgumentNullException(nameof(sdk));
        }

        #endregion

        #region Public-Methods

        /// <inheritdoc />
        public async Task<LabelMetadata> Create(LabelMetadata label, CancellationToken token = default)
        {
            if (label == null) throw new ArgumentNullException(nameof(label));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + label.TenantGUID + "/labels";
            return await _Sdk.PutCreate<LabelMetadata>(url, label, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<List<LabelMetadata>> CreateMany(Guid tenantGuid, List<LabelMetadata> labels, CancellationToken token = default)
        {
            if (labels == null || labels.Count < 1) throw new ArgumentNullException(nameof(labels));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/labels/bulk";
            return await _Sdk.PutCreate<List<LabelMetadata>>(url, labels, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<List<LabelMetadata>> ReadMany(
            Guid tenantGuid,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0, 
            CancellationToken token = default)
        {
            if (skip < 0) throw new ArgumentOutOfRangeException(nameof(skip));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/labels?skip=" + skip + "&order=" + order.ToString();
            return await _Sdk.GetMany<LabelMetadata>(url, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<LabelMetadata> ReadByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/labels/" + guid;
            return await _Sdk.Get<LabelMetadata>(url, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<List<LabelMetadata>> ReadByGuids(Guid tenantGuid, List<Guid> guids, CancellationToken token = default)
        {
            if (guids == null || guids.Count < 1) throw new ArgumentNullException(nameof(guids));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/labels?guids=" + string.Join(",", guids);
            return await _Sdk.Get<List<LabelMetadata>>(url, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<LabelMetadata> Update(LabelMetadata label, CancellationToken token = default)
        {
            if (label == null) throw new ArgumentNullException(nameof(label));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + label.TenantGUID + "/labels/" + label.GUID;
            return await _Sdk.PutUpdate<LabelMetadata>(url, label, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task DeleteByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/labels/" + guid;
            await _Sdk.Delete(url, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task DeleteMany(Guid tenantGuid, List<Guid> guids, CancellationToken token = default)
        {
            if (guids == null || guids.Count < 1) throw new ArgumentNullException(nameof(guids));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/labels/bulk";
            await _Sdk.Delete<List<Guid>>(url, guids, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<bool> ExistsByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/labels/" + guid;
            return await _Sdk.Head(url, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<EnumerationResult<LabelMetadata>> Enumerate(EnumerationQuery query, CancellationToken token = default)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (query.TenantGUID == null) throw new ArgumentNullException(nameof(query.TenantGUID));
            string url = _Sdk.Endpoint + "v2.0/tenants/" + query.TenantGUID.Value + "/labels";
            return await _Sdk.Post<EnumerationQuery, EnumerationResult<LabelMetadata>>(url, query, token).ConfigureAwait(false);
        }

        #endregion

        #region Private-Methods

        #endregion
    }
}
