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

    async create(obj){
      const createdItem = await axiosInstance.post(this._rota, obj);
      console.log(createdItem);
      return createdItem;
    }
}

export default CommonApi;