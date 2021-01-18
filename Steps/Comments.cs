using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using APITestsTypicode.Models;


namespace APITestsTypicode.Steps
{
    [Binding]
    public class Comments
    {
        private RestRequest request;
        private IRestResponse response;
        private RestClient client;
        private Helpers helper = new Helpers();
        private const string BASE_URL = "https://jsonplaceholder.typicode.com/";

        [Given(@"I have made a API request to get comments on post (.*)")]
        public void GivenIHaveMadeAAPIRequestToGetCommentsOnPost(string postNumber)
        {
            client = helper.SetUrl(BASE_URL, "posts/" + postNumber + "/comments");
            request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            response = helper.GetResponse(client, request);
        }

        [Then(@"I see list of comments on specified post  with status (.*)")]
        public void ThenISeeListOfCommentsOnSpecifiedPostWithStatus(string statusCode)
        {
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(statusCode));
        }

        [Then(@"I see list of comments on invalid post  with status (.*)")]
        public void ThenISeeListOfCommentsOnInvalidPostWithStatusNotFound(string statusCode)
        {
            Assert.IsFalse(response.StatusCode.ToString().Equals(statusCode));
        }
    }
}
