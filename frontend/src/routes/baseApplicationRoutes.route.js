import { Routes, Route } from "react-router-dom"
import NavigationBar from "../components/navigation/navigationBar.component"
import ClientesPage from "../pages/clientes/clientes.page";
import ProdutosPage from "../pages/produtos/produtos.page";

const BaseApplicationRoutes = () => {

    return <Routes>
        <Route path="/" element={<NavigationBar />}>
            <Route index element={<ClientesPage/>} />
            <Route path="/produtos" element={<ProdutosPage />}/>
        </Route>
    </Routes>
}

export default BaseApplicationRoutes;