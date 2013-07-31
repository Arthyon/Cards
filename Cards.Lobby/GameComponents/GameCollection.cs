using System;
using System.Collections.ObjectModel;
using System.Linq;
using Cards.Lobby.Components;

namespace Cards.Lobby.GameComponents
{
    internal class GameCollection : Collection<Game>
    {
        public Game StartNewGame(Game game)
        {
            Add(game);

            return game;
        }

        public Maybe<Game> GetGame(Guid id)
        {
            return new Maybe<Game>(this.FirstOrDefault(game => game.GameId == id));
        }
    }
}
