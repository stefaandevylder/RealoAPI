using Newtonsoft.Json;
using RealoAPI.Models;
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

        private RealoRestClient Client { get; set; }

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
            Client = new RealoRestClient(publicKey, privateKey, URL);
        }

        /// <summary>
        /// GET: /agencies/{agency}/listings
        /// </summary>
        /// <param name="agency">ID of the parent agency</param>
        /// <returns>An array of all listings</returns>
        public Listing[] GetAllListings(int agency) {
            return JsonConvert.DeserializeObject<Listing[]>(Client.Get($"/agencies/{agency}/listings").Content);
        }

        /// <summary>
        /// POST /agencies/{agency}/listings
        /// </summary>
        /// <param name="listing">The listing to post</param>
        /// <param name="agency">The agency we post the listing in</param>
        /// <returns>True if code 200</returns>
        public bool PostNewListing(Listing listing, int agency) {
            return Client.Post(listing, $"/agencies/{agency}/listings").IsSuccessful;
        }
    }

}
