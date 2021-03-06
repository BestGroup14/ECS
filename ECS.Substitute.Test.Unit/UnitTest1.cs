﻿using System;
using ECS.New;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NSubstitute;

namespace ECS.Substitute.Test.Unit
{
    [TestFixture]
    public class UnitTest1
    {
        private IHeater _fakeHeater;
        private ITempSensor _fakeTempSensor;
        private IWindow _fakeWindow;
        private ECSClass _uut;

        [SetUp]
        public void Setup()
        {
            _fakeHeater = NSubstitute.Substitute.For<IHeater>();
            _fakeTempSensor = NSubstitute.Substitute.For<ITempSensor>();
            _fakeTempSensor.GetTemp().Returns(30);
            _fakeWindow = NSubstitute.Substitute.For<IWindow>();
        }

        [Test]
        public void Test_RunSelfTest_2false_false()
        {
            _uut = new ECSClass(25, 35, _fakeTempSensor, _fakeHeater, _fakeWindow);

            _fakeHeater.RunSelfTest().Returns(false);
            _fakeTempSensor.RunSelfTest().Returns(false);

            Assert.IsFalse(_uut.RunSelfTest());
        }

        [Test]
        public void Test_RunSelfTest_1false1true_false()
        {
            _uut = new ECSClass(25, 35, _fakeTempSensor, _fakeHeater, _fakeWindow);

            _fakeHeater.RunSelfTest().Returns(false);
            _fakeTempSensor.RunSelfTest().Returns(true);

            Assert.IsFalse(_uut.RunSelfTest());
        }

        [Test]
        public void Test_RunSelfTest_2true_true()
        {
            _uut = new ECSClass(25, 35, _fakeTempSensor, _fakeHeater, _fakeWindow);

            _fakeHeater.RunSelfTest().Returns(true);
            _fakeTempSensor.RunSelfTest().Returns(true);

            Assert.IsTrue(_uut.RunSelfTest());
        }

        [Test]
        public void Test_GetCurTemp()
        {
            _uut = new ECSClass(25, 35, _fakeTempSensor, _fakeHeater, _fakeWindow);


            Assert.That(_uut.GetCurTemp(),Is.EqualTo(30));
        }

        [Test]
        public void Test_GetThreshold()
        {
            _uut = new ECSClass(25, 35, _fakeTempSensor, _fakeHeater, _fakeWindow);

            Assert.That(_uut.GetThreshold(), Is.EqualTo(25));
        }

        [Test]
        public void TestWindowClose2()
        {
            _uut = new ECSClass(25, 35, _fakeTempSensor, _fakeHeater, _fakeWindow);

            _uut.Regulate();

            _fakeWindow.Received(1).CloseWindow();
        }

        [Test]
        public void TestWindowClose1()
        {
            _uut = new ECSClass(35, 40, _fakeTempSensor, _fakeHeater, _fakeWindow);

            _uut.Regulate();

            _fakeWindow.Received(1).CloseWindow();
        }

        [Test]
        public void TestWindowOpen()
        {
            _uut = new ECSClass(20, 25, _fakeTempSensor, _fakeHeater, _fakeWindow);

            _uut.Regulate();

            _fakeWindow.Received(1).OpenWindow();
        }

        [Test]
        public void TestTurnOn()
        {
            _uut = new ECSClass(35, 40, _fakeTempSensor, _fakeHeater, _fakeWindow);

            _uut.Regulate();

            _fakeHeater.Received(1).TurnOn();
        }

        [Test]
        public void TestTurnOff()
        {
            _uut = new ECSClass(25, 40, _fakeTempSensor, _fakeHeater, _fakeWindow);

            _uut.Regulate();

            _fakeHeater.Received(1).TurnOff();
        }
    }
}
