using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //User Story 1
        public void Mazes_I_would_like_to_exist()
        {

            //I decided to use a graphic interface to speed up the results
            
            //Defining Start Point
            int _MaxWidthMaze = 5;
            int _MaxHeightMaze = 5;

            //Variant Positions
            int xVar = _MaxWidthMaze;
            int yVar = _MaxHeightMaze;
            
            bool defStartPoint = ((0 != yVar) || (0 != xVar));
            
            Assert.AreEqual(defStartPoint, true, "Initial Start Point");

            
            //Defining Exit Point
            int iExitPointX = _MaxWidthMaze;
            int iExitPointY = _MaxHeightMaze;
            //Start Exit Point
            bool defExitPoint = ((iExitPointX == _MaxHeightMaze) || (iExitPointY == _MaxWidthMaze));


            Assert.AreEqual(defExitPoint, true, "Initial Exit Point");


            //Create List Randomic To Define Internal Walls and Spaces
            //1s is Walls 0s is Spaces
            int[] _centerOfMaze = new int[]{1,0,1,1,0,1,0,1};
            //Generating Maze
            bool generateMaze = false;
            if ((defStartPoint) && (defExitPoint))
                if (_centerOfMaze.Length > 0)
                    generateMaze = true;

            Assert.AreEqual(generateMaze, true, "Generate Maz");

        }
    }
}
