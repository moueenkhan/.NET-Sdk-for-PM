// <copyright file="Bank.cs" company="APIMatic">
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
    /// Bank.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class.
        /// </summary>
        public Bank()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class.
        /// </summary>
        /// <param name="payerId">payerId.</param>
        /// <param name="bankId">bankId.</param>
        /// <param name="payerIdType">payerIdType.</param>
        public Bank(
            string payerId,
            string bankId,
            string payerIdType)
        {
            this.PayerId = payerId;
            this.BankId = bankId;
            this.PayerIdType = payerIdType;
        }

        /// <summary>
        /// Gets or sets PayerId.
        /// </summary>
        [JsonProperty("payerId")]
        public string PayerId { get; set; }

        /// <summary>
        /// Gets or sets BankId.
        /// </summary>
        [JsonProperty("bankId")]
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets PayerIdType.
        /// </summary>
        [JsonProperty("payerIdType")]
        public string PayerIdType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Bank : ({string.Join(", ", toStringOutput)})";
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

            return obj is Bank other &&
                ((this.PayerId == null && other.PayerId == null) || (this.PayerId?.Equals(other.PayerId) == true)) &&
                ((this.BankId == null && other.BankId == null) || (this.BankId?.Equals(other.BankId) == true)) &&
                ((this.PayerIdType == null && other.PayerIdType == null) || (this.PayerIdType?.Equals(other.PayerIdType) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PayerId = {(this.PayerId == null ? "null" : this.PayerId == string.Empty ? "" : this.PayerId)}");
            toStringOutput.Add($"this.BankId = {(this.BankId == null ? "null" : this.BankId == string.Empty ? "" : this.BankId)}");
            toStringOutput.Add($"this.PayerIdType = {(this.PayerIdType == null ? "null" : this.PayerIdType == string.Empty ? "" : this.PayerIdType)}");
        }
    }
}