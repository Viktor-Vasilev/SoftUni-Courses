window.addEventListener("load", solve);

function solve() {

    let title = document.getElementById('post-title');
    let category = document.getElementById('post-category');
    let content = document.getElementById('post-content');
    let btnPublish = document.getElementById('publish-btn');
    let btnClear = document.getElementById('clear-btn');

    let postForReview = document.getElementById('review-list');
    let publishedList = document.getElementById('published-list');

    // let holdData = { title: `${title.value}`, category: `${category.value}`, content: `${content.value}` };
    btnPublish.addEventListener('click', postContent);

    function postContent(ev) {
        ev.preventDefault();


        if (title.value.trim() && category.value.trim() && content.value.trim()) {
            // btnPublish.style.display = 'none'; //////////////////

            let li = document.createElement('li');
            li.className = 'rpost';

            let article = makeArticleElement(title, category, content);
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
            document.querySelector
                //2.Edit information
            btnEdit.addEventListener('click', (e) => {
                let input = e.target.parentElement;
                let ta = input.querySelector('h4');
                let cat = input.querySelectorAll('p')[0];
                let co = input.querySelectorAll('p')[1];

                title.value = ta.textContent;
                category.value = cat.textContent.replace('Category: ', '');
                content.value = co.textContent.replace('Content: ', '');

                e.target.parentElement.parentElement.remove();

            });

            btnApprove.addEventListener('click', (e) => {

                let element = e.target.parentElement.parentElement;
                let rr = element.querySelectorAll('button');
                rr[0].remove();
                rr[1].remove();

                publishedList.appendChild(element);
                // e.target.parentElement.parentElement.remove();
            });

            btnClear.addEventListener('click', (e) => {
                let ull = document.getElementById('published-list');

                ull.innerHTML = '';
            })
            title.value = '';
            category.value = '';
            content.value = '';

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
