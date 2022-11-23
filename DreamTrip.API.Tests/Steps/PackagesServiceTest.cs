using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using DreamTrip.API.DreamTrip.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace DreamTrip.API.Tests.Steps;

[Binding]
public sealed class PackagesServiceTest : WebApplicationFactory<Program>
{

    private readonly WebApplicationFactory<Program> _factory;

    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    
    private Task<HttpResponseMessage> Response { get; set; }

    
    public PackagesServiceTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/package is available")]
    public void GivenTheEndpointHttpsLocalhostApiVPackageIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/package");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }
    
    [When(@"a Get request is sent with id (.*)")]
    public void WhenAGetRequestIsSentWithId(int id)
    {
        Response = Client.GetAsync(BaseUri + $"/{id}");
    }

    [Then(@"a Response Package with Status (.*)")]
    public void ThenAResponsePackageWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a Package Resource is included in Response Body")]
    public async void ThenAPackageResourceIsIncludedInResponseBody(Table expectedPackageResource)
    {
        var expectedResource = expectedPackageResource.CreateSet<PackageResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<PackageResource>(responseData);
        Assert.Equal(expectedResource.Category, resource.Category);
    }

    [When(@"a Post request is sent")]
    public void WhenAPostRequestIsSent(Table savedPackageResource)
    {
        var resource = savedPackageResource.CreateSet<SavePackageResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }
}