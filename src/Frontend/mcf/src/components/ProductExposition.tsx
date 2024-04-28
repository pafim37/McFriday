import { Typography } from "@mui/material";
import React from "react";

interface ProductExpositionProps {
  imageData: string;
  name: string;
}

const ProductExposition: React.FC<ProductExpositionProps> = (props) => {
  return (
    <>
      {props.imageData && (
        <img
          src={`data:image/jpeg;base64,${props.imageData}`}
          alt="Obraz"
          width="100"
          height="100"
        />
      )}
      <Typography>{props.name}</Typography>
    </>
  );
};

export default ProductExposition;
