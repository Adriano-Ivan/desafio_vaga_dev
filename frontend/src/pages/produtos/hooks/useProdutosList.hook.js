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
            setProdutos(response.data);
            setLoading(false);
        });
    }, [flagToReset]);

    const insertProduto = async (produto) => {
        setLoading(true);
        const response = await produtosApi.create(produto);
        setFlagToReset(!flagToReset);
        return response;
    }

    return {
        produtos, 
        loading,
        insertProduto
    };
}

export default useProdutosList;