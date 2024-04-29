import Product from "./Product";

type Order = {
    product: Product;
    size: string;
    number: string;
    extension: Array<string>
}

export default Order;