using RealoAPI.Models;
using System;
using Xunit;
using Xunit.Abstractions;

namespace RealoAPI.Tests {

    public class SimpleTests {

        private readonly ITestOutputHelper _output;

        private readonly RealoAPI RealoAPI;
        private readonly Listing Listing;

        public SimpleTests(ITestOutputHelper output) {
            _output = output;

            RealoAPI = new RealoAPI("private", "public", true);

            Listing = new Listing(ListingType.APARTMENT, ListingWay.SALE);
        }

        [Fact]
        public void GetAllListings() {
            Listing[] listings = RealoAPI.GetAllListings(1);
            _output.WriteLine(listings.ToString());
            Assert.NotEmpty(listings);
        }
    }

}
