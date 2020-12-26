using FakeAxeAndDummy.Contracts;
using FakeAxeAndDummy.Tests.Fakes;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void GivenHero_WhenAttackedTargetDies_ThenHeroReceivesExperience()
    {
        IAttackable fakeTarget = new IAttackableFake();
        IWeapon fakeWeapon = new IWeaponFake();

        Hero hero = new Hero("Pesho", fakeWeapon);

        hero.Attack(fakeTarget);

        Assert.AreEqual(hero.Experience, 20);

    }

    [Test]
    public void WITHMock_GivenHero_WhenAttackedTargetDies_ThenHeroReceivesExperience()
    {
        Mock<IAttackable> fakeTarget = new Mock<IAttackable>();
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        fakeTarget.Setup(f => f.GiveExperience()).Returns(20);
        fakeTarget.Setup(f => f.IsDead()).Returns(true);

        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.AreEqual(hero.Experience, 20);

    }




}