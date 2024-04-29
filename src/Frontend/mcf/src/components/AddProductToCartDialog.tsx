import {
  Button,
  Checkbox,
  Dialog,
  DialogTitle,
  Stack,
  Typography,
  FormControlLabel,
  Box,
  Radio,
  RadioGroup,
  FormControl,
  TextField,
} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import RemoveIcon from "@mui/icons-material/Remove";
import React from "react";
import CartContext, { CartContextType } from "../context/CartDataProvider.tsx";
import Product from "../types/Product.ts";
import Order from "../types/Order.ts";
import ProductImage from "./ProductImage.tsx";

interface AddProductToCartDialogProps {
  open: boolean;
  setOpen: React.Dispatch<React.SetStateAction<boolean>>;
  product: Product;
  isNewOrder: boolean;
  setIsNewOrder: React.Dispatch<React.SetStateAction<boolean>>;
}

const AddProductToCartDialog: React.FC<AddProductToCartDialogProps> = (
  props
) => {
  const [size, setSize] = React.useState<string>("500");
  const [amount, setAmount] = React.useState<number>(1);
  const [isIce, setIsIce] = React.useState<boolean>(true);
  const { cart } = React.useContext(CartContext) as CartContextType;

  const handleOrder = (add: boolean) => {
    if (add) {
      var extension: Array<string> = [];
      if (isIce) {
        extension = ["WithIce"];
      } else {
        extension = ["WithoutIce"];
      }
      if (cart.orders === undefined) {
        cart.orders = [
          {
            product: props.product,
            size: size,
            number: amount.toString(),
            extension: extension,
          } as Order,
        ];
      } else {
        cart.orders = [
          ...cart.orders,
          {
            product: props.product,
            size: size,
            number: amount.toString(),
            extension: extension,
          } as Order,
        ];
      }
      props.setIsNewOrder(!props.isNewOrder);
    }
    console.log(cart);
    props.setOpen(false);
  };

  const handleSize = (event) => {
    setSize(event.target.value);
  };

  const handleAmount = (increase: boolean) => {
    if (increase) {
      setAmount(amount + 1);
    } else {
      setAmount(amount - 1);
    }
  };

  const handleIce = () => {
    setIsIce(!isIce);
  };

  return (
    <>
      <Dialog open={props.open}>
        <DialogTitle>Czy dodać do koszyka następujący produkt?</DialogTitle>
        <Typography variant="h5" sx={{ m: "auto" }}>
          {props.product.name}
        </Typography>
        <Box sx={{ m: "auto" }}>
          <ProductImage imageData={props.product.imageBase64} />
        </Box>
        <Stack
          direction={"row"}
          justifyItems={"center"}
          display={"flex"}
          justifyContent={"center"}
        >
          <Button onClick={() => handleAmount(false)}>
            <RemoveIcon />
          </Button>
          <TextField value={amount} size="small" sx={{ width: "10%" }} />
          <Button onClick={() => handleAmount(true)}>
            <AddIcon />
          </Button>
        </Stack>
        <Box sx={{ m: "auto" }}>
          <FormControlLabel
            value={isIce}
            control={<Checkbox checked={isIce} onChange={handleIce} />}
            label="Z lodem"
            labelPlacement="end"
          />
        </Box>
        <FormControl sx={{ m: "auto" }}>
          <RadioGroup row defaultValue="500">
            <FormControlLabel
              value="300"
              control={<Radio />}
              label="300ml"
              onChange={handleSize}
            />
            <FormControlLabel
              value="500"
              control={<Radio />}
              label="500ml"
              onChange={handleSize}
            />
            <FormControlLabel
              value="700"
              control={<Radio />}
              label="700ml"
              onChange={handleSize}
            />
          </RadioGroup>
        </FormControl>
        <Stack direction={"row"} spacing={2} sx={{ m: "auto", p: 2 }}>
          <Button
            variant="contained"
            size="large"
            onClick={() => handleOrder(true)}
          >
            Tak
          </Button>
          <Button
            variant="contained"
            size="large"
            onClick={() => handleOrder(false)}
          >
            Nie
          </Button>
        </Stack>
      </Dialog>
    </>
  );
};

export default AddProductToCartDialog;
