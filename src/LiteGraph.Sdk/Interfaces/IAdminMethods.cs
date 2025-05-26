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
    /// Interface for admin methods.
    /// </summary>
    public interface IAdminMethods
    {
        /// <summary>
        /// Database backup request.
        /// </summary>
        /// <param name="outputFilename">Output filename.</param>
        /// <param name="token">Cancellation token.</param>
        Task Backup(string outputFilename, CancellationToken token = default);
    }
}