namespace StokvelNamespace {
    public interface IMember {
        void PayOut(int amount);
        int Withdrawn { get; }
        void Contribute();
    }
}