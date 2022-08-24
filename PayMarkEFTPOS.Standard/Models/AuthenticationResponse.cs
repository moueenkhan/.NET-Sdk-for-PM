// <copyright file="AuthenticationResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace PayMarkEFTPOS.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using PayMarkEFTPOS.Standard;
    using PayMarkEFTPOS.Standard.Utilities;

    /// <summary>
    /// AuthenticationResponse.
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationResponse"/> class.
        /// </summary>
        public AuthenticationResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationResponse"/> class.
        /// </summary>
        /// <param name="issuedAt">issued_at.</param>
        /// <param name="applicationName">application_name.</param>
        /// <param name="scope">scope.</param>
        /// <param name="status">status.</param>
        /// <param name="expiresIn">expires_in.</param>
        /// <param name="tokenType">token_type.</param>
        /// <param name="clientId">client_id.</param>
        /// <param name="accessToken">access_token.</param>
        public AuthenticationResponse(
            string issuedAt,
            string applicationName,
            string scope,
            string status,
            string expiresIn,
            string tokenType,
            string clientId,
            string accessToken)
        {
            this.IssuedAt = issuedAt;
            this.ApplicationName = applicationName;
            this.Scope = scope;
            this.Status = status;
            this.ExpiresIn = expiresIn;
            this.TokenType = tokenType;
            this.ClientId = clientId;
            this.AccessToken = accessToken;
        }

        /// <summary>
        /// Gets or sets IssuedAt.
        /// </summary>
        [JsonProperty("issued_at")]
        public string IssuedAt { get; set; }

        /// <summary>
        /// Gets or sets ApplicationName.
        /// </summary>
        [JsonProperty("application_name")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets Scope.
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets ExpiresIn.
        /// </summary>
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets TokenType.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets ClientId.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets AccessToken.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AuthenticationResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is AuthenticationResponse other &&
                ((this.IssuedAt == null && other.IssuedAt == null) || (this.IssuedAt?.Equals(other.IssuedAt) == true)) &&
                ((this.ApplicationName == null && other.ApplicationName == null) || (this.ApplicationName?.Equals(other.ApplicationName) == true)) &&
                ((this.Scope == null && other.Scope == null) || (this.Scope?.Equals(other.Scope) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.ExpiresIn == null && other.ExpiresIn == null) || (this.ExpiresIn?.Equals(other.ExpiresIn) == true)) &&
                ((this.TokenType == null && other.TokenType == null) || (this.TokenType?.Equals(other.TokenType) == true)) &&
                ((this.ClientId == null && other.ClientId == null) || (this.ClientId?.Equals(other.ClientId) == true)) &&
                ((this.AccessToken == null && other.AccessToken == null) || (this.AccessToken?.Equals(other.AccessToken) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IssuedAt = {(this.IssuedAt == null ? "null" : this.IssuedAt == string.Empty ? "" : this.IssuedAt)}");
            toStringOutput.Add($"this.ApplicationName = {(this.ApplicationName == null ? "null" : this.ApplicationName == string.Empty ? "" : this.ApplicationName)}");
            toStringOutput.Add($"this.Scope = {(this.Scope == null ? "null" : this.Scope == string.Empty ? "" : this.Scope)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"this.ExpiresIn = {(this.ExpiresIn == null ? "null" : this.ExpiresIn == string.Empty ? "" : this.ExpiresIn)}");
            toStringOutput.Add($"this.TokenType = {(this.TokenType == null ? "null" : this.TokenType == string.Empty ? "" : this.TokenType)}");
            toStringOutput.Add($"this.ClientId = {(this.ClientId == null ? "null" : this.ClientId == string.Empty ? "" : this.ClientId)}");
            toStringOutput.Add($"this.AccessToken = {(this.AccessToken == null ? "null" : this.AccessToken == string.Empty ? "" : this.AccessToken)}");
        }
    }
}