// <copyright file="RegularPaymentReqBody.cs" company="APIMatic">
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
    /// RegularPaymentReqBody.
    /// </summary>
    public class RegularPaymentReqBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegularPaymentReqBody"/> class.
        /// </summary>
        public RegularPaymentReqBody()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegularPaymentReqBody"/> class.
        /// </summary>
        /// <param name="bank">bank.</param>
        /// <param name="merchant">merchant.</param>
        /// <param name="transaction">transaction.</param>
        public RegularPaymentReqBody(
            Models.Bank bank,
            Models.Merchant merchant,
            Models.Transaction transaction)
        {
            this.Bank = bank;
            this.Merchant = merchant;
            this.Transaction = transaction;
        }

        /// <summary>
        /// Gets or sets Bank.
        /// </summary>
        [JsonProperty("bank")]
        public Models.Bank Bank { get; set; }

        /// <summary>
        /// Gets or sets Merchant.
        /// </summary>
        [JsonProperty("merchant")]
        public Models.Merchant Merchant { get; set; }

        /// <summary>
        /// Gets or sets Transaction.
        /// </summary>
        [JsonProperty("transaction")]
        public Models.Transaction Transaction { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RegularPaymentReqBody : ({string.Join(", ", toStringOutput)})";
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

            return obj is RegularPaymentReqBody other &&
                ((this.Bank == null && other.Bank == null) || (this.Bank?.Equals(other.Bank) == true)) &&
                ((this.Merchant == null && other.Merchant == null) || (this.Merchant?.Equals(other.Merchant) == true)) &&
                ((this.Transaction == null && other.Transaction == null) || (this.Transaction?.Equals(other.Transaction) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Bank = {(this.Bank == null ? "null" : this.Bank.ToString())}");
            toStringOutput.Add($"this.Merchant = {(this.Merchant == null ? "null" : this.Merchant.ToString())}");
            toStringOutput.Add($"this.Transaction = {(this.Transaction == null ? "null" : this.Transaction.ToString())}");
        }
    }
}