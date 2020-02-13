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
        private FakeWindow fakeWindow;
        private ECSClass uut;

        [SetUp]
        public void SetUp()
        {
            fakeHeater = new FakeHeater();
            fakeTempSensor = new FakeTempSensor();
            fakeWindow = new FakeWindow();
        }


        [Test]
        public void TestTurnOn()
        {
            uut = new ECSClass(35,40, fakeTempSensor, fakeHeater,fakeWindow);

            uut.Regulate();

            Assert.That(fakeHeater.TurnOnCounter, Is.EqualTo(1));
        }

        [Test]
        public void TestTurnOff()
        {
            uut = new ECSClass(25,40,fakeTempSensor, fakeHeater,fakeWindow);

            uut.Regulate();

            Assert.That(fakeHeater.TurnOffCounter, Is.EqualTo(1));
        }

        [Test]
        public void TestTemp()
        {
            uut = new ECSClass(25,40, fakeTempSensor, fakeHeater,fakeWindow);

            uut.Regulate();

            Assert.That(fakeTempSensor.GetTemp(), Is.EqualTo(30));
        }

        [Test]
        public void TestWindowOpen()
        {
            uut = new ECSClass(20,25,fakeTempSensor,fakeHeater,fakeWindow);

            uut.Regulate();

            Assert.That(fakeWindow.WindowStatus,Is.EqualTo(true));
        }

        [Test]
        public void TestWindowClose1()
        {
            uut = new ECSClass(35, 40, fakeTempSensor, fakeHeater, fakeWindow);

            uut.Regulate();

            Assert.That(fakeWindow.WindowStatus, Is.EqualTo(false));
        }

        [Test]
        public void TestWindowClose2()
        {
            uut = new ECSClass(25, 35, fakeTempSensor, fakeHeater, fakeWindow);

            uut.Regulate();

            Assert.That(fakeWindow.WindowStatus, Is.EqualTo(false));
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

        public class FakeWindow : IWindow
        {
            public bool WindowStatus { get; set; }
            public void CloseWindow()
            {
                WindowStatus = false;
            }

            public void OpenWindow()
            {
                WindowStatus = true;
            }
        }
    }
}
