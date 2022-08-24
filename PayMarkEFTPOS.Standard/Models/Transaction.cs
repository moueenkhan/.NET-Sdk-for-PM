// <copyright file="Transaction.cs" company="APIMatic">
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
    /// Transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        public Transaction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="amount">amount.</param>
        /// <param name="transactionType">transactionType.</param>
        /// <param name="currency">currency.</param>
        /// <param name="description">description.</param>
        /// <param name="orderId">orderId.</param>
        /// <param name="userAgent">userAgent.</param>
        /// <param name="userIpAddress">userIpAddress.</param>
        public Transaction(
            int amount,
            string transactionType,
            string currency,
            string description,
            string orderId,
            string userAgent,
            string userIpAddress)
        {
            this.Amount = amount;
            this.TransactionType = transactionType;
            this.Currency = currency;
            this.Description = description;
            this.OrderId = orderId;
            this.UserAgent = userAgent;
            this.UserIpAddress = userIpAddress;
        }

        /// <summary>
        /// Gets or sets Amount.
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets TransactionType.
        /// </summary>
        [JsonProperty("transactionType")]
        public string TransactionType { get; set; }

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets OrderId.
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets UserAgent.
        /// </summary>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets UserIpAddress.
        /// </summary>
        [JsonProperty("userIpAddress")]
        public string UserIpAddress { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Transaction : ({string.Join(", ", toStringOutput)})";
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

            return obj is Transaction other &&
                this.Amount.Equals(other.Amount) &&
                ((this.TransactionType == null && other.TransactionType == null) || (this.TransactionType?.Equals(other.TransactionType) == true)) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.UserAgent == null && other.UserAgent == null) || (this.UserAgent?.Equals(other.UserAgent) == true)) &&
                ((this.UserIpAddress == null && other.UserIpAddress == null) || (this.UserIpAddress?.Equals(other.UserIpAddress) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Amount = {this.Amount}");
            toStringOutput.Add($"this.TransactionType = {(this.TransactionType == null ? "null" : this.TransactionType == string.Empty ? "" : this.TransactionType)}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency == string.Empty ? "" : this.Currency)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
            toStringOutput.Add($"this.UserAgent = {(this.UserAgent == null ? "null" : this.UserAgent == string.Empty ? "" : this.UserAgent)}");
            toStringOutput.Add($"this.UserIpAddress = {(this.UserIpAddress == null ? "null" : this.UserIpAddress == string.Empty ? "" : this.UserIpAddress)}");
        }
    }
}