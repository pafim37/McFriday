import React from "react";
import { Box, Typography } from "@mui/material";
import ProductType from "../types/ProductType.ts";
import FoodCatalog from "./FoodCatalog.tsx";
import CartDisplayPanel from "./CartDisplayPanel.tsx";

interface MainPanelProps {
  productTypes: Array<ProductType>;
}

function Header() {
  return (
    <Typography variant="h3" className="header">
      Witamy w restauracji McFriday
    </Typography>
  );
}

const MainPanel: React.FC<MainPanelProps> = (props) => {
  return (
    <Box>
      <Header />
      <FoodCatalog productTypes={props.productTypes} />
      <CartDisplayPanel />
    </Box>
  );
};

export default MainPanel;
