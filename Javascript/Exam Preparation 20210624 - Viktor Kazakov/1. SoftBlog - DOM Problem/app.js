function solve(){
   let createButton = document.querySelector('.site-content aside button.btn.create'); // взимаме си бутона
   //console.log(createButton);
   createButton.addEventListener('click', createArticleHandler); // закачаме му функция

   function createArticleHandler(e) {
      e.preventDefault(); // премахваме презареждането

      // взимаме си инпут полетата
      let authorInput = document.querySelector('#creator');
      let titleInput = document.querySelector('#title');
      let categoryInput = document.querySelector('#category');
      let contentTextArea = document.querySelector('#content');

      // създаваме си структурата и попълваме данните, закачаме всичко 
      let articleElement = document.createElement('article');

      let titleHeading = document.createElement('h1');
      titleHeading.textContent = titleInput.value;

      let categoryParagraph = document.createElement('p');
      categoryParagraph.textContent = 'Category: ';
      let categoryStrong = document.createElement('strong');
      categoryStrong.textContent = categoryInput.value;
      categoryParagraph.appendChild(categoryStrong);

      let creatorParagraph = document.createElement('p');
      creatorParagraph.textContent = 'Creator: ';
      let creatorStrong = document.createElement('strong');
      creatorStrong.textContent = authorInput.value;
      creatorParagraph.appendChild(creatorStrong);

      let contentParagraph = document.createElement('p');
      contentParagraph.textContent = contentTextArea.value;

      let buttonsDiv = document.createElement('div');
      buttonsDiv.classList.add('buttons');

      let deleteButton = document.createElement('button');
      deleteButton.textContent = 'Delete';
      deleteButton.classList.add('btn', 'delete');
      buttonsDiv.appendChild(deleteButton);
      deleteButton.addEventListener('click', deleteArticleHandler);

      let archiveButton = document.createElement('button');
      archiveButton.textContent = 'Archive';
      archiveButton.classList.add('btn', 'archive');
      buttonsDiv.appendChild(archiveButton);
      archiveButton.addEventListener('click', archiveArticleHndler);

      articleElement.appendChild(titleHeading);
      articleElement.appendChild(categoryParagraph);
      articleElement.appendChild(creatorParagraph);
      articleElement.appendChild(contentParagraph);
      articleElement.appendChild(buttonsDiv);

      let postsSection = document.querySelector('.site-content main section');
      postsSection.appendChild(articleElement);

   }
   function deleteArticleHandler(e) { 
      let deleteButton = e.target; // взимаме си event-target
      let articleToDelete = deleteButton.parentElement.parentElement; // намираме го в структурата
      articleToDelete.remove(); // премахваме го
   }

   function archiveArticleHndler(e) {
      let archiveButton = e.target; // взимаме си event-target
      let articleToArchive = archiveButton.parentElement.parentElement; // намираме го в структурата

      let archiveOl = document.querySelector('.archive-section ol'); // взимаме мястото където да добавим заглавието

      // правим масив за секцията
      let archiveLis = Array.from(archiveOl.querySelectorAll('li'));

      //взимаме си заглавието
      let aricleTitleHeading = articleToArchive.querySelector('h1');
      let articleTitle = aricleTitleHeading.textContent;

      // правим новия елемент и му подаваме заглавието
      let newTitleLi = document.createElement('li');
      newTitleLi.textContent = articleTitle;

      // зачистваме от секцията
      articleToArchive.remove();

      // вкараме го в масива
      archiveLis.push(newTitleLi);

      // сортираме и добавяме
      archiveLis
      .sort((a, b) => a.textContent
      .localeCompare(b.textContent))
      .forEach(li => archiveOl.appendChild(li));

   }
  }
