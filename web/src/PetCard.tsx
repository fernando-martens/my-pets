import React, { useState } from 'react';
import CancelIcon from './assets/cancelIcon.svg';
import CheckIcon from './assets/checkIcon.svg';
import DeleteIcon from './assets/deleteIcon.svg';
import { IPet, PetType } from './App';


const PetCard: React.FC<{ pet: IPet, callback: Function }> = ({ pet, callback }) => {

  const [requestDelete, setRequestDelete] = useState(false);

  async function deletePet() {
    try {
      fetch('http://localhost:5248/Pets/Delete', {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(pet) 
      }).then(() => {
        callback();
      })
    } catch (error) {
      console.log('Error:', error);
    }
  }

  function convertType(type: PetType){
    switch (type) {
      case PetType.Cat:
        return "🐈 Gato";
      case PetType.Dog:
        return "🐕 Cachorro"
      case PetType.Turtle:
        return "🐢 Tartaruga"
      default:
        return ""
    }
  }

  return (
    <div key={pet.id} className="card">
      <div className="infos">
      {convertType(pet.type)} - {pet.name}
      </div>
      <div className="buttons">
        {requestDelete ? (
          <>
            <button onClick={() => setRequestDelete(false)}>
              <img src={CancelIcon} />
            </button>
            <button onClick={() => deletePet()}>
                <img src={CheckIcon} />
            </button>
          </>
        ) : (
          <button onClick={() => setRequestDelete(true)}>
            <img src={DeleteIcon} />
          </button>
        )}
      </div>
    </div>
  );
}

export default PetCard;