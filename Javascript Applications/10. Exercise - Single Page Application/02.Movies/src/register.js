// initialization
// - find relevant section

import { showView } from './dom.js';

// - detach section from DOM
const section = document.getElementById('form-sign-up');
section.remove();

// display logic - трябва да изпразни съдържанието на страницата и да добави своето
export function showRegister() {
    showView(section);
}



