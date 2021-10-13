const { expect } = require('chai');
const isSymmetric = require('./5. Check for Symmetry');

describe('Symmetry Checker', () => {
    it('return true for symmetric array', () => {
        expect(isSymmetric([1, 2, 2, 1])).to.be.true;
    });

    it('return false for non-symmetric array', () => {
        expect(isSymmetric([1, 2, 3])).to.be.false;
    });

    it('return false for type different symmetric array', () => {
        expect(isSymmetric([1, 2, '1'])).to.be.false;
    });

    it('returns false for non-array', () => {
        expect(isSymmetric(5)).to.be.false;
    });

    it('return true for symmetric array of odd elements', () => {
        expect(isSymmetric([1, 2, 1])).to.be.true;
    });

    it('return true for symmetric array of strings', () => {
        expect(isSymmetric(['a','b', 'b', 'a'])).to.be.true;
    });

    it('return false for non-symmetric array of strings', () => {
        expect(isSymmetric(['a','c', 'b', 'a'])).to.be.false;
    });

    it('return false for non-array string', () => {
        expect(isSymmetric('abba')).to.be.false;
    });

});
