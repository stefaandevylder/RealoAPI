using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealoAPI.Models {

    public class VirtualTour {

        /// <summary>
        /// Virtual tour provider.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public VirtualTourProvider? Provider { get; set; }

        /// <summary>
        /// Source ID as given by the provider.
        /// Example: https://my.matterport.com/show/?m=aMBQj9caMwR has source ID aMBQj9caMwR.
        /// </summary>
        public string SourceId { get; set; }

        /// <summary>
        /// URL to the virtual tour, as given by the provider.
        /// </summary>
        public string Url { get; set; }

    }

}
