import CommonApi from "./common.api";

class ClientesApi extends CommonApi {
    constructor(){
        super("clientes");
    }

    async create(cliente){
        try {
            return await super.create(cliente);
        } catch(e) {
            if(e.response?.data) {
                const error = e.response.data === "DUPLICATE_CPF" ? 'duplicate_cpf' : "invalid_cpf"
                return {
                    'cpfError': error
                }
            }

            return {
                genericError: "ERRO GENÉRICO"
            }
        }
    }
}


export default ClientesApi;
