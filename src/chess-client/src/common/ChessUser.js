const ChessUser = {
  get: (gameId) => {
    const localInfo = localStorage.getItem("chess-game-" + gameId);
    if (!localInfo) return null;

    return localInfo;
  },

  set: (gameId, playerId) => {
    localStorage.setItem("chess-game-" + gameId, playerId);
  },
};

export default ChessUser;
