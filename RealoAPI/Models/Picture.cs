namespace RealoAPI.Models {

    public class Picture {

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Picture url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Thumbnail url.
        /// </summary>
        public string ThumbnailUrl { get; private set; }

        /// <summary>
        /// Original md5 hash of the picture.
        /// </summary>
        public string Md5Hash { get; private set; }

        /// <summary>
        /// Picture order.
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// Create a new picture object.
        /// </summary>
        /// <param name="url">Picture url.</param>
        public Picture(string url) {
            Url = url;
        }

    }

}
