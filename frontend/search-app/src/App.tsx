import React, { useState, useEffect } from 'react';
import { Container, TextField, Button, Box, Dialog, DialogTitle, DialogContent, DialogActions, Typography } from '@mui/material';
import PersonCard from './components/PersonCard';
import { Person } from './types';
import { fetchPeople, searchPeople, deletePerson, addPerson } from './api';

function App() {
  const [people, setPeople] = useState<Person[]>([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [openDialog, setOpenDialog] = useState(false);
  const [newPerson, setNewPerson] = useState<Partial<Person>>({
    name: '',
    phone: '',
    skills: [],
    jobs: []
  });

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

  const handleAdd = async () => {
    if (newPerson.name && newPerson.phone) {
      const addedPerson = await addPerson(newPerson as Person);
      if (addedPerson) {
        setPeople([...people, addedPerson]);
        setOpenDialog(false);
        setNewPerson({
          name: '',
          phone: '',
          skills: [],
          jobs: []
        });
      }
    }
  };

  return (
    <Container maxWidth="md" sx={{ py: 4 }}>
      <Box sx={{ mb: 4, display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
        <TextField
          label="Search by name"
          variant="outlined"
          value={searchTerm}
          onChange={(e) => handleSearch(e.target.value)}
          sx={{ width: '70%' }}
        />
        <Button
          variant="contained"
          color="primary"
          onClick={() => setOpenDialog(true)}
        >
          Add
        </Button>
      </Box>

      {people.map((person) => (
        <PersonCard
          key={person.id}
          person={person}
          onDelete={handleDelete}
        />
      ))}

      <Dialog open={openDialog} onClose={() => setOpenDialog(false)}>
        <DialogTitle>Add New Employee</DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            label="Name"
            fullWidth
            value={newPerson.name}
            onChange={(e) => setNewPerson({ ...newPerson, name: e.target.value })}
          />
          <TextField
            margin="dense"
            label="Phone"
            fullWidth
            value={newPerson.phone}
            onChange={(e) => setNewPerson({ ...newPerson, phone: e.target.value })}
          />
          <TextField
            margin="dense"
            label="Skills (comma separated)"
            fullWidth
            value={newPerson.skills?.join(', ')}
            onChange={(e) => setNewPerson({ ...newPerson, skills: e.target.value.split(',').map(s => s.trim()) })}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenDialog(false)}>Cancel</Button>
          <Button onClick={handleAdd} color="primary">
            Add
          </Button>
        </DialogActions>
      </Dialog>
    </Container>
  );
}

export default App;
