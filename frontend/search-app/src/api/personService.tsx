import axios from 'axios';
import { Person } from '../data/Models';
import { apiPort } from '../data/Constants';

const api = axios.create({
    baseURL: `http://localhost:${apiPort}`, // Replace with your API endpoint
  });// Replace with your actual API base URL

const personService = {
    getAllPersons: async (): Promise<Person[]> => {
        const response = await api.get<Person[]>(`/people`);
        return response.data;
    },

    getPersonsByName: async (name: string): Promise<Person[]> => {
        const response = await api.get<Person[]>(`/people/${name}`);
        return response.data;
    },
};

export default personService;