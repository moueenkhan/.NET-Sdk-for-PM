// <copyright file="Merchant1.cs" company="APIMatic">
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
    /// Merchant1.
    /// </summary>
    public class Merchant1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Merchant1"/> class.
        /// </summary>
        public Merchant1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Merchant1"/> class.
        /// </summary>
        /// <param name="merchantIdCode">merchantIdCode.</param>
        /// <param name="callbackUrl">callbackUrl.</param>
        public Merchant1(
            string merchantIdCode,
            string callbackUrl)
        {
            this.MerchantIdCode = merchantIdCode;
            this.CallbackUrl = callbackUrl;
        }

        /// <summary>
        /// Gets or sets MerchantIdCode.
        /// </summary>
        [JsonProperty("merchantIdCode")]
        public string MerchantIdCode { get; set; }

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

            return $"Merchant1 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Merchant1 other &&
                ((this.MerchantIdCode == null && other.MerchantIdCode == null) || (this.MerchantIdCode?.Equals(other.MerchantIdCode) == true)) &&
                ((this.CallbackUrl == null && other.CallbackUrl == null) || (this.CallbackUrl?.Equals(other.CallbackUrl) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantIdCode = {(this.MerchantIdCode == null ? "null" : this.MerchantIdCode == string.Empty ? "" : this.MerchantIdCode)}");
            toStringOutput.Add($"this.CallbackUrl = {(this.CallbackUrl == null ? "null" : this.CallbackUrl == string.Empty ? "" : this.CallbackUrl)}");
        }
    }
}