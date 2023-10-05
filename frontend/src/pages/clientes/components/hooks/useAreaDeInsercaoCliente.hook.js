import { useEffect, useState } from "react";

const defaultFormValues = {
    name: "",
    cpf: "",
};

const useAreaDeInsercaoCliente = () => {
    const [formValues, setFormValues] = useState(defaultFormValues);

    useEffect(() => {
        console.log(formValues)
    },[formValues]);
    const handleFormChange = (changeData) => {
        setFormValues({
            ...formValues,
           [ `${changeData.target.name}`]: changeData.target.value
        })
    }

    return {
        formValues,
        setFormValues,
        handleFormChange
    };
}

export default useAreaDeInsercaoCliente;