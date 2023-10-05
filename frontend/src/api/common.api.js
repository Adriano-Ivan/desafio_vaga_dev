import axiosInstance from "./axiosInstance";

class CommonApi {
    constructor(rota){
        this._rota = rota;
    }

    async list() {
      const itens = await  axiosInstance.get(this._rota);
      console.log(itens);
      return itens;
    }
}

export default CommonApi;