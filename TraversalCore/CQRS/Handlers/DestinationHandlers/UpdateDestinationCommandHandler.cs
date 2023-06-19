using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Drawing.Charts;
using TraversalCore.CQRS.Commands.DestinationCommands;

namespace TraversalCore.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand command) 
        {
            var value = _context.Destinations.Find(command.DestinationID);
            value.City = command.City;
            value.DayNight= command.DayNight;
            value.Price= command.Price;
            _context.SaveChanges();
        }
    }
}
