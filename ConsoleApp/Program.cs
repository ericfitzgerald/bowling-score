using System;
using Services;
using Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var scoreService = new ScoreService();
            Frame[] frames = new Frame[10];


            for (int i = 1; i <= 10; i++) {
                var frame = scoreService.GetRandomFrame(i);
                frames[i - 1] = frame;
            }
            
            scoreService.GetScores(frames);
            Console.WriteLine("Frame | Roll 1 | Roll 2 | Roll 3 | Score | Note");
            Console.WriteLine("--------------------------------------------------");
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("{0,5} | {1,6} | {2,6} | {3,6} | {4,5} | {5}", frames[i].FrameNumber, frames[i].Score1, frames[i].Score2, frames[i].Score3.HasValue ? frames[i].Score3.Value : "", frames[i].FrameScore, frames[i].GetNote());
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Total Score: " + scoreService.TotalScore(frames));
        }
    }
}
