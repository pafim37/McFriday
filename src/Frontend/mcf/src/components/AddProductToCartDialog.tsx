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
} from "@mui/material";
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
  const context = React.useContext(CartContext);

  const handleOrder = (add: boolean) => {
    if (add) {
      console.log(context);
      if (context.order === undefined) {
        context.order = [{ name: "Test2", size: "XL", number: "1" } as Order];
      } else {
        context.order = [
          ...context.order,
          { name: "Test", size: "XL", number: "1" } as Order,
        ];
      }
      console.log("ZADziałało");
    }
    props.setOpen(false);
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
        <Box sx={{ m: "auto" }}>
          <FormControlLabel
            value="end"
            control={<Checkbox defaultChecked />}
            label="Z lodem"
            labelPlacement="end"
          />
        </Box>
        <FormControl sx={{ m: "auto" }}>
          <RadioGroup row>
            <FormControlLabel value="300" control={<Radio />} label="300ml" />
            <FormControlLabel value="500" control={<Radio />} label="500ml" />
            <FormControlLabel value="700" control={<Radio />} label="700ml" />
          </RadioGroup>
        </FormControl>
        <Stack direction={"row"} sx={{ m: "auto" }}>
          <Button onClick={() => handleOrder(true)}>Tak</Button>
          <Button onClick={() => handleOrder(false)}>Nie</Button>
        </Stack>
      </Dialog>
    </>
  );
};

export default AddProductToCartDialog;
