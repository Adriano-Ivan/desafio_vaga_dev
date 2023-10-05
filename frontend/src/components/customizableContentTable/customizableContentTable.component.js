import { TableContainer, Table, TableBody, TableHead, Paper} from "@mui/material";

const CustomizableContentTable = ({funcHeaders, funcContent}) => {

    return ( <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    {
                        funcHeaders()
                    }
                </TableHead>
                <TableBody>
                    {
                        funcContent()
                    }
                </TableBody>
                </Table>
            </TableContainer>
    );
}

export default CustomizableContentTable;