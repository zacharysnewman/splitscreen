using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Splitscreen
{
    public class SplitscreenRects
    {
        const float Full = 1;
        const float Half = 0.5f;
        const float OneThird = 0.333f;
        const float OneThirdPlus = 0.334f;
        const float TwoThirds = 0.666f;
        const float TwoThirdsPlus = 0.667f;

        //  |---------------------|
        //  |                     |
        //  |                     |
        //  |                     |
        //  |                     |
        //  |                     |
        //  |---------------------|
        private static readonly Rect Fullscreen = new Rect(0, 0, Full, Full);

        //  |---------------------|
        //  |                     |
        //  |                     |
        //  |---------------------|
        //  |                     |
        //  |                     |
        //  |---------------------|
        private static readonly Rect TopHalf = new Rect(0, 0, Full, Half);
        private static readonly Rect BottomHalf = new Rect(0, Half, Full, Half);

        //  |----------|----------|
        //  |          |          |
        //  |          |          |
        //  |----------|----------|
        //  |          |          |
        //  |          |          |
        //  |----------|----------|
        private static readonly Rect TLQuarter = new Rect(0, 0, Half, Half);
        private static readonly Rect TRQuarter = new Rect(Half, 0, Half, Half);
        private static readonly Rect BLQuarter = new Rect(0, Half, Half, Half);
        private static readonly Rect BRQuarter = new Rect(Half, Half, Half, Half);

        //  |------|-------|------|
        //  |      |       |      |
        //  |      |       |      |
        //  |------|-------|------|
        //  |      |       |      |
        //  |      |       |      |
        //  |------|-------|------|
        private static readonly Rect TLSixth = new Rect(0, 0, OneThird, Half);
        private static readonly Rect TCSixth = new Rect(OneThird, 0, OneThirdPlus, Half);
        private static readonly Rect TRSixth = new Rect(TwoThirdsPlus, 0, OneThird, Half);
        private static readonly Rect BLSixth = new Rect(0, Half, OneThird, Half);
        private static readonly Rect BCSixth = new Rect(OneThird, Half, OneThirdPlus, Half);
        private static readonly Rect BRSixth = new Rect(TwoThirdsPlus, Half, OneThird, Half);

        //  |------|-------|------|
        //  |  33  | 34,33 |  33  |
        //  |------|-------|------|
        //  |33, 34| 34,34 |33, 34|
        //  |------|-------|------|
        //  |  33  | 34,33 |  33  |
        //  |------|-------|------|
        private static readonly Rect TLNinth = new Rect(0, 0, OneThird, OneThird);
        private static readonly Rect TCNinth = new Rect(TLNinth.width, 0, OneThirdPlus, OneThird);
        private static readonly Rect TRNinth = new Rect(TLNinth.width + TCNinth.width, 0, OneThird, OneThird);
        private static readonly Rect MLNinth = new Rect(0, TLNinth.height, OneThird, OneThirdPlus);
        private static readonly Rect MCNinth = new Rect(MLNinth.width, TCNinth.height, OneThirdPlus, OneThirdPlus);
        private static readonly Rect MRNinth = new Rect(MLNinth.width + MCNinth.width, TRNinth.height, OneThird, OneThirdPlus);
        private static readonly Rect BLNinth = new Rect(0, TLNinth.height + MLNinth.height, OneThird, OneThird);
        private static readonly Rect BCNinth = new Rect(BLNinth.width, TCNinth.height + MCNinth.height, OneThirdPlus, OneThird);
        private static readonly Rect BRNinth = new Rect(BLNinth.width + BCNinth.width, TRNinth.height + MCNinth.height, OneThird, OneThird);

        private static readonly Rect[][] ScreenSplits = new Rect[][]
        {
            new Rect[]
            {

            }, // 0
            new Rect[]
            {
                Fullscreen
            }, // 1
            new Rect[]
            {
                TopHalf,
                BottomHalf
            }, // 2
            new Rect[]
            {
                TopHalf,
                BLQuarter, BRQuarter
            }, // 3
            new Rect[]
            {
                TLQuarter, TRQuarter,
                BLQuarter, BRQuarter
            }, // 4
            new Rect[]
            {
                TLQuarter, TRQuarter,
                BLSixth, BCSixth, BRSixth
            }, // 5
            new Rect[]
            {
                TLSixth, TCSixth, TRSixth,
                BLSixth, BCSixth, BRSixth
            }, // 6
            new Rect[]
            {
                TLNinth, TCNinth, TRNinth,
                MLNinth, /*MCNinth,*/ MRNinth,
                BLNinth, /*BCNinth,*/ BRNinth
            }, // 7
            new Rect[]
            {
                TLNinth, TCNinth, TRNinth,
                MLNinth, /*MCNinth,*/ MRNinth,
                BLNinth, BCNinth, BRNinth
            }, // 8
        };

        public static Rect[] GetScreenSplits(int splitCount) =>
            splitCount >= 0 && splitCount <= 8 ? ScreenSplits[splitCount] : new Rect[] { };
    }
}
