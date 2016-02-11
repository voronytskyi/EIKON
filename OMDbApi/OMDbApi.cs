using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using OMDbApi.DTOs;
using OMDbApi.Model;

namespace OMDbApi
{
    public class OMDbApi : IOMDbApi
    {
        public ApiSearchRootDto Search(string title, int? page)
        {
            RequestParamteres requestParams = InitRequest();
            requestParams.Title = title;
            requestParams.Page = page;

            string omdbapiUrl = ConfigurationManager.AppSettings["omdbapiUrl"];
            string responseData = InvokeRequest(omdbapiUrl, requestParams);
            return JsonConvert.DeserializeObject<ApiSearchRootDto>(responseData);
        }

        public ApiDetailsDto GetDetails(string id)
        {
            RequestParamteres requestParams = InitRequest();
            requestParams.ImdbId = id;

            string omdbapiUrl = ConfigurationManager.AppSettings["omdbapiUrl"];
            string responseData = InvokeRequest(omdbapiUrl, requestParams);
            return JsonConvert.DeserializeObject<ApiDetailsDto>(responseData);
        }

        private RequestParamteres InitRequest()
        {
            return new RequestParamteres()
            {
                Version = "1",
                ResponseType = ResponseTypes.json
            };
        }

        private string InvokeRequest(string apiUrl, RequestParamteres requestDto)
        {
            string composeParameters = ComposeParameters(requestDto);
            string requestUrl = apiUrl + "?" + composeParameters;

            WebRequest request = WebRequest.Create(requestUrl);
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            if (dataStream != null)
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();

                return responseFromServer;
            }
            return null;
        }

        private string ComposeParameters(RequestParamteres requestDto)
        {
            Dictionary<string, string> parameterDictionary = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(requestDto.ImdbId))
            {
                parameterDictionary.Add("i", requestDto.ImdbId);
            }
            if (!string.IsNullOrEmpty(requestDto.Title))
            {
                parameterDictionary.Add("s", requestDto.Title);
            }
            if (requestDto.Page.HasValue)
            {
                parameterDictionary.Add("page", requestDto.Page.Value.ToString());
            }
            parameterDictionary.Add("r", requestDto.ResponseType.ToString());

            return ConcatenateParameters(parameterDictionary);
        }

        private string ConcatenateParameters(Dictionary<string, string> parameterDictionary)
        {
            StringBuilder parameters = new StringBuilder();
            int count = 0;
            foreach (var item in parameterDictionary)
            {
                parameters.Append(string.Format("{0}={1}", item.Key, item.Value));
                count++;
                if (count != parameterDictionary.Count)
                {
                    parameters.Append("&");
                }
            }
            return parameters.ToString();
        }
    }
}
