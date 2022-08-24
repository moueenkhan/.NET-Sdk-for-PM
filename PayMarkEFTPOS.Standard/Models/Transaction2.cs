// <copyright file="Transaction2.cs" company="APIMatic">
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
    /// Transaction2.
    /// </summary>
    public class Transaction2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction2"/> class.
        /// </summary>
        public Transaction2()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction2"/> class.
        /// </summary>
        /// <param name="refundAmount">refundAmount.</param>
        /// <param name="refundReason">refundReason.</param>
        /// <param name="refundId">refundId.</param>
        /// <param name="originalPaymentId">originalPaymentId.</param>
        /// <param name="userAgent">userAgent.</param>
        /// <param name="userIpAddress">userIpAddress.</param>
        public Transaction2(
            int refundAmount,
            string refundReason,
            string refundId,
            string originalPaymentId,
            string userAgent,
            string userIpAddress)
        {
            this.RefundAmount = refundAmount;
            this.RefundReason = refundReason;
            this.RefundId = refundId;
            this.OriginalPaymentId = originalPaymentId;
            this.UserAgent = userAgent;
            this.UserIpAddress = userIpAddress;
        }

        /// <summary>
        /// Gets or sets RefundAmount.
        /// </summary>
        [JsonProperty("refundAmount")]
        public int RefundAmount { get; set; }

        /// <summary>
        /// Gets or sets RefundReason.
        /// </summary>
        [JsonProperty("refundReason")]
        public string RefundReason { get; set; }

        /// <summary>
        /// Gets or sets RefundId.
        /// </summary>
        [JsonProperty("refundId")]
        public string RefundId { get; set; }

        /// <summary>
        /// Gets or sets OriginalPaymentId.
        /// </summary>
        [JsonProperty("originalPaymentId")]
        public string OriginalPaymentId { get; set; }

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

            return $"Transaction2 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Transaction2 other &&
                this.RefundAmount.Equals(other.RefundAmount) &&
                ((this.RefundReason == null && other.RefundReason == null) || (this.RefundReason?.Equals(other.RefundReason) == true)) &&
                ((this.RefundId == null && other.RefundId == null) || (this.RefundId?.Equals(other.RefundId) == true)) &&
                ((this.OriginalPaymentId == null && other.OriginalPaymentId == null) || (this.OriginalPaymentId?.Equals(other.OriginalPaymentId) == true)) &&
                ((this.UserAgent == null && other.UserAgent == null) || (this.UserAgent?.Equals(other.UserAgent) == true)) &&
                ((this.UserIpAddress == null && other.UserIpAddress == null) || (this.UserIpAddress?.Equals(other.UserIpAddress) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.RefundAmount = {this.RefundAmount}");
            toStringOutput.Add($"this.RefundReason = {(this.RefundReason == null ? "null" : this.RefundReason == string.Empty ? "" : this.RefundReason)}");
            toStringOutput.Add($"this.RefundId = {(this.RefundId == null ? "null" : this.RefundId == string.Empty ? "" : this.RefundId)}");
            toStringOutput.Add($"this.OriginalPaymentId = {(this.OriginalPaymentId == null ? "null" : this.OriginalPaymentId == string.Empty ? "" : this.OriginalPaymentId)}");
            toStringOutput.Add($"this.UserAgent = {(this.UserAgent == null ? "null" : this.UserAgent == string.Empty ? "" : this.UserAgent)}");
            toStringOutput.Add($"this.UserIpAddress = {(this.UserIpAddress == null ? "null" : this.UserIpAddress == string.Empty ? "" : this.UserIpAddress)}");
        }
    }
}