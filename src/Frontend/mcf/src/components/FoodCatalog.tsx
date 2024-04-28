import React from "react";
import {
  Grid,
  List,
  ListItem,
  ListItemButton,
  Typography,
} from "@mui/material";
import ProductExposition from "./ProductExposition.tsx";

interface FoodCatalogProps {
  productTypes: Array<ProductType>;
}

const FoodCatalog: React.FC<FoodCatalogProps> = (props) => {
  const [currIndex, setCurrIndex] = React.useState<number>(0);
  const [currProducts, setCurrProducts] = React.useState<Array<Product>>([]);

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
        <Grid item xs={10}>
          <Grid container>
            {currProducts.map(p => (
              <Grid xs={4}>
                <ProductExposition name={p.name} imageData={p.imageBase64}/>
              </Grid>
            ))}
          </Grid>
        </Grid>
      </Grid>
    </>
  );
};

export default FoodCatalog;
