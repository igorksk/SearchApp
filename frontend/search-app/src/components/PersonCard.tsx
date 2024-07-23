import React from 'react';
import { Card, CardContent, Typography, Button, Box } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import { Person } from '../types';

interface PersonCardProps {
  person: Person;
  onDelete: (id: number) => void;
}

const PersonCard: React.FC<PersonCardProps> = ({ person, onDelete }) => {
  return (
    <Card sx={{ minWidth: 275, mb: 2 }}>
      <CardContent>
        <Box display="flex" justifyContent="space-between" alignItems="center">
          <Typography variant="h5" component="div">
            {person.name}
          </Typography>
          <Button
            color="error"
            startIcon={<DeleteIcon />}
            onClick={() => onDelete(person.id)}
          >
            Delete
          </Button>
        </Box>
        <Typography sx={{ mb: 1.5 }} color="text.secondary">
          Phone: {person.phone}
        </Typography>
        <Typography variant="body2">
          Skills: {person.skills.join(', ')}
        </Typography>
        <Typography variant="body2" sx={{ mt: 1 }}>
          Work Experience:
        </Typography>
        {person.jobs.map((job, index) => (
          <Typography key={index} variant="body2" sx={{ ml: 2 }}>
            • {job.position} ({job.years} years)
          </Typography>
        ))}
      </CardContent>
    </Card>
  );
};

export default PersonCard;