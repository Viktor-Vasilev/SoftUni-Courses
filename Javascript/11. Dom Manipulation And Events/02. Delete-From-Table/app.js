function deleteByEmail() {
    // select input field and read value
    const input = document.querySelector('input[name="email"]');

    // get tbody children
    const rows = Array.from(document.querySelector('tbody').children);

    // repeat for every row
    // -- select second cell
    // if match  - remove row
    let removed = false;

    for(let row of rows){
        if(row.children[1].textContent == input.value) {
            row.remove();
            removed = true;
        }
    }
   

    // if match print deleted, otherwise - not found
    if(removed){
        document.getElementById('result').textContent = 'Deleted.';
    }else {
        document.getElementById('result').textContent = 'Not found.';
    };
   
}