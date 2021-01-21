using RealoAPI.Models;
using RestSharp;
using System;
using System.Security.Cryptography;
using System.Text;

namespace RealoAPI {

    class RealoRestClient {

        private RestClient Client { get; set; }

        private string Url { get; set; }
        private string PublicKey { get; set; }
        private string PrivateKey { get; set; }

        /// <summary>
        /// Creates a new object of the custom restclient.
        /// This client contains all neccecairy headers.
        /// </summary>
        /// <param name="url"></param>
        public RealoRestClient(string publicKey, string privateKey, string url) {
            if (string.IsNullOrWhiteSpace(publicKey) || string.IsNullOrWhiteSpace(privateKey) || string.IsNullOrWhiteSpace(url)) {
                throw new ArgumentException("The public key, private key and url cannot be null or empty!");
            }

            Client = new RestClient(url);

            Url = url;
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        /// <summary>
        /// Do a GET request.
        /// </summary>
        /// <param name="resource">The resource URL</param>
        /// <returns>An IRestResponse with all information</returns>
        public IRestResponse Get(string resource) {
            return Client.Get(CreateRequest(RequestMethod.GET, resource));
        }

        /// <summary>
        /// Do a POST request.
        /// </summary>
        /// <param name="resource">The resource URL</param>
        /// <returns>An IRestResponse with all information</returns>
        public IRestResponse Post(string resource) {
            return Client.Post(CreateRequest(RequestMethod.POST, resource));
        }

        /// <summary>
        /// Do PUT request.
        /// </summary>
        /// <param name="resource">The resource URL</param>
        /// <returns>An IRestResponse with all information</returns>
        public IRestResponse Put(string resource) {
            return Client.Get(CreateRequest(RequestMethod.PUT, resource));
        }

        /// <summary>
        /// Do a DELETE request.
        /// </summary>
        /// <param name="resource">The resource URL</param>
        /// <returns>An IRestResponse with all information</returns>
        public IRestResponse Delete(string resource) {
            return Client.Get(CreateRequest(RequestMethod.DELETE, resource));
        }

        /// <summary>
        /// Creates a new request we can use.
        /// Adds the correct headers and authorization.
        /// </summary>
        /// <param name="requestMethod">The request method we are doing</param>
        /// <param name="resource">The request sub-url</param>
        /// <returns>A RestRequest object with the correct authorization header</returns>
        private RestRequest CreateRequest(RequestMethod requestMethod, string resource) {
            RestRequest request = new RestRequest(resource);

            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", 
                $"Realo key=\"{ PublicKey }\", " +
                $"signature=\"{ CreateSignature(requestMethod.ToString(), $"{Url}/{resource}", request.Body.Value.ToString()) }\" " +
                $"version=\"1.0\"");

            return request;
        }

        /// <summary>
        /// Creates the signature to send with the authorization
        /// token to verify it is the right request. (Required by Realo)
        /// </summary>
        /// <param name="method">The method we are doing (GET, POST, PUT & DELETE)</param>
        /// <param name="url">The URL we are requesting to</param>
        /// <param name="body">Any body we send with our request</param>
        /// <returns>A signature in string form</returns>
        private string CreateSignature(string method, string url, string body) {
            string baseString = $"{method}&{url}&{body}";

            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(baseString);
            Byte[] keyBytes = encoding.GetBytes(PrivateKey);
            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }

    enum RequestMethod {

        GET,
        POST,
        PUT,
        DELETE

    }
}
