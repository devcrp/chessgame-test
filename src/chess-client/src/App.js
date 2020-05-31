import React, { useState, useEffect } from "react";
import "./App.css";
import Board from "./components/Board";
import { Button, Container, Row, Col } from "reactstrap";
import Api from "./constants/Api";

function App() {
  const [gameId, setGameId] = useState("");
  const [game, setGame] = useState({});

  const onInitGameHandler = () => {
    fetch(Api.baseUrl + "/api/game/start", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify({ player1: "Carlos", player2: "Marta" }),
    }).then(async (res) => {
      const data = await res.json();
      setGameId(data.result);
    });
  };

  const onPieceKilledHandler = (piece) => {
    if (piece.color === "white")
      game.whitesPlayer.pieces = [...game.whitesPlayer.pieces].filter(
        (p) => p.id !== piece.id
      );
    else
      game.blacksPlayer.pieces = [...game.blacksPlayer.pieces].filter(
        (p) => p.id !== piece.id
      );
  };

  const onUpdatePositionHandler = (piece, currentTurn) => {
    const newGame = { ...game };
    newGame.currentTurn = { ...currentTurn };
    if (piece.color === "white") {
      const index = newGame.whitesPlayer.pieces.findIndex(
        (p) => p.id === piece.id
      );
      newGame.whitesPlayer.pieces[index] = { ...piece };
    } else {
      const index = newGame.blacksPlayer.pieces.findIndex(
        (p) => p.id === piece.id
      );
      newGame.blacksPlayer.pieces[index] = { ...piece };
    }

    setGame(newGame);
  };

  useEffect(() => {
    if (!gameId) return;

    fetch(Api.baseUrl + "/api/game/" + gameId).then(async (res) => {
      const data = await res.json();
      setGame(data.result);
    });
  }, [gameId]);

  return (
    <Container className="p-3" fluid>
      <div className="mb-3">
        <Button color="success" onClick={onInitGameHandler}>
          Init game!
        </Button>
      </div>
      <div className="p-3">
        <Row>
          <Col md="auto">
            <Board
              gameId={game?.id}
              blackPieces={game?.blacksPlayer?.pieces}
              whitePieces={game?.whitesPlayer?.pieces}
              onPieceKilled={onPieceKilledHandler}
              onUpdatePosition={onUpdatePositionHandler}
            ></Board>
          </Col>
          <Col>
            {game.id && (
              <>
                <h5>Players</h5>
                <div className="pb-2">
                  <strong>Whites: </strong>
                  <span
                    className={
                      game.currentTurn.player.name === game.whitesPlayer.name
                        ? "text-success font-weight-bold"
                        : ""
                    }
                  >
                    {game.whitesPlayer.name}
                  </span>
                </div>
                <div>
                  <strong>Blacks: </strong>
                  <span
                    className={
                      game.currentTurn.player.name === game.blacksPlayer.name
                        ? "text-success font-weight-bold"
                        : ""
                    }
                  >
                    {game.blacksPlayer.name}
                  </span>
                </div>
              </>
            )}
          </Col>
        </Row>
      </div>
    </Container>
  );
}

export default App;
