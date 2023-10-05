import { AppBar, Typography, Toolbar, Menu, MenuItem,Box, CssBaseline} from "@mui/material";
import { Link, Outlet } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import useStyles from "./navigationBar.styles";

const NavigationBar = () => {
    const navigate = useNavigate();
    const classes = useStyles();

    const irParaClientes = () => {
        navigate("/")
    }

    const irParaProdutos = () => {
        navigate("/produtos")
    }

    return <>
      <AppBar position="static">
        <CssBaseline />
        <Toolbar>

            <div style={classes.navlinks}>
                <MenuItem onClick={irParaClientes}>
                <span  style={classes.link}>Clientes</span>
                </MenuItem>
                <MenuItem onClick={irParaProdutos}>
                <span  style={classes.link}>Produtos</span>
                </MenuItem>
            
            </div>
        </Toolbar>
      </AppBar>
      <Outlet/>
    </> ;
}

export default NavigationBar;