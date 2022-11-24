using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;

namespace Tests.StepDefinitions
{
    internal class MockEconomicRepository : IEconomicFollowingRepository
    {

        public async Task<IEnumerable<EconomicFollowing>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EconomicFollowing> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EconomicFollowing>> FindByTravelerId(int travelerId)
        {
            return null;
        }

        public async Task AddAsync(EconomicFollowing economicFollowings)
        {
            throw new NotImplementedException();
        }

        public void Update(EconomicFollowing economicFollowings)
        {
            throw new NotImplementedException();
        }

        public void Remove(EconomicFollowing economicFollowings)
        {
            throw new NotImplementedException();
        }
    }
}
