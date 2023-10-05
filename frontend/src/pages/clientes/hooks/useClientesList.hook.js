import ClientesApi from "../../../api/clientes.api"
import { useState,useMemo, useEffect } from "react";

const useClientesList = () => {
    const clientesApi = useMemo(() => new ClientesApi(), []);
    const [clientes, setClientes] = useState([]);
    const [flagToReset, setFlagToReset ] = useState(false);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        setLoading(true);
        clientesApi.list().then((response) => {
            setClientes(response.data);
            setLoading(false);
        });
    }, [flagToReset]);

    const insertCliente = async (cliente) => {
        setLoading(true);
        const response = await clientesApi.create(cliente);
        setFlagToReset(!flagToReset);
        return response;
    }

    return {
        clientes,
        insertCliente,
        loading
    }
}

export default useClientesList;