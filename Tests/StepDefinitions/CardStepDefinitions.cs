using System.Runtime.Serialization;
using DreamTrip.API.DreamTrip.Persistence.Repositories;
using DreamTrip.API.DreamTrip.Services;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;

namespace Tests.StepDefinitions
{
    [Binding]
    public sealed class CardStepDefinitions
    {
        TravelerCardService travelerCardService;
        
        bool result;
        int Id;

        [Given("The traveler card with Id (.*)")]
        public void GivenUserAddReview(int Id)
        {
            this.Id = Id;

            ITravelerCardRepository travelerCardRepository = new MockCardRepository();

            travelerCardService = new TravelerCardService(travelerCardRepository, null);

        }

        [When("When the user enter to add card")]
        public void WhenTheUserEnterToAddCard()
        {
            result = travelerCardService.FindByIdAsync(Id);

        }

        [Then("The user registered his card")]
        public void ThenUserAddCard()
        {
            Assert.True(result);

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