// 20 05 2020 Created by Tony Horsham 11:24


using System;
using FRTForm.BlockTime.Enums;
using FRTForm.BlockTime.Models;
using FRTForm.BlockTime.Utilities;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BlockTimeUtilitiesTests
    {
        [Test]
        public void EnableValues_StartTightlyConstrained_LimitsRespected([Values(5, 30)] int interval)
        {
            // setup one hour block starting at 1100 today
            // cannot do in Setup because Start and/or Duration changed in each test
            var block = (new Block(0, DateTimeOffset.Now.Date + new TimeSpan(11, 0, 0),
                new TimeSpan(1, 0, 0), 1, BlockType.NotAvailable,
                "test", "", ""));
            var startLimit = block.Start - TimeSpan.FromMinutes(interval);
            var endLimit = block.End + TimeSpan.FromMinutes(interval);
            var minBlockDuration = 30;
            var enableValues = BlockTimeUtilities.GetEnableSettings(block, isStart: true,
                startLimit, endLimit, minBlockDuration);
            if (interval == 5)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsFalse(enableValues.Minus30);
            }
            if (interval == 30)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsTrue(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
        }
        [Test]
        public void EnableValues_DurationTightlyConstrained_LimitsRespected([Values(5, 30)] int interval)
        {
            // setup one hour block starting at 1100 today
            // cannot do in Setup because Start and/or Duration changed in each test
            var block = (new Block(0, DateTimeOffset.Now.Date + new TimeSpan(11, 0, 0),
                new TimeSpan(1, 0, 0), 1, BlockType.NotAvailable,
                "test", "", ""));
            var startLimit = block.Start - TimeSpan.FromMinutes(interval);
            var endLimit = block.End + TimeSpan.FromMinutes(interval);
            var minBlockDuration = 30;
            var enableValues = BlockTimeUtilities.GetEnableSettings(block, isStart: false,
                startLimit, endLimit, minBlockDuration);
            if (interval == 5)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
            if (interval == 30)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsTrue(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
        }
        [Test]
        public void EnableValues_StartOverConstrained_LimitsRespected([Values(5, 30)] int interval)
        {
            // setup one hour block starting at 1100 today
            // cannot do in Setup because Start and/or Duration changed in each test
            var block = (new Block(0, DateTimeOffset.Now.Date + new TimeSpan(11, 0, 0),
                new TimeSpan(1, 0, 0), 1, BlockType.NotAvailable,
                "test", "", ""));
            var startLimit = block.Start - TimeSpan.FromMinutes(interval - 0.5);
            var endLimit = block.End + TimeSpan.FromMinutes(interval - 0.5);
            var minBlockDuration = 30;
            var enableValues = BlockTimeUtilities.GetEnableSettings(block, isStart: true,
                startLimit, endLimit, minBlockDuration);
            if (interval == 5)
            {
                Assert.IsFalse(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsFalse(enableValues.Minus5);
                Assert.IsFalse(enableValues.Minus30);
            }
            if (interval == 30)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsFalse(enableValues.Minus30);
            }
        }
        [Test]
        public void EnableValues_DurationOverConstrained_LimitsRespected([Values(5, 30)] int interval)
        {
            // setup one hour block starting at 1100 today
            // cannot do in Setup because Start and/or Duration changed in each test
            var block = (new Block(0, DateTimeOffset.Now.Date + new TimeSpan(11, 0, 0),
                new TimeSpan(1, 0, 0), 1, BlockType.NotAvailable,
                "test", "", ""));
            var startLimit = block.Start - TimeSpan.FromMinutes(interval - 0.5);
            var endLimit = block.End + TimeSpan.FromMinutes(interval - 0.5);
            var minBlockDuration = 30;
            var enableValues = BlockTimeUtilities.GetEnableSettings(block, isStart: false,
                startLimit, endLimit, minBlockDuration);
            if (interval == 5)
            {
                Assert.IsFalse(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
            if (interval == 30)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
        }
        [Test]
        public void EnableValues_StartTightlyConstrainedDurationIncreased_LimitsRespected([Values(5, 30)] int interval)
        {
            // setup one hour block starting at 1100 today
            // cannot do in Setup because Start and/or Duration changed in each test
            var block = (new Block(0, DateTimeOffset.Now.Date + new TimeSpan(11, 0, 0),
                new TimeSpan(1, 0, 0), 1, BlockType.NotAvailable,
                "test", "", ""));
            var startLimit = block.Start - TimeSpan.FromMinutes(interval);
            var endLimit = block.End + TimeSpan.FromMinutes(interval);
            var minBlockDuration = 30;
            var enableValues = BlockTimeUtilities.GetEnableSettings(block, isStart: true,
                startLimit, endLimit, minBlockDuration);
            if (interval == 5)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsFalse(enableValues.Minus30);
            }
            if (interval == 30)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsTrue(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
            block.Duration += new TimeSpan(0, 0, interval, 0);
            enableValues = BlockTimeUtilities.GetEnableSettings(block, isStart: true,
                startLimit, endLimit, minBlockDuration);
            if (interval == 5)
            {
                Assert.IsFalse(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsFalse(enableValues.Minus30);
            }
            if (interval == 30)
            {
                Assert.IsFalse(enableValues.Plus5);// even 5 is too much
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
        }
        [Test]
        public void EnableValues_DurationTightlyConstrainedLaterStart_LimitsRespected([Values(5, 30)] int interval)
        {
            // setup one hour block starting at 1100 today
            // cannot do in Setup because Start and/or Duration changed in each test
            var block = (new Block(0, DateTimeOffset.Now.Date + new TimeSpan(11, 0, 0),
                new TimeSpan(1, 0, 0), 1, BlockType.NotAvailable,
                "test", "", ""));
            var startLimit = block.Start - TimeSpan.FromMinutes(interval);
            var endLimit = block.End + TimeSpan.FromMinutes(interval);
            var minBlockDuration = 30;
            var enableValues = BlockTimeUtilities.GetEnableSettings(block, isStart: false,
                startLimit, endLimit, minBlockDuration);
            if (interval == 5)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
            if (interval == 30)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsTrue(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
            block.Start = block.Start.AddMinutes(interval);
            enableValues = BlockTimeUtilities.GetEnableSettings(block, isStart: false,
                startLimit, endLimit, minBlockDuration);
            if (interval == 5)
            {
                Assert.IsFalse(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
            if (interval == 30)
            {
                Assert.IsFalse(enableValues.Plus5);// even 5 is too much
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsTrue(enableValues.Minus5);
                Assert.IsTrue(enableValues.Minus30);
            }
        }
        [Test]
        public void EnableValues_DurationTightlyConstrainedDurationAtLowLimit_LimitsRespected([Values(5, 30)] int interval)
        {
            // setup half hour block starting at 1100 today
            // cannot do in Setup because Start and/or Duration changed in each test
            var block = (new Block(0, DateTimeOffset.Now.Date + new TimeSpan(11, 0, 0),
                new TimeSpan(0, interval, 0), 1, BlockType.NotAvailable,
                "test", "", ""));
            var startLimit = block.Start - TimeSpan.FromMinutes(interval);
            var endLimit = block.End + TimeSpan.FromMinutes(interval);
            var minBlockDuration = interval;
            var enableValues = BlockTimeUtilities.GetEnableSettings(block, isStart: false,
                startLimit, endLimit, minBlockDuration);
            if (interval == 5)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsFalse(enableValues.Plus30);
                Assert.IsFalse(enableValues.Minus5);
                Assert.IsFalse(enableValues.Minus30);
            }
            if (interval == 30)
            {
                Assert.IsTrue(enableValues.Plus5);
                Assert.IsTrue(enableValues.Plus30);
                Assert.IsFalse(enableValues.Minus5);
                Assert.IsFalse(enableValues.Minus30);
            }
            Assert.AreEqual(1, 1);
        }
    }
}