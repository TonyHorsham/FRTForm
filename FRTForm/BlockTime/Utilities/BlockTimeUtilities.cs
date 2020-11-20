using System;
using System.Collections.Generic;
using FRTForm.BlockTime.Enums;
using FRTForm.BlockTime.Models;

namespace FRTForm.BlockTime.Utilities
{
    public static class BlockTimeUtilities
    {
        public static (bool Plus30, bool Plus5, bool Minus5, bool Minus30)
            GetEnableSettings(Block block, bool isStart, DateTimeOffset startLimit,
                DateTimeOffset endLimit, int minBlockDuration)
        {
            var enableValues = (Plus30: false, Plus5: false, Minus5: false, Minus30: false);
            var test30 = 29.9999;
            var test5 = 4.9999;
            var headRoom = (block.Start - startLimit).TotalMinutes;
            if (!isStart)
            {
                headRoom = block.Duration.TotalMinutes - minBlockDuration;
            }
            //else headRoom = block.Duration.TotalMinutes - minBlockDuration;
            enableValues.Minus30 = headRoom > test30;
            enableValues.Minus5 = headRoom > test5;
            if (!isStart)
            {
                // check for minimum duration
                if (block.Duration.TotalMinutes <= minBlockDuration)
                {
                    enableValues.Minus5 = false;
                    enableValues.Minus30 = false;
                }
            }
            var lowerRoom = (endLimit - block.End).TotalMinutes;
            enableValues.Plus30 = lowerRoom > test30;
            enableValues.Plus5 = lowerRoom > test5;
            return enableValues;
        }
        /// <summary>
        /// Get the limits for an existing block for editing.
        /// N.B. not suitable for new blocks
        /// </summary>
        /// <param name="displayBlocks"></param>
        /// <param name="block"></param>
        /// <returns></returns>
        public static (DateTimeOffset startLimit, DateTimeOffset endLimit) GetLimits(List<Block> displayBlocks,
            Block block)
        {
            // need to find surrounding blocks for limits
            // first find the index of this block
            var index = displayBlocks.IndexOf(block);
            DateTimeOffset startLimit;
            DateTimeOffset endLimit;
            if (index == 0)
            {
                // if first, startLimit will be block.Start
                startLimit = block.Start;
            }
            else
            {
                // else startLimit is .End of previous block
                // unless it is Available => .Start
                var priorBlock = displayBlocks[index - 1];
                // Booking may have a start Buffer that should be ignored for limits
                if (priorBlock.BlockType == BlockType.Buffer && index > 1)
                {
                    priorBlock = displayBlocks[index - 2];
                }
                startLimit = priorBlock.BlockType != BlockType.Available ? priorBlock.End : priorBlock.Start;
            }
            if (index == displayBlocks.Count - 1)
            {
                // if last, endLimit will be block.End
                endLimit = block.End;
            }
            else
            {
                // else endLimit is .Start of next block
                // unless it is Available => .End
                var nextBlock = displayBlocks[index + 1];
                // Booking may have a start Buffer that should be ignored for limits
                if (nextBlock.BlockType == BlockType.Buffer && index < displayBlocks.Count - 1)
                {
                    nextBlock = displayBlocks[index + 2];
                }
                endLimit = nextBlock.BlockType != BlockType.Available ? nextBlock.Start : nextBlock.End;
            }
            return (startLimit, endLimit);
        }
    }
}
