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
  
export const DATA: Person[] = [
{
    id: 0,
    name: 'Alex',
    phone: '+38098022',
    skills: ['Dev', 'DevOps'],
    jobs: [
    {
        position: 'Dev',
        years: 1,
    },
    {
        position: 'DevOps',
        years: 2,
    },
    ],
},
{
    id: 1,
    name: 'Margo',
    phone: '+11111111',
    skills: ['Designer', 'MotionDesigner'],
    jobs: [
    {
        position: 'Dev',
        years: 1,
    },
    {
        position: 'DevOps',
        years: 2,
    },
    ],
},
{
    id: 2,
    name: 'Sasha',
    phone: '+22222222',
    skills: ['Dev', 'DevOps'],
    jobs: [
    {
        position: 'Dev',
        years: 1,
    },
    {
        position: 'DevOps',
        years: 2,
    },
    ],
},
];