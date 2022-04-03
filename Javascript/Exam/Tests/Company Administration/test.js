const companyAdministration = require('./companyAdministration');
const { expect } = require('chai');

describe('companyAdministration', () => {

    describe('hiringEmployee', () => {
        it('throw', () => {
            expect(() => companyAdministration.hiringEmployee('Pesho', 'skier', 5)).to.throw(`We are not looking for workers for this position.`);
        });

        it('work', () => {
            expect(companyAdministration.hiringEmployee('Pesho', 'Programmer', 5)).to.equal(`Pesho was successfully hired for the position Programmer.`);
        });

        it('3', () => {
            expect(companyAdministration.hiringEmployee('Pesho', 'Programmer', 3)).to.equal(`Pesho was successfully hired for the position Programmer.`);
        });

        it('2', () => {
            expect(companyAdministration.hiringEmployee('Pesho', 'Programmer', 2)).to.equal(`Pesho is not approved for this position.`);
        });

        it('4.5', () => {
            expect(companyAdministration.hiringEmployee('Ivan', 'Programmer', 4.5)).to.equal(`Ivan was successfully hired for the position Programmer.`);
        });

    });

    describe('companyAdministration', () => {
        
        describe('calculateSalary', () => {
            it('throw', () => {
                expect(() => companyAdministration.calculateSalary('9')).to.throw("Invalid hours");
            });

            it('throw', () => {
                expect(() => companyAdministration.calculateSalary('c')).to.throw("Invalid hours");
            });
            it('throw', () => {
                expect(() => companyAdministration.calculateSalary(undefined)).to.throw("Invalid hours");
            });

            it('throw', () => {
                expect(() => companyAdministration.calculateSalary(null)).to.throw("Invalid hours");
            });

            it('throw', () => {
                expect(() => companyAdministration.calculateSalary()).to.throw("Invalid hours");
            });

            it('throw', () => {
                expect(() => companyAdministration.calculateSalary(-6)).to.throw("Invalid hours");
            });

            it('bonus', () => {
                expect(companyAdministration.calculateSalary(20)).to.equal(300);
            });

            it('bonus', () => {
                expect(companyAdministration.calculateSalary(1.5)).to.equal(22.5);
            });

            it('bonus', () => {
                expect(companyAdministration.calculateSalary(300)).to.equal(5500);
            });

            it('bonus', () => {
                expect(companyAdministration.calculateSalary(160)).to.equal(2400);
            });
            it('bonus', () => {
                expect(companyAdministration.calculateSalary(161)).to.equal(3415);
            });
        });

    });

    describe('companyAdministration', () => {

        describe('firedEmployee', () => {
            it('throw', () => {
                expect(() => companyAdministration.firedEmployee('Pesho', 1)).to.throw("Invalid input");
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee(2)).to.throw("Invalid input");
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee(2, 2)).to.throw("Invalid input");
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee(null, 1)).to.throw("Invalid input");
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee(undefined, 2)).to.throw("Invalid input");
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee([], 1)).to.throw("Invalid input");
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee((["Petar", 2, "George"], 9)).to.throw("Invalid input"));
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee((["Petar", "Ivan", "George"], 'b')).to.throw("Invalid input"));
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee((["Petar", "Ivan", "George"], 2.5)).to.throw("Invalid input"));
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee((["Petar", "Ivan", "George"], -2)).to.throw("Invalid input"));
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee((["Petar", "Ivan", "George"], 7)).to.throw("Invalid input"));
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee((["Petar", "Ivan", "George"], 3)).to.throw("Invalid input"));
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee((["Petar", "Ivan", "George"], null)).to.throw("Invalid input"));
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee((["Petar", "Ivan", "George"], undefined)).to.throw("Invalid input"));
            });

            it('throw', () => {
                expect(() => companyAdministration.firedEmployee((["Petar", "Ivan", "George"])).to.throw("Invalid input"));
            });

            it('work', () => {
                expect(companyAdministration.firedEmployee(["Petar", "Ivan", "George"], 1)).to.equal("Petar, George");
            });

            it('work', () => {
                expect(companyAdministration.firedEmployee(["Petar", "Ivan", "George"], 0)).to.equal("Ivan, George");
            });

            it('work', () => {
                expect(companyAdministration.firedEmployee(["Petar", "Ivan", "George"], 2)).to.equal("Petar, Ivan");
            });

            it('work', () => {
                expect(companyAdministration.firedEmployee(["George"], 0)).to.equal("");
            });
        });

    });


});