using DataAccessLayer.Concrete;
using MediatR;
using TraversalCore.CQRS.Commands.GuideCommands;
using EntityLayer.Concrete;
namespace TraversalCore.CQRS.Handlers.GuideHandlers
{
    public class UpdateGuideCommandHandler:IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;

        public UpdateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Update(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true,
                GuideID= request.GuideID
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
