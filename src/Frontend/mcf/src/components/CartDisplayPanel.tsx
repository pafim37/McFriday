import React from "react";
import { Box, Button, Stack } from "@mui/material";
import CartDialog from "./CartDialog.tsx";

const CartDisplayPanel = () => {
  const [isOpenCart, setIsOpenCart] = React.useState<boolean>(false);

  const handleOpenCart = () => {
    setIsOpenCart(true);
  };
  return (
    <Box>
      <Stack
        direction={"row"}
        spacing={2}
        justifyItems={"center"}
        display={"flex"}
        justifyContent={"center"}
      >
        <Button variant="contained" size="large" onClick={handleOpenCart}>
          Przejdź do podsumowania
        </Button>
        <Button variant="contained" size="large">
          Rozpocznij jeszcze raz
        </Button>
      </Stack>
      <CartDialog isOpen={isOpenCart} setIsOpen={setIsOpenCart} />
    </Box>
  );
};

export default CartDisplayPanel;
