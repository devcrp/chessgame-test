import React, { useState, useEffect, useRef } from "react";
import "./App.css";
import Board from "./components/Board";
import { Button, Container, Row, Col, Input } from "reactstrap";
import Api from "./constants/Api";
import { HubConnectionBuilder } from "@microsoft/signalr";
import ListPage from "./pages/ListPage";
import { Switch, Route, BrowserRouter } from "react-router-dom";
import BoardPage from "./pages/BoardPage";

function App() {
  const [gameId, setGameId] = useState("");
  const [joinGameId, setJoinGameId] = useState("");
  const [playerName, setPlayerName] = useState("Player 1");
  const [game, setGame] = useState({});

  const connectionRef = useRef();
  useEffect(() => {
    connectionRef.current = new HubConnectionBuilder()
      .withUrl("https://localhost:44386/gamehub")
      .build();

    connectionRef.current.on("RefreshGame", function () {
      if (gameId) refreshBoard(gameId);
    });

    connectionRef.current
      .start()
      .then(function () {})
      .catch(function (err) {
        alert(err);
      });
  }, [gameId]);

  const onStartGameHandler = () => {
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

  const onPrepareGameHandler = () => {
    fetch(Api.baseUrl + "/api/game/prepare", {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
    }).then(async (res) => {
      const data = await res.json();

      fetch(Api.baseUrl + `/api/game/${data}/addplayer`, {
        headers: {
          "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify(playerName),
      }).then(async (res) => {
        if (res.ok) {
          setGameId(data);
        }
      });
    });
  };

  const onJoinGameHandler = () => {
    fetch(Api.baseUrl + `/api/game/${joinGameId}/addplayer`, {
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
      body: JSON.stringify(playerName),
    }).then(async (res) => {
      if (res.ok) {
        setGameId(joinGameId);
      }
    });
  };

  const refreshBoard = (gId) => {
    fetch(Api.baseUrl + "/api/game/" + gId).then(async (res) => {
      const data = await res.json();
      setGame(data);
    });
  };

  const onActionPerformedHandler = () => {
    connectionRef.current.invoke("RefreshGame").catch(function (err) {
      alert(err);
    });
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
    <BrowserRouter>
      <Container className="py-4">
        <Switch></Switch>
        <Route path="/" component={ListPage} exact></Route>
        <Route path="/games/:gameId" component={BoardPage} exact></Route>
      </Container>
    </BrowserRouter>
  );

  return (
    <Container className="p-3" fluid>
      <div className="mb-3">
        <div className="d-flex align-items-center justify-content-start mb-1">
          <Button color="danger" onClick={() => refreshBoard(gameId)}>
            Refresh
          </Button>
        </div>
        <div className="d-flex align-items-center justify-content-start mb-1">
          <Button color="success" onClick={onStartGameHandler}>
            Set up local game
          </Button>
        </div>
        <div className="d-flex align-items-center justify-content-start mb-1">
          <Button color="primary" onClick={onPrepareGameHandler}>
            Create new game
          </Button>
          &nbsp;
          <Input
            className="w-25"
            placeholder="Type here your name"
            onChange={(e) => setPlayerName(e.target.value)}
            value={playerName}
          ></Input>
        </div>
        <div className="d-flex align-items-center justify-content-start mb-1">
          <Button color="warning" onClick={onJoinGameHandler}>
            Join game
          </Button>
          &nbsp;
          <Input
            className="w-25"
            placeholder="Game ID"
            onChange={(e) => setJoinGameId(e.target.value)}
            value={joinGameId}
          ></Input>
        </div>
      </div>
      <div className="p-3">
        <Row>
          <Col md="auto">
            <span>{gameId}</span>
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
                      game.currentTurnPlayer !== null &&
                      game.blacksPlayer !== null &&
                      game.currentTurnPlayer.name === game.blacksPlayer.name
                        ? "text-success font-weight-bold"
                        : ""
                    }
                  >
                    {game.blacksPlayer !== null
                      ? game.blacksPlayer.name
                      : "PENDING"}
                  </span>
                </div>
                <div>
                  <strong>Whites: </strong>
                  <span
                    className={
                      game.currentTurnPlayer !== null &&
                      game.whitesPlayer !== null &&
                      game.currentTurnPlayer.name === game.whitesPlayer.name
                        ? "text-success font-weight-bold"
                        : ""
                    }
                  >
                    {game.whitesPlayer !== null
                      ? game.whitesPlayer.name
                      : "PENDING"}
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
