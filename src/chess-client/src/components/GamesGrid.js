import React from "react";
import { Card, CardBody, Button, Badge, CardHeader } from "reactstrap";
import { Link } from "react-router-dom";

const GamesGrid = (props) => {
  const { list, onJoin } = props;

  return (
    <div>
      {list.map((item) => (
        <Card key={item.id} className="mb-3">
          <CardHeader
            className={
              (item.isOver ? "" : "bg-success") +
              " d-flex justify-content-between align-items-center"
            }
          >
            <span className="font-weight-bold">
              Game {item.externalIdentifier}
              {item.isOver && (
                <Badge className="ml-3" color="danger">
                  GAME OVER
                </Badge>
              )}
            </span>
            <small>started at {item.startedTimeUtc}</small>
          </CardHeader>
          <CardBody>
            <div>
              <div className="d-flex justify-content-between align-items-center">
                {item.blacksPlayer === null && (
                  <Button
                    color="danger"
                    size="sm"
                    onClick={onJoin.bind(this, item.id)}
                  >
                    Join as oponent
                  </Button>
                )}
                <Link to={`/games/${item.id}`}>
                  <Button outline color="warning" size="sm">
                    Join as viewer
                  </Button>
                </Link>
              </div>
              <hr />
              <div>
                {item.whitesPlayer?.name}
                <Badge color="info" className="ml-2">
                  whites
                </Badge>
              </div>
              {item.blacksPlayer !== null && (
                <div>
                  {item.blacksPlayer.name}
                  <Badge color="secondary" className="ml-2">
                    blacks
                  </Badge>
                </div>
              )}
            </div>
          </CardBody>
        </Card>
      ))}
    </div>
  );
};

export default GamesGrid;
