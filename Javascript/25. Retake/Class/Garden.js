class Garden {
	constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
        
    }

    addPlant(plantName, spaceRequired) {
        if (this.spaceAvailable < spaceRequired) {
            throw new Error("Not enough space in the garden.");
        }

        let plant = {
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        };

        this.spaceAvailable -= spaceRequired;

        this.plants.push(plant);

        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant(plantName, quantity) {
        let currentPlant = this.plants.find(c => c.plantName == plantName)

        if (!currentPlant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (currentPlant.ripe == true) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        currentPlant.ripe = true;

        currentPlant.quantity += quantity;

        if (quantity == 1) {
            return `${quantity} ${plantName} has successfully ripened.`;
        } else {
            return `${quantity} ${plantName}s have successfully ripened.`;
        }

    }

    harvestPlant(plantName) {
        let currentPlant = this.plants.find(c => c.plantName == plantName)

        if (!currentPlant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (currentPlant.ripe == false) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.plants = this.plants.filter(c => c.plantName != currentPlant.plantName);

        this.storage.push(currentPlant);

        this.spaceAvailable -= currentPlant.spaceRequired;

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport() {
        let result = [];
        result.push(`The garden has ${ this.spaceAvailable } free space left.`);
        result.push(`Plants in the garden: `)

        let sortedPlants = this.plants
        .slice()
        .sort((a, b) => a.plantName.localeCompare(b.plantName))
        .forEach(c => {
            
            result.push(`${c.plantName}`)
        });

        if (this.storage.length == 0) {
            result.push('Plants in storage: The storage is empty.');
        } else {
            result.push('Plants in storage: ');
            this.storage
            .sort((a, b) => a.plantName
            .localeCompare(b.plantName))
            .forEach(s => result
            .push(`${s.plantName} - ${s.quantity}`));
        }

        return result.join(" ,");
    }

}
// 1
// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('olive', 50));

// 2
// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('orange', 4));

// 3
// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('orange', 4));

// 4
// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('cucumber', -5));

// 5
// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 200));
// console.log(myGarden.addPlant('raspberry', 10));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.harvestPlant('apple'));
// console.log(myGarden.harvestPlant('olive'));

// 6
const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());
