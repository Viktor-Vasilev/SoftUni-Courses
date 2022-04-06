window.addEventListener("load", solve);

function solve() {

  let inputTitle = document.getElementById('post-title');
  let inputCategory = document.getElementById('post-category');
  let inputContent = document.getElementById('post-content');
  let btnPublish = document.getElementById('publish-btn');
  let btnClear = document.getElementById('clear-btn');

  let postForReview = document.getElementById('review-list');
  let publishedList = document.getElementById('published-list');

  btnPublish.addEventListener('click', postContent);

  function postContent(ev) {
      ev.preventDefault();

      if (inputTitle.value.trim() && inputCategory.value.trim() && inputContent.value.trim()) {

          let li = document.createElement('li');
          li.className = 'rpost';

          let article = makeArticleElement(inputTitle, inputCategory, inputContent);
          li.appendChild(article);

          let btnApprove = document.createElement('button');
          btnApprove.className = 'action-btn approve';
          btnApprove.textContent = 'APPROVE';
          article.appendChild(btnApprove);

          let btnEdit = document.createElement('button');
          btnEdit.className = 'action-btn edit';
          btnEdit.textContent = 'EDIT';
          article.appendChild(btnEdit);

          postForReview.appendChild(li);

          btnEdit.addEventListener('click', (e) => {
              e.target.parentElement.parentElement.remove();

          });

          btnApprove.addEventListener('click', (e) => {

              let liRpost = document.createElement('li');
              liRpost.className = 'rpost';

              let artElement = makeArticleElement(inputTitle, inputCategory, inputContent);
              liRpost.appendChild(artElement);

              publishedList.appendChild(liRpost);

              e.target.parentElement.parentElement.remove();
              inputTitle.value = '';
              inputCategory.value = '';
              inputContent.value = '';

          });

          btnClear.addEventListener('click', (e) => {
              let list = document.getElementById('published-list');
              list.innerHTML = '';
          })
      }

  }

  function makeArticleElement(title, category, content) {

      let article = document.createElement('article');

      let h4 = document.createElement('h4');
      h4.textContent = title.value;
      article.appendChild(h4);

      let pCategory = document.createElement('p');
      pCategory.textContent = `Category: ${category.value}`;
      article.appendChild(pCategory);

      let pContent = document.createElement('p');
      pContent.textContent = `Content: ${content.value}`;
      article.appendChild(pContent);

      return article;
  }
}
