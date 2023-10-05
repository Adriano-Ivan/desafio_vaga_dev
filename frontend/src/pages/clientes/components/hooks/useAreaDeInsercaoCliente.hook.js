import { useEffect, useState } from "react";

const defaultFormValues = {
    name: "",
    cpf: "",
};

const useAreaDeInsercaoCliente = () => {
    const [formValues, setFormValues] = useState(defaultFormValues);

    const handleFormChange = (changeData) => {
        setFormValues({
            ...formValues,
           [ `${changeData.target.name}`]: changeData.target.value
        })
    }

    const emptyFields = () => {
        return formValues.name.trim() === "" || formValues.cpf.trim() === "";
    }

    return {
        formValues,
        setFormValues,
        handleFormChange,
        emptyFields
    };
}

export default useAreaDeInsercaoCliente;