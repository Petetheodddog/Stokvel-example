using NUnit.Framework;
using StokvelNamespace;
using NSubstitute;
using Moq;

namespace StokvelNamespace.Tests
{
    public class Tests
    {
        [Test]
        public void PayoutPeriodAndContributionAmountAreSetCorrectly()
        {
            // ARRANGE -- empty, nothing needed
            // ACT
            IStokvel s = new Stokvel(4, 1000);
            // ASSERT
            Assert.That(s.PayoutPeriod, Is.EqualTo(4));
            Assert.That(s.ContributionAmount, Is.EqualTo(1000));
        }

        [Test]
        public void CheckThatPayoutsOccurCorrectly() {
            // ARRANGE
            IStokvel s = new Stokvel(4, 1000);
            IMember a = Substitute.For<IMember>();
            s.AddMember(a);
            IMember b = Substitute.For<IMember>();
            s.AddMember(b);
            IMember c = Substitute.For<IMember>();
            s.AddMember(c);
            // ACT
            s.NextMeeting();
            s.NextMeeting();
            s.NextMeeting();
            s.NextMeeting();
            // ASSERT
            a.Received(1).PayOut(Arg.Any<int>());
            b.DidNotReceive().PayOut(Arg.Any<int>());
            c.DidNotReceive().PayOut(Arg.Any<int>());
        }

        [Test]
        public void CheckThatPayoutsOccurCorrectly_Version2() {
            // ARRANGE
            IStokvel s = new Stokvel(4, 1000);
            Mock<IMember> a = new Mock<IMember>();
            s.AddMember(a.Object);
            Mock<IMember> b = new Mock<IMember>();
            s.AddMember(b.Object);
            Mock<IMember> c = new Mock<IMember>();
            s.AddMember(c.Object);
            // ACT
            s.NextMeeting();
            s.NextMeeting();
            s.NextMeeting();
            s.NextMeeting();
            // ASSERT
            a.Verify(x => x.PayOut(It.IsAny<int>()), Times.Once());
            b.Verify(x => x.PayOut(It.IsAny<int>()), Times.Never());
            c.Verify(x => x.PayOut(It.IsAny<int>()), Times.Never());
        }

        [Test]
        public void CheckThatPayoutsDoNotOccurPrematurely() {
            // ARRANGE
            IStokvel s = new Stokvel(4, 1000);
            IMember a = new Member("Adam", s);
            IMember b = new Member("Bob", s);
            IMember c = new Member("Chloe", s);
            // ACT
            s.NextMeeting();
            s.NextMeeting();
            s.NextMeeting();
            // ASSERT
            Assert.That(a.Withdrawn, Is.EqualTo(0));
            Assert.That(b.Withdrawn, Is.EqualTo(0));
            Assert.That(c.Withdrawn, Is.EqualTo(0));
        }
    }
}