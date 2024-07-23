import { Person } from './types';

const API_URL = 'http://localhost:7091/api';

export const fetchPeople = async (): Promise<Person[]> => {
  const response = await fetch(`${API_URL}/people`);
  if (!response.ok) {
    throw new Error('Failed to fetch people');
  }
  return response.json();
};

export const searchPeople = async (name: string): Promise<Person[]> => {
  const response = await fetch(`${API_URL}/people/search?name=${encodeURIComponent(name)}`);
  if (!response.ok) {
    throw new Error('Failed to search people');
  }
  return response.json();
};

export const deletePerson = async (id: number): Promise<boolean> => {
  const response = await fetch(`${API_URL}/people/${id}`, {
    method: 'DELETE',
  });
  return response.ok;
};

export const addPerson = async (person: Person): Promise<Person> => {
  const response = await fetch(`${API_URL}/people`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(person),
  });
  if (!response.ok) {
    throw new Error('Failed to add person');
  }
  return response.json();
}; 