/* main module:
// init other modules with dependencies:
// - rendering
// - communication between modules

// in catalog module:
// list module:
// display list of books
// control books (edit, delete)

// in create module
// create module
// control create form (validation) 

// in update module
// update module:
// control edit form

// in utlity module
// api module:
// load books
// edit book
// delete book
// create book
*/

import { showCatalog } from './catalog.js';
import { showCreate } from './create.js';
import { showUpdate } from './update.js';
import { render } from './utility.js';
// main module:
// init other modules with dependencies:
// - rendering
// - communication between modules

const root = document.body;

const ctx = {
    update   // ???
};

update();

function update() {
    render([
        showCatalog(ctx),
        showCreate(ctx),
        showUpdate(ctx)
    ], root);
}
