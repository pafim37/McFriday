import React, { useState } from "react";

export interface OrderRestartContextType {
    restart: boolean;
    setRestart: React.Dispatch<React.SetStateAction<boolean>>;
  }

const OrderRestartContext = React.createContext<OrderRestartContextType | undefined>(undefined);

export const OrderRestartDataProvider = ({ children }) => {
  const [restart, setRestart] = useState<boolean>(false)
  
  return (
    <OrderRestartContext.Provider value={{restart, setRestart}}>
      {children}
    </OrderRestartContext.Provider>
  );
};

export default OrderRestartContext;
