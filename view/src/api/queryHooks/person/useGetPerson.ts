import useAxiosJwt from '../../axiosInstanceHooks/useAxiosJwt';
import { useQuery } from '@tanstack/react-query';
import type { IPerson } from '../../../Types';
import queryClient from '../../ReactQueryClient';

const useGetPersonKey = (identifier: string) => {
    const key = ['getPerson', identifier];
    return key;
};

const useGetPerson = (identifier: string) => {
    const api = useAxiosJwt();
    const key = useGetPersonKey(identifier);

    const fetchFn = async() => {
        const resp = await api.get<IPerson>(`person/getPerson/${identifier}`);
        return resp.data;
    };

    return useQuery({ queryKey: key, queryFn: fetchFn });
};

export default useGetPerson;
export { useGetPersonKey };