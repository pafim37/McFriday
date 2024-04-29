import React from "react";
import axios from "axios";
import EatPlaceChoose from "./components/EatPlaceChoose.tsx";
import MainPanel from "./components/MainPanel.tsx";
import ProductType from "./types/ProductType.ts";
import CartContext, { CartContextType } from "./context/CartDataProvider.tsx";

import OrderRestartContext, {
  OrderRestartContextType,
} from "./context/OrderRestartProvider.tsx";

const App = () => {
  const [productTypes, setProductTypes] = React.useState<Array<ProductType>>(
    []
  );

  const { restart, setRestart } = React.useContext(
    OrderRestartContext
  ) as OrderRestartContextType;

  const { cart, setCart } = React.useContext(CartContext) as CartContextType;

  React.useEffect(() => {
    if (!restart) {
      resetCart();
      fetchData();
    }
    setRestart(false);
  }, [restart]);

  const resetCart = () => {
    var newCart = { place: "", orders: [] };
    setCart(newCart);
  };

  const fetchData = () => {
    const baseUrl = "http://localhost:5226/";
    axios
      .get(baseUrl)
      .then((response) => {
        setProductTypes(response.data);
        console.log(response.data);
      })
      .catch((error) => console.log(error));
  };

  return (
    <>
      {cart.place === "" ? (
        <EatPlaceChoose />
      ) : (
        <MainPanel productTypes={productTypes} />
      )}
    </>
  );
};

export default App;
