import { TableContainer,Table, TableBody, TableHead,TableCell, TableRow,Paper} from "@mui/material";
import useClientesList from "./hooks/useClientesList.hook";
import { useEffect } from "react";

const ClientesPage = () => {
    const {clientes} = useClientesList();
    
    useEffect(() => {
      console.log('cc',clientes)
    },[clientes])
    return (
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Nome</TableCell>
                <TableCell align="right">CPF</TableCell>
       
              </TableRow>
            </TableHead>
            <TableBody>
              {clientes.map((cliente) => (
                <TableRow
                  key={cliente.id}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {cliente.name}
                  </TableCell>
                  <TableCell align="right">{cliente.cpf}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      );
}

export default ClientesPage;