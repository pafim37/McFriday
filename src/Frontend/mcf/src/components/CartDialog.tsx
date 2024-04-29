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

interface CartDialogProps {
  isOpen: boolean;
  setIsOpen: React.Dispatch<React.SetStateAction<boolean>>;
}

const CartDialog: React.FC<CartDialogProps> = (props) => {
  const context = React.useContext(CartContext);

  const handleClick = () => {
    props.setIsOpen(false);
  };

  React.useEffect(() => {
    console.log(context);
  }, []);
  return (
    <Dialog open={props.isOpen}>
      <DialogTitle>Koszyk</DialogTitle>
      <Box>
        {context.orders.map((order, index) => (
          <Stack key={index} direction={"row"}>
            <Typography>{order.number} x </Typography>
            <img
              src={`data:image/jpeg;base64,${order.product.imageBase64}`}
              alt="Obraz"
              width="100"
              height="100"
            />
            <Typography>{order.size}ml</Typography>
            {order.extension[0] === "WithIce" ? (
              <Typography>Z lodem</Typography>
            ) : null}
          </Stack>
        ))}
      </Box>
      <Button onClick={handleClick}>OK</Button>
    </Dialog>
  );
};

export default CartDialog;