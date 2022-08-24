// <copyright file="AuthController.cs" company="APIMatic">
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
    /// AuthController.
    /// </summary>
    public class AuthController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal AuthController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// Authenticate EndPoint.
        /// </summary>
        /// <param name="contentType">Required parameter: Example: application/x-www-form-urlencoded.</param>
        /// <param name="authorization">Required parameter: Example: Basic dUhucXY2a3pveTJZQWM5NTdHRGhhbm5LUzZUVmltRzM6QkVBTGZhTVFuSnRsWEc4aQ==.</param>
        /// <param name="grantType">Required parameter: Example: client_credentials.</param>
        /// <returns>Returns the Models.AuthenticationResponse response from the API call.</returns>
        public Models.AuthenticationResponse CreateAuthenticate(
                string contentType,
                string authorization,
                string grantType)
        {
            Task<Models.AuthenticationResponse> t = this.CreateAuthenticateAsync(contentType, authorization, grantType);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Authenticate EndPoint.
        /// </summary>
        /// <param name="contentType">Required parameter: Example: application/x-www-form-urlencoded.</param>
        /// <param name="authorization">Required parameter: Example: Basic dUhucXY2a3pveTJZQWM5NTdHRGhhbm5LUzZUVmltRzM6QkVBTGZhTVFuSnRsWEc4aQ==.</param>
        /// <param name="grantType">Required parameter: Example: client_credentials.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AuthenticationResponse response from the API call.</returns>
        public async Task<Models.AuthenticationResponse> CreateAuthenticateAsync(
                string contentType,
                string authorization,
                string grantType,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/bearer/");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", contentType },
                { "Authorization", authorization },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("grant_type", grantType),
            };

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, fields);

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.AuthenticationResponse>(response.Body);
        }
    }
}