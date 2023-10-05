import { useMemo, useState, useEffect } from "react";
import ProdutosApi from "../../../api/produtos.api";

const useProdutosList = () => {
    const produtosApi = useMemo(() => new ProdutosApi(), []);
    const [produtos, setProdutos] = useState([]);
    const [flagToReset, setFlagToReset ] = useState(false);
    const [loading, setLoading ] = useState(false);

    useEffect(() => {
        setLoading(true);
        produtosApi.list().then((response) => {
            console.log(response);
            setProdutos(response.data);
            setLoading(false);
        });
    }, [flagToReset]);

    const insertProduto = () => {

    }

    return {
        produtos, 
        loading,
        insertProduto
    };
}

export default useProdutosList;