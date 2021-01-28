using RealoAPI.Models;
using Xunit;
using Xunit.Abstractions;

namespace RealoAPI.Tests {

    public class SimpleTests {

        private readonly ITestOutputHelper _output;

        private readonly RealoClient RealoClient;
        private readonly Listing Listing;

        public SimpleTests(ITestOutputHelper output) {
            _output = output;

            RealoClient = new RealoClient("private", "public", true);

            Listing = new Listing(ListingType.APARTMENT, ListingWay.SALE);
        }

        [Fact]
        public void GetAllListings() {
            Listing[] listings = RealoClient.Listings.GetAll(1);
            _output.WriteLine(listings.ToString());
            Assert.NotEmpty(listings);
        }
    }

}
