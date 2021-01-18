using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using APITestsTypicode.Models;

namespace APITestsTypicode.Steps
{
    [Binding]
    public class PostsSteps
    {
        private RestRequest request;
        private IRestResponse response;
        private RestClient client;
        private Helpers helper = new Helpers();
        private const string BASE_URL = "https://jsonplaceholder.typicode.com/";

        [Given(@"I have made a API request to get posts")]
        public void GivenIHaveMadeAAPIRequestToGetPosts()
        {
            client = helper.SetUrl(BASE_URL, "posts/");
            request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            response = helper.GetResponse(client, request);

        }

        [Then(@"I see list of posts  with status (.*)")]
        public void ThenISeeListOfPostsWithStatus(string statusCode)
        {
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(statusCode));
        }

        [Given(@"I have made a API request to get all posts for (.*)")]
        public void GivenIHaveMadeAAPIRequestToGetAllPostsFor(string postNumber)
        {
            client = helper.SetUrl(BASE_URL, "posts/"+postNumber);
            request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            response = helper.GetResponse(client, request);
        }

        [Then(@"I see post  with status (.*)")]
        public void ThenISeePostWithStatus(string statusCode)
        {
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(statusCode));
        }

        [Then(@"I see post with invalid status ""(.*)""")]
        public void ThenISeePostWithInvalidStatus(string statusCode)
        {
            Assert.That(response.StatusCode.ToString(), Is.EqualTo(statusCode));
        }

    }
}
