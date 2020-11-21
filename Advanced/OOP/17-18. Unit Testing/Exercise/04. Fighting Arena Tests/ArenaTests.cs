using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior w1;
        private Warrior attacker;
        private Warrior defender;


        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();

            this.w1 = new Warrior("Pesho", 5, 50);

            this.attacker = new Warrior("Pesho", 10, 80);

            this.defender = new Warrior("Gosho", 5, 60);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors); // проверяваме дали колекцията не е празна
        }

        [Test]
        public void TestEnrollShouldAddTheWarriorToArena()
        {
            this.arena.Enroll(this.w1);

            Assert.That(this.arena.Warriors, Has.Member(this.w1));  // проверка дали един обект се съдържа в дадена колекция !!!!
               
        }

        [Test]
        public void EnrollShouldIncreaseCount()
        {
            int expectedCount = 2;


            this.arena.Enroll(this.w1);
            this.arena.Enroll(new Warrior("Gosho", 5, 60));

            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        
        }

        [Test]
        public void EnrollSameWarriorShouldThrowException()
        {

            this.arena.Enroll(this.w1); // имаме го един път, сега го добавяме втори път

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(this.w1);

            });

        }

        [Test]
        public void EnrollTwoWarriorWithSameNameShouldThrowException()
        {

            Warrior w1Copy = new Warrior(w1.Name, w1.Damage, w1.HP);

            this.arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(w1Copy);

            });

        }

        [Test]
        public void TestFightingWithMissingAttacker()
        {
            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });
            
        }

        [Test]
        public void TestFightingWithMissingDefender()
        {
            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            });

        }

        [Test]
        public void TestFightingTwoWarriors()
        {
            int expectedAttackerHP = this.attacker.HP - this.defender.Damage;
            int expecteddefenderHP = this.defender.HP - this.attacker.Damage;
                   
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(this.attacker.Name, this.defender.Name);

            Assert.AreEqual(expectedAttackerHP, this.attacker.HP);
            Assert.AreEqual(expecteddefenderHP, this.defender.HP);

        }
    }
}
