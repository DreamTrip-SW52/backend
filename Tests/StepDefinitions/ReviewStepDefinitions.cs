using System.Runtime.Serialization;
using DreamTrip.API.DreamTrip.Persistence.Repositories;
using DreamTrip.API.DreamTrip.Services;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;

namespace Tests.StepDefinitions
{
    [Binding]
    public sealed class ReviewStepDefinitions
    {
        ReviewService reviewservice;
        bool result;
        int packageId;
        int travelerId;

       [Given("The user with ID (.*)")]
        public void GivenTravelerId(int travelerId)
        {
            this.travelerId = travelerId;
            IReviewRepository reviewRepository = new MockReviewRepository();

            reviewservice = new ReviewService(reviewRepository, null);

        }

       [Given("The package (.*)")]
        public void GivenPackageId(int packageId)
        {    
            this.packageId = packageId;

        }
       

        [When("The user enters to add a review and it is verified that he did not write a review previously")]
        public void WhenVerifiedThatHeDidNotWriteReview()
        {
            result = reviewservice.ValidationReview(packageId, travelerId);

        }

        [Then("The user can add a review")]
        public void ThenTheUserCanAddReview()
        {
            Assert.False(result);
            
        }
        [Then("The user can not add a review")]
        public void ThenTheUserCanNotAddReview()
        {
            Assert.True(result);

        }
    }

    /*[Serializable]
    internal class NotAddReviewException : Exception
    {  The user can not add a review
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