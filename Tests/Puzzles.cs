using System;
using System.Collections.Generic;
using System.Linq;
using NonogramSolver;
using NUnit.Framework;
using PixelPuzzle.Logic;

namespace Tests {
    public class Tests {
        [Test]
        public void Small_Boat() {
            TestLevel(1, SmallMapGenerator.Boat());
        }

        [Test]
        public void Small_Pattern() {
            TestLevel(2, SmallMapGenerator.Pattern());
        }

        [Test]
        public void Small_Heart() {
            TestLevel(3, SmallMapGenerator.Heart());
        }

        [Test]
        public void Small_Bag() {
            TestLevel(4, SmallMapGenerator.Bag());
        }

        [Test]
        public void Small_Pi() {
            TestLevel(5, SmallMapGenerator.Pi());
        }

        [Test]
        public void Small_Medal() {
            TestLevel(6, SmallMapGenerator.Medal());
        }

        [Test]
        public void Small_Dungbell() {
            TestLevel(7, SmallMapGenerator.Dungbell());
        }

        [Test]
        public void Small_BowlingBall() {
            TestLevel(8, SmallMapGenerator.BowlingBall());
        }

        [Test]
        public void Small_Cross() {
            TestLevel(9, SmallMapGenerator.Cross());
        }

        [Test]
        public void Small_Tower() {
            TestLevel(10, SmallMapGenerator.Tower());
        }

        [Test]
        public void Small_Lamp() {
            TestLevel(11, SmallMapGenerator.Lamp());
        }

        [Test]
        public void Small_Pattern4() {
            TestLevel(12, SmallMapGenerator.Pattern4());
        }

        [Test]
        public void Small_Face() {
            TestLevel(13, SmallMapGenerator.Face());
        }

        [Test]
        public void Small_Tortoise() {
            TestLevel(14, SmallMapGenerator.Tortoise());
        }

        [Test]
        public void Small_Apple() {
            TestLevel(15, SmallMapGenerator.Apple());
        }

        [Test]
        public void Small_Kettle() {
            TestLevel(16, SmallMapGenerator.Kettle());
        }

        [Test]
        public void Small_SpaceHoper() {
            TestLevel(17, SmallMapGenerator.SpaceHoper());
        }

        [Test]
        public void Small_Axe() {
            TestLevel(18, SmallMapGenerator.Axe());
        }

        [Test]
        public void Small_Candle() {
            TestLevel(19, SmallMapGenerator.Candle());
        }

        [Test]
        public void Small_Lightning() {
            TestLevel(20, SmallMapGenerator.Lightning());
        }

        [Test]
        public void Small_Pattern3() {
            TestLevel(21, SmallMapGenerator.Pattern3());
        }

        [Test]
        public void Small_Pattern5() {
            TestLevel(22, SmallMapGenerator.Pattern5());
        }

        [Test]
        public void Small_Cookie() {
            TestLevel(23, SmallMapGenerator.Cookie());
        }

        [Test]
        public void Small_Skull() {
            TestLevel(24, SmallMapGenerator.Skull());
        }

        [Test]
        public void Small_Bed() {
            TestLevel(25, SmallMapGenerator.Bed());
        }

        [Test]
        public void Small_Creeper() {
            TestLevel(26, SmallMapGenerator.Creeper());
        }

        [Test]
        public void Small_Pokemon() {
            TestLevel(27, SmallMapGenerator.Pokemon());
        }

        [Test]
        public void Small_SpaceShip() {
            TestLevel(28, SmallMapGenerator.SpaceShip());
        }

        [Test]
        public void Small_Fish() {
            TestLevel(29, SmallMapGenerator.Fish());
        }

        [Test]
        public void Small_Dog() {
            TestLevel(30, SmallMapGenerator.Dog());
        }

        [Test]
        public void Small_Pattern6() {
            TestLevel(31, SmallMapGenerator.Pattern6());
        }

        [Test]
        public void Small_Ghost() {
            TestLevel(32, SmallMapGenerator.Ghost());
        }

        [Test]
        public void Small_Mushroom() {
            TestLevel(33, SmallMapGenerator.Mushroom());
        }

        [Test]
        public void Small_Cat() {
            TestLevel(34, SmallMapGenerator.Cat());
        }

        [Test]
        public void Small_Wink() {
            TestLevel(35, SmallMapGenerator.Wink());
        }

        [Test]
        public void Small_Snake() {
            TestLevel(36, SmallMapGenerator.Snake());
        }

        [Test]
        public void Small_Sword() {
            TestLevel(37, SmallMapGenerator.Sword());
        }

        [Test]
        public void Small_Pattern2() {
            TestLevel(38, SmallMapGenerator.Pattern2());
        }

        [Test]
        public void Small_TennisRacket() {
            TestLevel(39, SmallMapGenerator.TennisRacket());
        }

        [Test]
        public void Small_Glasses() {
            TestLevel(40, SmallMapGenerator.Glasses());
        }

        [Test]
        public void Medium_JellyFish() {
            TestLevel(1, MediumMapGenerator.JellyFish());
        }

        [Test]
        public void Medium_Tree() {
            TestLevel(2, MediumMapGenerator.Tree());
        }

        [Test]
        public void Medium_Hat() {
            TestLevel(3, MediumMapGenerator.Hat());
        }

        [Test]
        public void Medium_Jug() {
            TestLevel(4, MediumMapGenerator.Jug());
        }

        [Test]
        public void Medium_Pig() {
            TestLevel(5, MediumMapGenerator.Pig());
        }

        [Test]
        public void Medium_Camera() {
            TestLevel(6, MediumMapGenerator.Camera());
        }

        [Test]
        public void Medium_Heart() {
            TestLevel(7, MediumMapGenerator.Heart());
        }

        [Test]
        public void Medium_Pint() {
            TestLevel(8, MediumMapGenerator.Pint());
        }

        [Test]
        public void Medium_Socks() {
            TestLevel(9, MediumMapGenerator.Socks());
        }

        [Test]
        public void Medium_Ghost() {
            TestLevel(10, MediumMapGenerator.Ghost());
        }

        [Test]
        public void Medium_Smile() {
            TestLevel(11, MediumMapGenerator.Smile());
        }

        [Test]
        public void Medium_Toilet() {
            TestLevel(12, MediumMapGenerator.Toilet());
        }

        [Test]
        public void Medium_MoonAndStars() {
            TestLevel(13, MediumMapGenerator.MoonAndStars());
        }

        [Test]
        public void Medium_SoundIcon() {
            TestLevel(14, MediumMapGenerator.SoundIcon());
        }

        [Test]
        public void Medium_House() {
            TestLevel(15, MediumMapGenerator.House());
        }

        [Test]
        public void Medium_Sheep() {
            TestLevel(16, MediumMapGenerator.Sheep());
        }

        [Test]
        public void Medium_Mushroom() {
            TestLevel(17, MediumMapGenerator.Mushroom());
        }

        [Test]
        public void Medium_MarioMushroom() {
            TestLevel(18, MediumMapGenerator.MarioMushroom());
        }

        [Test]
        public void Medium_Submarine() {
            TestLevel(19, MediumMapGenerator.Submarine());
        }

        [Test]
        public void Medium_Gameboy() {
            TestLevel(20, MediumMapGenerator.Gameboy());
        }

        [Test]
        public void Medium_Tv() {
            TestLevel(21, MediumMapGenerator.Tv());
        }

        [Test]
        public void Medium_Lock() {
            TestLevel(22, MediumMapGenerator.Lock());
        }

        [Test]
        public void Medium_Lamp() {
            TestLevel(23, MediumMapGenerator.Lamp());
        }

        [Test]
        public void Medium_Kangaroo() {
            TestLevel(24, MediumMapGenerator.Kangaroo());
        }

        [Test]
        public void Medium_Perfume() {
            TestLevel(25, MediumMapGenerator.Perfume());
        }

        [Test]
        public void Medium_Pattern() {
            TestLevel(26, MediumMapGenerator.Pattern());
        }

        [Test]
        public void Medium_Paw() {
            TestLevel(27, MediumMapGenerator.Paw());
        }

        [Test]
        public void Medium_Wine() {
            TestLevel(28, MediumMapGenerator.Wine());
        }

        [Test]
        public void Medium_DancingBoy() {
            TestLevel(29, MediumMapGenerator.DancingBoy());
        }

        [Test]
        public void Medium_TennisRacketAndBall() {
            TestLevel(30, MediumMapGenerator.TennisRacketAndBall());
        }

        [Test]
        public void Medium_Scales() {
            TestLevel(31, MediumMapGenerator.Scales());
        }

        [Test]
        public void Medium_Martini() {
            TestLevel(32, MediumMapGenerator.Martini());
        }

        [Test]
        public void Medium_Penguin() {
            TestLevel(33, MediumMapGenerator.Penguin());
        }

        [Test]
        public void Medium_YingYang() {
            TestLevel(34, MediumMapGenerator.YingYang());
        }

        [Test]
        public void Medium_Table() {
            TestLevel(35, MediumMapGenerator.Table());
        }

        [Test]
        public void Medium_Plant() {
            TestLevel(36, MediumMapGenerator.Plant());
        }

        [Test]
        public void Medium_People() {
            TestLevel(37, MediumMapGenerator.People());
        }

        [Test]
        public void Medium_Balloon() {
            TestLevel(38, MediumMapGenerator.Balloon());
        }

        [Test]
        public void Medium_Motorbike() {
            TestLevel(39, MediumMapGenerator.Motorbike());
        }

        [Test]
        public void Medium_Kart() {
            TestLevel(40, MediumMapGenerator.Kart());
        }

        [Test]
        public void Large_Castle() {
            TestLevel(1, LargeMapGenerator.Castle());
        }

        [Test]
        public void Large_Apple() {
            TestLevel(2, LargeMapGenerator.Apple());
        }

        [Test]
        public void Large_Umbrella() {
            TestLevel(3, LargeMapGenerator.Umbrella());
        }

        [Test]
        public void Large_Pumpkin() {
            TestLevel(4, LargeMapGenerator.Pumpkin());
        }

        [Test]
        public void Large_Robot() {
            TestLevel(5, LargeMapGenerator.Robot());
        }

        [Test]
        public void Large_Tractor() {
            TestLevel(6, LargeMapGenerator.Tractor());
        }

        [Test]
        public void Large_Helicopter() {
            TestLevel(7, LargeMapGenerator.Helicopter());
        }

        [Test]
        public void Large_Car() {
            TestLevel(8, LargeMapGenerator.Car());
        }

        [Test]
        public void Large_Microphone() {
            TestLevel(9, LargeMapGenerator.Microphone());
        }

        [Test]
        public void Large_Truck() {
            TestLevel(10, LargeMapGenerator.Truck());
        }

        [Test]
        public void Large_Ship() {
            TestLevel(11, LargeMapGenerator.Ship());
        }

        [Test]
        public void Large_Bag() {
            TestLevel(12, LargeMapGenerator.Bag());
        }

        [Test]
        public void Large_Rocket2() {
            TestLevel(13, LargeMapGenerator.Rocket2());
        }

        [Test]
        public void Large_Rocket() {
            TestLevel(14, LargeMapGenerator.Rocket());
        }

        [Test]
        public void Large_WizardHat() {
            TestLevel(15, LargeMapGenerator.WizardHat());
        }

        [Test]
        public void Large_Dice() {
            TestLevel(16, LargeMapGenerator.Dice());
        }

        [Test]
        public void Large_Clover() {
            TestLevel(17, LargeMapGenerator.Clover());
        }

        [Test]
        public void Large_House() {
            TestLevel(18, LargeMapGenerator.House());
        }

        [Test]
        public void Large_Plane() {
            TestLevel(19, LargeMapGenerator.Plane());
        }

        [Test]
        public void Large_Chair() {
            TestLevel(20, LargeMapGenerator.Chair());
        }

        [Test]
        public void Large_Duck() {
            TestLevel(21, LargeMapGenerator.Duck());
        }

        [Test]
        public void Large_Swan() {
            TestLevel(22, LargeMapGenerator.Swan());
        }

        [Test]
        public void Large_Moose() {
            TestLevel(23, LargeMapGenerator.Moose());
        }

        [Test]
        public void Large_FlowerPot() {
            TestLevel(24, LargeMapGenerator.FlowerPot());
        }

        [Test]
        public void Large_Cat() {
            TestLevel(25, LargeMapGenerator.Cat());
        }

        [Test]
        public void Large_Candle() {
            TestLevel(26, LargeMapGenerator.Candle());
        }

        [Test]
        public void Large_Bee() {
            TestLevel(27, LargeMapGenerator.Bee());
        }

        [Test]
        public void Large_Clock() {
            TestLevel(28, LargeMapGenerator.Clock());
        }

        [Test]
        public void Large_Camera() {
            TestLevel(29, LargeMapGenerator.Camera());
        }

        [Test]
        public void Large_Carrot() {
            TestLevel(30, LargeMapGenerator.Carrot());
        }

        [Test]
        public void Large_HotAirBalloon() {
            TestLevel(31, LargeMapGenerator.HotAirBalloon());
        }

        [Test]
        public void Large_Panda() {
            TestLevel(32, LargeMapGenerator.Panda());
        }

        [Test]
        public void Large_Snail() {
            TestLevel(33, LargeMapGenerator.Snail());
        }

        [Test]
        public void Large_Turtle() {
            TestLevel(34, LargeMapGenerator.Turtle());
        }

        [Test]
        public void Large_Giraffe() {
            TestLevel(35, LargeMapGenerator.Giraffe());
        }

        [Test]
        public void Large_Whale() {
            TestLevel(36, LargeMapGenerator.Whale());
        }

        [Test]
        public void Large_Ladybug() {
            TestLevel(37, LargeMapGenerator.Ladybug());
        }

        [Test]
        public void Large_Quad() {
            TestLevel(38, LargeMapGenerator.Quad());
        }

        [Test]
        public void Large_Drum() {
            TestLevel(39, LargeMapGenerator.Drum());
        }

        [Test]
        public void Large_Cherry() {
            TestLevel(40, LargeMapGenerator.Cherry());
        }

        [Test]
        public void Large_WuTangClan() {
            TestLevel(41, LargeMapGenerator.WuTangClan());
        }

        [Test]
        public void Large_Bird() {
            TestLevel(42, LargeMapGenerator.Bird());
        }

        [Test]
        public void Large_Cherrys() {
            TestLevel(43, LargeMapGenerator.Cherrys());
        }

        [Test]
        public void Large_PalmTree() {
            TestLevel(44, LargeMapGenerator.PalmTree());
        }

        [Test]
        public void Large_Santa() {
            TestLevel(45, LargeMapGenerator.Santa());
        }

        [Test]
        public void Large_Lol() {
            TestLevel(46, LargeMapGenerator.Lol());
        }

        [Test]
        public void Large_Landscape() {
            TestLevel(47, LargeMapGenerator.Landscape());
        }

        [Test]
        public void Large_ManRidingHorse() {
            TestLevel(48, LargeMapGenerator.ManRidingHorse());
        }

        [Test]
        public void Large_Hamster() {
            TestLevel(49, LargeMapGenerator.Hamster());
        }

        [Test]
        public void Large_Cow() {
            TestLevel(50, LargeMapGenerator.Cow());
        }

        [Test]
        public void Large_GiraffeFace() {
            TestLevel(51, LargeMapGenerator.GiraffeFace());
        }

        [Test]
        public void Large_Bin() {
            TestLevel(52, LargeMapGenerator.Bin());
        }

        [Test]
        public void Large_Ape() {
            TestLevel(53, LargeMapGenerator.Ape());
        }

        [Test]
        public void Large_Pharaoh() {
            TestLevel(54, LargeMapGenerator.Pharaoh());
        }

        [Test]
        public void Large_Man() {
            TestLevel(55, LargeMapGenerator.Man());
        }

        [Test]
        public void Large_Tap() {
            TestLevel(56, LargeMapGenerator.Tap());
        }

        [Test]
        public void Large_Builder() {
            TestLevel(57, LargeMapGenerator.Builder());
        }

        [Test]
        public void Large_Dog() {
            TestLevel(58, LargeMapGenerator.Dog());
        }

        [Test]
        public void Large_Lizard() {
            TestLevel(59, LargeMapGenerator.Lizard());
        }

        [Test]
        public void Large_Coffee() {
            TestLevel(60, LargeMapGenerator.Coffee());
        }


        private void TestLevel(int number, int[,] map) {
            var rowHints = GenerateRowHints(map);
            var columnHints = GenerateColumnHints(map);

            Nonogram nonogram = new Nonogram(rowHints, columnHints);
            var result = nonogram.Solve();

            Assert.IsTrue(result.IsSolved);
        }

        private int[][] GenerateRowHints(int[,] map) {
            int gridLength = (int)Math.Sqrt(map.Length);
            IList<int[]> hints = new List<int[]>();

            for (int row = 0; row < gridLength; row++) {
                NonogramSolver.CellValue[] rowCells = new NonogramSolver.CellValue[gridLength];

                for (int col = 0; col < gridLength; col++) {
                    rowCells[col] = map[row, col] == 1 ? NonogramSolver.CellValue.Filled : NonogramSolver.CellValue.Blank;
                }

                hints.Add(LineSolver.CreateLineHints(rowCells));
            }

            return hints.ToArray();
        }

        private int[][] GenerateColumnHints(int[,] map) {
            int gridLength = (int)Math.Sqrt(map.Length);
            IList<int[]> hints = new List<int[]>();

            for (int col = 0; col < gridLength; col++) {
                NonogramSolver.CellValue[] columnCells = new NonogramSolver.CellValue[gridLength];

                for (int row = 0; row < gridLength; row++) {
                    columnCells[row] = map[row, col] == 1 ? NonogramSolver.CellValue.Filled : NonogramSolver.CellValue.Blank;
                }

                hints.Add(LineSolver.CreateLineHints(columnCells));
            }

            return hints.ToArray();
        }
    }
}