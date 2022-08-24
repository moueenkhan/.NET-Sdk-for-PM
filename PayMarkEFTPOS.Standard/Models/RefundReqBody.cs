// <copyright file="RefundReqBody.cs" company="APIMatic">
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
    /// RefundReqBody.
    /// </summary>
    public class RefundReqBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefundReqBody"/> class.
        /// </summary>
        public RefundReqBody()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RefundReqBody"/> class.
        /// </summary>
        /// <param name="merchant">merchant.</param>
        /// <param name="transaction">transaction.</param>
        public RefundReqBody(
            Models.Merchant2 merchant,
            Models.Transaction2 transaction)
        {
            this.Merchant = merchant;
            this.Transaction = transaction;
        }

        /// <summary>
        /// Gets or sets Merchant.
        /// </summary>
        [JsonProperty("merchant")]
        public Models.Merchant2 Merchant { get; set; }

        /// <summary>
        /// Gets or sets Transaction.
        /// </summary>
        [JsonProperty("transaction")]
        public Models.Transaction2 Transaction { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RefundReqBody : ({string.Join(", ", toStringOutput)})";
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

            return obj is RefundReqBody other &&
                ((this.Merchant == null && other.Merchant == null) || (this.Merchant?.Equals(other.Merchant) == true)) &&
                ((this.Transaction == null && other.Transaction == null) || (this.Transaction?.Equals(other.Transaction) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Merchant = {(this.Merchant == null ? "null" : this.Merchant.ToString())}");
            toStringOutput.Add($"this.Transaction = {(this.Transaction == null ? "null" : this.Transaction.ToString())}");
        }
    }
}