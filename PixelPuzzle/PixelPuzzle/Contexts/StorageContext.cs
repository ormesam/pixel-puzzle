using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using PixelPuzzle.Logic;

namespace PixelPuzzle.Contexts {
    public class StorageContext {
        public readonly IBlobCache Storage = BlobCache.LocalMachine;

        public IDictionary<string, SavedGame> GetSavedGames() {
            var savedGames = Storage.GetAllObjects<SavedGame>().Wait();

            return savedGames.ToDictionary(i => i.Key);
        }

        public async Task SaveGame(SavedGame game) {
            await SaveObject(game.Key, game);
        }

        private async Task SaveObject<T>(string id, T obj) {
            await Storage.InsertObject(id, obj);
        }

        private async Task RemoveObject<T>(string id) {
            await Storage.InvalidateObject<T>(id);
        }
    }
}
