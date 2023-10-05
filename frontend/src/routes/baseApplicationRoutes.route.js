import { Routes, Route } from "react-router-dom"
import NavigationBar from "../components/navigation/navigationBar.component"
import ClientesPage from "../pages/clientes/clientes.page";

const BaseApplicationRoutes = () => {

    return <Routes>
        <Route path="/" element={<NavigationBar />}>
            <Route index element={<ClientesPage/>} />
            <Route path="/produtos" element={<div>Produtos</div>}/>
        </Route>
    </Routes>
}

export default BaseApplicationRoutes;