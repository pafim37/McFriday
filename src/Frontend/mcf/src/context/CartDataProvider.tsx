import React from "react";
import CartType from "../types/CartType.ts";

const initialData: CartType = {
  order: [],
};

const CartContext = React.createContext<CartType>(initialData);

export const CartDataProvider = ({ children }) => {
  var data = initialData;

  return <CartContext.Provider value={data}>{children}</CartContext.Provider>;
};

export default CartContext;
