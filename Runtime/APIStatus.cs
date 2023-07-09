using UnityEngine.Networking;

namespace swzwij.API
{
    /// <summary>
    /// The status of the API call.
    /// </summary>
    public class APIStatus
    {
        /// <summary>
        /// The web request.
        /// </summary>
        private UnityWebRequest _request;

        /// <summary>
        /// The status of the API call.
        /// </summary>
        public string Status 
        {
            get
            {
                return _request.result switch
                {
                    UnityWebRequest.Result.InProgress => "The request hasn't finished yet",
                    UnityWebRequest.Result.Success => "The request succeeded",
                    UnityWebRequest.Result.ConnectionError => "Failed to communicate with the server",
                    UnityWebRequest.Result.ProtocolError => "The server returned an error response. The request succeeded in communicating with the server, but received an error as defined by the connection protocol",
                    UnityWebRequest.Result.DataProcessingError => "Error processing data. The request succeeded in communicating with the server, but encountered an error when processing the received data",
                    _ => "Failed to get status",
                };
            }
        }

        /// <summary>
        /// The status of the API call.
        /// </summary>
        /// <param name="result">The web request.</param>
        public APIStatus(UnityWebRequest result) => _request = result;
    }
}