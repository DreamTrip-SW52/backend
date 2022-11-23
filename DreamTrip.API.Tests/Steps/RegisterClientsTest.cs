
using System.Net;
using System.Net.Mime;
using System.Text;
using DreamTrip.API.DreamTrip.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace DreamTrip.API.Tests.Steps;
//server=sql10.freemysqlhosting.net;user=sql10579112;password=Wk3l7TXIMf;database=sql10579112

[Binding]
public sealed class RegisterClientsTest : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;
    

    public RegisterClientsTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    
    private Task<HttpResponseMessage> Response { get; set; }
    
    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/travelers is available")]
    public void GivenTheEndpointHttpsLocalhostApiVTravellersIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/travelers");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }
    
    [When(@"a Register traveler request is sent")]
    public void WhenARegisterTravelerRequestIsSent(Table saveTravelerResource)
    {
        var resource = saveTravelerResource.CreateSet<SaveTravelerResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }
    
    [Then(@"a Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }
    
    [Then(@"a Traveler Resource is included in Response Body")]
    public async void ThenATravelerResourceIsIncludedInResponseBody(Table expectedTravelerResource)
    {
        var expectedResource = expectedTravelerResource.CreateSet<TravelerResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<TravelerResource>(responseData);
        Assert.Equal(expectedResource.Name, resource.Name);
    }
    
    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/agencies is available")]
    public void GivenTheEndpointHttpsLocalhostApiVAgenciesIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/agencies");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }

    [When(@"a Register Agency request is sent")]
    public void WhenARegisterAgencyRequestIsSent(Table saveAgencyResource)
    {
        var resource = saveAgencyResource.CreateSet<SaveAgencyResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }
    

    [Then(@"a Agency Resource is included in Response Body")]
    public async void ThenAAgencyResourceIsIncludedInResponseBody(Table expectedAgencyResource)
    {
        var expectedResource = expectedAgencyResource.CreateSet<AgencyResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<AgencyResource>(responseData);
        Assert.Equal(expectedResource.Ruc, resource.Ruc);        
    }

    
}