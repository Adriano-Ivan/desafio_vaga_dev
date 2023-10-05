import { useEffect, useMemo, useState } from "react";
import ClientesApi from "../../../../api/clientes.api";

const defaultFormValues = {
    name: "",
    clienteId: "",
};

const useAreaDeInsercaoProduto = () => {
    const clientesApi = useMemo(() => new ClientesApi(), []);
    const [formValues, setFormValues] = useState(defaultFormValues);
    const [clientesForSelect, setClientesForSelect] = useState([]);

    useEffect(() => {
        clientesApi.list().then((response) => {
            setClientesForSelect(response.data);
        });
    }, []);

    const handleFormChange = (changeData) => {
        setFormValues({
            ...formValues,
           [ `${changeData.target.name}`]: changeData.target.value
        })
    }

    const handleNameChange = (dataChange) => {
        setFormValues({
            ...formValues,
            name: dataChange.target.value
        });
    }

    const handleClienteChange = (dataChange) => {
        setFormValues({
            ...formValues,
            clienteId: dataChange.target.value
        });
    }

    const thereIsCliente = () => {
        return formValues.clienteId !== 0 && formValues.clienteId.trim() !== "";
    }

    const thereIsName = () => {
        return formValues.name.length > 1;
    }

    return {
        formValues,
        clientesForSelect,
        setFormValues,
        handleFormChange,
        handleNameChange,
        handleClienteChange,
        thereIsName,
        thereIsCliente,
    };
}

export default useAreaDeInsercaoProduto;