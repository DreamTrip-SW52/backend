using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;

namespace Tests.StepDefinitions
{
    internal class MockReviewRepository : IReviewRepository
    {
        public Task AddAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<Review> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> FindByPackageId(int packageId)
        {
            throw new NotImplementedException();
        }

        public Task<Review> FindByPackageIdAndTravelerId(int packageId, int travelerId)
        {
            return Task<Review>.Factory.StartNew(() => {
                List<Review> reviews = new List<Review>();
                //Crear 1 objeto review
                Review review = new Review();
                review.PackageId = 3;
                review.TravelerId = 5;
                reviews.Add(review);

                Review review2 = new Review();
                review2.PackageId = packageId;
                review2.TravelerId = travelerId;
                return reviews.Contains(review2) ? review2: null;
            });
        }

        public Task<Review> FindByTravelerId(int travelerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(Review review)
        {
            throw new NotImplementedException();
        }

        public void Update(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
