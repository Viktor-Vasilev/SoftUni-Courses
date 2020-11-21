using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 50;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHP, actualHp);
        }

        [Test]

        public void TestWithLikeNullName()
        {
            string name = null;
            int dmg = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });            
        }


        [Test]
        public void TestWithLikeEmptyName()
        {
            string name = string.Empty;
            int dmg = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeWhitespaceName()
        {
            string name = "        ";
            int dmg = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeZeroDamage()
        {
            string name = "Pesho";
            int dmg = 0;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });

        }

        [Test]
        public void TestWithLikeNegativeDamage()
        {
            string name = "Pesho";
            int dmg = -10;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });

        }

        [Test]
        public void TestWithLikeNegativeHP()
        {
            string name = "Pesho";
            int dmg = 50;
            int hp = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });

        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWhenLowHPShouldThrowException(int attackerHP)
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;

            string defenderName = "Gosho";
            int defenderDmg = 10;
            int defenderHP = 40;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });

        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWhitLowHPShouldThrowException(int defenderHP)
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;
            int attackerHP = 100;

            string defenderName = "Gosho";
            int defenderDmg = 10;
            

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });

        }

        [Test]
        public void AttackingStrongerEnemyShouldThrowException()
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;
            int attackerHP = 35;

            string defenderName = "Gosho";
            int defenderDmg = 40;
            int defenderHP = 35;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });

        }

        [Test]
        public void AttackingShouldDecreaseHPWhenSuccessful()
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;
            int attackerHP = 40;

            string defenderName = "Gosho";
            int defenderDmg = 5;
            int defenderHP = 50;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            

            int expectedAttackerHP = attackerHP - defenderDmg;
            int expectedDefenderHP = defenderHP - attackerDmg;

            attacker.Attack(defender);


            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }


        [Test]
        public void TestKillingEnemyWithAttack()
        {
            string attackerName = "Pesho";
            int attackerDmg = 80;
            int attackerHP = 100;

            string defenderName = "Gosho";
            int defenderDmg = 10;
            int defenderHP = 60;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            int expectedAttackerHP = attackerHP - defenderDmg;
            int expectedDefenderHP = 0;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

    }
}