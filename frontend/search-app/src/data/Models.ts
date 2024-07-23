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