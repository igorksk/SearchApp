import axios from 'axios';

export interface Job {
    position: string;
    years: number;
    }
  
export interface Person {
    id: number;
    name: string;
    phone: string;
    skills: string[];
    jobs: Job[];
  }

const URL = '7091'

const baseUrl = 'https://localhost:' + URL +'/people'; // Replace with your actual API base URL

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