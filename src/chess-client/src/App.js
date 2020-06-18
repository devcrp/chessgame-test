import React, { useEffect, useState } from "react";
import "./App.css";
import { Container } from "reactstrap";
import Api from "./constants/Api";
import ListPage from "./pages/ListPage";
import { Switch, Route, BrowserRouter } from "react-router-dom";
import BoardPage from "./pages/BoardPage";
import ChessUser from "./common/ChessUser";

function App() {
  const [isLoaded, setIsLoaded] = useState(false);

  useEffect(() => {
    if (!ChessUser.getId()) {
      fetch(Api.baseUrl + "/api/players/newid", {
        method: "POST",
        headers: {
          headers: {
            "Content-Type": "application/json",
          },
          method: "POST",
        },
      }).then(async (res) => {
        if (res.ok) {
          const newPlayerId = await res.json();
          ChessUser.setId(newPlayerId);
          setIsLoaded(true);
        }
      });
    } else {
      setIsLoaded(true);
    }
  }, []);

  if (!isLoaded)
    return (
      <Container>
        <div>Loading...</div>
      </Container>
    );

  return (
    <BrowserRouter>
      <Container className="py-4">
        <Switch></Switch>
        <Route path="/" component={ListPage} exact></Route>
        <Route path="/games/:gameId" component={BoardPage} exact></Route>
      </Container>
    </BrowserRouter>
  );
}

export default App;
