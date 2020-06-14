import React from "react";
import { Card, CardBody } from "reactstrap";

const BoardTile = (props) => {
  return (
    <Card
      className={
        "mb-2 " +
        (props.highlight ? "bg-" + (props.highlightColor ?? "success") : "")
      }
    >
      <CardBody className="p-2">
        {props.label?.length > 0 && (
          <>
            <small className={props.highlight ? "" : "text-muted"}>
              {props.label}
            </small>
            <br />
          </>
        )}
        {props.children}
      </CardBody>
    </Card>
  );
};

export default BoardTile;
