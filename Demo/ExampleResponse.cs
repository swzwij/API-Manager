namespace swzwij.API.Demo
{
    /// <summary>
    /// Class to handle the example response.
    /// This is a class made from the json response that gets given the API.
    /// </summary>
    public class ExampleResponse
    {
        public int place_id;
        public string licence;
        public string powered_by;
        public string osm_type;
        public int osm_id;
        public string lat;
        public string lon;
        public string display_name;
        public AddressData address;
        public string[] boundingbox;

        /// <summary>
        /// The address data.
        /// </summary>
        [System.Serializable]
        public class AddressData
        {
            /// <summary>
            /// The city block of the address.
            /// </summary>
            public string city_block;

            /// <summary>
            /// The suburb of the address.
            /// </summary>
            public string suburb;

            /// <summary>
            /// The city district of the address.
            /// </summary>
            public string city_district;

            /// <summary>
            /// The country of the address.
            /// </summary>
            public string county;

            /// <summary>
            /// The state of the address.
            /// </summary>
            public string state;

            /// <summary>
            /// The region of the address.
            /// </summary>
            public string region;

            /// <summary>
            /// The postal code of the address.
            /// </summary>
            public string postcode;

            /// <summary>
            /// The country of the address.
            /// </summary>
            public string country;

            /// <summary>
            /// The city code of the address.
            /// </summary>
            public string country_code;
        }
    }
}