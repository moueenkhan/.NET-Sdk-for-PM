// <copyright file="Merchant.cs" company="APIMatic">
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
    /// Merchant.
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Merchant"/> class.
        /// </summary>
        public Merchant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Merchant"/> class.
        /// </summary>
        /// <param name="merchantIdCode">merchantIdCode.</param>
        /// <param name="merchantUrl">merchantUrl.</param>
        /// <param name="callbackUrl">callbackUrl.</param>
        public Merchant(
            string merchantIdCode,
            string merchantUrl,
            string callbackUrl)
        {
            this.MerchantIdCode = merchantIdCode;
            this.MerchantUrl = merchantUrl;
            this.CallbackUrl = callbackUrl;
        }

        /// <summary>
        /// Gets or sets MerchantIdCode.
        /// </summary>
        [JsonProperty("merchantIdCode")]
        public string MerchantIdCode { get; set; }

        /// <summary>
        /// Gets or sets MerchantUrl.
        /// </summary>
        [JsonProperty("merchantUrl")]
        public string MerchantUrl { get; set; }

        /// <summary>
        /// Gets or sets CallbackUrl.
        /// </summary>
        [JsonProperty("callbackUrl")]
        public string CallbackUrl { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Merchant : ({string.Join(", ", toStringOutput)})";
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

            return obj is Merchant other &&
                ((this.MerchantIdCode == null && other.MerchantIdCode == null) || (this.MerchantIdCode?.Equals(other.MerchantIdCode) == true)) &&
                ((this.MerchantUrl == null && other.MerchantUrl == null) || (this.MerchantUrl?.Equals(other.MerchantUrl) == true)) &&
                ((this.CallbackUrl == null && other.CallbackUrl == null) || (this.CallbackUrl?.Equals(other.CallbackUrl) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantIdCode = {(this.MerchantIdCode == null ? "null" : this.MerchantIdCode == string.Empty ? "" : this.MerchantIdCode)}");
            toStringOutput.Add($"this.MerchantUrl = {(this.MerchantUrl == null ? "null" : this.MerchantUrl == string.Empty ? "" : this.MerchantUrl)}");
            toStringOutput.Add($"this.CallbackUrl = {(this.CallbackUrl == null ? "null" : this.CallbackUrl == string.Empty ? "" : this.CallbackUrl)}");
        }
    }
}