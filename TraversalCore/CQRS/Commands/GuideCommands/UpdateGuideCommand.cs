using MediatR;

namespace TraversalCore.CQRS.Commands.GuideCommands
{
    public class UpdateGuideCommand:IRequest
    {
        public int GuideID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
