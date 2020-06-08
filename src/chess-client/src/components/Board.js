import React, { useState } from "react";
import { Row, Col } from "reactstrap";
import Api from "../constants/Api";

const Board = (props) => {
  const [selectedCell, setSelectedCell] = useState("");

  const [positionsInv, positions] = initArrays();

  const { blackPieces, whitePieces, gameId } = props;

  const getPiece = (position) => {
    let foundPiece = blackPieces.find(
      (piece) => piece.position.key === position
    );
    if (!foundPiece)
      foundPiece = whitePieces.find((piece) => piece.position.key === position);

    return foundPiece;
  };

  const renderPiece = (position) => {
    if (!blackPieces || !whitePieces) return null;

    const foundPiece = getPiece(position);

    if (!foundPiece) return null;

    return (
      <img
        className="piece-img"
        alt={foundPiece.type}
        src={`/chess-pieces/${foundPiece.type}-${foundPiece.color}.svg`}
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
    if (selectedCell === positionKey) setSelectedCell("");
    else if (selectedCell === "") {
      setSelectedCell(positionKey);
    } else {
      const pieceAtDestination = getPiece(positionKey);

      fetch(Api.baseUrl + `/api/game/${gameId}/move`, {
        headers: {
          "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify({
          origin: selectedCell,
          destination: positionKey,
        }),
      }).then(async (res) => {
        if (res.ok) {
          const data = await res.json();
          console.log(data);
          if (pieceAtDestination) {
            props.onPieceKilled(pieceAtDestination);
          }
          props.onUpdatePosition(data.result.piece, data.result.currentTurn);
          setSelectedCell("");
        } else {
          const errMessage = await res.text();
          if (errMessage) {
            alert(errMessage);
            setSelectedCell("");
          }
        }
      });
    }
  };

  return (
    <div className="board">
      {positionsInv.map((p1, idx1) => (
        <Row key={idx1}>{renderCell(positions, p1)}</Row>
      ))}
    </div>
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
