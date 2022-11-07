namespace WineTestingRoche.Steps
{
    using RestSharp;
    using TechTalk.SpecFlow;

    [Binding]
    public class WineOpenAPIStepDefinitions
    {
        private RestClient restClient;
        private RestRequest restRequest;
        private RestResponse restResponse;

        [Given(@"Wine Open Database API")]
        public void GivenWineOpenDatabaseAPI()
        {
            restClient = new RestClient("https://wines-api.herokuapp.com/api");
        }

        [When(@"I make a get request to /comments")]
        public void WhenIMakeAGetRequestToComments()
        {
            restRequest = new RestRequest("/comments", Method.Get);
            restRequest.AddHeader("content-type", "application/json");
        }

        [Then(@"the response status code is (.*)")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            restResponse = restClient.Execute(restRequest);
            Assert.That((int)restResponse.StatusCode, Is.EqualTo(statusCode));
        }

        [Then(@"the response data should be the number of comments")]
        public void ThenTheResponseDataShouldBeTheNumberOfComments()
        {
            Assert.That(restResponse.Content, Does.Contain("count"));
        }

        [When(@"I make a get request to /likes")]
        public void WhenIMakeAGetRequestToLikes()
        {
            restRequest = new RestRequest("/likes", Method.Get);
            restRequest.AddHeader("content-type", "application/json");
        }

        [Then(@"the response data should be the number of likes")]
        public void ThenTheResponseDataShouldBeTheNumberOfLikes()
        {
            Assert.That(restResponse.Content, Does.Contain("count"));
        }

        [When(@"I make a get request to /regions")]
        public void WhenIMakeAGetRequestToRegions()
        {
            restRequest = new RestRequest("/regions", Method.Get);
            restRequest.AddHeader("content-type", "application/json");
        }

        [Then(@"the response data should contains all regions list")]
        public void ThenTheResponseDataShouldContainsAllRegionsList()
        {
            Assert.That(restResponse.Content, Does.Contain("Bordeaux"));
            Assert.That(restResponse.Content, Does.Contain("Loire"));
        }

        [When(@"I make a get request to /wines with ""([^""]*)""")]
        public void WhenIMakeAGetRequestToWineWith(string wineId)
        {
            restRequest = new RestRequest("/wines/" + wineId, Method.Get);
            restRequest.AddHeader("content-type", "application/json");
        }

        [Then(@"the response data should contains all wine information")]
        public void ThenTheResponseDataShouldContainsAllWineInformation()
        {
            Assert.That(restResponse.Content, Does.Contain("name"));
            Assert.That(restResponse.Content, Does.Contain("type"));
            Assert.That(restResponse.Content, Does.Contain("appellation"));
            Assert.That(restResponse.Content, Does.Contain("grapes"));
        }

        [When(@"I make a get request to /wines\?region with ""([^""]*)""")]
        public void WhenIMakeAGetRequestToWinesRegionWith(string region)
        {
            restRequest = new RestRequest("/wines?region=" + region, Method.Get);
            restRequest.AddHeader("content-type", "application/json");
        }

    }
}
