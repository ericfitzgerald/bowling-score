using System;
using Models;

namespace Services
{
    public class ScoreService
    {
        public Frame GetRandomFrame(int frameNumber) {
            var newFrame = new Frame(frameNumber);
            Random random = new Random();

            newFrame.Score1 = random.Next(1,11);
            if ((!newFrame.IsFinalFrame && !newFrame.IsStrike) || (newFrame.IsFinalFrame && !newFrame.IsStrike)) {
                newFrame.Score2 = random.Next(0,11-newFrame.Score1);
            } else if (newFrame.IsFinalFrame && newFrame.IsStrike) {
                newFrame.Score2 = random.Next(0,11);
            }
            if (newFrame.IsFinalFrame && (newFrame.IsStrike || newFrame.IsSpare)) {
                newFrame.Score3 = random.Next(0,11);
            }

            return newFrame;
        }

        public void GetScores(Frame[] frames) {
            int score;

            for (int i = 0; i < 10; i++) {
                score = 0;
                if (!frames[i].IsFinalFrame || (!frames[i].IsStrike && !frames[i].IsSpare)) {
                    if (frames[i].IsStrike) {
                        if (frames[i+1].IsStrike && !frames[i+1].IsFinalFrame) {
                            score += 10 + frames[i+1].Score1 + frames[i+2].Score1;
                        } else {
                            score += 10 + frames[i+1].Score1 + frames[i+1].Score2;
                        }
                    }
                    else if (frames[i].IsSpare) {
                        score += 10 + frames[i+1].Score1;
                    }
                    else {
                        score += frames[i].Score1 + frames[i].Score2;
                    }
                }
                else {
                    if (frames[i].IsSpare) {
                        score += 10 + frames[i].Score3.Value;
                    } else {
                        score += 10 + frames[i].Score2 + frames[i].Score3.Value;
                    }
                }

                frames[i].FrameScore = score;
            }

            return;
        }

        public int TotalScore(Frame[] frames) {
            int totalScore = 0;
            for (int i = 0; i < 10; i++) {
                totalScore += frames[i].FrameScore;
            }
            return totalScore;
        }
    }
}
