import { Button, Grid, Typography } from "@mui/material";
import React from "react";
import "../styles/EatPlaceChoose.css";
import CartContext, { CartContextType } from "../context/CartDataProvider.tsx";
import CartType from "../types/CartType.ts";

const EatPlaceChoose: React.FC = () => {
  const { cart, setCart } = React.useContext(CartContext) as CartContextType;

  const handleClick = (place: string) => {
    var newCart = { place: place, orders: cart.orders } as CartType;
    setCart(newCart);
  };

  return (
    <Grid container className="container" alignItems="center">
      <Grid container spacing={1}>
        <Grid item xs={12} sm={12}>
          <Typography variant="h3" className="header">
            Na miejscu czy na wynos?
          </Typography>
        </Grid>
        <Grid item className="item" xs={12} sm={6}>
          <Button
            variant="contained"
            className="button"
            onClick={() => handleClick("restaurant")}
          >
            Na miejscu
          </Button>
        </Grid>
        <Grid item className="item" xs={12} sm={6}>
          <Button
            variant="contained"
            className="button"
            onClick={() => handleClick("takeaway")}
          >
            Na wynos
          </Button>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default EatPlaceChoose;
