import React from "react";
import axios from "axios";
import EatPlaceChoose from "./components/EatPlaceChoose.tsx";
import FoodCatalog from "./components/FoodCatalog.tsx";
import ProductType from "./types/ProductType.ts";
import { CartDataProvider } from "./context/CartDataProvider.tsx";

const App = () => {
  const [isPlace, setIsPlace] = React.useState<boolean>(false);
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

  return (
    <CartDataProvider>
      {!isPlace ? (
        <EatPlaceChoose setIsPlace={setIsPlace} />
      ) : (
        <FoodCatalog productTypes={productTypes} />
      )}
    </CartDataProvider>
  );
};

export default App;
