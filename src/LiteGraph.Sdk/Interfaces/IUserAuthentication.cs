namespace LiteGraph.Sdk.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using LiteGraph.Sdk;

    /// <summary>
    /// Interface for user authentication methods.
    /// </summary>
    public interface IUserAuthentication
    {
        /// <summary>
        /// Get tenants for an email address.
        /// </summary>
        /// <param name="email">Email address.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>List of tenants.</returns>
        Task<List<TenantMetadata>> GetTenantsForEmail(string email, CancellationToken token = default);

        /// <summary>
        /// Generate a security token.
        /// </summary>
        /// <param name="email">Email address.</param>
        /// <param name="password">Password.</param>
        /// <param name="tenantGuid">Tenant GUID.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Authentication token.</returns>
        Task<AuthenticationToken> GenerateToken(string email, string password, Guid tenantGuid, CancellationToken token = default);

        /// <summary>
        /// Get token details.
        /// </summary>
        /// <param name="authToken">Authentication token string.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Authentication token details.</returns>
        Task<AuthenticationToken> GetTokenDetails(string authToken, CancellationToken token = default);
    }
}

