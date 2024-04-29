import React from "react";
import {
  Box,
  Button,
  Grid,
  List,
  ListItem,
  ListItemButton,
  Stack,
  Typography,
} from "@mui/material";
import ProductExposition from "./ProductExposition.tsx";
import ProductType from "../types/ProductType.ts";
import Product from "../types/Product.ts";
import CartContext from "../context/CartDataProvider.tsx";

interface FoodCatalogProps {
  productTypes: Array<ProductType>;
}

const FoodCatalog: React.FC<FoodCatalogProps> = (props) => {
  const [currIndex, setCurrIndex] = React.useState<number>(0);
  const [currProducts, setCurrProducts] = React.useState<Array<Product>>([]);
  const [isNewOrder, setIsNewOrder] = React.useState<boolean>(true);
  const orderData = React.useContext(CartContext);

  const handleClick = (index: number, productType: ProductType) => {
    setCurrIndex(index);
    setCurrProducts(productType.products);
  };

  return (
    <>
      <Typography variant="h3" className="header">
        Witamy w restauracji McFriday
      </Typography>
      <Grid container>
        <Grid item xs={2}>
          <List>
            {props.productTypes.map((productType, index) => (
              <ListItem key={index}>
                <ListItemButton
                  selected={currIndex === index}
                  onClick={() => handleClick(index, productType)}
                >
                  {productType.name}
                </ListItemButton>
              </ListItem>
            ))}
          </List>
        </Grid>
        <Grid item xs={8}>
          <Grid container>
            {currProducts.map((p, index) => (
              <Grid item xs={4} key={index}>
                <ProductExposition
                  product={p}
                  isNewOrder={isNewOrder}
                  setIsNewOrder={setIsNewOrder}
                />
              </Grid>
            ))}
          </Grid>
        </Grid>
        <Grid item xs={2}>
          {orderData.orders.map((o, index) => (
            <Box key={index}>{o.name}</Box>
          ))}
          <Button variant="contained">Podejrzyj koszyk</Button>
        </Grid>
      </Grid>
      <Stack
        direction={"row"}
        spacing={2}
        justifyItems={"center"}
        display={"flex"}
        justifyContent={"center"}
        sx={{ m: "auto" }}
      >
        <Button variant="contained" size="large">
          Przejdź do podsumowania
        </Button>
        <Button variant="contained" size="large">
          Rozpocznij jeszcze raz
        </Button>
      </Stack>
    </>
  );
};

export default FoodCatalog;
