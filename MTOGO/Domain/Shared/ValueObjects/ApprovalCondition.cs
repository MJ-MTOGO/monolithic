

namespace Domain.Shared.ValueObjects
{
    public class ApprovalCondition
    {
        public readonly TimeSpan StartTime;
        public readonly TimeSpan EndTime;

        public ApprovalCondition(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public bool IsWithinEligibleTime(DateTime time)
        {
            var currentTime = time.TimeOfDay;
            return currentTime >= StartTime || currentTime < EndTime;
        }

        public override bool Equals(object obj)
        {
            if (obj is ApprovalCondition other)
                return StartTime == other.StartTime && EndTime == other.EndTime;
            return false;
        }

        public override int GetHashCode() => (StartTime, EndTime).GetHashCode();
    }
}
