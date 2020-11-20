using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void WeaponShouldLoseDurabilityAfterAttack()
    {
        //Arrange

        Axe axe = new Axe(10, 10);

        Dummy dummy = new Dummy(100, 100);

        //Act

        axe.Attack(dummy);


        //Assert

        var expectedResult = 9;
        var actualResult = axe.DurabilityPoints;

        Assert.AreEqual(expectedResult, actualResult);
    }
    [Test]
    public void AttackShouldThrowInvalidOperationExceptionWhenAxeDurabilityIsBelowZero()
    {
        // Arrange
        Axe axe = new Axe(20, 0);

        Dummy dummy = new Dummy(10, 10);

        //Act -- Assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));


      


    }
}