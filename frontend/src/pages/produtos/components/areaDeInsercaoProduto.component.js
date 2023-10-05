import { Grid, FormControl, TextField, Button, FormLabel, Select, MenuItem } from "@mui/material";
import useAreaDeInsercaoProduto from "./hooks/useAreaDeInsercaoProduto.hook";

const AreaDeInsercaoProduto = ({funcInserirProduto}) => {
    const {formValues, clientesForSelect, handleNameChange, handleClienteChange, 
        thereIsCliente, thereIsName} = useAreaDeInsercaoProduto();

    const createProduto = async () => {
        if(!thereIsCliente()) {
            alert("Informe um cliente, por favor")
        } else if(!thereIsName()) {
            alert("Informe um nome para o produto, por favor")
        } else {
            const response = await funcInserirProduto({name: formValues.name, clienteId: formValues.clienteId});

            if(response.error){
                alert("Erro no cadastro !!")
            } else {
                alert('Cadastrado !')
            }
        }
    }

    return (
        <form >
            <Grid container alignItems="center" justify="center" direction="column">
                <Grid item>
                    <FormControl>
                        <FormLabel>Nome:</FormLabel>
                        <TextField name="name" onChange={handleNameChange} />
                    </FormControl>
                    <FormControl style={{minWidth: 120}}>
                        <FormLabel>Cliente</FormLabel>
                        <Select
                            name="cliente"
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            defaultValue={0}
                            fullWidth
                            label="Age"
                            onChange={handleClienteChange}
                        >
                            
                            <MenuItem value={0}>Nenhum cliente selecionado</MenuItem>
                            {
                                clientesForSelect.map((cliente) => {
                                    return <MenuItem value={cliente.id} key={cliente.id}>{ cliente.name }</MenuItem>
                                })
                            }
                        </Select>
                    </FormControl>
                </Grid>
                <Button variant="contained" color="success" onClick={createProduto}>Cadastrar produto</Button>
            </Grid>       
        </form>
    )
}

export default AreaDeInsercaoProduto;