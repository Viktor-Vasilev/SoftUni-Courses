const pizzUni = require('./pizza');
const {expect} = require('chai');

describe('pizza', () => {

    describe('makeAnOrder', () => {
        it('pizza only', () => {
            let order = {orderedPizza: 'Margaritta'};
            expect(pizzUni.makeAnOrder(order)).to.equal(`You just ordered ${order.orderedPizza}`);
        });
        it('pizza and drink', () => {
            let order = {orderedPizza: 'Margaritta', orderedDrink: 'boza'};
            expect(pizzUni.makeAnOrder(order)).to.equal(`You just ordered ${order.orderedPizza} and ${order.orderedDrink}.`);
        });
        it('throw with blanc object', () => {
            let order = {};
            expect(() => pizzUni.makeAnOrder(order)).to.throw();
        });
        it('throw with only drink', () => {
            let order = {orderedDrink: 'boza'};
            expect(() => pizzUni.makeAnOrder(order)).to.throw();
        });
        it('throw no object', () => {

            expect(() => pizzUni.makeAnOrder()).to.throw();
        });
       
    });


    describe('getRemainingWork', () => {
        it('All orders are complete - 1 order', () => {
            let statusArr = [{pizzaName: 'Margaritta', status: 'ready'}];
            expect(pizzUni.getRemainingWork(statusArr)).to.equal('All orders are complete!');
        });
        it('All orders are complete - 2 order', () => {
            let statusArr = [{pizzaName: 'Margaritta', status: 'ready'}, {pizzaName: 'Boloneze', status: 'ready'}];
            expect(pizzUni.getRemainingWork(statusArr)).to.equal('All orders are complete!');
        });
        it('1 Incomplete - 2 order', () => {
            let statusArr = [{pizzaName: 'Margaritta', status: 'preparing'}, {pizzaName: 'Boloneze', status: 'ready'}];
            expect(pizzUni.getRemainingWork(statusArr)).to.equal(`The following pizzas are still preparing: Margaritta.`);
        });
        it('2 Incomplete - 2 order', () => {
            let statusArr = [{pizzaName: 'Margaritta', status: 'preparing'}, {pizzaName: 'Boloneze', status: 'preparing'}];
            expect(pizzUni.getRemainingWork(statusArr)).to.equal(`The following pizzas are still preparing: Margaritta, Boloneze.`);
        });
        it('2 Incomplete - 3 order', () => {
            let statusArr = [{pizzaName: 'Margaritta', status: 'preparing'}, {pizzaName: 'Boloneze', status: 'preparing'}, {pizzaName: 'Italiana', status: 'ready'}];
            expect(pizzUni.getRemainingWork(statusArr)).to.equal(`The following pizzas are still preparing: Margaritta, Boloneze.`);
        });


    });


    describe('orderType', () => {
        it('case Carry Out', () => {
            expect(pizzUni.orderType(10, 'Carry Out')).to.equal(9);
        });
        it('case CDelivery', () => {
            expect(pizzUni.orderType(10, 'Delivery')).to.equal(10);
        });
// Test with floating point?? 
// Test with negative values??
        
    });

  
});