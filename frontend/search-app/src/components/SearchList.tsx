import { useState, useEffect } from "react";
import { Person } from "../data/Models";
import { debounceDelay } from "../data/Constants";
import useDebounce from "../hooks/Hooks";
import PersonCard from "./PersonCard"
import personService from '../api/personService';

const SearchList: React.FC = () => {

  const [persons, setPersons] = useState<Person[]>([]);

  const [searchTerm, setSearchTerm] = useState<string>('');

  const debouncedSearchTerm = useDebounce(searchTerm, debounceDelay);

    const handleSearch = async () => {
      if (searchTerm === '') {
        const allPersons = await personService.getAllPersons();
        setPersons(allPersons);
      } else {
        const filteredPersons = await personService.getPersonsByName(searchTerm);
        setPersons(filteredPersons);
      }
    };

    useEffect(() => {
      const fetchPersons = async () => {
        const personsData = await personService.getAllPersons();
        setPersons(personsData);
      };
  
      fetchPersons();
    }, []);

    useEffect(() => {
      handleSearch();
    }, [debouncedSearchTerm]);

    return (       
      <div>
        <input className="search-input"
          type="text"
          placeholder="Enter your search term"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
          {persons.map((person) => (
            <PersonCard key={person.id} person={person} />
          ))}
      </div>
    );
  };

export default SearchList;