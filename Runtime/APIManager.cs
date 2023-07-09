using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace swzwij.API
{
    /// <summary>
    /// Class used to make get calls to an API. 
    /// </summary>
    public class APIManager : MonoBehaviour
    {
        #region Singleton Behaviour

        /// <summary>
        /// API Manager instance.
        /// </summary>
        private static APIManager _instance;

        /// <summary>
        /// Getting the API manager instance.
        /// </summary>
        public static APIManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = FindObjectOfType<APIManager>();

                if (_instance != null)
                    return _instance;

                GameObject singletonObject = new();
                _instance = singletonObject.AddComponent<APIManager>();
                singletonObject.name = typeof(APIManager).ToString();
                DontDestroyOnLoad(singletonObject);

                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// Making a get call to the given URL and handling the json response.
        /// </summary>
        /// <typeparam name="T">The data that the API sends back.</typeparam>
        /// <param name="request">The request that gets send to the API.</param>
        /// <param name="onComplete">Event for when the API call is complete.</param>
        /// <param name="onFailure">Event for when the API call fails.</param>
        public void GetCall<T>(APIRequest request, Action<T> onComplete = null, Action<APIStatus> onFailure = null) =>
            StartCoroutine(WebRequest(request, onComplete, onFailure));

        /// <summary>
        /// Making a web request to the API url.
        /// </summary>
        /// <typeparam name="T">The data that the API sends back.</typeparam>
        /// <param name="request">The data that gets send to the API.</param>
        /// <param name="onComplete">Event for when the API call is complete.</param>
        /// <param name="onFailure">Event for when the API call fails.</param>
        private IEnumerator WebRequest<T>(APIRequest request, Action<T> onComplete, Action<APIStatus> onFailure)
        {
            UnityWebRequest webRequest = new(request.URL)
            {
                downloadHandler = new DownloadHandlerBuffer()
            };

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                onFailure?.Invoke(new(webRequest));
                yield break;
            }

            T response = JsonUtility.FromJson<T>(webRequest.downloadHandler.text);
            onComplete?.Invoke(response);
        }
    }
}