import React from "react";
import { Card, CardBody, Input } from "reactstrap";

const ChatPanel = (props) => {
  return (
    <>
      <div>
        <small>CHAT</small>
      </div>
      <Card className="mb-1 rounded-0">
        <CardBody className="p-2">
          <div className="d-flex justify-content-end">
            <small className="text-muted">User 1</small>
          </div>
          <div className="d-flex justify-content-end">
            <span style={{ fontSize: "0.95em" }}>Hola</span>
          </div>

          <div>
            <small className="text-muted">User 1</small>
          </div>
          <div>
            <span style={{ fontSize: "0.95em" }}>Hola</span>
          </div>
        </CardBody>
      </Card>
      <div>
        <Input
          className="rounded-0 p-1"
          placeholder="Type here..."
          style={{ fontSize: "0.8em" }}
        ></Input>
      </div>
    </>
  );
};

export default ChatPanel;
