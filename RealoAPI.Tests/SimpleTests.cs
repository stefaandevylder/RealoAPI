using RealoAPI.Models;
using System;
using Xunit;

namespace RealoAPI.Tests {

    public class SimpleTests {

        private readonly RealoAPI RealoAPI;
        private readonly Listing Listing;

        public SimpleTests() {
            RealoAPI = new RealoAPI("private", "public", true);

            //Listing = new Listing()
        }

        [Fact]
        public void Test1() {

        }
    }

}
