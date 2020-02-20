namespace StokvelNamespace {
    public class Member : IMember {
        public string Name { get; private set; }
        public int Contribution { get; private set; }
        public int Withdrawn { get; private set; }
        private IStokvel stokvel;
        public Member(string name, IStokvel stokvel) {
            Name = name;
            this.stokvel = stokvel;
        }
        public void Contribute() {
            stokvel.Contribute(this);
            Contribution += stokvel.ContributionAmount;
        }
        public void PayOut(int amount) {
            Withdrawn += amount;
        }
    }
}