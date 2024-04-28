import { Box, Typography } from "@mui/material";
import React from "react";
import AddProductToCartDialog from "./AddProductToCartDialog.tsx";

interface ProductExpositionProps {
  imageData: string;
  name: string;
}

const ProductExposition: React.FC<ProductExpositionProps> = (props) => {
  
  const [isOpenDialog, setIsOpenDialog] = React.useState<boolean>(false);

  const handleClick = () => {
    setIsOpenDialog(true);
  }

  return (
    <>
    <Box onClick={handleClick}>
      {props.imageData && (
        <img
          src={`data:image/jpeg;base64,${props.imageData}`}
          alt="Obraz"
          width="100"
          height="100"
        />
      )}
      <Typography>{props.name}</Typography>
    </Box>
    <AddProductToCartDialog open={isOpenDialog} setOpen={setIsOpenDialog} imageData={props.imageData} productName={props.name}/>
    </>
  );
};

export default ProductExposition;
