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
       // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

       [Given("The user enters the add review window and does not have a review already done previously")]
        public void GivenUserAddReview(int packageId, int travelerId)
        {
            this.packageId = packageId;
            this.travelerId = travelerId;
            IReviewRepository reviewRepository = new MockReviewRepository();

            reviewservice = new ReviewService(reviewRepository, null);

        }

        [When("The user enters to add a review and it is verified that he did not write a review previously")]
        public void WhenVerifiedThatHeDidNotWriteReview()
        {
            result = reviewservice.ValidationReview(packageId, travelerId);

            travelerId = 5;
            packageId = 10;
        }

        [Then("The user can add a review")]
        public void ThenUserCanAddReview(bool Spectecresult)
        {
            Assert.Equal(Spectecresult, result);
            
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