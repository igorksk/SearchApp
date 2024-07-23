import React, { useState, useEffect } from 'react';
import { Container, TextField } from '@mui/material';
import PersonCard from "./PersonCard"
import { Person } from '../types';
import { fetchPeople, searchPeople, deletePerson } from '../api';

const SearchList: React.FC = () => {
  const [people, setPeople] = useState<Person[]>([]);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    loadPeople();
  }, []);

  const loadPeople = async () => {
    const data = await fetchPeople();
    setPeople(data);
  };

  const handleSearch = async (value: string) => {
    setSearchTerm(value);
    if (value.trim()) {
      const data = await searchPeople(value);
      setPeople(data);
    } else {
      await loadPeople();
    }
  };

  const handleDelete = async (id: number) => {
    const success = await deletePerson(id);
    if (success) {
      setPeople(people.filter(p => p.id !== id));
    }
  };

  return (
    <Container maxWidth="md" sx={{ py: 4 }}>
      <TextField
        label="Search by name"
        variant="outlined"
        value={searchTerm}
        onChange={(e) => handleSearch(e.target.value)}
        sx={{ width: '100%', mb: 4 }}
      />
      {people.map((person) => (
        <PersonCard
          key={person.id}
          person={person}
          onDelete={handleDelete}
        />
      ))}
    </Container>
  );
};

export default SearchList;