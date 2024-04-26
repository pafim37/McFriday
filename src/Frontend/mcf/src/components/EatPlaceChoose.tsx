import { Button, Grid } from "@mui/material";
import React from "react";
import "../styles/EatPlaceChoose.css";

interface EatPlaceChooseProps {
    setPlace: React.Dispatch<React.SetStateAction<string>>;
}

const EatPlaceChoose : React.FC<EatPlaceChooseProps> = (props) => {

  const handleClick = (place : string) => {
    props.setPlace(place);
  }

  return (
    <Grid container spacing={1}>
      <Grid item className="item" xs={12} sm={6}>
        <Button variant="contained" className="button" onClick={() => handleClick("restaurant")}>
          Na miejscu
        </Button>
      </Grid>
      <Grid item className="item"  xs={12} sm={6}>
        <Button variant="contained" className="button" onClick={() => handleClick("takeaway")}>
          Na wynos
        </Button>
      </Grid>
    </Grid>
  );
};

export default EatPlaceChoose;
