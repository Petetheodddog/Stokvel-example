namespace StokvelNamespace {
    public interface IStokvel {
        int ContributionAmount { get; }
        void Contribute(IMember m);
    }
}