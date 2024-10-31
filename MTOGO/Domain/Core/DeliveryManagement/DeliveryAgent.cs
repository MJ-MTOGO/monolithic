

namespace Domain.Core.DeliveryManagement
{
    public class DeliveryAgent
    {
        public Guid AgentId { get; private set; }
        public string Name { get; private set; }
        public TimeSpan ShiftStart { get; private set; }
        public TimeSpan ShiftEnd { get; private set; }

        public DeliveryAgent(Guid agentId, string name, TimeSpan shiftStart, TimeSpan shiftEnd)
        {
            AgentId = agentId;
            Name = name;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
        }

        public bool IsAvailable(DateTime currentTime)
        {
            var currentHour = currentTime.TimeOfDay;
            return currentHour >= ShiftStart && currentHour <= ShiftEnd;
        }
    }
}
