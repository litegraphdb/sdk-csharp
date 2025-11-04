namespace LiteGraph.Sdk
{
    using LiteGraph.Sdk.Implementations;
    using LiteGraph.Sdk.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// LiteGraph SDK. 
    /// </summary>
    public class LiteGraphSdk : SdkBase
    {
        #region Public-Members

        /// <summary>
        /// Admin methods.
        /// </summary>
        public IAdminMethods Admin { get; }

        /// <summary>
        /// Batch methods.
        /// </summary>
        public IBatchMethods Batch { get; }
        
        /// <summary>
        /// Credential methods.
        /// </summary>
        public ICredentialMethods Credential { get; }

        /// <summary>
        /// Edge methods.
        /// </summary>
        public IEdgeMethods Edge { get; }

        /// <summary>
        /// Graph methods.
        /// </summary>
        public IGraphMethods Graph { get; }

        /// <summary>
        /// Label methods.
        /// </summary>
        public ILabelMethods Label { get; }

        /// <summary>
        /// Node methods.
        /// </summary>
        public INodeMethods Node { get; }

        /// <summary>
        /// Tag methods.
        /// </summary>
        public ITagMethods Tag { get; }

        /// <summary>
        /// Tenant methods.
        /// </summary>
        public ITenantMethods Tenant { get; }

        /// <summary>
        /// User methods.
        /// </summary>
        public IUserMethods User { get; }

        /// <summary>
        /// Vector methods.
        /// </summary>
        public IVectorMethods Vector { get; }

        /// <summary>
        /// User authentication methods.
        /// </summary>
        public IUserAuthentication UserAuthentication { get; }

        #endregion

        #region Private-Members

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate.
        /// </summary>
        /// <param name="endpoint">Endpoint URL.</param>
        /// <param name="bearerToken">Bearer token.</param>
        public LiteGraphSdk(
            string endpoint = "http://localhost:8701/",
            string bearerToken = "default") : base(endpoint, bearerToken)
        {
            Admin = new AdminMethods(this);
            Batch = new BatchMethods(this);
            Credential = new CredentialMethods(this);
            Edge = new EdgeMethods(this);
            Graph = new GraphMethods(this);
            Label = new LabelMethods(this);
            Node = new NodeMethods(this);
            Tag = new TagMethods(this);
            Tenant = new TenantMethods(this);
            User = new UserMethods(this);
            Vector = new VectorMethods(this);
            UserAuthentication = new UserAuthentication(this);
        }

        #endregion

        #region Public-Methods

        #endregion

        #region Private-Methods

        #endregion
    }
}
