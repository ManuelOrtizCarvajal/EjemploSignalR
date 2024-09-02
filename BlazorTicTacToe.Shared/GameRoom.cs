using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTicTacToe.Shared
{
    public class GameRoom
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public List<Player> Players { get; set; } = new();
        public TicTacToeGame Game { get; set; } = new();

        public GameRoom(string roomId, string roomName)
        {
            RoomId = roomId;
            RoomName = roomName;
        }

        public bool TryAddPlayer(Player newPlayer)
        {
            if (Players.Count < 2 && !Players.Any(x => x.ConnectionId == newPlayer.ConnectionId))
            {
                Players.Add(newPlayer);
                switch (Players.Count)
                {
                    case 1:
                        Game.PlayerXId = newPlayer.ConnectionId;
                        break;
                    case 2:
                        Game.PlayerOId = newPlayer.ConnectionId;
                        break;

                    default:
                        break;
                }
                return true;
            }
            return false;
        }
    }
}
