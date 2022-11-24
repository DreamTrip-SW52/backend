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

        public async Task<Review> FindByPackageIdAndTravelerId(int packageId, int travelerId)
        {
            return await Task<Review>.Factory.StartNew(() => {
                List<Review> reviews = new List<Review>();
                //Crear 1 objeto review
                Review review = new Review();
                review.PackageId = 3;
                review.TravelerId = 5;
                reviews.Add(review);

                Review review2 = new Review();
                review2.PackageId = packageId;
                review2.TravelerId = travelerId;
                //return reviews.Contains(review2) ? review2: null; reviews.Where(r => r.PackageId == review2.PackageId).ToList();
                List<Review> filteredReviews = reviews
                 .Where(r => r.PackageId == review2.PackageId && r.TravelerId == review2.TravelerId)
                .ToList();

                if(filteredReviews.Count() == 0)
                {
                    return null;
                }

                return filteredReviews.ElementAt(0);

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
