using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TraversalCore.CQRS.Results.DestinationResults;

namespace TraversalCore.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetAllDestinationQueryResult> Handle() 
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult()
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                daynight = x.DayNight,
                price = x.Price,
                city = x.City
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
