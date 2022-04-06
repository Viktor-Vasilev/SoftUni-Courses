const bookSelection = require('./bookSelection');
const {expect} = require('chai');
const {assert} = require('chai');

describe('bookSelection', () => {

    describe('bookSelection', () => {
        it('not working', () => {
            expect(bookSelection.isGenreSuitable('Thriller', 2)).to.equal('Books with Thriller genre are not suitable for kids at 2 age');
        });
        it('not working', () => {
            expect(bookSelection.isGenreSuitable('Horror', 4)).to.equal('Books with Horror genre are not suitable for kids at 4 age');
        });
        it('not working', () => {
            expect(bookSelection.isGenreSuitable('Thriller', 12)).to.equal('Books with Thriller genre are not suitable for kids at 12 age');
        });
        it('not working', () => {
            expect(bookSelection.isGenreSuitable('Horror', 12)).to.equal('Books with Horror genre are not suitable for kids at 12 age');
        });
        it('work', () => {
            expect(bookSelection.isGenreSuitable('Horror', 66)).to.equal('Those books are suitable');
        });
        it('work', () => {
            expect(bookSelection.isGenreSuitable('Thriller', 13)).to.equal('Those books are suitable');
        });
        
    });

describe('isItAffordable', () => {
    it('work', () => {
        expect(bookSelection.isItAffordable(6, 7)).to.equal('Book bought. You have 1$ left');
    });
    it('work', () => {
        expect(bookSelection.isItAffordable(1, 1)).to.equal('Book bought. You have 0$ left');
    });
    it('work', () => {
        expect(bookSelection.isItAffordable(2.5, 3)).to.equal('Book bought. You have 0.5$ left');
    });
    it('work', () => {
        expect(bookSelection.isItAffordable(2, 2.5)).to.equal('Book bought. You have 0.5$ left');
    });
    it('work', () => {
        expect(bookSelection.isItAffordable(3.5, 4.5)).to.equal('Book bought. You have 1$ left');
    });
    it('not work', () => {
        expect(bookSelection.isItAffordable(9, 8)).to.equal("You don't have enough money");
    });
    it('not work', () => {
        expect(bookSelection.isItAffordable(4, 3.5)).to.equal("You don't have enough money");
    });
    it('not work', () => {
        expect(bookSelection.isItAffordable(7.5, 6.5)).to.equal("You don't have enough money");
    });
    it('not work', () => {
        expect(bookSelection.isItAffordable(4, 3.5)).to.equal("You don't have enough money");
    });
    it('not work', () => {
        expect(() => bookSelection.isItAffordable('b')).to.throw('Invalid input');
    });
    it('not work', () => {
        expect(() => bookSelection.isItAffordable('')).to.throw('Invalid input');
    });
    it('not work', () => {
        expect(() => bookSelection.isItAffordable(-2)).to.throw('Invalid input');
    });


});

describe('suitableTitles', () => {
    it('not work', () => {
        expect(() => bookSelection.suitableTitles(4, 'b')).to.throw('Invalid input');
    });
    it('not work', () => {
        expect(() => bookSelection.suitableTitles('c', 'c')).to.throw('Invalid input');
    });
    it('not work', () => {
        expect(() => bookSelection.suitableTitles([{title: "The Da Vinci Code", genre: "Thriller" },{ title: "Moon Shadow", genre: "Thriller"} ], 9)).to.throw('Invalid input');
    });
    it("work", function () {
        assert.deepEqual(bookSelection.suitableTitles([{title: 'The Da Vinci Code', genre: 'Thriller'}], 'Thriller'), ['The Da Vinci Code']);

    });

});

  
});