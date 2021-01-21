using System;
using System.Security.Cryptography;
using System.Text;

namespace RealoAPI {

    public class RealoAPI {

        private string URL {
            get {
                return Sandbox ?
                    "https://api-sandbox.realo.com/1.0/" :
                    "https://api.realo.com/1.0/";
            }
        }

        private string PublicKey { get; set; }
        private string PrivateKey { get; set; }
        private bool Sandbox { get; set; }

        /// <summary>
        /// Creates a client of the Realo API.
        /// You need to use this to send over the property
        /// to the API servers.
        /// </summary>
        /// <param name="publicKey">Your public authorization key</param>
        /// <param name="privateKey">Your private authorization key</param>
        /// <param name="useSandbox">If you need to test, enable this so your rate limit stays the same</param>
        public RealoAPI(string publicKey, string privateKey, bool useSandbox = false) {
            if (string.IsNullOrWhiteSpace(publicKey) || string.IsNullOrWhiteSpace(privateKey)) {
                throw new ArgumentException("The public and private keys cannot be null or empty!");
            }

            PublicKey = publicKey;
            PrivateKey = privateKey;
            Sandbox = useSandbox;
        }

        /// <summary>
        /// Calculates the signature to send with the authorization
        /// token to verify it is the right request. (Required by Realo)
        /// </summary>
        /// <param name="method">The method we are doing (GET, POST, PUT & DELETE)</param>
        /// <param name="url">The URL we are requesting to</param>
        /// <param name="body">Any body we send with our request</param>
        /// <returns>A signature in string form</returns>
        private string CalculateSignature(string method, string url, string body) {
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

}
