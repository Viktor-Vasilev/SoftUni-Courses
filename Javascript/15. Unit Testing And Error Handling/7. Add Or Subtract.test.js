
// const { expect } = require('chai');
// const createCalculator = require('./7. Add Or Subtract');

// describe('Testing createCalculator functionality', () => {
//     it("should return 3 after add(10); subtract('7'); add('-2'); subtract(-1)", function () {
//         let calculator = createCalculator();

//         calculator.add(10);
//         calculator.subtract('7');

//         expect(calculator.get()).to.equal(3);
//     });

//     it("should return -1 add('-2'); subtract(-1)", function () {
//         let calculator = createCalculator();

//         calculator.add('-2');
//         calculator.subtract(-1);

//         expect(calculator.get()).to.equal(-1);
//     });
// });

const { expect } = require('chai');
const createCalculator = require('./7. Add Or Subtract');



describe('Calculator', () => {
    let instance = null;

    beforeEach(() => {
        instance = createCalculator();
    })


    it('has all methods', () => {
        expect(instance).to.has.ownProperty('add');
        expect(instance).to.has.ownProperty('subtract');
        expect(instance).to.has.ownProperty('get');
    });

    it('adds single number', () => {
        instance.add(1);
        expect(instance.get()).to.equal(1);  
    });

    it('adds multiple numbers', () => {
        instance.add(1);
        instance.add(2);
        expect(instance.get()).to.equal(3);  
    });

    it('subtract single number', () => {
        instance.subtract(1);
        expect(instance.get()).to.equal(-1);  
    });

    it('subtract multiple numbers', () => {
        instance.subtract(1);
        instance.subtract(2);
        expect(instance.get()).to.equal(-3);  
    });

    it('add and subtract multiple numbers', () => {
        instance.add(5);
        instance.subtract(2);
        expect(instance.get()).to.equal(3);  
    });

    it('numbers as strings add and subtract multiple numbers', () => {
        instance.add('5');
        instance.subtract('2');
        expect(instance.get()).to.equal(3);  
    });
    
    it('one number as string add and subtract multiple numbers', () => {
        instance.add(5);
        instance.subtract('2');
        expect(instance.get()).to.equal(3);  
    });

    it('2 negatives one number as string add and subtract multiple numbers', () => {
        instance.add('-2');
        instance.subtract(-1);
        expect(instance.get()).to.equal(-1);  
    });

});