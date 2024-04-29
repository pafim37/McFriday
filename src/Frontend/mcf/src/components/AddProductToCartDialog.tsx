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
import CartContext from "../context/CartDataProvider.tsx";

interface AddProductToCartDialogProps {
  open: boolean;
  setOpen: React.Dispatch<React.SetStateAction<boolean>>;
  imageData: string;
  productName: string;
}

const AddProductToCartDialog: React.FC<AddProductToCartDialogProps> = (
  props
) => {
  const [size, setSize] = React.useState<string>("500");
  const [amount, setAmount] = React.useState<number>(1);
  const [isIce, setIsIce] = React.useState<boolean>(true);
  const context = React.useContext(CartContext);

  const handleOrder = (add: boolean) => {
    if (add) {
      var extension: Array<string> = [];
      if (isIce) {
        extension = ["WithIce"];
      } else {
        extension = ["WithoutIce"];
      }
      if (context.orders === undefined) {
        context.orders = [
          {
            name: props.productName,
            size: size,
            number: amount.toString(),
            extension: extension,
          } as Order,
        ];
      } else {
        context.orders = [
          ...context.orders,
          {
            name: props.productName,
            size: size,
            number: amount.toString(),
            extension: extension,
          } as Order,
        ];
      }
    }
    console.log(context);
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
          {props.productName}
        </Typography>
        <Box sx={{ m: "auto" }}>
          <img
            src={`data:image/jpeg;base64,${props.imageData}`}
            alt="Obraz"
            width="100"
            height="100"
          />
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
