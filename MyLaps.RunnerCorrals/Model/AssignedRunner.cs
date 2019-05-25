namespace MyLaps.RunnerCorrals.Model
{
    public class AssignedRunner : Runner
    {
        public AssignedRunner(Runner runner, int bib)
        {
            BIB = bib;
        }

        public int BIB { get; }

        protected bool Equals(AssignedRunner other)
        {
            return base.Equals(other) && BIB == other.BIB;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AssignedRunner)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ BIB;
            }
        }
    }
}