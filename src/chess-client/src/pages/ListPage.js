import React, { useEffect, useState, useRef } from "react";
import { Button } from "reactstrap";
import Api from "../constants/Api";
import GamesGrid from "../components/GamesGrid";
import PlayerNameModal from "../components/PlayerNameModal";
import { useHistory } from "react-router-dom";
import ChessUser from "../common/ChessUser";

const ListPage = (props) => {
  const [list, setList] = useState([]);
  const [modalOptions, setModalOptions] = useState({ open: false });
  const inputRef = useRef();
  const history = useHistory();

  const refreshList = () => {
    fetch(Api.baseUrl + "/api/games").then(async (res) => {
      const data = await res.json();
      setList(data);
    });
  };

  useEffect(() => {
    refreshList();
  }, []);

  const openNewGameModalHandler = () => {
    setModalOptions({
      open: true,
      actionType: "prepare",
      buttonText: "Create",
      buttonColor: "success",
    });
  };

  const onJoinHandler = (gameId) => {
    setModalOptions({
      open: true,
      actionType: gameId,
      buttonText: "Join",
      buttonColor: "success",
    });
  };

  const setOpenModal = (value) => {
    setModalOptions((state) => {
      return { ...modalOptions, open: value };
    });
  };

  const onAcceptModalHandler = (playerName, actionType) => {
    if (playerName.length === 0) return;

    ChessUser.setName(playerName);

    setOpenModal(false);

    if (actionType === "prepare") {
      fetch(Api.baseUrl + "/api/games/prepare", {
        headers: {
          "Content-Type": "application/json",
        },
        method: "POST",
      }).then(async (res) => {
        const gameId = await res.json();
        fetch(Api.baseUrl + `/api/games/${gameId}/addplayer`, {
          headers: {
            "Content-Type": "application/json",
          },
          method: "POST",
          body: JSON.stringify(playerName),
        }).then(async (res) => {
          if (res.ok) {
            const playerId = await res.json();
            ChessUser.setId(gameId, playerId);
            history.push(`/games/${gameId}`);
          }
        });
      });
    } else {
      // join
      const gameId = actionType;
      fetch(Api.baseUrl + `/api/games/${gameId}/addplayer`, {
        headers: {
          "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify(playerName),
      }).then(async (res) => {
        if (res.ok) {
          const playerId = await res.json();
          ChessUser.setId(gameId, playerId);
          history.push(`/games/${gameId}`);
        }
      });
    }
  };

  return (
    <>
      <div>
        <div className="d-flex justify-content-between align-items-center">
          <h2>🕹 All games</h2>
          <Button outline color="success" onClick={openNewGameModalHandler}>
            New Game
          </Button>
        </div>
        {list.length === 0 && (
          <div className="py-5 text-center lead">
            There're no games at this moment.
          </div>
        )}

        <div className="mt-4">
          {list.length > 0 && (
            <GamesGrid list={list} onJoin={onJoinHandler}></GamesGrid>
          )}
        </div>
      </div>
      <PlayerNameModal
        modalOptions={modalOptions}
        onToggle={() => {
          setOpenModal(!modalOptions.open);
        }}
        onAccept={onAcceptModalHandler}
        inputRef={inputRef}
      ></PlayerNameModal>
    </>
  );
};

export default ListPage;
