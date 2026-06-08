import axios from 'axios';

const useAxiosJwt = () => {
const BASE_URL = import.meta.env.VITE_API_URL;

    const authApi = axios.create({
        baseURL: BASE_URL
    });

    return authApi;
};
export default useAxiosJwt;