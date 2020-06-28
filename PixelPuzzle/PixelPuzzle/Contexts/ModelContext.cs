using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Contexts {
    public class ModelContext {
        private readonly StorageContext storageContext;
        private readonly IDictionary<string, SavedGame> savedLevels;

        public IList<Level> Small { get; }
        public IList<Level> Medium { get; }
        public IList<Level> Hard { get; }

        public ModelContext() {
            storageContext = new StorageContext();

            savedLevels = storageContext.GetSavedGames();

            Small = GetSmallLevels();
            Medium = GetMediumLevels();
            Hard = GetHardLevels();

            TransformLevels();
        }

        private void TransformLevels() {
            TransformLevels(Small);
            TransformLevels(Medium);
            TransformLevels(Hard);
        }

        private void TransformLevels(IList<Level> levels) {
            foreach (var level in levels) {
                if (!savedLevels.ContainsKey(level.Key)) {
                    continue;
                }

                var state = savedLevels[level.Key];
                level.UserMap = state.Map;
                level.IsComplete = state.IsComplete;
            }
        }

        public async Task SaveLevel(int levelNumber, Difficulty difficulty, CellValue[,] userMap, bool isComplete) {
            var level = GetLevels(difficulty)
                .Where(i => i.LevelNumber == levelNumber)
                .SingleOrDefault();

            if (level != null) {
                level.UserMap = userMap;
                level.IsComplete = isComplete;
            }

            var save = new SavedGame {
                Difficulty = difficulty,
                IsComplete = isComplete,
                LevelNumber = levelNumber,
                Map = userMap,
            };

            await storageContext.SaveGame(save);

            savedLevels[save.Key] = save;
        }

        public SavedGame LoadLevel(int levelNumber, Difficulty difficulty) {
            var key = CreateKey(levelNumber, difficulty);

            if (savedLevels.ContainsKey(key)) {
                return savedLevels[key];
            }

            return null;
        }

        public string CreateKey(int levelNumber, Difficulty difficulty) {
            return $"{difficulty}.{levelNumber}";
        }

        public IList<Level> GetLevels(Difficulty difficulty) {
            switch (difficulty) {
                case Difficulty.Small:
                    return Small;
                case Difficulty.Medium:
                    return Medium;
                case Difficulty.Large:
                    return Hard;
                default:
                    return new List<Level>();
            }
        }

        private IList<Level> GetSmallLevels() {
            return new List<Level>(){
                new Level(1, Difficulty.Small,  MapGenerator.SmallBoat()),
                new Level(2, Difficulty.Small,  MapGenerator.SmallPattern()),
                new Level(3, Difficulty.Small,  MapGenerator.SmallFish()),
                new Level(4, Difficulty.Small,  MapGenerator.SmallSword()),
                new Level(5, Difficulty.Small,  MapGenerator.SmallHeart()),
                new Level(6, Difficulty.Small,  MapGenerator.SmallBowlingBall()),
                new Level(7, Difficulty.Small,  MapGenerator.SmallCross()),
                new Level(8, Difficulty.Small,  MapGenerator.SmallPattern2()),
                new Level(9, Difficulty.Small,  MapGenerator.SmallTower()),
                new Level(10, Difficulty.Small,  MapGenerator.SmallLamp()),
                new Level(11, Difficulty.Small,  MapGenerator.SmallApple()),
                new Level(12, Difficulty.Small,  MapGenerator.SmallLightning()),
                new Level(13, Difficulty.Small,  MapGenerator.SmallMedal()),
                new Level(14, Difficulty.Small,  MapGenerator.SmallPattern3()),
                new Level(15, Difficulty.Small,  MapGenerator.SmallSkull()),
                new Level(16, Difficulty.Small,  MapGenerator.SmallBag()),
                new Level(17, Difficulty.Small,  MapGenerator.SmallKettle()),
                new Level(18, Difficulty.Small,  MapGenerator.SmallSpaceHoper()),
                new Level(19, Difficulty.Small,  MapGenerator.SmallPattern4()),
                new Level(20, Difficulty.Small,  MapGenerator.SmallPattern5()),
                new Level(21, Difficulty.Small,  MapGenerator.SmallDog()),
                new Level(22, Difficulty.Small,  MapGenerator.SmallBed()),
                new Level(23, Difficulty.Small,  MapGenerator.SmallFinger()),
            };
        }

        private IList<Level> GetMediumLevels() {
            return new List<Level>(){
                new Level(1, Difficulty.Medium,  MapGenerator.MediumJellyFish()),
                new Level(2, Difficulty.Medium,  MapGenerator.MediumCamera()),
                new Level(3, Difficulty.Medium,  MapGenerator.MediumGameboy()),
                new Level(4, Difficulty.Medium,  MapGenerator.MediumTv()),
                new Level(5, Difficulty.Medium,  MapGenerator.MediumSoundIcon()),
                new Level(6, Difficulty.Medium,  MapGenerator.MediumLock()),
                new Level(7, Difficulty.Medium,  MapGenerator.MediumMartini()),
                new Level(8, Difficulty.Medium,  MapGenerator.MediumPenguin()),
                new Level(9, Difficulty.Medium,  MapGenerator.MediumCactus()),
                new Level(10, Difficulty.Medium,  MapGenerator.MediumHouse()),
                new Level(11, Difficulty.Medium,  MapGenerator.MediumLamp()),
                new Level(12, Difficulty.Medium,  MapGenerator.MediumSheep()),
                new Level(13, Difficulty.Medium,  MapGenerator.MediumMotorbike()),
                new Level(14, Difficulty.Medium,  MapGenerator.MediumKart()),
                new Level(15, Difficulty.Medium,  MapGenerator.MediumYingYang()),
                new Level(16, Difficulty.Medium,  MapGenerator.MediumHeart()),
                new Level(17, Difficulty.Medium,  MapGenerator.MediumMushroom()),
                new Level(18, Difficulty.Medium,  MapGenerator.MediumFootball()),
                new Level(19, Difficulty.Medium,  MapGenerator.MediumPlant()),
            };
        }

        private IList<Level> GetHardLevels() {
            return new List<Level>(){
                new Level(1, Difficulty.Large,  MapGenerator.LargeRobot()),
                new Level(2, Difficulty.Large,  MapGenerator.LargeRocket()),
                new Level(3, Difficulty.Large,  MapGenerator.LargeApple()),
                new Level(4, Difficulty.Large,  MapGenerator.LargeTractor()),
                new Level(5, Difficulty.Large,  MapGenerator.Large5()),
                new Level(6, Difficulty.Large,  MapGenerator.LargeBee()),
                new Level(7, Difficulty.Large,  MapGenerator.LargeCastle()),
                new Level(8, Difficulty.Large,  MapGenerator.LargeUmbrella()),
                new Level(9, Difficulty.Large,  MapGenerator.LargeHelicopter()),
                new Level(10, Difficulty.Large,  MapGenerator.LargeFlowerPot()),
                new Level(11, Difficulty.Large,  MapGenerator.LargeCar()),
                new Level(12, Difficulty.Large,  MapGenerator.LargeCat()),
                new Level(13, Difficulty.Large,  MapGenerator.LargePlane()),
                new Level(14, Difficulty.Large,  MapGenerator.LargeMicrophone()),
                new Level(15, Difficulty.Large,  MapGenerator.LargeTruck()),
                new Level(16, Difficulty.Large,  MapGenerator.LargeShip()),
                new Level(17, Difficulty.Large,  MapGenerator.LargeQuad()),
                new Level(18, Difficulty.Large,  MapGenerator.LargeWizardHat()),
                new Level(19, Difficulty.Large,  MapGenerator.LargeClock()),
                new Level(20, Difficulty.Large,  MapGenerator.LargeBag()),
                new Level(21, Difficulty.Large,  MapGenerator.LargeCamera()),
                new Level(22, Difficulty.Large,  MapGenerator.LargeCandle()),
                new Level(23, Difficulty.Large,  MapGenerator.LargeCarrot()),
                new Level(24, Difficulty.Large,  MapGenerator.LargeChair()),
                new Level(25, Difficulty.Large,  MapGenerator.LargeDice()),
                new Level(26, Difficulty.Large,  MapGenerator.LargeDrum()),
                new Level(27, Difficulty.Large,  MapGenerator.LargeHotAirBalloon()),
                new Level(28, Difficulty.Large,  MapGenerator.LargePattern()),
                new Level(29, Difficulty.Large,  MapGenerator.LargePattern2()),
                new Level(30, Difficulty.Large,  MapGenerator.LargePumpkin()),
                new Level(31, Difficulty.Large,  MapGenerator.LargeRocket2()),
                new Level(32, Difficulty.Large,  MapGenerator.LargeSnail()),
            };
        }
    }
}
