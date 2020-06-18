import React, { useEffect, useState, useRef } from "react";
import { useParams } from "react-router-dom";
import Api from "../constants/Api";
import Board from "../components/Board";
import { Container, Row, Col } from "reactstrap";
import BoardTile from "../components/BoardTile";
import { HubConnectionBuilder } from "@microsoft/signalr";
import ChessUser from "../common/ChessUser";

const BoardPage = (props) => {
  let { gameId } = useParams();
  const [game, setGame] = useState(null);
  const [message, setMessage] = useState("");
  const playerId = ChessUser.getId();
  const connectionRef = useRef();

  const refreshGame = (gId) => {
    fetch(Api.baseUrl + "/api/games/" + gId).then(async (res) => {
      const data = await res.json();
      setGame(data);
    });
  };

  const onErrorHandler = (msg) => {
    setMessage(msg);
  };

  useEffect(() => {
    connectionRef.current = new HubConnectionBuilder()
      .withUrl(Api.baseUrl + "/gamehub")
      .build();

    connectionRef.current.on("RefreshGame", function () {
      if (gameId) refreshGame(gameId);
    });

    connectionRef.current
      .start()
      .then(function () {})
      .catch(function (err) {
        alert(err);
      });

    refreshGame(gameId);
  }, [gameId]);

  const isCurrentTurn = (playerId) => {
    return game?.currentTurnPlayer?.id === playerId;
  };

  const getCurrentUserName = () => {
    if (!game) return "";

    if (game.whitesPlayer.id === playerId) return game.whitesPlayer.name;
    else if (game.blacksPlayer?.id === playerId) return game.blacksPlayer.name;
    else return "-";
  };

  const getCurrentUserColor = () => {
    if (!game) return "";
    if (game.whitesPlayer.id === playerId) return "whites";
    else if (game.blacksPlayer?.id === playerId) return "blacks";
    else return "";
  };

  return (
    <>
      <Container fluid>
        <Row>
          <Col md="2" className="px-1">
            <BoardTile label="ID">
              <span className="text-success">{game?.externalIdentifier}</span>
            </BoardTile>
            <BoardTile label={getCurrentUserColor().toUpperCase() + " PLAYER"}>
              <span className="text-info">{getCurrentUserName()}</span>{" "}
            </BoardTile>
            <hr />
            <BoardTile
              label="WHITES"
              highlight={isCurrentTurn(game?.whitesPlayer?.id)}
            >
              {game?.whitesPlayer?.name}
            </BoardTile>
            {game?.blacksPlayer !== null && (
              <BoardTile
                label="BLACKS"
                highlight={isCurrentTurn(game?.blacksPlayer?.id)}
              >
                {game?.blacksPlayer?.name}
              </BoardTile>
            )}

            {game?.blacksPlayer === null && (
              <BoardTile label="" highlight={true} highlightColor="danger">
                Waiting for oponent
              </BoardTile>
            )}

            {message.length > 0 && (
              <BoardTile label="" highlight={true} highlightColor="warning">
                {message}
              </BoardTile>
            )}
            {/* <div>
              <ChatPanel></ChatPanel>
            </div> */}
          </Col>
          <Col md="10" className="overflow-auto px-1">
            <Board
              gameId={game?.id}
              board={game?.board}
              onActionPerformed={() => {}}
              onError={onErrorHandler}
            ></Board>
          </Col>
        </Row>
      </Container>
    </>
  );
};

export default BoardPage;
