namespace RealoAPI.Models {

    public class Agency {

        /// <summary>
        /// Id of the agency.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Agency address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Name of the agency.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Telephone number of the agency.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Mobile number of the agency.
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Email address of the agency.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Email address of the agency to receive buyer leads.
        /// </summary>
        public string BuyerLeadEmail { get; set; }

        /// <summary>
        /// Email address of the agency to receive renter leads.
        /// </summary>
        public string RenterLeadEmail { get; set; }

        /// <summary>
        /// Email address of the agency to receive seller leads.
        /// </summary>
        public string SellerLeadEmail { get; set; }

        /// <summary>
        /// Email address of the agency to receive letter (property owner) leads.
        /// </summary>
        public string LetterLeadEmail { get; set; }

        /// <summary>
        /// Website URL of the agency.
        /// </summary>
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Language of the agency.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Your own id when using the api.
        /// </summary>
        public int? SourceId { get; set; }

        /// <summary>
        /// Code of the agency.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The publications Feed URL of the agency.
        /// </summary>
        public string FeedUrl { get; set; }

        /// <summary>
        /// The publications Feed URL type of the agency
        /// REALO, POLIRIS, KYERO, OTHER.
        /// </summary>
        public string FeedType { get; set; }

        /// <summary>
        /// The avatar image URL of the agency.
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Create a new agency.
        /// </summary>
        /// <param name="address">Agency address.</param>
        /// <param name="name">Name of the agency.</param>
        /// <param name="telephone">Telephone number of the agency.</param>
        /// <param name="email">Email address of the agency.</param>
        /// <param name="websiteUrl">Website URL of the agency.</param>
        /// <param name="language">Language of the agency.</param>
        public Agency(Address address, string name, string telephone, string email, string websiteUrl, string language) {
            Address = address;
            Name = name;
            Telephone = telephone;
            Email = email;
            WebsiteUrl = websiteUrl;
            Language = language;
        }

    }

}
