import { useEffect, useState } from 'react';
import { uniqueNamesGenerator, Config, names, adjectives } from 'unique-names-generator';
import './App.css'
import PetCard from './PetCard';

export interface IPet {
  id:          string;
  name:        string;
  type:        PetType;
  description: string;
}

export enum PetType{
  Cat = 1,
  Dog = 2,
  Turtle = 3
}

function App() {

  
  const [pets, setPets] = useState<IPet[]>([]);

  const customConfigName: Config = {
    dictionaries: [names],
  };

  const customConfigDescription: Config = {
    dictionaries: [adjectives],
  };
  

  async function registerPet() {
    try {
      fetch('http://localhost:5248/Pets/Insert', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          name: uniqueNamesGenerator(customConfigName),
          type: Math.floor(Math.random() * (3 - 1 + 1)) + 1,
          description: uniqueNamesGenerator(customConfigDescription),
        })
      })
      .then(() => {
        getData();
      })
    } catch (error) {
      console.log('Error:', error);
    }
  }

  async function getData() {
    try {
      fetch('http://localhost:5248/Pets/GetAll', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json'
        }
      })
      .then((data) => {
        if(data.status != 200)
         return undefined;
        return data.json();
      })
      .then((data) => {
        setPets(data);
      })
    } catch (error) {
      console.log('Error:', error);
    }
  }

  useEffect(() => {
    getData();
  },[])

  return (
    <>
      <div className="navbar">
        <img src='/mypets.png' />
        <button onClick={() => registerPet()}>
          Cadastrar novo pet
        </button>
      </div>
      <div className="container-cards">
        {pets?.map((pet) => {
          return (
            <PetCard key={pet.id} pet={pet} callback={getData} />
          )
        })}
      </div>
    </>
  )
}

export default App;
