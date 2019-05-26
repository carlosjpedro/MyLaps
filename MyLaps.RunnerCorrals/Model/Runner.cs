namespace MyLaps.RunnerCorrals.Model
{
    public class Runner
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public long RaceTime { get; set; }

        protected bool Equals(Runner other)
        {
            return Age == other.Age && Gender == other.Gender && RaceTime.Equals(other.RaceTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Runner)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Age;
                hashCode = (hashCode * 397) ^ (int)Gender;
                hashCode = (hashCode * 397) ^ RaceTime.GetHashCode();
                return hashCode;
            }
        }
        public override string ToString()
        {
            return $"Age: {Age}\tGender: {Gender}\tRace Time: {RaceTime}";
        }
    }
}