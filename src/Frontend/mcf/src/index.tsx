import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";

import { OrderRestartDataProvider } from "./context/OrderRestartProvider.tsx";

const root = ReactDOM.createRoot(document.getElementById("root")!);
root.render(
  <React.StrictMode>
    <OrderRestartDataProvider>
      <App />
    </OrderRestartDataProvider>
  </React.StrictMode>
);
