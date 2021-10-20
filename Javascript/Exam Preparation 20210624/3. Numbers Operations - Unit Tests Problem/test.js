const numberOperations = require('./numberOperations');
const {expect} = require('chai');

describe('numberOperations', () => {

    describe('powNumber', () => {
        it('works with positive numbers', () => {
            expect(numberOperations.powNumber(6)).to.equal(36);
        });
       
    });

    // describe('numberChecker', () => {
    //     it('', () => {
    //         expect(.()).to.equal();
    //     });


    // });

    // describe('sumArrays', () => {
    //     it('', () => {
    //         expect(.()).to.equal();
    //     });

        
    // });

  
});