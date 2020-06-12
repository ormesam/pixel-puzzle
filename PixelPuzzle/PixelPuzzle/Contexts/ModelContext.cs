using System.Collections.Generic;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Contexts {
    public class ModelContext {
        public IList<Level> GetLevels(Difficulty difficulty) {
            switch (difficulty) {
                case Difficulty.Easy:
                    return GetEasyLevels();
                case Difficulty.Medium:
                    return GetMediumLevels();
                case Difficulty.Hard:
                    return GetHardLevels();
                default:
                    return new List<Level>();
            }
        }

        private IList<Level> GetEasyLevels() {
            return new List<Level>(){
                new Level(1, Difficulty.Easy,  MapGenerator.Easy1()),
                new Level(2, Difficulty.Easy,  MapGenerator.Easy2()),
                new Level(3, Difficulty.Easy,  MapGenerator.Easy3()),
                new Level(4, Difficulty.Easy,  MapGenerator.Easy4()),
                new Level(5, Difficulty.Easy,  MapGenerator.Easy5()),
                new Level(6, Difficulty.Easy,  MapGenerator.Easy6()),
                new Level(7, Difficulty.Easy,  MapGenerator.Easy7()),
                new Level(8, Difficulty.Easy,  MapGenerator.Easy8()),
                new Level(9, Difficulty.Easy,  MapGenerator.Easy9()),
                new Level(10, Difficulty.Easy,  MapGenerator.Easy10()),
                new Level(11, Difficulty.Easy,  MapGenerator.Easy11()),
                new Level(12, Difficulty.Easy,  MapGenerator.Easy12()),
                new Level(13, Difficulty.Easy,  MapGenerator.Easy13()),
                new Level(14, Difficulty.Easy,  MapGenerator.Easy14()),
                new Level(15, Difficulty.Easy,  MapGenerator.Easy15()),
                new Level(16, Difficulty.Easy,  MapGenerator.Easy16()),
                new Level(17, Difficulty.Easy,  MapGenerator.Easy17()),
                new Level(18, Difficulty.Easy,  MapGenerator.Easy18()),
                new Level(19, Difficulty.Easy,  MapGenerator.Easy19()),
                new Level(20, Difficulty.Easy,  MapGenerator.Easy20()),
                new Level(21, Difficulty.Easy,  MapGenerator.Easy21()),
                new Level(22, Difficulty.Easy,  MapGenerator.Easy22()),
                new Level(23, Difficulty.Easy,  MapGenerator.Easy23()),
                new Level(24, Difficulty.Easy,  MapGenerator.Easy24()),
                new Level(25, Difficulty.Easy,  MapGenerator.Easy25()),
                new Level(26, Difficulty.Easy,  MapGenerator.Easy26()),
                new Level(27, Difficulty.Easy,  MapGenerator.Easy27()),
                new Level(28, Difficulty.Easy,  MapGenerator.Easy28()),
                new Level(29, Difficulty.Easy,  MapGenerator.Easy29()),
                new Level(30, Difficulty.Easy,  MapGenerator.Easy30()),
                new Level(31, Difficulty.Easy,  MapGenerator.Easy31()),
                new Level(32, Difficulty.Easy,  MapGenerator.Easy32()),
                new Level(33, Difficulty.Easy,  MapGenerator.Easy33()),
                new Level(34, Difficulty.Easy,  MapGenerator.Easy34()),
                new Level(35, Difficulty.Easy,  MapGenerator.Easy35()),
                new Level(36, Difficulty.Easy,  MapGenerator.Easy36()),
                new Level(37, Difficulty.Easy,  MapGenerator.Easy37()),
                new Level(38, Difficulty.Easy,  MapGenerator.Easy38()),
                new Level(39, Difficulty.Easy,  MapGenerator.Easy39()),
                new Level(40, Difficulty.Easy,  MapGenerator.Easy40()),
            };
        }

        private IList<Level> GetMediumLevels() {
            return new List<Level>(){
                new Level(1, Difficulty.Medium,  MapGenerator.Medium1()),
                new Level(2, Difficulty.Medium,  MapGenerator.Medium2()),
                new Level(3, Difficulty.Medium,  MapGenerator.Medium3()),
                new Level(4, Difficulty.Medium,  MapGenerator.Medium4()),
                new Level(5, Difficulty.Medium,  MapGenerator.Medium5()),
                new Level(6, Difficulty.Medium,  MapGenerator.Medium6()),
                new Level(7, Difficulty.Medium,  MapGenerator.Medium7()),
                new Level(8, Difficulty.Medium,  MapGenerator.Medium8()),
                new Level(9, Difficulty.Medium,  MapGenerator.Medium9()),
                new Level(10, Difficulty.Medium,  MapGenerator.Medium10()),
                new Level(11, Difficulty.Medium,  MapGenerator.Medium11()),
                new Level(12, Difficulty.Medium,  MapGenerator.Medium12()),
                new Level(13, Difficulty.Medium,  MapGenerator.Medium13()),
                new Level(14, Difficulty.Medium,  MapGenerator.Medium14()),
                new Level(15, Difficulty.Medium,  MapGenerator.Medium15()),
                new Level(16, Difficulty.Medium,  MapGenerator.Medium16()),
                new Level(17, Difficulty.Medium,  MapGenerator.Medium17()),
                new Level(18, Difficulty.Medium,  MapGenerator.Medium18()),
                new Level(19, Difficulty.Medium,  MapGenerator.Medium19()),
                new Level(20, Difficulty.Medium,  MapGenerator.Medium20()),
                new Level(21, Difficulty.Medium,  MapGenerator.Medium21()),
                new Level(22, Difficulty.Medium,  MapGenerator.Medium22()),
                new Level(23, Difficulty.Medium,  MapGenerator.Medium23()),
                new Level(24, Difficulty.Medium,  MapGenerator.Medium24()),
                new Level(25, Difficulty.Medium,  MapGenerator.Medium25()),
                new Level(26, Difficulty.Medium,  MapGenerator.Medium26()),
                new Level(27, Difficulty.Medium,  MapGenerator.Medium27()),
                new Level(28, Difficulty.Medium,  MapGenerator.Medium28()),
                new Level(29, Difficulty.Medium,  MapGenerator.Medium29()),
                new Level(30, Difficulty.Medium,  MapGenerator.Medium30()),
                new Level(31, Difficulty.Medium,  MapGenerator.Medium31()),
                new Level(32, Difficulty.Medium,  MapGenerator.Medium32()),
                new Level(33, Difficulty.Medium,  MapGenerator.Medium33()),
                new Level(34, Difficulty.Medium,  MapGenerator.Medium34()),
                new Level(35, Difficulty.Medium,  MapGenerator.Medium35()),
                new Level(36, Difficulty.Medium,  MapGenerator.Medium36()),
                new Level(37, Difficulty.Medium,  MapGenerator.Medium37()),
                new Level(38, Difficulty.Medium,  MapGenerator.Medium38()),
                new Level(39, Difficulty.Medium,  MapGenerator.Medium39()),
                new Level(40, Difficulty.Medium,  MapGenerator.Medium40()),
            };
        }

        private IList<Level> GetHardLevels() {
            return new List<Level>(){
                new Level(1, Difficulty.Hard,  MapGenerator.Hard1()),
                new Level(2, Difficulty.Hard,  MapGenerator.Hard2()),
                new Level(3, Difficulty.Hard,  MapGenerator.Hard3()),
                new Level(4, Difficulty.Hard,  MapGenerator.Hard4()),
                new Level(5, Difficulty.Hard,  MapGenerator.Hard5()),
                new Level(6, Difficulty.Hard,  MapGenerator.Hard6()),
                new Level(7, Difficulty.Hard,  MapGenerator.Hard7()),
                new Level(8, Difficulty.Hard,  MapGenerator.Hard8()),
                new Level(9, Difficulty.Hard,  MapGenerator.Hard9()),
                new Level(10, Difficulty.Hard,  MapGenerator.Hard10()),
                new Level(11, Difficulty.Hard,  MapGenerator.Hard11()),
                new Level(12, Difficulty.Hard,  MapGenerator.Hard12()),
                new Level(13, Difficulty.Hard,  MapGenerator.Hard13()),
                new Level(14, Difficulty.Hard,  MapGenerator.Hard14()),
                new Level(15, Difficulty.Hard,  MapGenerator.Hard15()),
                new Level(16, Difficulty.Hard,  MapGenerator.Hard16()),
                new Level(17, Difficulty.Hard,  MapGenerator.Hard17()),
                new Level(18, Difficulty.Hard,  MapGenerator.Hard18()),
                new Level(19, Difficulty.Hard,  MapGenerator.Hard19()),
                new Level(20, Difficulty.Hard,  MapGenerator.Hard20()),
                new Level(21, Difficulty.Hard,  MapGenerator.Hard21()),
                new Level(22, Difficulty.Hard,  MapGenerator.Hard22()),
                new Level(23, Difficulty.Hard,  MapGenerator.Hard23()),
                new Level(24, Difficulty.Hard,  MapGenerator.Hard24()),
                new Level(25, Difficulty.Hard,  MapGenerator.Hard25()),
                new Level(26, Difficulty.Hard,  MapGenerator.Hard26()),
                new Level(27, Difficulty.Hard,  MapGenerator.Hard27()),
                new Level(28, Difficulty.Hard,  MapGenerator.Hard28()),
                new Level(29, Difficulty.Hard,  MapGenerator.Hard29()),
                new Level(30, Difficulty.Hard,  MapGenerator.Hard30()),
                new Level(31, Difficulty.Hard,  MapGenerator.Hard31()),
                new Level(32, Difficulty.Hard,  MapGenerator.Hard32()),
                new Level(33, Difficulty.Hard,  MapGenerator.Hard33()),
                new Level(34, Difficulty.Hard,  MapGenerator.Hard34()),
                new Level(35, Difficulty.Hard,  MapGenerator.Hard35()),
                new Level(36, Difficulty.Hard,  MapGenerator.Hard36()),
                new Level(37, Difficulty.Hard,  MapGenerator.Hard37()),
                new Level(38, Difficulty.Hard,  MapGenerator.Hard38()),
                new Level(39, Difficulty.Hard,  MapGenerator.Hard39()),
                new Level(40, Difficulty.Hard,  MapGenerator.Hard40()),
            };
        }
    }
}
