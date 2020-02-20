using System.Collections.Generic;

namespace StokvelNamespace {
    public class Stokvel : IStokvel {
        public int ContributionAmount { get; private set; }
        public int PayoutPeriod { get; private set; }
        public int Funds { get; private set; }
        private List<IMember> members = new List<IMember>();
        private int meetingCounter = 0;
        private int nextTurnForPayout = 0;
        public IReadOnlyList<IMember> Members {
            get {
                return members.AsReadOnly();
            }
        }
        public void Contribute(IMember m) {
            Funds += ContributionAmount;
        }
        public bool AddMember(IMember m) {
            if (Funds == 0) {
                members.Add(m);
                return true;
            }
            return false;
        }
        public Stokvel(int payoutPeriod, int fixedAmount) {
            PayoutPeriod = payoutPeriod;
            ContributionAmount = fixedAmount;
        }
        public void NextMeeting() {
            meetingCounter++;
            if (meetingCounter % PayoutPeriod == 0) {
                members[nextTurnForPayout].PayOut(Funds);
                Funds = 0;
            }
            foreach (Member m in Members) {
                m.Contribute();
            }
        }
    }
}