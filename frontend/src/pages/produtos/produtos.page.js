import { TableRow, TableCell, Box, CircularProgress } from "@mui/material";
import CustomizableContentTable from "../../components/customizableContentTable/customizableContentTable.component";
import useProdutosList from "./hooks/useProdutosList.hook";
import AreaDeInsercaoProduto from "./components/areaDeInsercaoProduto.component";

const ProdutosPage = () => {
    const {produtos, loading, insertProduto} = useProdutosList();

    const returnHeaders = () => {
        return (
            <TableRow>
              <TableCell>Nome</TableCell>
              <TableCell align="right">Cliente</TableCell>
            </TableRow>
          ) ;
    }

    const returnContent = () => {
        return (
            produtos.map((produto) => (
              <TableRow
                key={produto.id}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {produto.name}
                </TableCell>
                <TableCell align="right">{produto.cliente.name}</TableCell>
              </TableRow>
            ))
          );
    }

    return (
        loading ?
            <Box sx={{display: "flex"}}>
                <CircularProgress size="6rem"/> 
            </Box>   :
        <>
            <AreaDeInsercaoProduto funcInserirProduto={insertProduto}/>
            <CustomizableContentTable 
                funcHeaders={returnHeaders}
                funcContent={returnContent}
            /> 
        </>

    )
}

export default ProdutosPage;