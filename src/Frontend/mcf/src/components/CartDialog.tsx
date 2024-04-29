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
import axios from "axios";
import CartType from "../types/CartType.ts";

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
    var dataToSend = prepareDataToSend(cart);
    axios.post("http://localhost:5226/", dataToSend)
    .then(function (response) {
      console.log(response);
    })
    .catch(function (error) {
      console.log(error);
    });
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

function prepareDataToSend( cart : CartType) {
  var ordersToSend = Array<any>();
  cart.orders.forEach(order => {
    var newOrder = {
      productName: order.product.name,
      productType: order.product.productType,
      size: order.size,
      number: order.number,
      extension: order.extension
     }
     ordersToSend.push(newOrder)
  });
  var dataToSend = {place: cart.place, orders: ordersToSend}
  return dataToSend;
}