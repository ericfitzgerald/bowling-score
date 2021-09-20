using System;

namespace Models
{
    public class Frame
    {
        public Frame(int frameNumber) {
            FrameNumber = frameNumber;
        }

        public Frame() {
        }

        public int Score1 {get; set;}
        public int Score2 {get; set;}
        public int? Score3 {get; set;}
        public int FrameScore {get; set;}
        public int FrameNumber {get; set;}

        public bool IsFinalFrame {
            get {
                return FrameNumber == 10;
            }
        }

        public bool IsStrike {
            get {
                return Score1 == 10;
            }
        }

        public bool IsSpare {
            get {
                return Score1 + Score2 == 10 && !IsStrike;
            }
        }

        public string GetNote() {
            if (IsStrike)
                return "Strike!";
            if (IsSpare)
                return "Spare!";
            return "";
        }
    }
}
