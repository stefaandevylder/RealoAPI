﻿using Newtonsoft.Json;
using RealoAPI.Models;

namespace RealoAPI {

    public class RealoClient {

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

        public Listings Listings { get; private set; }

        /// <summary>
        /// Creates a client of the Realo API.
        /// You need to use this to send over the property
        /// to the API servers.
        /// </summary>
        /// <param name="publicKey">Your public authorization key</param>
        /// <param name="privateKey">Your private authorization key</param>
        /// <param name="useSandbox">If you need to test, enable this so your rate limit stays the same</param>
        public RealoClient(string publicKey, string privateKey, bool useSandbox = false) {
            Sandbox = useSandbox;

            RealoRestClient client = new RealoRestClient(publicKey, privateKey, URL);
            Listings = new Listings(client);
        }

    }

    public class Listings {

        private RealoRestClient Client { get; set; }

        public Listings(RealoRestClient client) {
            Client = client;
        }

        /// <summary>
        /// This endpoint returns all active listings owned by the parent agency resource.
        /// 
        /// GET: /agencies/{agency}/listings
        /// </summary>
        /// <param name="agency">ID of the parent agency</param>
        /// <returns>An array of all listings</returns>
        public Listing[] GetAll(int agency) {
            return JsonConvert.DeserializeObject<Listing[]>(Client.Get($"/agencies/{agency}/listings").Content);
        }

        /// <summary>
        /// This endpoint is responsible for the creation of new listings. It is a subresource of the agencies resource, 
        /// which means that the newly created listing will be owned by the parent agency.
        /// All new listings are be created with an UNPUBLISHED status.Only published listings will trigger notifications for our users. 
        /// To publish a listing, call the publish endpoint after you have added all pictures to the listing.
        /// 
        /// POST /agencies/{agency}/listings
        /// </summary>
        /// <param name="listing">The listing to post</param>
        /// <param name="agency">The agency we post the listing in</param>
        /// <returns>The ID of the posted listing</returns>
        public int Add(Listing listing, int agency) {
            var definition = new { Data = new { Id = 0 } };
            return JsonConvert.DeserializeAnonymousType(Client.Post(listing, $"/agencies/{agency}/listings").Content, definition).Data.Id;
        }

        /// <summary>
        /// This endpoint is used to retrieve single listings.
        /// 
        /// GET: /listings/{id}
        /// </summary>
        /// <param name="listingId">ID of the listing</param>
        /// <returns>One listing</returns>
        public Listing Get(int listingId) {
            return JsonConvert.DeserializeObject<Listing>(Client.Get($"/listings/{listingId}").Content);
        }

        /// <summary>
        /// This endpoint is used to update listings and supports both partial and full update requests for a listing resource. 
        /// You are free to choose if you want to send us only the fields which have changed or the entire updated listing resource.
        /// Please note that you should also use this endpoint to mark listings as OFFMARKET, SOLD or RENTED by changing the listing status.
        /// 
        /// PUT /listings/{id}
        /// </summary>
        /// <param name="listing">The listing to put</param>
        /// <param name="listingId">ID of the listing</param>
        /// <returns>True if succeeded</returns>
        public bool Update(Listing listing, int listingId) {
            var definition = new { Success = false };
            return JsonConvert.DeserializeAnonymousType(Client.Put(listing, $"/listings/{listingId}").Content, definition).Success;
        }

        /// <summary>
        /// Use this endpoint to delete listings.
        /// WARNING! Do not use this endpoint if a listing was sold or rented. 
        /// To mark a listing as sold or rented, use the update endpoint to set the status to SOLD or RENTED.
        /// 
        /// DELETE /listings/{id}
        /// </summary>
        /// <param name="listingId">ID of the listing</param>
        /// <returns>True if succeeded</returns>
        public bool Delete(int listingId) {
            var definition = new { Success = false };
            return JsonConvert.DeserializeAnonymousType(Client.Delete($"/listings/{listingId}").Content, definition).Success;
        }

        /// <summary>
        /// Batch picture upload endpoint.
        /// 
        /// POST /listings/{id}/pictures
        /// </summary>
        /// <param name="pictures">The pictures to post</param>
        /// <param name="listingId">ID of the listing</param>
        /// <returns>The id of the new picture</returns>
        public int PostPicture(Picture[] pictures, int listingId) {
            var definition = new { Data = new { Id = 0 } };
            return JsonConvert.DeserializeAnonymousType(Client.Post(pictures, $"/listings/{listingId}/pictures").Content, definition).Data.Id;
        }

        /// <summary>
        /// To move a picture, use this endpoint to update the order of a specific picture.
        /// 
        /// PUT /listings/{id}/pictures/{id}
        /// </summary>
        /// <param name="pictureId">The picture to move</param>
        /// <param name="listingId">ID of the listing</param>
        /// <returns>True if succeeded</returns>
        public bool PutPicture(int pictureId, int listingId) {
            var definition = new { Success = false };
            return JsonConvert.DeserializeAnonymousType(Client.Put(pictureId, $"/listings/{listingId}/pictures/{pictureId}").Content, definition).Success;
        }

        /// <summary>
        /// Use this endpoint to permanently remove a picture from a listing.
        /// 
        /// DELETE /listings/{id}/pictures/{id}
        /// </summary>
        /// <param name="pictureId">The picture to move</param>
        /// <param name="listingId">ID of the listing</param>
        /// <returns>True if succeeded</returns>
        public bool DeletePicture(int pictureId, int listingId) {
            var definition = new { Success = false };
            return JsonConvert.DeserializeAnonymousType(Client.Delete($"/listings/{listingId}/pictures/{pictureId}").Content, definition).Success;
        }

        /// <summary>
        /// Publish an unpublished listing.
        /// 
        /// GET /listings/{id}/publish
        /// </summary>
        /// <param name="listingId">ID of the listing</param>
        /// <returns>True if succeeded</returns>
        public bool Publish(int listingId) {
            var definition = new { Success = false };
            return JsonConvert.DeserializeAnonymousType(Client.Get($"/listings/{listingId}/publish").Content, definition).Success;
        }
    }

}
