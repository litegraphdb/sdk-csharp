namespace LiteGraph.Sdk.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using LiteGraph.Sdk.Interfaces;

    /// <summary>
    /// Admin methods.
    /// </summary>
    public class AdminMethods : IAdminMethods
    {
        #region Public-Members

        #endregion

        #region Private-Members

        private LiteGraphSdk _Sdk = null;

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Admin methods.
        /// </summary>
        /// <param name="sdk">LiteGraph SDK.</param>
        public AdminMethods(LiteGraphSdk sdk)
        {
            _Sdk = sdk ?? throw new ArgumentNullException(nameof(sdk));
        }

        #endregion

        #region Public-Methods

        /// <inheritdoc />
        public async Task Backup(string outputFilename, CancellationToken token = default)
        {
            if (String.IsNullOrEmpty(outputFilename)) throw new ArgumentNullException(nameof(outputFilename));
            string url = _Sdk.Endpoint + "v1.0/backup";

            BackupRequest req = new BackupRequest
            {
                Filename = outputFilename
            };

            await _Sdk.Post<BackupRequest, object>(url, req, token).ConfigureAwait(false);
        }

        #endregion

        #region Private-Methods

        #endregion
    }
}
