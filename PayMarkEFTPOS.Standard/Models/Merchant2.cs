// <copyright file="Merchant2.cs" company="APIMatic">
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
    /// Merchant2.
    /// </summary>
    public class Merchant2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Merchant2"/> class.
        /// </summary>
        public Merchant2()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Merchant2"/> class.
        /// </summary>
        /// <param name="merchantIdCode">merchantIdCode.</param>
        public Merchant2(
            string merchantIdCode)
        {
            this.MerchantIdCode = merchantIdCode;
        }

        /// <summary>
        /// Gets or sets MerchantIdCode.
        /// </summary>
        [JsonProperty("merchantIdCode")]
        public string MerchantIdCode { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Merchant2 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Merchant2 other &&
                ((this.MerchantIdCode == null && other.MerchantIdCode == null) || (this.MerchantIdCode?.Equals(other.MerchantIdCode) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantIdCode = {(this.MerchantIdCode == null ? "null" : this.MerchantIdCode == string.Empty ? "" : this.MerchantIdCode)}");
        }
    }
}