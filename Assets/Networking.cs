using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;

public class Networking : MonoBehaviour
{
    public static string BaseUrl = "http://localhost:8080";
    private static Networking _networking;

    private void Awake()
    {
        Application.runInBackground = true;

        if (_networking) Destroy(_networking);
        _networking = this;
    }


    public abstract class Request<T> where T : class
    {
        private readonly Dictionary<string, string> _headers;
        private readonly LinkedList<string> _params;

        private readonly string _path;

        [CanBeNull] private Action<ErrorBody> _errorAction;
        [CanBeNull] private Action<T> _responseAction;
        [CanBeNull] private Action _successAction;

        protected Request(string path)
        {
            _params = new LinkedList<string>();
            _headers = new Dictionary<string, string>();
            _path = path;
        }

        public Request<T> AddParam(string key, string value)
        {
            _params.AddLast($"{key}={HttpUtility.UrlEncode(value)}");
            return this;
        }

        public Request<T> AddHeader(string key, string value)
        {
            _headers.Add(key, value);
            return this;
        }

        public Request<T> OnError(Action<ErrorBody> action)
        {
            _errorAction = action;
            return this;
        }

        public Request<T> OnSuccess(Action action)
        {
            _successAction = action;
            return this;
        }

        public Request<T> OnResponse(Action<T> action)
        {
            _responseAction += action;
            return this;
        }

        protected abstract UnityWebRequest WebRequest(string url);

        private IEnumerator _Request(string url)
        {
            using var webRequest = WebRequest(url);
            webRequest.timeout = 15;
            foreach (var (key, value) in _headers)
                webRequest.SetRequestHeader(key, value);
            yield return webRequest.SendWebRequest();
            
            webRequest.downloadHandler ??= new DownloadHandlerBuffer();
            var bodyText = webRequest.downloadHandler.text;
            if (webRequest.result == UnityWebRequest.Result.Success)
                if (webRequest.responseCode is >= 200 and <= 299)
                {
                    if (typeof(T) == typeof(void))
                        _responseAction?.Invoke(null);
                    else if (typeof(T) == typeof(string))
                        _responseAction?.Invoke(bodyText as T);
                    else
                        _responseAction?.Invoke(JsonUtility.FromJson<T>(bodyText));
                    _successAction?.Invoke();

                    yield break;
                }
            _errorAction?.Invoke(JsonUtility.FromJson<ErrorBody>(bodyText));
        }

        public void Build()
        {
            var parameters = _params.Count > 0 ? $"?{string.Join("&", _params)}" : "";
            _networking.StartCoroutine(_Request(BaseUrl + _path + parameters));
        }
    }

    public class Get<T> : Request<T> where T : class
    {
        public Get(string path) : base(path)
        {
        }

        protected override UnityWebRequest WebRequest(string url)
        {
            return UnityWebRequest.Get(url);
        }
    }
    
    public class Post<T> : Request<T> where T : class
    {
        private readonly string _body;

        public Post(string path, object body) : base(path)
        {
            _body = JsonUtility.ToJson(body);
            Debug.Log($"Added to body: {_body}");
        }

        protected override UnityWebRequest WebRequest(string url)
        {
            return UnityWebRequest.Post(url, _body, "application/json");
        }
    }
}