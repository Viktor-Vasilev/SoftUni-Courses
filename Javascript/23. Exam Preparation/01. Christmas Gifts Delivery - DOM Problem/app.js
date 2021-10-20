function solution() {
    // attach event listeners to input form
    const [gifts, sent, discarded] = document.querySelectorAll('section ul'); // референция към трите секции
    const input = document.querySelector('input'); // референция към input полето
    document.querySelector('button').addEventListener('click', addGift); // само закачаме listener към бутона

    // create gift elements with buttons
    function addGift() {
        const name = input.value;  //взимаме името на подаръка
        input.value = ''; //зачистваме input полето

        const element = e('li', name, 'gift'); // правим елемент li с name и клас gift

        const sendBtn = e('button', 'Send', 'sendButton'); // правим бутон с име Send и клас sendButton
        const discardBtn = e('button', 'Discard', 'discardButton'); // правим бутон с име Discard и клас discardButton
        element.appendChild(sendBtn); // закачаме бутоните за li
        element.appendChild(discardBtn); // закачаме бутоните за li

        sendBtn.addEventListener('click', () => sendGift(name, element)); // закачаме listener към бутона и му подаваме данните
        discardBtn.addEventListener('click', () =>  discardGift(name, element)); // закачаме listener към бутона и му подаваме данните

        gifts.appendChild(element); // закачаме елемента към gifts

        sortGifts(); // викаме сортиращата функция
    }

    // logic for sending gifts
    function sendGift(name, gift) {
        // remove element from original list
        gift.remove();
        // create new list item
        const element = e('li', name, 'gift'); // правим елемент li с name и клас gift
        // add element to new list
        sent.appendChild(element);
    }

    // logic for discarding gifts
    function discardGift(name, gift) {
         // remove element from original list
         gift.remove();
         // create new list item
         const element = e('li', name, 'gift'); // правим елемент li с name и клас gift
         // add element to new list
         discarded.appendChild(element);
    }

    // sort gifts lists
    function sortGifts() {
        Array.
        from(gifts.children)
        .sort((a, b) => a.textContent // .sort((a,b) => a.childNodes[0].textContent.localeComapre(b.childNodes[0].textContent))
        .localeCompare(b.textContent))
        .forEach(g => gifts.appendChild(g));
        
    }

    function e(type, content, className) {
        const result = document.createElement(type);
        result.textContent = content;

        if (className) {
            result.className = className;
        }

        return result;

    }
}