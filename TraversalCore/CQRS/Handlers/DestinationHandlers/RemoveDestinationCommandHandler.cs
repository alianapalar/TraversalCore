using DataAccessLayer.Concrete;
using TraversalCore.CQRS.Commands.DestinationCommands;

namespace TraversalCore.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(RemoveDestinationCommand command) 
        {
           var value= _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(value);
            _context.SaveChanges();
        }
    }
}
