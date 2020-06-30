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
                new Level(1, Difficulty.Small,  SmallMapGenerator.Boat()),
                new Level(2, Difficulty.Small,  SmallMapGenerator.Pattern()),
                new Level(3, Difficulty.Small,  SmallMapGenerator.Fish()),
                new Level(4, Difficulty.Small,  SmallMapGenerator.Sword()),
                new Level(5, Difficulty.Small,  SmallMapGenerator.Heart()),
                new Level(6, Difficulty.Small,  SmallMapGenerator.BowlingBall()),
                new Level(7, Difficulty.Small,  SmallMapGenerator.Cross()),
                new Level(8, Difficulty.Small,  SmallMapGenerator.Pattern2()),
                new Level(9, Difficulty.Small,  SmallMapGenerator.Tower()),
                new Level(10, Difficulty.Small,  SmallMapGenerator.Lamp()),
                new Level(11, Difficulty.Small,  SmallMapGenerator.Apple()),
                new Level(12, Difficulty.Small,  SmallMapGenerator.Lightning()),
                new Level(13, Difficulty.Small,  SmallMapGenerator.Medal()),
                new Level(14, Difficulty.Small,  SmallMapGenerator.Pattern3()),
                new Level(15, Difficulty.Small,  SmallMapGenerator.Skull()),
                new Level(16, Difficulty.Small,  SmallMapGenerator.Bag()),
                new Level(17, Difficulty.Small,  SmallMapGenerator.Kettle()),
                new Level(18, Difficulty.Small,  SmallMapGenerator.SpaceHoper()),
                new Level(19, Difficulty.Small,  SmallMapGenerator.Pattern4()),
                new Level(20, Difficulty.Small,  SmallMapGenerator.Pattern5()),
                new Level(21, Difficulty.Small,  SmallMapGenerator.Dog()),
                new Level(22, Difficulty.Small,  SmallMapGenerator.Bed()),
                new Level(23, Difficulty.Small,  SmallMapGenerator.Pattern6()),
                new Level(24, Difficulty.Small,  SmallMapGenerator.Creeper()),
                new Level(25, Difficulty.Small,  SmallMapGenerator.Ghost()),
                new Level(26, Difficulty.Small,  SmallMapGenerator.Pi()),
                new Level(27, Difficulty.Small,  SmallMapGenerator.Pokemon()),
                new Level(28, Difficulty.Small,  SmallMapGenerator.Axe()),
                new Level(29, Difficulty.Small,  SmallMapGenerator.Face()),
                new Level(30, Difficulty.Small,  SmallMapGenerator.Mushroom()),
                new Level(31, Difficulty.Small,  SmallMapGenerator.Tortoise()),
                new Level(32, Difficulty.Small,  SmallMapGenerator.Dungbell()),
                new Level(33, Difficulty.Small,  SmallMapGenerator.Cat()),
                new Level(34, Difficulty.Small,  SmallMapGenerator.TennisRacket()),
                new Level(35, Difficulty.Small,  SmallMapGenerator.Glasses()),
                new Level(36, Difficulty.Small,  SmallMapGenerator.Snake()),
                new Level(37, Difficulty.Small,  SmallMapGenerator.SpaceShip()),
                new Level(38, Difficulty.Small,  SmallMapGenerator.Wink()),
                new Level(39, Difficulty.Small,  SmallMapGenerator.Candle()),
                new Level(40, Difficulty.Small,  SmallMapGenerator.Cookie()),
            };
        }

        private IList<Level> GetMediumLevels() {
            return new List<Level>(){
                new Level(1, Difficulty.Medium,  MediumMapGenerator.JellyFish()),
                new Level(2, Difficulty.Medium,  MediumMapGenerator.Camera()),
                new Level(3, Difficulty.Medium,  MediumMapGenerator.Gameboy()),
                new Level(4, Difficulty.Medium,  MediumMapGenerator.Tv()),
                new Level(5, Difficulty.Medium,  MediumMapGenerator.SoundIcon()),
                new Level(6, Difficulty.Medium,  MediumMapGenerator.Lock()),
                new Level(7, Difficulty.Medium,  MediumMapGenerator.Martini()),
                new Level(8, Difficulty.Medium,  MediumMapGenerator.Penguin()),
                new Level(9, Difficulty.Medium,  MediumMapGenerator.Ghost()),
                new Level(10, Difficulty.Medium,  MediumMapGenerator.House()),
                new Level(11, Difficulty.Medium,  MediumMapGenerator.Lamp()),
                new Level(12, Difficulty.Medium,  MediumMapGenerator.Sheep()),
                new Level(13, Difficulty.Medium,  MediumMapGenerator.Motorbike()),
                new Level(14, Difficulty.Medium,  MediumMapGenerator.Kart()),
                new Level(15, Difficulty.Medium,  MediumMapGenerator.YingYang()),
                new Level(16, Difficulty.Medium,  MediumMapGenerator.Heart()),
                new Level(17, Difficulty.Medium,  MediumMapGenerator.Mushroom()),
                new Level(18, Difficulty.Medium,  MediumMapGenerator.Pattern()),
                new Level(19, Difficulty.Medium,  MediumMapGenerator.Plant()),
                new Level(20, Difficulty.Medium,  MediumMapGenerator.Paw()),
            };
        }

        private IList<Level> GetHardLevels() {
            return new List<Level>(){
                new Level(1, Difficulty.Large,  LargeMapGenerator.Robot()),
                new Level(2, Difficulty.Large,  LargeMapGenerator.Rocket()),
                new Level(3, Difficulty.Large,  LargeMapGenerator.Apple()),
                new Level(4, Difficulty.Large,  LargeMapGenerator.Tractor()),
                new Level(5, Difficulty.Large,  LargeMapGenerator.Ladybug()),
                new Level(6, Difficulty.Large,  LargeMapGenerator.Bee()),
                new Level(7, Difficulty.Large,  LargeMapGenerator.Castle()),
                new Level(8, Difficulty.Large,  LargeMapGenerator.Umbrella()),
                new Level(9, Difficulty.Large,  LargeMapGenerator.Helicopter()),
                new Level(10, Difficulty.Large,  LargeMapGenerator.FlowerPot()),
                new Level(11, Difficulty.Large,  LargeMapGenerator.Car()),
                new Level(12, Difficulty.Large,  LargeMapGenerator.Cat()),
                new Level(13, Difficulty.Large,  LargeMapGenerator.Plane()),
                new Level(14, Difficulty.Large,  LargeMapGenerator.Microphone()),
                new Level(15, Difficulty.Large,  LargeMapGenerator.Truck()),
                new Level(16, Difficulty.Large,  LargeMapGenerator.Ship()),
                new Level(17, Difficulty.Large,  LargeMapGenerator.Quad()),
                new Level(18, Difficulty.Large,  LargeMapGenerator.WizardHat()),
                new Level(19, Difficulty.Large,  LargeMapGenerator.Clock()),
                new Level(20, Difficulty.Large,  LargeMapGenerator.Bag()),
                new Level(21, Difficulty.Large,  LargeMapGenerator.Camera()),
                new Level(22, Difficulty.Large,  LargeMapGenerator.Candle()),
                new Level(23, Difficulty.Large,  LargeMapGenerator.Carrot()),
                new Level(24, Difficulty.Large,  LargeMapGenerator.Chair()),
                new Level(25, Difficulty.Large,  LargeMapGenerator.Dice()),
                new Level(26, Difficulty.Large,  LargeMapGenerator.Drum()),
                new Level(27, Difficulty.Large,  LargeMapGenerator.HotAirBalloon()),
                new Level(28, Difficulty.Large,  LargeMapGenerator.Whale()),
                new Level(29, Difficulty.Large,  LargeMapGenerator.Swan()),
                new Level(30, Difficulty.Large,  LargeMapGenerator.Pumpkin()),
                new Level(31, Difficulty.Large,  LargeMapGenerator.Rocket2()),
                new Level(32, Difficulty.Large,  LargeMapGenerator.Snail()),
                new Level(33, Difficulty.Large,  LargeMapGenerator.Cherry()),
                new Level(34, Difficulty.Large,  LargeMapGenerator.Turtle()),
                new Level(35, Difficulty.Large,  LargeMapGenerator.Panda()),
                new Level(36, Difficulty.Large,  LargeMapGenerator.Moose()),
                new Level(37, Difficulty.Large,  LargeMapGenerator.Duck()),
                new Level(38, Difficulty.Large,  LargeMapGenerator.Clover()),
                new Level(39, Difficulty.Large,  LargeMapGenerator.House()),
                new Level(40, Difficulty.Large,  LargeMapGenerator.Giraffe()),
            };
        }
    }
}
