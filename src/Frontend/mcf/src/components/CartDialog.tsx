import React from "react";
import {
  Box,
  Button,
  Checkbox,
  Dialog,
  DialogTitle,
  Stack,
  Typography,
} from "@mui/material";
import CartContext from "../context/CartDataProvider.tsx";
import ProductImage from "./ProductImage.tsx";
import OrderRestartContext, {
  OrderRestartContextType,
} from "../context/OrderRestartProvider.tsx";

interface CartDialogProps {
  isOpen: boolean;
  setIsOpen: React.Dispatch<React.SetStateAction<boolean>>;
}

const CartDialog: React.FC<CartDialogProps> = (props) => {
  const cartContext = React.useContext(CartContext);
  const { restart, setRestart } = React.useContext(
    OrderRestartContext
  ) as OrderRestartContextType;

  const handleClick = () => {
    console.log(restart);
    setRestart(true);
    props.setIsOpen(false);
  };

  return (
    <Dialog open={props.isOpen}>
      <DialogTitle>Koszyk</DialogTitle>
      <Box>
        {cartContext.orders.map((order, index) => (
          <Stack key={index} direction={"row"}>
            <Typography>{order.number} x </Typography>
            <ProductImage imageData={order.product.imageBase64} />
            <Typography>{order.size}ml</Typography>
            {order.extension[0] === "WithIce" ? (
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
