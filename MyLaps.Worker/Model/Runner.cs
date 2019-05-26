namespace MyLaps.Worker.Model
{
    public class Runner
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public long RaceTime { get; set; }
        public int? CorralId { get; set; }
        public int BIBNumber { get; set; }

        protected bool Equals(Runner other)
        {
            return Age == other.Age && Gender == other.Gender && RaceTime == other.RaceTime && CorralId == other.CorralId && BIBNumber == other.BIBNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Runner) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Age;
                hashCode = (hashCode * 397) ^ (int) Gender;
                hashCode = (hashCode * 397) ^ RaceTime.GetHashCode();
                hashCode = (hashCode * 397) ^ CorralId.GetHashCode();
                hashCode = (hashCode * 397) ^ BIBNumber;
                return hashCode;
            }
        }
    }
}