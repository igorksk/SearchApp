import axios from 'axios';
import { Person } from '../data/Models';
import { apiPort } from '../data/Constants';

const baseUrl = `https://localhost:${apiPort}/people`; // Replace with your actual API base URL

const personService = {
    getAllPersons: async (): Promise<Person[]> => {
        const response = await axios.get<Person[]>(baseUrl);
        return response.data;
    },

    getPersonsByName: async (name: string): Promise<Person[]> => {
        const response = await axios.get<Person[]>(`${baseUrl}/${name}`);
        return response.data;
    },
};

export default personService;