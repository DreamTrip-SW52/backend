using System.Runtime.Serialization;
using DreamTrip.API.DreamTrip.Persistence.Repositories;
using DreamTrip.API.DreamTrip.Services;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;

namespace Tests.StepDefinitions
{
    [Binding]
    public sealed class EconomicStepDefinitions
    {
        EconomicFollowingService economicfollowingService;
        
        bool result;
        int travelerCardId;

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("The user adds new invoices in the following economic aspects section to verify how much he is spending on his trip")]
        public void GivenUserAddinvoices(int travelerId)
        {

            IEconomicFollowingRepository economicfollowingRepository = new MockEconomicRepository();

            economicfollowingService = new EconomicFollowingService(economicfollowingRepository, null);

        }

        [When("When the user enters the invoices in following economic")]
        public void WhenTheUserEnterToAddinvoices()
        {
            throw new NotImplementedException();

            travelerCardId = 5;
        }

        [Then("The user add Another bills in following economic")]
        public void ThenUserAddinvoices(bool Spectecresult)
        {
            Assert.True(Spectecresult, result);
            
        }
    }

    /*[Serializable]
    internal class NotAddReviewException : Exception
    {
        public NotAddReviewException()
        {
        }

        public NotAddReviewException(string? message) : base(message)
        {
        }

        public NotAddReviewException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotAddReviewException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }*/
}