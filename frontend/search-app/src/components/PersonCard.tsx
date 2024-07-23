import { Person } from "../data/Models";

interface PersonCardProps {
    person: Person;
  }

const PersonCard: React.FC<PersonCardProps> = ({ person }) => {
    return (
      <div className="card">
        <h2>{person.name}</h2>
        <p>Phone: {person.phone}</p>
        <p>Skills: {person.skills.join(', ')}</p>
        <ul>
          {person.jobs.map((job, index) => (
            <li key={index}>
              {job.position} - {job.years} years
            </li>
          ))}
        </ul>
      </div>
    );
  };

  export default PersonCard;