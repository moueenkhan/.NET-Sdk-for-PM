// <copyright file="PaymentsController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace PayMarkEFTPOS.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using PayMarkEFTPOS.Standard;
    using PayMarkEFTPOS.Standard.Authentication;
    using PayMarkEFTPOS.Standard.Http.Client;
    using PayMarkEFTPOS.Standard.Http.Request;
    using PayMarkEFTPOS.Standard.Http.Request.Configuration;
    using PayMarkEFTPOS.Standard.Http.Response;
    using PayMarkEFTPOS.Standard.Utilities;

    /// <summary>
    /// PaymentsController.
    /// </summary>
    public class PaymentsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal PaymentsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// Create a Regular Payment EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="contentType">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="authorization">Required parameter: Example: Bearer kARcGkNy4mArFN1HZQ2INAJ5mFDw.</param>
        /// <param name="regularPaymentBody">Required parameter: Example: .</param>
        /// <returns>Returns the Models.RegularPaymentResponse response from the API call.</returns>
        public Models.RegularPaymentResponse CreateARegularPayment(
                string accept,
                string contentType,
                string authorization,
                Models.RegularPaymentReqBody regularPaymentBody)
        {
            Task<Models.RegularPaymentResponse> t = this.CreateARegularPaymentAsync(accept, contentType, authorization, regularPaymentBody);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Create a Regular Payment EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="contentType">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="authorization">Required parameter: Example: Bearer kARcGkNy4mArFN1HZQ2INAJ5mFDw.</param>
        /// <param name="regularPaymentBody">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RegularPaymentResponse response from the API call.</returns>
        public async Task<Models.RegularPaymentResponse> CreateARegularPaymentAsync(
                string accept,
                string contentType,
                string authorization,
                Models.RegularPaymentReqBody regularPaymentBody,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/transaction/oepayment/");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Content-Type", contentType },
                { "Authorization", authorization },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(regularPaymentBody);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.RegularPaymentResponse>(response.Body);
        }

        /// <summary>
        /// Autopay Details EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="contentType">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="authorization">Required parameter: Example: Bearer kARcGkNy4mArFN1HZQ2INAJ5mFDw.</param>
        /// <param name="id">Required parameter: Example: 381a08c8-9189-4995-b07b-6c3821f70e35.</param>
        public void GetAutopayDetails(
                string accept,
                string contentType,
                string authorization,
                string id)
        {
            Task t = this.GetAutopayDetailsAsync(accept, contentType, authorization, id);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Autopay Details EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="contentType">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="authorization">Required parameter: Example: Bearer kARcGkNy4mArFN1HZQ2INAJ5mFDw.</param>
        /// <param name="id">Required parameter: Example: 381a08c8-9189-4995-b07b-6c3821f70e35.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetAutopayDetailsAsync(
                string accept,
                string contentType,
                string authorization,
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/oemerchanttrust/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Content-Type", contentType },
                { "Authorization", authorization },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Create a Refund EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="contentType">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="authorization">Required parameter: Example: Bearer kARcGkNy4mArFN1HZQ2INAJ5mFDw.</param>
        /// <param name="refundReqBody">Required parameter: Example: .</param>
        public void CreateARefund(
                string accept,
                string contentType,
                string authorization,
                Models.RefundReqBody refundReqBody)
        {
            Task t = this.CreateARefundAsync(accept, contentType, authorization, refundReqBody);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Create a Refund EndPoint.
        /// </summary>
        /// <param name="accept">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="contentType">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="authorization">Required parameter: Example: Bearer kARcGkNy4mArFN1HZQ2INAJ5mFDw.</param>
        /// <param name="refundReqBody">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task CreateARefundAsync(
                string accept,
                string contentType,
                string authorization,
                Models.RefundReqBody refundReqBody,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/transaction/oerefund/");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Content-Type", contentType },
                { "Authorization", authorization },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(refundReqBody);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Retrieve Multiple Payments EndPoint.
        /// </summary>
        /// <param name="orderId">Required parameter: Example: 165.</param>
        /// <param name="merchantIdCode">Required parameter: Example: 301234567.</param>
        /// <param name="payerId">Required parameter: Example: 0215551234.</param>
        /// <param name="fromCreationTime">Required parameter: Example: .</param>
        /// <param name="toCreationTime">Required parameter: Example: .</param>
        /// <param name="fromActualSettlementDate">Required parameter: Example: .</param>
        /// <param name="toActualSettlementDate">Required parameter: Example: .</param>
        /// <param name="status">Required parameter: Example: AUTHORISED.</param>
        /// <param name="offset">Required parameter: Example: 0fe3085c-1f8a-4830-b587-f778d0f5340a.</param>
        /// <param name="limit">Required parameter: Example: 2.</param>
        /// <param name="accept">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="contentType">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="authorization">Required parameter: Example: Bearer 2qYLkfqqeDb77GkYcgW1eAaNpGvY.</param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public dynamic RetrieveMultiplePayments(
                int orderId,
                int merchantIdCode,
                int payerId,
                DateTime fromCreationTime,
                DateTime toCreationTime,
                DateTime fromActualSettlementDate,
                DateTime toActualSettlementDate,
                string status,
                string offset,
                int limit,
                string accept,
                string contentType,
                string authorization)
        {
            Task<dynamic> t = this.RetrieveMultiplePaymentsAsync(orderId, merchantIdCode, payerId, fromCreationTime, toCreationTime, fromActualSettlementDate, toActualSettlementDate, status, offset, limit, accept, contentType, authorization);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve Multiple Payments EndPoint.
        /// </summary>
        /// <param name="orderId">Required parameter: Example: 165.</param>
        /// <param name="merchantIdCode">Required parameter: Example: 301234567.</param>
        /// <param name="payerId">Required parameter: Example: 0215551234.</param>
        /// <param name="fromCreationTime">Required parameter: Example: .</param>
        /// <param name="toCreationTime">Required parameter: Example: .</param>
        /// <param name="fromActualSettlementDate">Required parameter: Example: .</param>
        /// <param name="toActualSettlementDate">Required parameter: Example: .</param>
        /// <param name="status">Required parameter: Example: AUTHORISED.</param>
        /// <param name="offset">Required parameter: Example: 0fe3085c-1f8a-4830-b587-f778d0f5340a.</param>
        /// <param name="limit">Required parameter: Example: 2.</param>
        /// <param name="accept">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="contentType">Required parameter: Example: application/vnd.paymark_api+json.</param>
        /// <param name="authorization">Required parameter: Example: Bearer 2qYLkfqqeDb77GkYcgW1eAaNpGvY.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the dynamic response from the API call.</returns>
        public async Task<dynamic> RetrieveMultiplePaymentsAsync(
                int orderId,
                int merchantIdCode,
                int payerId,
                DateTime fromCreationTime,
                DateTime toCreationTime,
                DateTime fromActualSettlementDate,
                DateTime toActualSettlementDate,
                string status,
                string offset,
                int limit,
                string accept,
                string contentType,
                string authorization,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/transaction/oepayment/");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "orderId", orderId },
                { "merchantIdCode", merchantIdCode },
                { "payerId", payerId },
                { "fromCreationTime", fromCreationTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK") },
                { "toCreationTime", toCreationTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK") },
                { "fromActualSettlementDate", fromActualSettlementDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK") },
                { "toActualSettlementDate", toActualSettlementDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK") },
                { "status", status },
                { "offset", offset },
                { "limit", limit },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", accept },
                { "Content-Type", contentType },
                { "Authorization", authorization },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<dynamic>(response.Body);
        }
    }
}