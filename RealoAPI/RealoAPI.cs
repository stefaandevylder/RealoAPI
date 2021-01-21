using System;

namespace RealoAPI {

    public class RealoAPI {

        /// <summary>
        /// The URL we use to connect to the Realo API.
        /// </summary>
        private string URL {
            get {
                return Sandbox ?
                    "https://api-sandbox.realo.com/1.0/" :
                    "https://api.realo.com/1.0/";
            }
        }

        private bool Sandbox { get; set; }

        private RealoRestClient RestClient { get; set; }

        /// <summary>
        /// Creates a client of the Realo API.
        /// You need to use this to send over the property
        /// to the API servers.
        /// </summary>
        /// <param name="publicKey">Your public authorization key</param>
        /// <param name="privateKey">Your private authorization key</param>
        /// <param name="useSandbox">If you need to test, enable this so your rate limit stays the same</param>
        public RealoAPI(string publicKey, string privateKey, bool useSandbox = false) {
            Sandbox = useSandbox;
            RestClient = new RealoRestClient(publicKey, privateKey, URL);
        }

    }

}
