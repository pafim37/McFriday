import React from "react";
import axios from "axios";
import EatPlaceChoose from "./components/EatPlaceChoose.tsx";
import MainPanel from "./components/MainPanel.tsx";
import ProductType from "./types/ProductType.ts";
import CartContext, { CartDataProvider } from "./context/CartDataProvider.tsx";

import OrderRestartContext, {
  OrderRestartContextType,
} from "./context/OrderRestartProvider.tsx";

const App = () => {
  const [isPlace, setIsPlace] = React.useState<boolean>(false);
  const [productTypes, setProductTypes] = React.useState<Array<ProductType>>(
    []
  );

  const { restart, setRestart } = React.useContext(
    OrderRestartContext
  ) as OrderRestartContextType;

  const orderData = React.useContext(CartContext);

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

  React.useEffect(() => {
    console.log("Działa");
  }, [restart]);

  return (
    <CartDataProvider>
      {!isPlace ? (
        <EatPlaceChoose setIsPlace={setIsPlace} />
      ) : (
        <MainPanel productTypes={productTypes} />
      )}
    </CartDataProvider>
  );
};

export default App;
