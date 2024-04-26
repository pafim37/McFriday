import React from "react";
import EatPlaceChoose from "./components/EatPlaceChoose.tsx";
import FoodCatalog from "./components/FoodCatalog.tsx";

const App = () => {
  const [place, setPlace] = React.useState<string>("");

  return place === "" ? (
    <EatPlaceChoose setPlace={setPlace} />
  ) : (
    <FoodCatalog />
  );
};

export default App;
