using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;

namespace Tests.StepDefinitions
{
    internal class MockCardRepository : ITravelerCardRepository
    {
        public async Task<IEnumerable<TravelerCard>> ListAsync()
        {
            
            throw new NotImplementedException();
        }

        public async Task<TravelerCard> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TravelerCard>> FindByTravelerId(int travelerId)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(TravelerCard travelerCard)
        {
            throw new NotImplementedException();
        }

        public void Update(TravelerCard travelerCard)
        {
            throw new NotImplementedException();
        }

        public void Remove(TravelerCard travelerCard)
        {
            throw new NotImplementedException();
        }
    }
}
