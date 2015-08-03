namespace SampleDb
{
    public class User
    {
        public long Id { get; set; }

        public string StdNumber { get; set; }

        public string Pass { get; set; }

        public string TestResult { get; set; }

        protected bool Equals(User other)
        {
            return Id == other.Id && string.Equals(StdNumber, other.StdNumber) &&
                   string.Equals(Pass, other.Pass) && string.Equals(TestResult, other.TestResult);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (StdNumber != null ? StdNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Pass != null ? Pass.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TestResult != null ? TestResult.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }
    }
}
