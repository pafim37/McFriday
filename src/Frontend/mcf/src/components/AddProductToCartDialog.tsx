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
interface AddProductToCartDialogProps {
  open: boolean;
  setOpen: React.Dispatch<React.SetStateAction<boolean>>;
  imageData: string;
  productName: string;
}

const AddProductToCartDialog: React.FC<AddProductToCartDialogProps> = (
  props
) => {
  const [add, setAdd] = React.useState<boolean>(false);
  const handleCloseDialog = (add: boolean) => {
    setAdd(add);
    props.setOpen(false);
  };

  React.useEffect(() => {
    console.log(add);
  }, [add]);

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
          <Button onClick={() => handleCloseDialog(true)}>Tak</Button>
          <Button onClick={() => handleCloseDialog(false)}>Nie</Button>
        </Stack>
      </Dialog>
    </>
  );
};

export default AddProductToCartDialog;
