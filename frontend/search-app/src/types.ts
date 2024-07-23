export interface Job {
  id?: number;
  position: string;
  years: number;
  personId?: number;
}

export interface Person {
  id: number;
  name: string;
  phone: string;
  skills: string[];
  jobs: Job[];
} 