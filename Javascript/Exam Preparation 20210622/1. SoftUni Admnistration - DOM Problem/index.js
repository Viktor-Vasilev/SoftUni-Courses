function solve() {
    let buttonElement = document.querySelector('.admin-view .action button'); // взимаме си бутона
    //console.log(buttonElement);
    buttonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let lectures = {}; // правим обект, където да държим всички модули

        //взимаме си референции към полетата
        let lectureNameElement = document.querySelector('input[name="lecture-name"]');
        let lectureDateElement = document.querySelector('input[name="lecture-date"]');
        let lectureModuleElement = document.querySelector('select[name="lecture-module"]');
        //console.log(lectureModuleElement.value);
        //console.log(lectureDateElement.value); - виждаме как ни дава формата на датата и часа

        // проверка дали не са празни полетата
        if(!lectureDateElement.value || !lectureDateElement){ // 
            return;
        }

        // проверка дали полето не е на дефолтна стойност
        if(lectureModuleElement.value == 'Select module') {
            return;
        }
        // console.log('works')

        if(!lectures[lectureModuleElement.value]) { // проверяваме дали има такъв модул, ако няма го създаваме
            lectures[lectureModuleElement.value] = [];
        }

        // правим обект с масив в него, където да държим всичко
        let currentLecture = {name: lectureNameElement.value, data: formatDate(lectureDateElement.value)};
        lectures[lectureModuleElement.value].push(currentLecture);


        // създаваме си lecture
        let liElement = document.createElement('li'); // създаваме li елемент
        liElement.classList.add('flex'); // добавяме му клас

        let courseHeadingelement = document.createElement('h4'); //създаваме h4 елемент

        courseHeadingelement.textContent = 
        `${lectureNameElement.value} - ${formatDate(lectureDateElement.value)}`; // създаваме лекцията
        //console.log(formatDate(lectureDateElement.value));

        let deleteButtonElement = document.createElement('button'); //създаваме бутона
        deleteButtonElement.classList.add('red'); // добавяме му класа
        deleteButtonElement.textContent = 'Del'; // добавяме му текста

        // навързваме ги
        liElement.appendChild(courseHeadingelement);
        liElement.appendChild(deleteButtonElement);
        //console.log(liElement);


        // създаваме Module
        let moduleElement = createModule(lectureModuleElement.value, liElement);

        // взимаме референция къде да закрепим Module
        let modulesElemenet = document.querySelector('.modules');
        modulesElemenet.appendChild(moduleElement); // добавяме го


    });

    

    function createModule(name, liElement) {
        let divElement = document.createElement('div');
        divElement.classList.add('module');

        let headingElement = document.createElement('h3');
        headingElement.textContent = `${name.toUpperCase()}-MODULE`;

        let lectureListElement = document.createElement('ul');
        lectureListElement.appendChild(liElement);

        divElement.appendChild(headingElement);
        divElement.appendChild(lectureListElement);

        return divElement;
    }
    

    function formatDate(dateInput) {
        //2021-10-01T00:11
        let [date, time] = dateInput.split('T');
        date = date.replace(/-/g, '/');

        return `${date} - ${time}`;
    }


};