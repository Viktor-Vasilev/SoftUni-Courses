namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            // var robot = new Robot("Alex", 100);
            var robotManager = new RobotManager(100);
            Assert.AreEqual(100, robotManager.Capacity);
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenInvalid()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-100));
        }

        [Test]
        public void RobotsCountShouldCountProperly()
        {
            var robotManager = new RobotManager(100);
            var robot = new Robot("Viktor", 1000);
            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RobotManagerAddMethethodShouldThrowExceptionForDuplicateRobotName()
        {
            var robot = new Robot("Viktor", 80);
            var robotManager = new RobotManager(10);
            robotManager.Add(robot);


            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void RobotManagerAddMethethodShouldThrowExceptionForInvalidCapacity()
        {
            var robot = new Robot("Viktor", 80);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);


            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }


        [Test]
        public void RobotManagerRemoveMethethodShouldWorkProperly()
        {
            var robot = new Robot("Viktor", 80);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            robotManager.Remove("Viktor");


            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManagerRemoveMethethodShouldThrowExceptionForInvalidRobotName()
        {

            var robotManager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Viktor"));
        }

        [Test]
        public void WorkShouldDecreaseRobotBattery()
        {
            var robot = new Robot("Viktor", 80);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);

            robotManager.Work("Viktor", "Cleaning", 10);

            Assert.AreEqual(70, robot.Battery);

        }

        [Test]
        public void WorkShouldThrowExceptionForInvalidRobot()
        {           
            var robotManager = new RobotManager(1);          
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Stoyan", "Cleaning", 10));

        }

        [Test]
        public void WorkShouldThrowExceptionWhenNotEnoughBattery()
        {
            var robot = new Robot("Viktor", 80);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Viktor", "Cleaning", 100));

        }

        [Test]
        public void ChargeShouldThrowExceptionForInvalidRobot()
        {
            var robotManager = new RobotManager(1);
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Stoyan"));

        }

        [Test]
        public void ChargeShouldSetRobotBatteryToMax()
        {
            var robot = new Robot("Viktor", 80);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);

            robotManager.Work("Viktor", "Cleaning", 20);

            robotManager.Charge("Viktor");

            Assert.AreEqual(80, robot.Battery);

        }


    }
}
