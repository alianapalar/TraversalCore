using DataAccessLayer.Concrete;
using MediatR;
using TraversalCore.CQRS.Commands.GuideCommands;

namespace TraversalCore.CQRS.Handlers.GuideHandlers
{
    public class RemoveGuideCommandHandler:IRequestHandler<RemoveGuideCommand>
    {
        private readonly Context _context;

        public RemoveGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveGuideCommand request, CancellationToken cancellationToken)
        {
           var value= await _context.Guides.FindAsync(request.Id);
           _context.Guides.Remove(value);
           await _context.SaveChangesAsync();
          return Unit.Value;
        }
    }
}
