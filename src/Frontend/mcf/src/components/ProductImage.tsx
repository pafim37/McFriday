import React from "react";

interface ProductImageProps {
  imageData: string;
  width?: string;
  height?: string;
}

const ProductImage: React.FC<ProductImageProps> = (props) => {
  return (
    <img
      src={`data:image/jpeg;base64,${props.imageData}`}
      alt="Obraz"
      width={props.width ? props.width : "100"}
      height={props.height ? props.height : "100"}
    />
  );
};

export default ProductImage;
