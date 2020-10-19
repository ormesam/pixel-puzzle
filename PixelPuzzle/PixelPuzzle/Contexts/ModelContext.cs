using System;
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
        public IList<Level> Large { get; }

        public ModelContext() {
            storageContext = new StorageContext();

            savedLevels = storageContext.GetSavedGames();

            Small = new List<Level>();
            Medium = new List<Level>();
            Large = new List<Level>();

            RegisterLevels();
            TransformLevels();
        }

        private void RegisterLevels() {
            RegisterSmallLevels();
            RegisterMediumLevels();
            RegisterHardLevels();
        }

        private void RegisterSmallLevels() {
            RegisterSmallLevel(1, SmallMapGenerator.Boat());
            RegisterSmallLevel(2, SmallMapGenerator.Pattern());
            RegisterSmallLevel(3, SmallMapGenerator.Heart());
            RegisterSmallLevel(4, SmallMapGenerator.Bag());
            RegisterSmallLevel(5, SmallMapGenerator.Pi());
            RegisterSmallLevel(6, SmallMapGenerator.Medal());
            RegisterSmallLevel(7, SmallMapGenerator.Dungbell());
            RegisterSmallLevel(8, SmallMapGenerator.BowlingBall());
            RegisterSmallLevel(9, SmallMapGenerator.Cross());
            RegisterSmallLevel(10, SmallMapGenerator.Tower());
            RegisterSmallLevel(11, SmallMapGenerator.Lamp());
            RegisterSmallLevel(12, SmallMapGenerator.Pattern4());
            RegisterSmallLevel(13, SmallMapGenerator.Face());
            RegisterSmallLevel(14, SmallMapGenerator.Tortoise());
            RegisterSmallLevel(15, SmallMapGenerator.Apple());
            RegisterSmallLevel(16, SmallMapGenerator.Kettle());
            RegisterSmallLevel(17, SmallMapGenerator.SpaceHoper());
            RegisterSmallLevel(18, SmallMapGenerator.Axe());
            RegisterSmallLevel(19, SmallMapGenerator.Candle());
            RegisterSmallLevel(20, SmallMapGenerator.Lightning());
            RegisterSmallLevel(21, SmallMapGenerator.Pattern3());
            RegisterSmallLevel(22, SmallMapGenerator.Pattern5());
            RegisterSmallLevel(23, SmallMapGenerator.Cookie());
            RegisterSmallLevel(24, SmallMapGenerator.Skull());
            RegisterSmallLevel(25, SmallMapGenerator.Bed());
            RegisterSmallLevel(26, SmallMapGenerator.Creeper());
            RegisterSmallLevel(27, SmallMapGenerator.Pokemon());
            RegisterSmallLevel(28, SmallMapGenerator.SpaceShip());
            RegisterSmallLevel(29, SmallMapGenerator.Fish());
            RegisterSmallLevel(30, SmallMapGenerator.Dog());
            RegisterSmallLevel(31, SmallMapGenerator.Pattern6());
            RegisterSmallLevel(32, SmallMapGenerator.Ghost());
            RegisterSmallLevel(33, SmallMapGenerator.Mushroom());
            RegisterSmallLevel(34, SmallMapGenerator.Cat());
            RegisterSmallLevel(35, SmallMapGenerator.Wink());
            RegisterSmallLevel(36, SmallMapGenerator.Snake());
            RegisterSmallLevel(37, SmallMapGenerator.Sword());
            RegisterSmallLevel(38, SmallMapGenerator.Pattern2());
            RegisterSmallLevel(39, SmallMapGenerator.TennisRacket());
            RegisterSmallLevel(40, SmallMapGenerator.Glasses());
        }

        private void RegisterSmallLevel(int number, int[,] map) {
            if (Small.Any(i => i.LevelNumber == number)) {
#if DEBUG
                throw new Exception("Level already exists for Small: " + number);
#else
                return;
#endif
            }

            Small.Add(CreateLevel(number, Difficulty.Small, map));
        }

        private void RegisterMediumLevels() {
            RegisterMediumLevel(1, MediumMapGenerator.JellyFish());
            RegisterMediumLevel(2, MediumMapGenerator.Tree());
            RegisterMediumLevel(3, MediumMapGenerator.Hat());
            RegisterMediumLevel(4, MediumMapGenerator.Jug());
            RegisterMediumLevel(5, MediumMapGenerator.Pig());
            RegisterMediumLevel(6, MediumMapGenerator.Camera());
            RegisterMediumLevel(7, MediumMapGenerator.Heart());
            RegisterMediumLevel(8, MediumMapGenerator.Pint());
            RegisterMediumLevel(9, MediumMapGenerator.Socks());
            RegisterMediumLevel(10, MediumMapGenerator.Ghost());
            RegisterMediumLevel(11, MediumMapGenerator.Smile());
            RegisterMediumLevel(12, MediumMapGenerator.Toilet());
            RegisterMediumLevel(13, MediumMapGenerator.MoonAndStars());
            RegisterMediumLevel(14, MediumMapGenerator.SoundIcon());
            RegisterMediumLevel(15, MediumMapGenerator.House());
            RegisterMediumLevel(16, MediumMapGenerator.Sheep());
            RegisterMediumLevel(17, MediumMapGenerator.Mushroom());
            RegisterMediumLevel(18, MediumMapGenerator.MarioMushroom());
            RegisterMediumLevel(19, MediumMapGenerator.Submarine());
            RegisterMediumLevel(20, MediumMapGenerator.Gameboy());
            RegisterMediumLevel(21, MediumMapGenerator.Tv());
            RegisterMediumLevel(22, MediumMapGenerator.Lock());
            RegisterMediumLevel(23, MediumMapGenerator.Lamp());
            RegisterMediumLevel(24, MediumMapGenerator.Kangaroo());
            RegisterMediumLevel(25, MediumMapGenerator.Perfume());
            RegisterMediumLevel(26, MediumMapGenerator.Pattern());
            RegisterMediumLevel(27, MediumMapGenerator.Paw());
            RegisterMediumLevel(28, MediumMapGenerator.Wine());
            RegisterMediumLevel(29, MediumMapGenerator.DancingBoy());
            RegisterMediumLevel(30, MediumMapGenerator.TennisRacketAndBall());
            RegisterMediumLevel(31, MediumMapGenerator.Scales());
            RegisterMediumLevel(32, MediumMapGenerator.Martini());
            RegisterMediumLevel(33, MediumMapGenerator.Penguin());
            RegisterMediumLevel(34, MediumMapGenerator.YingYang());
            RegisterMediumLevel(35, MediumMapGenerator.Table());
            RegisterMediumLevel(36, MediumMapGenerator.Plant());
            RegisterMediumLevel(37, MediumMapGenerator.People());
            RegisterMediumLevel(38, MediumMapGenerator.Balloon());
            RegisterMediumLevel(39, MediumMapGenerator.Motorbike());
            RegisterMediumLevel(40, MediumMapGenerator.Kart());
        }

        private void RegisterMediumLevel(int number, int[,] map) {
            if (Medium.Any(i => i.LevelNumber == number)) {
#if DEBUG
                throw new Exception("Level already exists for Medium: " + number);
#else
                return;
#endif
            }

            Medium.Add(CreateLevel(number, Difficulty.Medium, map));
        }

        private void RegisterHardLevels() {
            RegisterLargeLevel(1, LargeMapGenerator.Castle());
            RegisterLargeLevel(2, LargeMapGenerator.Apple());
            RegisterLargeLevel(3, LargeMapGenerator.Umbrella());
            RegisterLargeLevel(4, LargeMapGenerator.Pumpkin());
            RegisterLargeLevel(5, LargeMapGenerator.Robot());
            RegisterLargeLevel(6, LargeMapGenerator.Tractor());
            RegisterLargeLevel(7, LargeMapGenerator.Helicopter());
            RegisterLargeLevel(8, LargeMapGenerator.Car());
            RegisterLargeLevel(9, LargeMapGenerator.Microphone());
            RegisterLargeLevel(10, LargeMapGenerator.Truck());
            RegisterLargeLevel(11, LargeMapGenerator.Ship());
            RegisterLargeLevel(12, LargeMapGenerator.Bag());
            RegisterLargeLevel(13, LargeMapGenerator.Rocket2());
            RegisterLargeLevel(14, LargeMapGenerator.Rocket());
            RegisterLargeLevel(15, LargeMapGenerator.WizardHat());
            RegisterLargeLevel(16, LargeMapGenerator.Dice());
            RegisterLargeLevel(17, LargeMapGenerator.Clover());
            RegisterLargeLevel(18, LargeMapGenerator.House());
            RegisterLargeLevel(19, LargeMapGenerator.Plane());
            RegisterLargeLevel(20, LargeMapGenerator.Chair());
            RegisterLargeLevel(21, LargeMapGenerator.Duck());
            RegisterLargeLevel(22, LargeMapGenerator.Swan());
            RegisterLargeLevel(23, LargeMapGenerator.Moose());
            RegisterLargeLevel(24, LargeMapGenerator.FlowerPot());
            RegisterLargeLevel(25, LargeMapGenerator.Cat());
            RegisterLargeLevel(26, LargeMapGenerator.Candle());
            RegisterLargeLevel(27, LargeMapGenerator.Bee());
            RegisterLargeLevel(28, LargeMapGenerator.Clock());
            RegisterLargeLevel(29, LargeMapGenerator.Camera());
            RegisterLargeLevel(30, LargeMapGenerator.Carrot());
            RegisterLargeLevel(31, LargeMapGenerator.HotAirBalloon());
            RegisterLargeLevel(32, LargeMapGenerator.Panda());
            RegisterLargeLevel(33, LargeMapGenerator.Snail());
            RegisterLargeLevel(34, LargeMapGenerator.Turtle());
            RegisterLargeLevel(35, LargeMapGenerator.Giraffe());
            RegisterLargeLevel(36, LargeMapGenerator.Whale());
            RegisterLargeLevel(37, LargeMapGenerator.Ladybug());
            RegisterLargeLevel(38, LargeMapGenerator.Quad());
            RegisterLargeLevel(39, LargeMapGenerator.Drum());
            RegisterLargeLevel(40, LargeMapGenerator.Cherry());
            RegisterLargeLevel(41, LargeMapGenerator.WuTangClan());
        }

        private void RegisterLargeLevel(int number, int[,] map) {
            if (Large.Any(i => i.LevelNumber == number)) {
#if DEBUG
                throw new Exception("Level already exists for Large: " + number);
#else
                return;
#endif
            }

            Large.Add(CreateLevel(number, Difficulty.Large, map));
        }

        private Level CreateLevel(int number, Difficulty difficulty, int[,] map) {
            return new Level(number, difficulty, map);
        }

        private void TransformLevels() {
            TransformLevels(Small);
            TransformLevels(Medium);
            TransformLevels(Large);
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
                SavedUtc = DateTime.UtcNow,
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
                    return Large;
                default:
                    return new List<Level>();
            }
        }
    }
}
