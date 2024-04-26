import React from "react";
import EatPlaceChoose from "./components/EatPlaceChoose.tsx";
import { Grid } from "@mui/material";

const App = () => {
  const [place, setPlace] = React.useState<string>("");
  
  return (
    <Grid container id="containerP" alignItems="center" sx={{ minHeight: "100vh"}}>
      <EatPlaceChoose setPlace={setPlace} />
      <>{place}</>
    </Grid>
  );
};

export default App;
