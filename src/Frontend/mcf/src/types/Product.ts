import ProductType from "./ProductType.ts";

type Product = {
  productType: ProductType;
  name: string;
  imageBase64: string;
};

export default Product;
