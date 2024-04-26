import React, { useEffect } from "react";
import EatPlaceChoose from "./components/EatPlaceChoose.tsx";
import { Grid } from "@mui/material";

const App = () => {
  const [place, setPlace] = React.useState<string>("");

  return (
    <Grid container id="containerP" alignItems="center" sx={{ minHeight: "100vh"}}>
      {place == "" && <EatPlaceChoose setPlace={setPlace} />}
    </Grid>
  );
};

export default App;
