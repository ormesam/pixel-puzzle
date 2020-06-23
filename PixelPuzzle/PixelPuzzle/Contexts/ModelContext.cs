using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Contexts {
    public class ModelContext {
        private StorageContext storageContext;
        private IDictionary<string, SavedGame> savedLevels;

        public IList<Level> Easy { get; }
        public IList<Level> Medium { get; }
        public IList<Level> Hard { get; }

        public ModelContext() {
            storageContext = new StorageContext();

            savedLevels = storageContext.GetSavedGames();

            Easy = GetEasyLevels();
            Medium = GetMediumLevels();
            Hard = GetHardLevels();

            TransformLevels();
        }

        private void TransformLevels() {
            TransformLevels(Easy);
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
                    return Easy;
                case Difficulty.Medium:
                    return Medium;
                case Difficulty.Large:
                    return Hard;
                default:
                    return new List<Level>();
            }
        }

        private IList<Level> GetEasyLevels() {
            return new List<Level>(){
                new Level(1, Difficulty.Small,  MapGenerator.SmallBoat()),
                new Level(2, Difficulty.Small,  MapGenerator.SmallPattern()),
                //new Level(3, Difficulty.Easy,  MapGenerator.Easy3()),
                //new Level(4, Difficulty.Easy,  MapGenerator.Easy4()),
                //new Level(5, Difficulty.Easy,  MapGenerator.Easy5()),
                //new Level(6, Difficulty.Easy,  MapGenerator.Easy6()),
                //new Level(7, Difficulty.Easy,  MapGenerator.Easy7()),
                //new Level(8, Difficulty.Easy,  MapGenerator.Easy8()),
                //new Level(9, Difficulty.Easy,  MapGenerator.Easy9()),
                //new Level(10, Difficulty.Easy,  MapGenerator.Easy10()),
                //new Level(11, Difficulty.Easy,  MapGenerator.Easy11()),
                //new Level(12, Difficulty.Easy,  MapGenerator.Easy12()),
                //new Level(13, Difficulty.Easy,  MapGenerator.Easy13()),
                //new Level(14, Difficulty.Easy,  MapGenerator.Easy14()),
                //new Level(15, Difficulty.Easy,  MapGenerator.Easy15()),
                //new Level(16, Difficulty.Easy,  MapGenerator.Easy16()),
                //new Level(17, Difficulty.Easy,  MapGenerator.Easy17()),
                //new Level(18, Difficulty.Easy,  MapGenerator.Easy18()),
                //new Level(19, Difficulty.Easy,  MapGenerator.Easy19()),
                //new Level(20, Difficulty.Easy,  MapGenerator.Easy20()),
                //new Level(21, Difficulty.Easy,  MapGenerator.Easy21()),
                //new Level(22, Difficulty.Easy,  MapGenerator.Easy22()),
                //new Level(23, Difficulty.Easy,  MapGenerator.Easy23()),
                //new Level(24, Difficulty.Easy,  MapGenerator.Easy24()),
                //new Level(25, Difficulty.Easy,  MapGenerator.Easy25()),
                //new Level(26, Difficulty.Easy,  MapGenerator.Easy26()),
                //new Level(27, Difficulty.Easy,  MapGenerator.Easy27()),
                //new Level(28, Difficulty.Easy,  MapGenerator.Easy28()),
                //new Level(29, Difficulty.Easy,  MapGenerator.Easy29()),
                //new Level(30, Difficulty.Easy,  MapGenerator.Easy30()),
                //new Level(31, Difficulty.Easy,  MapGenerator.Easy31()),
                //new Level(32, Difficulty.Easy,  MapGenerator.Easy32()),
                //new Level(33, Difficulty.Easy,  MapGenerator.Easy33()),
                //new Level(34, Difficulty.Easy,  MapGenerator.Easy34()),
                //new Level(35, Difficulty.Easy,  MapGenerator.Easy35()),
                //new Level(36, Difficulty.Easy,  MapGenerator.Easy36()),
                //new Level(37, Difficulty.Easy,  MapGenerator.Easy37()),
                //new Level(38, Difficulty.Easy,  MapGenerator.Easy38()),
                //new Level(39, Difficulty.Easy,  MapGenerator.Easy39()),
                //new Level(40, Difficulty.Easy,  MapGenerator.Easy40()),
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
                //new Level(7, Difficulty.Medium,  MapGenerator.Medium7()),
                //new Level(8, Difficulty.Medium,  MapGenerator.Medium8()),
                //new Level(9, Difficulty.Medium,  MapGenerator.Medium9()),
                //new Level(10, Difficulty.Medium,  MapGenerator.Medium10()),
                //new Level(11, Difficulty.Medium,  MapGenerator.Medium11()),
                //new Level(12, Difficulty.Medium,  MapGenerator.Medium12()),
                //new Level(13, Difficulty.Medium,  MapGenerator.Medium13()),
                //new Level(14, Difficulty.Medium,  MapGenerator.Medium14()),
                //new Level(15, Difficulty.Medium,  MapGenerator.Medium15()),
                //new Level(16, Difficulty.Medium,  MapGenerator.Medium16()),
                //new Level(17, Difficulty.Medium,  MapGenerator.Medium17()),
                //new Level(18, Difficulty.Medium,  MapGenerator.Medium18()),
                //new Level(19, Difficulty.Medium,  MapGenerator.Medium19()),
                //new Level(20, Difficulty.Medium,  MapGenerator.Medium20()),
                //new Level(21, Difficulty.Medium,  MapGenerator.Medium21()),
                //new Level(22, Difficulty.Medium,  MapGenerator.Medium22()),
                //new Level(23, Difficulty.Medium,  MapGenerator.Medium23()),
                //new Level(24, Difficulty.Medium,  MapGenerator.Medium24()),
                //new Level(25, Difficulty.Medium,  MapGenerator.Medium25()),
                //new Level(26, Difficulty.Medium,  MapGenerator.Medium26()),
                //new Level(27, Difficulty.Medium,  MapGenerator.Medium27()),
                //new Level(28, Difficulty.Medium,  MapGenerator.Medium28()),
                //new Level(29, Difficulty.Medium,  MapGenerator.Medium29()),
                //new Level(30, Difficulty.Medium,  MapGenerator.Medium30()),
                //new Level(31, Difficulty.Medium,  MapGenerator.Medium31()),
                //new Level(32, Difficulty.Medium,  MapGenerator.Medium32()),
                //new Level(33, Difficulty.Medium,  MapGenerator.Medium33()),
                //new Level(34, Difficulty.Medium,  MapGenerator.Medium34()),
                //new Level(35, Difficulty.Medium,  MapGenerator.Medium35()),
                //new Level(36, Difficulty.Medium,  MapGenerator.Medium36()),
                //new Level(37, Difficulty.Medium,  MapGenerator.Medium37()),
                //new Level(38, Difficulty.Medium,  MapGenerator.Medium38()),
                //new Level(39, Difficulty.Medium,  MapGenerator.Medium39()),
                //new Level(40, Difficulty.Medium,  MapGenerator.Medium40()),
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
                new Level(12, Difficulty.Large,  MapGenerator.Large12()),
                new Level(13, Difficulty.Large,  MapGenerator.LargeCat()),
                new Level(14, Difficulty.Large,  MapGenerator.LargePlane()),
                new Level(15, Difficulty.Large,  MapGenerator.LargeMicrophone()),
                //new Level(16, Difficulty.Large,  MapGenerator.Large16()),
                new Level(17, Difficulty.Large,  MapGenerator.LargeTruck()),
                //new Level(18, Difficulty.Large,  MapGenerator.Large18()),
                new Level(19, Difficulty.Large,  MapGenerator.LargeShip()),
                //new Level(20, Difficulty.Hard,  MapGenerator.Hard20()),
                //new Level(21, Difficulty.Hard,  MapGenerator.Hard21()),
                //new Level(22, Difficulty.Hard,  MapGenerator.Hard22()),
                //new Level(23, Difficulty.Hard,  MapGenerator.Hard23()),
                //new Level(24, Difficulty.Hard,  MapGenerator.Hard24()),
                //new Level(25, Difficulty.Hard,  MapGenerator.Hard25()),
                //new Level(26, Difficulty.Hard,  MapGenerator.Hard26()),
                //new Level(27, Difficulty.Hard,  MapGenerator.Hard27()),
                //new Level(28, Difficulty.Hard,  MapGenerator.Hard28()),
                //new Level(29, Difficulty.Hard,  MapGenerator.Hard29()),
                //new Level(30, Difficulty.Hard,  MapGenerator.Hard30()),
                //new Level(31, Difficulty.Hard,  MapGenerator.Hard31()),
                //new Level(32, Difficulty.Hard,  MapGenerator.Hard32()),
                //new Level(33, Difficulty.Hard,  MapGenerator.Hard33()),
                //new Level(34, Difficulty.Hard,  MapGenerator.Hard34()),
                //new Level(35, Difficulty.Hard,  MapGenerator.Hard35()),
                //new Level(36, Difficulty.Hard,  MapGenerator.Hard36()),
                //new Level(37, Difficulty.Hard,  MapGenerator.Hard37()),
                //new Level(38, Difficulty.Hard,  MapGenerator.Hard38()),
                //new Level(39, Difficulty.Hard,  MapGenerator.Hard39()),
                //new Level(40, Difficulty.Hard,  MapGenerator.Hard40()),
            };
        }
    }
}
