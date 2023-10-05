import { TableCell, TableRow, CircularProgress, Box} from "@mui/material";
import useClientesList from "./hooks/useClientesList.hook";
import { useEffect } from "react";
import CustomizableContentTable from "../../components/customizableContentTable/customizableContentTable.component";
import AreaDeInsercaoCliente from "./components/areaDeInsercaoCliente.component";

const ClientesPage = () => {
    const {clientes, loading, insertCliente} = useClientesList();
    
    useEffect(() => {
      console.log('cc',clientes)
    },[clientes]);

    const returnHeaders = () => {
      return (
        <TableRow>
          <TableCell>Nome</TableCell>
          <TableCell align="right">CPF</TableCell>
        </TableRow>
      ) ;
    }

    const returnContent = () => {
        return (
          clientes.map((cliente) => (
            <TableRow
              key={cliente.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {cliente.name}
              </TableCell>
              <TableCell align="right">{cliente.cpf}</TableCell>
            </TableRow>
          ))
        );
    }

    return (
      loading ? 

        <Box sx={{display: "flex"}}>
          <CircularProgress size="6rem"/> 
        </Box>

      :

      <>
          <AreaDeInsercaoCliente funcInserirCliente={insertCliente}/>
          <CustomizableContentTable 
            funcHeaders={returnHeaders}
            funcContent={returnContent}
          /> 
      </>
   
    )
}

export default ClientesPage;