import ClientesApi from "../../../api/clientes.api"
import { useState,useMemo, useEffect } from "react";

const useClientesList = () => {
    const clientesApi = useMemo(() => new ClientesApi(), []);
    const [clientes, setClientes] = useState([]);

    useEffect(() => {
        clientesApi.list().then((response) => {
            console.log(response);
            setClientes(response.data)
        });
    }, []);

    return {
        clientes
    }
}

export default useClientesList;