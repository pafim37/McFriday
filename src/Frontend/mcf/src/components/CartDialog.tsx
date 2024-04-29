import React from "react";
import {
  Box,
  Button,
  Dialog,
  DialogTitle,
  Stack,
  Typography,
} from "@mui/material";
import CartContext, { CartContextType } from "../context/CartDataProvider.tsx";
import ProductImage from "./ProductImage.tsx";
import OrderRestartContext, {
  OrderRestartContextType,
} from "../context/OrderRestartProvider.tsx";

interface CartDialogProps {
  isOpen: boolean;
  setIsOpen: React.Dispatch<React.SetStateAction<boolean>>;
}

const CartDialog: React.FC<CartDialogProps> = (props) => {
  const { cart } = React.useContext(CartContext) as CartContextType;
  const { restart, setRestart } = React.useContext(
    OrderRestartContext
  ) as OrderRestartContextType;

  const handleClick = () => {
    setRestart(true);
    props.setIsOpen(false);
  };

  return (
    <Dialog open={props.isOpen}>
      <DialogTitle>Koszyk</DialogTitle>
      <Box>
        {cart.orders.map((o, index) => (
          <Stack key={index} direction={"row"}>
            <Typography>{o.number} x </Typography>
            <ProductImage imageData={o.product.imageBase64} />
            <Typography>{o.size}ml</Typography>
            {o.extension[0] === "WithIce" ? (
              <Typography>Z lodem</Typography>
            ) : null}
          </Stack>
        ))}
      </Box>
      <Button onClick={handleClick}>Zamów</Button>
    </Dialog>
  );
};

export default CartDialog;
