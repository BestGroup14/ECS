using System;
using ECS.New;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ECS.Test
{
    [TestFixture]
    public class UnitTest1
    {
        private FakeHeater fakeHeater;
        private FakeTempSensor fakeTempSensor;
        private ECSClass uut;

        [SetUp]
        public void SetUp()
        {
            fakeHeater = new FakeHeater();
            fakeTempSensor = new FakeTempSensor();
        }


        [Test]
        public void TestTurnOn()
        {
            uut = new ECSClass(35, fakeTempSensor, fakeHeater);

            uut.Regulate();

            Assert.That(fakeHeater.TurnOnCounter, Is.EqualTo(1));
        }

        [Test]
        public void TestTurnOff()
        {
            uut = new ECSClass(25, fakeTempSensor, fakeHeater);

            uut.Regulate();

            Assert.That(fakeHeater.TurnOffCounter, Is.EqualTo(1));
        }

        [Test]
        public void TestTemp()
        {
            uut = new ECSClass(25, fakeTempSensor, fakeHeater);

            uut.Regulate();

            Assert.That(fakeTempSensor.GetTemp(), Is.EqualTo(30));
        }

        public class FakeHeater : IHeater
        {
            public int TurnOffCounter { get; set; }
            public int TurnOnCounter { get; set; }

            public bool RunSelfTest()
            {
                return true;
            }

            public void TurnOff()
            {
                TurnOffCounter++;
            }

            public void TurnOn()
            {
                TurnOnCounter++;
            }
        }

        public class FakeTempSensor : ITempSensor
        {
            public int GetTemp()
            {
                return 30;
            }

            public bool RunSelfTest()
            {
                return true;
            }
        }
    }
}
