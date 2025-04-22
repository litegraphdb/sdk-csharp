namespace LiteGraph.Sdk.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using ExpressionTree;
    using LiteGraph.Sdk.Interfaces;

    /// <summary>
    /// Graph methods.
    /// </summary>
    public class GraphMethods : IGraphMethods
    {
        #region Public-Members

        #endregion

        #region Private-Members

        private LiteGraphSdk _Sdk = null;

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Graph methods.
        /// </summary>
        /// <param name="sdk">LiteGraph SDK.</param>
        public GraphMethods(LiteGraphSdk sdk)
        {
            _Sdk = sdk ?? throw new ArgumentNullException(nameof(sdk));
        }

        #endregion

        #region Public-Methods

        /// <inheritdoc />
        public async Task<Graph> Create(Graph graph, CancellationToken token = default)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + graph.TenantGUID + "/graphs";
            return await _Sdk.PutCreate<Graph>(url, graph, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<List<Graph>> ReadMany(
            Guid tenantGuid,
            EnumerationOrderEnum order = EnumerationOrderEnum.CreatedDescending,
            int skip = 0, 
            CancellationToken token = default)
        {
            if (skip < 0) throw new ArgumentOutOfRangeException(nameof(skip));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/graphs?skip=" + skip + "&order=" + order.ToString();
            return await _Sdk.GetMany<Graph>(url, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Graph> ReadByGuid(Guid tenantGuid, Guid graphGuid, CancellationToken token = default)
        {
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/graphs/" + graphGuid;
            return await _Sdk.Get<Graph>(url, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Graph> Update(Graph graph, CancellationToken token = default)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + graph.TenantGUID + "/graphs/" + graph.GUID;
            return await _Sdk.PutUpdate<Graph>(url, graph, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task DeleteByGuid(Guid tenantGuid, Guid graphGuid, bool force = false, CancellationToken token = default)
        {
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/graphs/" + graphGuid;
            if (force) url += "?force";
            await _Sdk.Delete(url, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<bool> ExistsByGuid(Guid tenantGuid, Guid guid, CancellationToken token = default)
        {
            string url = _Sdk.Endpoint + "v1.0/tenants/" + tenantGuid + "/graphs/" + guid;
            return await _Sdk.Head(url, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<SearchResult> Search(SearchRequest req, CancellationToken token = default)
        {
            if (req == null) throw new ArgumentNullException(nameof(req));
            string url = _Sdk.Endpoint + "v1.0/tenants/" + req.TenantGUID + "/graphs/search";
            return await _Sdk.Post<SearchRequest, SearchResult>(url, req, token).ConfigureAwait(false);
        }

        #endregion

        #region Private-Methods

        #endregion
    }
}