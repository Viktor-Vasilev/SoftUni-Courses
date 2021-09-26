// function editElement(element, match, replacer) {
//     const text = element.textContent;
//     element.textContent = text.replaceAll(match, replacer);
// }

function editElement(reference, match, replacer) {
    reference.textContent = reference.textContent.replace(new RegExp(match, 'g'), replacer);
}

function editElement(element, match, replacer) {
    const text = element.textContent;
    element.textContent = text.split(match).join(replacer);
}