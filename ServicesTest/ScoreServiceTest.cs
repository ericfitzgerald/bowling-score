using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services;

namespace ServicesTest
{
    [TestClass]
    public class ScoreServiceTest
    {
        [TestMethod]
        public void Max_Score_Should_Be_300()
        {
            Frame[] frames = new Frame[10];
            var scoreService = new ScoreService();

            for (int i = 0; i < 10; i++) {
                frames[i] = new Frame(i+1);
                frames[i].Score1 = 10;
            }
            frames[9].Score2 = 10;
            frames[9].Score3 = 10;

            scoreService.GetScores(frames);
            Assert.AreEqual(300,scoreService.TotalScore(frames));
        }

        [TestMethod]
        public void Known_Game_Should_Be_110()
        {
            Frame[] frames = new Frame[10];
            var scoreService = new ScoreService();

            for (int i = 0; i < 10; i++) {
                frames[i] = new Frame(i+1);
            }
            frames[0].Score1 = 4;
            frames[0].Score2 = 3;
            frames[1].Score1 = 7;
            frames[1].Score2 = 3;
            frames[2].Score1 = 5;
            frames[2].Score2 = 2;
            frames[3].Score1 = 8;
            frames[3].Score2 = 1;
            frames[4].Score1 = 4;
            frames[4].Score2 = 6;
            frames[5].Score1 = 2;
            frames[5].Score2 = 4;
            frames[6].Score1 = 8;
            frames[6].Score2 = 0;
            frames[7].Score1 = 8;
            frames[7].Score2 = 0;
            frames[8].Score1 = 8;
            frames[8].Score2 = 2;
            frames[9].Score1 = 10;
            frames[9].Score2 = 1;
            frames[9].Score3 = 7;

            scoreService.GetScores(frames);
            Assert.AreEqual(110, scoreService.TotalScore(frames));
        }
    }
}
