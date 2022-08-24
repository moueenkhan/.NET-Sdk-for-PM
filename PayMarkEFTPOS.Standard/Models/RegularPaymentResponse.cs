// <copyright file="RegularPaymentResponse.cs" company="APIMatic">
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
    /// RegularPaymentResponse.
    /// </summary>
    public class RegularPaymentResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegularPaymentResponse"/> class.
        /// </summary>
        public RegularPaymentResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegularPaymentResponse"/> class.
        /// </summary>
        /// <param name="links">links.</param>
        /// <param name="id">id.</param>
        /// <param name="status">status.</param>
        /// <param name="bank">bank.</param>
        /// <param name="merchant">merchant.</param>
        /// <param name="transaction">transaction.</param>
        /// <param name="creationTime">creationTime.</param>
        /// <param name="modificationTime">modificationTime.</param>
        public RegularPaymentResponse(
            List<Models.Link> links,
            string id,
            string status,
            Models.Bank bank,
            Models.Merchant1 merchant,
            Models.Transaction1 transaction,
            string creationTime,
            string modificationTime)
        {
            this.Links = links;
            this.Id = id;
            this.Status = status;
            this.Bank = bank;
            this.Merchant = merchant;
            this.Transaction = transaction;
            this.CreationTime = creationTime;
            this.ModificationTime = modificationTime;
        }

        /// <summary>
        /// Gets or sets Links.
        /// </summary>
        [JsonProperty("links")]
        public List<Models.Link> Links { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets Bank.
        /// </summary>
        [JsonProperty("bank")]
        public Models.Bank Bank { get; set; }

        /// <summary>
        /// Gets or sets Merchant.
        /// </summary>
        [JsonProperty("merchant")]
        public Models.Merchant1 Merchant { get; set; }

        /// <summary>
        /// Gets or sets Transaction.
        /// </summary>
        [JsonProperty("transaction")]
        public Models.Transaction1 Transaction { get; set; }

        /// <summary>
        /// Gets or sets CreationTime.
        /// </summary>
        [JsonProperty("creationTime")]
        public string CreationTime { get; set; }

        /// <summary>
        /// Gets or sets ModificationTime.
        /// </summary>
        [JsonProperty("modificationTime")]
        public string ModificationTime { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RegularPaymentResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is RegularPaymentResponse other &&
                ((this.Links == null && other.Links == null) || (this.Links?.Equals(other.Links) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Bank == null && other.Bank == null) || (this.Bank?.Equals(other.Bank) == true)) &&
                ((this.Merchant == null && other.Merchant == null) || (this.Merchant?.Equals(other.Merchant) == true)) &&
                ((this.Transaction == null && other.Transaction == null) || (this.Transaction?.Equals(other.Transaction) == true)) &&
                ((this.CreationTime == null && other.CreationTime == null) || (this.CreationTime?.Equals(other.CreationTime) == true)) &&
                ((this.ModificationTime == null && other.ModificationTime == null) || (this.ModificationTime?.Equals(other.ModificationTime) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Links = {(this.Links == null ? "null" : $"[{string.Join(", ", this.Links)} ]")}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"this.Bank = {(this.Bank == null ? "null" : this.Bank.ToString())}");
            toStringOutput.Add($"this.Merchant = {(this.Merchant == null ? "null" : this.Merchant.ToString())}");
            toStringOutput.Add($"this.Transaction = {(this.Transaction == null ? "null" : this.Transaction.ToString())}");
            toStringOutput.Add($"this.CreationTime = {(this.CreationTime == null ? "null" : this.CreationTime == string.Empty ? "" : this.CreationTime)}");
            toStringOutput.Add($"this.ModificationTime = {(this.ModificationTime == null ? "null" : this.ModificationTime == string.Empty ? "" : this.ModificationTime)}");
        }
    }
}