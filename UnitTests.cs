using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using APITestsTypicode.Models;

namespace APITestsTypicode
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void TestMethod1GET()
        {
            var client = new RestClient(" https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute<Posts>(request);

            Assert.That(response.Data.UserId, Is.EqualTo(1));
            Assert.That(response.Data.Title, Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"));
        }
        [Test]
        public void TestMethodGETComments()
        {
            var client = new RestClient(" https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("posts/{postid}/comments", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute<Comments>(request);

            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));

        }

        [Test]
        [System.Obsolete]
        public void TestMethod2POST()
        {
            var client = new RestClient(" https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Posts() { UserId = 20, Id = 101, Title = "sample text", Body = "Lorem Ipsum is simply dummy text of the printing." });

            var response = client.Execute<Posts>(request);

            Assert.That(response.Data.UserId, Is.EqualTo(20));
            Assert.That(response.Data.Title, Is.EqualTo("sample text"));
        }
    }
}
