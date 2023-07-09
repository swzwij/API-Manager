namespace swzwij.API.Demo
{
    /// <summary>
    /// An example request.
    /// </summary>
    public class ExampleAPIRequest : APIRequest
    {
        /// <summary>
        /// The latitude.
        /// </summary>
        private readonly double _latitude;

        /// <summary>
        /// The longitude.
        /// </summary>
        private readonly double _longitude;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string URL => $"https://geocode.maps.co/reverse?lat={_latitude}&lon={_longitude}";

        /// <summary>
        /// Creating the request that gets send to the API.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public ExampleAPIRequest(double latitude, double longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }
    }
}