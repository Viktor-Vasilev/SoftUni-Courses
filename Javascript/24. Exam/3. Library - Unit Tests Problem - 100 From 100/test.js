const library = require('./library');
const {expect} = require('chai');

describe('library', () => {

    describe('calcPriceOfBook', () => {
        it('correct price, normal book', () => {
            expect(library.calcPriceOfBook('book', 2000)).to.equal(`Price of book is 20.00`);
        });

        it('correct price, old book', () => {
            expect(library.calcPriceOfBook('book', 1970)).to.equal(`Price of book is 10.00`);
        });

        it('correct price, old book, exactly 1980', () => {
            expect(library.calcPriceOfBook('book', 1980)).to.equal(`Price of book is 10.00`);
        });

        it('year not integer, throws', () => {
            expect(() => library.calcPriceOfBook('book', 'a')).to.throw(`Invalid input`);
        });

        it('book not string, throws', () => {
            expect(() => library.calcPriceOfBook(1, 2000)).to.throw(`Invalid input`);
        });

        it('undefined1', () => {
            expect(() => library.calcPriceOfBook(undefined, 2000)).to.throw(`Invalid input`);
        });

        it('undefined2', () => {
            expect(() => library.calcPriceOfBook('book', undefined)).to.throw(`Invalid input`);
        });

        it('undefined3', () => {
            expect(() => library.calcPriceOfBook(undefined, undefined)).to.throw(`Invalid input`);
        });

    });


    describe('findBook', () => {
       
        it('throws empty array', () => {
            expect(() => library.findBook([], 'book')).to.throw("No books currently available");
        });

        it('correct book find', () => {
            expect(library.findBook(['book', 'book1', 'book2'], 'book1')).to.equal("We found the book you want.");
        });

        it('no book found', () => {
            expect(library.findBook(['book', 'book1', 'book2'], 'book9')).to.equal("The book you are looking for is not here!");
        });

    });

    describe('arrangeTheBooks', () => {
        it('countbook not a number - string', () => {
            expect(() => library.arrangeTheBooks('a')).to.throw("Invalid input");
        });

        it('countbook not a number - undefined', () => {
            expect(() => library.arrangeTheBooks(undefined)).to.throw("Invalid input");
        });

        it('countbook not a number - minus integer', () => {
            expect(() => library.arrangeTheBooks(-1)).to.throw("Invalid input");
        });

        it('countbook not a number - floating pint', () => {
            expect(() => library.arrangeTheBooks(1.5)).to.throw("Invalid input");
        });

        it('succsefull arrange', () => {
            expect(library.arrangeTheBooks(20)).to.equal("Great job, the books are arranged.");
        });

        it('succsefull arrange, 40 books', () => {
            expect(library.arrangeTheBooks(40)).to.equal("Great job, the books are arranged.");
        });

        it('unsuccsefull arrange, more than 40 books', () => {
            expect(library.arrangeTheBooks(41)).to.equal("Insufficient space, more shelves need to be purchased.");
        });
        
    });

});