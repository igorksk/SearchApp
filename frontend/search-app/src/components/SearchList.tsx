import { useState, useEffect } from "react";
import { DATA, Person } from "../data/CustomersDB";
import { debounceDelay } from "../data/Constants";
import useDebounce from "../hooks/Hooks";
import PersonCard from "./PersonCard"

const SearchList: React.FC = () => {

  const [customersList] = useState<Person[]>(DATA);
  const [filteredCustomersList, setFilteredCustomersList] = useState<Person[]>(DATA);

  const [searchTerm, setSearchTerm] = useState<string>('');

  const debouncedSearchTerm = useDebounce(searchTerm, debounceDelay);

    const handleSearch = () => {
      if (searchTerm === '') {
        setFilteredCustomersList(customersList);
      } else {
        setFilteredCustomersList(customersList.filter((c) => c.name.toLowerCase().startsWith(searchTerm.toLowerCase())))
      }
    };

    
    useEffect(() => {
      handleSearch();
      // Perform any action with the debounced value here, e.g., make an API call
    }, [debouncedSearchTerm]);
  
    return (       
      <div>
        <input className="search-input"
          type="text"
          placeholder="Enter your search term"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
          {filteredCustomersList.map((person) => (
            <PersonCard key={person.id} person={person} />
          ))}
      </div>
    );
  };

export default SearchList;