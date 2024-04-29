import { Box, Typography } from "@mui/material";
import React from "react";
import AddProductToCartDialog from "./AddProductToCartDialog.tsx";
import Product from "../types/Product.ts";
import ProductImage from "./ProductImage.tsx";

interface ProductExpositionProps {
  isNewOrder: boolean;
  setIsNewOrder: React.Dispatch<React.SetStateAction<boolean>>;
  product: Product;
}

const ProductExposition: React.FC<ProductExpositionProps> = (props) => {
  const [isOpenDialog, setIsOpenDialog] = React.useState<boolean>(false);

  const handleClick = () => {
    setIsOpenDialog(true);
  };

  return (
    <>
      <Box onClick={handleClick}>
        {props.product.imageBase64 && (
          <ProductImage imageData={props.product.imageBase64} />
        )}
        <Typography>{props.product.name}</Typography>
      </Box>
      <AddProductToCartDialog
        open={isOpenDialog}
        setOpen={setIsOpenDialog}
        product={props.product}
        isNewOrder={props.isNewOrder}
        setIsNewOrder={props.setIsNewOrder}
      />
    </>
  );
};

export default ProductExposition;
