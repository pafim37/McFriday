import React from "react";
import axios from "axios";
import EatPlaceChoose from "./components/EatPlaceChoose.tsx";
import FoodCatalog from "./components/FoodCatalog.tsx";
import ProductType from "./types/ProductType.ts";
import { CartDataProvider } from "./context/CartDataProvider.tsx";

const App = () => {
  const [place, setPlace] = React.useState<string>("");
  const [productTypes, setProductTypes] = React.useState<Array<ProductType>>(
    []
  );
  const baseUrl = "http://localhost:5226/";

  React.useEffect(() => {
    axios
      .get(baseUrl)
      .then((response) => {
        setProductTypes(response.data);
        console.log(response.data);
      })
      .catch((error) => console.log(error));
  }, []);

  return place === "" ? (
    <EatPlaceChoose setPlace={setPlace} />
  ) : (
    <CartDataProvider>
      <FoodCatalog productTypes={productTypes} />
    </CartDataProvider>
  );
};

export default App;
