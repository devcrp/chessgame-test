import React, { useState, useEffect } from "react";
import {
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Button,
  Input,
} from "reactstrap";
import ChessUser from "../common/ChessUser";

const PlayerNameModal = (props) => {
  const { modalOptions, onToggle, onAccept, inputRef } = props;
  const [playerName, setPlayerName] = useState("");

  useEffect(() => {
    const name = ChessUser.getName();
    if (name) {
      setPlayerName(name);
    }
  }, []);

  return (
    <Modal isOpen={modalOptions.open} toggle={onToggle}>
      <ModalHeader toggle={onToggle}>Enter your name</ModalHeader>
      <ModalBody>
        <Input
          ref={inputRef}
          placeholder="Name"
          value={playerName}
          onChange={(e) => setPlayerName(e.target.value)}
        ></Input>
      </ModalBody>
      <ModalFooter>
        <Button
          color={modalOptions.buttonColor}
          onClick={onAccept.bind(this, playerName, modalOptions.actionType)}
        >
          {modalOptions.buttonText}
        </Button>{" "}
        <Button color="secondary" onClick={onToggle}>
          Cancel
        </Button>
      </ModalFooter>
    </Modal>
  );
};

export default PlayerNameModal;
