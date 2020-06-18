import React, { useState } from "react";
import { Row, Col, Container } from "reactstrap";
import Api from "../constants/Api";
import ChessUser from "../common/ChessUser";

const GAME_OVER_TYPE = 2;

const Board = (props) => {
  const [selectedCell, setSelectedCell] = useState("");
  const [isGameOver, setIsGameOver] = useState(false);

  const [positionsInv, positions] = initArrays();

  const { board, gameId } = props;

  const getPieceName = (enumId) => {
    switch (enumId) {
      case 0:
        return "pawn";
      case 1:
        return "rook";
      case 2:
        return "knight";
      case 3:
        return "bishop";
      case 4:
        return "queen";
      case 5:
        return "king";
      default:
        return null;
    }
  };

  const getPiece = (position) => {
    let foundSquare = board.squares.find(
      (square) => square.position.id === position
    );

    if (!foundSquare) return null;

    return foundSquare.piece;
  };

  const renderPiece = (position) => {
    if (!board || !board.squares) return null;

    const foundPiece = getPiece(position);

    if (!foundPiece) return null;

    return (
      <img
        className="piece-img"
        alt={foundPiece.type}
        src={`/chess-pieces/${getPieceName(foundPiece.type)}-${
          foundPiece.color === 0 ? "white" : "black"
        }.svg`}
      ></img>
    );
  };

  const renderCell = (positions, p1) => {
    const getKey = (p2) => cols[p2 - 1].toString() + p1.toString();

    return (
      <>
        {positions.map((p2) => (
          <Col
            key={getKey(p2)}
            className={
              "square " + (selectedCell === getKey(p2) ? "selected" : "")
            }
            onClick={onClickCellHandler.bind(this, getKey(p2))}
          >
            {renderPiece(getKey(p2))}
            <div
              className="position-absolute"
              style={{ left: "1px", bottom: "1px" }}
            >
              {getKey(p2)}
            </div>
          </Col>
        ))}
      </>
    );
  };

  const onClickCellHandler = (positionKey) => {
    if (isGameOver) return;

    if (selectedCell === positionKey) setSelectedCell("");
    else if (selectedCell === "") {
      setSelectedCell(positionKey);
    } else {
      fetch(Api.baseUrl + `/api/games/${gameId}/move`, {
        headers: {
          "Content-Type": "application/json",
          PlayerId: ChessUser.getId(),
        },
        method: "POST",
        body: JSON.stringify({
          origin: selectedCell,
          destination: positionKey,
        }),
      }).then(async (res) => {
        if (res.ok) {
          const data = await res.json();
          const isOver =
            data.turnEvents[data.turnEvents.length - 1].eventType ===
            GAME_OVER_TYPE;
          props.onError("");
          props.onActionPerformed();
          setIsGameOver(isOver);
          setSelectedCell("");
        } else {
          const errMessage = await res.text();
          if (errMessage) {
            props.onError(errMessage);
            setSelectedCell("");
          }
        }
      });
    }
  };

  return (
    <>
      <Container fluid className="board">
        {positionsInv.map((p1, idx1) => (
          <Row key={idx1}>{renderCell(positions, p1)}</Row>
        ))}
      </Container>
    </>
  );
};

const initArrays = () => {
  const positionsInv = [];
  const positions = [];
  for (let i = 8; i >= 1; i--) positionsInv.push(i);
  for (let i = 1; i <= 8; i++) positions.push(i);

  return [positionsInv, positions];
};

const cols = ["A", "B", "C", "D", "E", "F", "G", "H"];

export default Board;
