namespace StokvelNamespace {
    public interface IStokvel {
        int ContributionAmount { get; }
        void Contribute(IMember m);
        bool AddMember(IMember m);
        int PayoutPeriod { get; }
        int Funds { get; }
        void NextMeeting();
    }
}