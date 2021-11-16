// initialization
// - find relevant section

import { showView } from './dom.js';
import { showDetails } from "./details.js";

// - detach section from DOM
const section = document.getElementById('add-movie');
section.remove();

// display logic - трябва да изпразни съдържанието на страницата и да добави своето
export function showCreate() {
    showView(section);
}

// ------------------ //

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
  
    const movie = {
      title: formData.get("title"),
      description: formData.get("description"),
      img: formData.get("imageUrl"),
    };
    
    const userData = JSON.parse(sessionStorage.getItem('userData'));

    const response = await fetch("http://localhost:3030/data/movies", {
      method: "post",
      headers: {
        "Content-Type": "application/json",
        "X-Authorization": userData.token,
      },
      body: JSON.stringify(movie),
    });
  
    if (response.ok) {
      const movie = await response.json();
      showDetails(movie._id);
    } else {
      const err = await response.json();
      alert(err.message);
    }
  }



