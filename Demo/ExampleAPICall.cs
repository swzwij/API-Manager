using UnityEngine;
using UnityEngine.UI;

namespace swzwij.API.Demo
{
    /// <summary>
    /// Class to handle the example API call.
    /// </summary>
    public class ExampleAPICall : MonoBehaviour
    {
        /// <summary>
        /// Reference to the text dispalying the location.
        /// </summary>
        [SerializeField]
        private Text _locationText;

        /// <summary>
        /// Reference to the longitude input field.
        /// </summary>
        [SerializeField]
        private InputField _longitudeInputField;

        /// <summary>
        /// Reference to the latitude input field.
        /// </summary>
        [SerializeField]
        private InputField _latitudeInputField;

        /// <summary>
        /// Reference to the button.
        /// </summary>
        [SerializeField]
        private Button _button;

        /// <summary>
        /// Setting the text to coordinates and making the API call.
        /// </summary>
        private void Awake()
        {
            _longitudeInputField.text = "12.4922";
            _latitudeInputField.text = "41.8902";

            MakeAPICall();
        }

        /// <summary>
        /// Setting the onClick listener for the button.
        /// </summary>
        private void OnEnable() => _button.onClick.AddListener(MakeAPICall);

        /// <summary>
        /// Removing the onClick listener for the button.
        /// </summary>
        private void OnDisable() => _button.onClick.RemoveListener(MakeAPICall);

        /// <summary>
        /// Make the API call.
        /// </summary>
        private void MakeAPICall()
        {
            // Get the latitude and the longtitude from the input fields.
            double latitude = double.Parse(_latitudeInputField.text);
            double longitude = double.Parse(_longitudeInputField.text);

            // Create a request.
            ExampleAPIRequest request = new(latitude, longitude);

            // Making the API get call with the request.
            APIManager.Instance.GetCall<ExampleResponse>(request,
                success => 
                { 
                    Debug.Log("succeeded to make API call.");

                    _locationText.text = success.display_name;
                },
                failure =>
                {
                    Debug.LogError("Failed to make API call.");
                });
        }
    }
}