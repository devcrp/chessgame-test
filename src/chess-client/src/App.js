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
      setGameId(data);
    });
  };

  const refreshBoard = (gId) => {
    fetch(Api.baseUrl + "/api/game/" + gId).then(async (res) => {
      const data = await res.json();
      setGame(data);
    });
  };

  const onActionPerformedHandler = () => {
    refreshBoard(gameId);
  };

  useEffect(() => {
    if (game && game.isOver) {
      setTimeout(() => {
        alert(`${game.winner.name} wins!`);
      }, 1);
    }
  }, [game]);

  useEffect(() => {
    if (!gameId) return;
    refreshBoard(gameId);
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
              board={game?.board}
              onActionPerformed={onActionPerformedHandler}
            ></Board>
          </Col>
          <Col>
            {game.id && (
              <>
                <h5>Players</h5>
                <div className="pb-2">
                  <strong>Blacks: </strong>
                  <span
                    className={
                      game.currentTurnPlayer.name === game.blacksPlayer.name
                        ? "text-success font-weight-bold"
                        : ""
                    }
                  >
                    {game.blacksPlayer.name}
                  </span>
                </div>
                <div>
                  <strong>Whites: </strong>
                  <span
                    className={
                      game.currentTurnPlayer.name === game.whitesPlayer.name
                        ? "text-success font-weight-bold"
                        : ""
                    }
                  >
                    {game.whitesPlayer.name}
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
