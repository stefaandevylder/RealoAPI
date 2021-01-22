namespace RealoAPI.Models {

    public class Address {

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Address precision.
        /// </summary>
        public AdressType Type { get; private set; }

        /// <summary>
        /// Country ISO 3166-2 code.
        /// </summary>
        public Country CountryISO { get; set; }

        /// <summary>
        /// Locality name.
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// Sub-locality name.
        /// </summary>
        public string SubLocality { get; private set; }

        /// <summary>
        /// District name.
        /// </summary>
        public string District { get; private set; }

        /// <summary>
        /// Postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Street name.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// House number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Box number.
        /// </summary>
        public string Box { get; set; }

        /// <summary>
        /// Free-form text, containing the full address to be resolved.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The longitude coordinate.
        /// </summary>
        public float? Longitude { get; set; }

        /// <summary>
        /// The latitude coordinate.
        /// </summary>
        public float? Latitude { get; set; }

        /// <summary>
        /// The accurracy of the coordinate.
        /// </summary>
        public AdressType? CoordinatesAccuracy { get; set; }

        /// <summary>
        /// Create a new address.
        /// </summary>
        /// <param name="country">Country ISO 3166-2 code.</param>
        public Address(Country country) {
            CountryISO = country;
        }

    }

}
