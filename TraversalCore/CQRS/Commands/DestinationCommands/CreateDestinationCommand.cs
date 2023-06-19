namespace TraversalCore.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {
        public int Capacity { get; set; }
        public string? City { get; set; }
        public string? DayNight { get; set; }
        public double Price { get; set; }
        
    }
}
