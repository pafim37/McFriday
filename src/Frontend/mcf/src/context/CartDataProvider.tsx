import React from "react";
import CartType from "../types/CartType.ts";

export interface CartContextType {
  cart: CartType;
  setCart: React.Dispatch<React.SetStateAction<CartType>>;
}

const CartContext = React.createContext<CartContextType | undefined>(undefined);

export const CartDataProvider = ({ children }) => {
  const [cart, setCart] = React.useState<CartType>({ place: "", orders: [] });

  return (
    <CartContext.Provider value={{ cart, setCart }}>
      {children}
    </CartContext.Provider>
  );
};

export default CartContext;
