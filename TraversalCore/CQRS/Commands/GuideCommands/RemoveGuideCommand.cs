using MediatR;

namespace TraversalCore.CQRS.Commands.GuideCommands
{
    public class RemoveGuideCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveGuideCommand(int id)
        {
            Id = id;
        }
    }
}
