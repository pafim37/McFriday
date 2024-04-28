import { Typography } from "@mui/material";
import React from "react";

interface ProductExpositionProps {
  name: string;
}

const ProductExposition: React.FC<ProductExpositionProps> = (props) => {
  return (
    <Typography>
      {props.name}
    </Typography>
  );
};

export default ProductExposition;
