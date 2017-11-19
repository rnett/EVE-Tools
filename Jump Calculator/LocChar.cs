using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Jump_Calculator
{
    public class LocChar
    {

        public static LocChar Character = null;

        private const string _crestClient = "ec355eed5c8748a5b36c3c178d3b79f8";
        private const string _crestSecret = "K4Tl1QT9pOt5bJlhY3KwlezYzdHpMgV1XbNYVbmR";
        // Character
        public string RefreshToken { get; private set; }
        public string AuthToken
        {
            get
            {
                if (DateTime.Now <= authTokenExpires)
                    return _authToken;
                else
                {
                    updateAuthToken();
                    return _authToken;
                }

            }
            private set
            {
                _authToken = value;
            }
        }
        private string _authToken;
        private DateTime authTokenExpires;

        public int CharacterID;
        public string CharacterName;

        public LocChar(string refreshToken)
        {
            RefreshToken = refreshToken;
            updateAuthToken();

            // character ID
            HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp("https://login.eveonline.com/oauth/verify");
            web.Method = "GET";
            web.Headers.Add("Authorization", "Bearer " + AuthToken);
            web.ContentLength = 0;

            var response = web.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string text = sr.ReadToEnd();
                JObject res = JObject.Parse(text);
                this.CharacterID = int.Parse((string)res["CharacterID"]);
                this.CharacterName = (string)res["CharacterName"];
            }
            Character = this;
        }

        private void updateAuthToken()
        {
            HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp("https://login.eveonline.com/oauth/token");
            web.Method = "POST";
            web.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(_crestClient + ":" + _crestSecret)));

            var postData = "refresh_token=" + RefreshToken;
            postData += "&grant_type=refresh_token";
            var data = Encoding.ASCII.GetBytes(postData);
            web.ContentType = "application/x-www-form-urlencoded";
            web.ContentLength = data.Length;

            using (var stream = web.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = web.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string text = sr.ReadToEnd();
                JObject res = JObject.Parse(text);
                this.RefreshToken = (string)res["refresh_token"];
                this.AuthToken = (string)res["access_token"];
                this.authTokenExpires = DateTime.Now.AddSeconds(double.Parse((string)res["expires_in"]));
            }

        }

        public string esiCharacter(string endpoint)
        {
            string url = "https://esi.tech.ccp.is/latest/characters/" + CharacterID + "/" + endpoint + "/?datasource=tranquility&token=" + AuthToken;
            if (endpoint == "")
            {
                url = "https://esi.tech.ccp.is/latest/characters/" + CharacterID + "/";
            }

            HttpWebRequest web = (HttpWebRequest)WebRequest.CreateHttp(url);
            web.Method = "GET";
            web.ContentLength = 0;

            var response = web.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }

        }

        public override string ToString()
        {
            return CharacterName;
        }

    }
}
