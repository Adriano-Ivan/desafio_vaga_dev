import { Button, FormControl, FormLabel, Grid,TextField } from "@mui/material";
import { useState } from "react";
import useAreaDeInsercaoCliente from "./hooks/useAreaDeInsercaoCliente.hook";


const AreaDeInsercaoCliente = ({funcInserirCliente}) => {
    const {formValues, handleFormChange} = useAreaDeInsercaoCliente();

    const createCliente = async () => {
         const response = await funcInserirCliente(formValues);

         if(response.cpfError === "invalid_cpf") {
            alert('CPF é inválido !!')
         } else if(response.cpfError === "duplicate_cpf") {
            alert("CPF duplicado !! Favor inserir outro CPF !!")
         }
    }


    return (
        <form >
            <Grid container alignItems="center" justify="center" direction="column">
                <Grid item>
                    <FormControl>
                        <FormLabel>Nome:</FormLabel>
                        <TextField name="name" onChange={handleFormChange} />
                    </FormControl>
                    <FormControl>
                        <FormLabel>CPF:</FormLabel>
                        <TextField name="cpf" onChange={handleFormChange}></TextField>
                    </FormControl>
                </Grid>
                <Button variant="contained" color="success" onClick={createCliente}>Cadastrar cliente</Button>
            </Grid>
            
        </form>
    );

}

export default AreaDeInsercaoCliente;