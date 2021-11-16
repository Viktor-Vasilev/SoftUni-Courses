const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

// from http://localhost:3030/jsonstore/collections/books
const mockData = {
    "d953e5fb-a585-4d6b-92d3-ee90697398a0": {
        "author": "J.K.Rowling",
        "title": "Harry Potter and the Philosopher's Stone"
    },
    "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
        "author": "Svetlin Nakov",
        "title": "C# Fundamentals"
    }
};

function json(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
}

describe('Tests', async function () {
    this.timeout(5000);

    let page, browser;

    before(async () => {
        browser = await chromium.launch();
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        await (new Promise(res => setTimeout(res, 2000)));
        page = await browser.newPage();
    });

    afterEach(async () => {
        await page.close();
    });

    // it('works', async () => {
    //     await page.goto('http://localhost:5500');
    //     await page.screenshot({path: 'page.png'});
    // });

    it('loads and displays all books', async () => {
        await page.route('**/jsonstore/collections/books*', (route) => {
            route.fulfill(json(mockData))
        });
        await page.goto('http://localhost:5500');

        await page.click('text=Load All Books');

        await page.waitForSelector('text=Harry Potter');

        const rows = await page.$$eval('tr', (rows) => rows.map(r => r.textContent.trim()));

        //console.log(rows);

        expect(rows[1]).to.contains('Harry Potter');
        expect(rows[1]).to.contains('Rowling');
        expect(rows[2]).to.contains('Fundamentals');
        expect(rows[2]).to.contains('Svetlin');
    });

    it('can create book', async () => {
        await page.goto('http://localhost:5500');

        await page.fill('form#createForm >> input[name="title"]', 'Title');
        await page.fill('form#createForm >> input[name="author"]', 'Author');

        const [request] = await Promise.all([
            page.waitForRequest(request => request.method() == 'POST'),
            page.click('form#createForm >> text=Submit')
        ]);

        const data = JSON.parse(request.postData());
        expect(data.title).to.equal('Title');
        expect(data.author).to.equal('Author');

        //console.log(request);
    });

    it('delete book', async () => {
        await page.goto('http://localhost:5500');

        await page.click('#loadBooks');
        
        page.on('dialog', async dialog => {
            await dialog.accept();
        });

        await page.click('button.deleteBtn');

        await page.click('#loadBooks');

        const books = await page.$$eval('tbody > tr > td', r => r.map(td => td.textContent));

        expect(books[0]).to.equal('C# Fundamentals');
        expect(books[1]).to.equal('Svetlin Nakov');
    })

    it('edit book', async () => {
        await page.goto('http://localhost:5500');

        await page.click('#loadBooks');

        await page.click('button.editBtn');

        await page.fill('#editForm > input[type=text]:nth-child(4)', 'Harry Potter and the Philosopher\'s Stone edited');
        await page.fill('#editForm > input[type=text]:nth-child(6)', 'J.K.Rowling edited');

        await page.click('#editForm > button')

        await page.click('#loadBooks');

        const books = await page.$$eval('tbody > tr > td', r => r.map(td => td.textContent));

        expect(books).includes('Harry Potter and the Philosopher\'s Stone edited');
        expect(books).includes('J.K.Rowling edited');
    })


});