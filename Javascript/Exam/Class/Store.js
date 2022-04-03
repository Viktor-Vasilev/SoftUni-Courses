class VegetableStore {  
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
        this._totalPrice = 0;
    }

    loadingVegetables (vegetables) {
        let result = [];
        vegetables.forEach((el) => {
            let [type, quantity, price] = el.split(' ');

            quantity = Number(quantity);
            price = Number(price);

            if (!this.availableProducts.some(p => p.type == type)) {
                this.availableProducts.push({
                    type,
                    quantity,
                    price,
                });
                result.push(type);
            } else {
                let currentProduct = this.availableProducts.find(p => p.type == type);
                currentProduct.quantity += quantity;

                if (currentProduct.price < price) {
                    currentProduct.price = price;
                }
            }
        });
        return 'Successfully added ' + result.join(', ');
    }

    buyingVegetables (selectedProducts) {
        this._totalPrice = 0;
        selectedProducts.forEach((el) => {
            let [type, quantity] = el.split(' ');

            quantity = Number(quantity);

            let currentProduct = this.availableProducts.find(p => p.type == type);

            if (currentProduct == undefined) {
                throw new Error(`${type} is not available in the store, your current bill is $${this._totalPrice.toFixed(2)}.`);
            } else {
                if (currentProduct.quantity < quantity) {
                    throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${this._totalPrice.toFixed(2)}.`)
                } else {
                    this._totalPrice += (quantity * currentProduct.price);
                    const index = this.availableProducts.indexOf(currentProduct);
                    this.availableProducts[index].quantity -= quantity;
                }
            }
        });
        return `Great choice! You must pay the following amount $${this._totalPrice.toFixed(2)}.`
    }

    rottingVegetable (type, quantity) {
        let currentProduct = this.availableProducts.find(p => p.type == type);
        const index = this.availableProducts.indexOf(currentProduct);

        if (currentProduct == undefined) {
            throw new Error(`${type} is not available in the store.`);
        } else {
            if (currentProduct.quantity < quantity) { 
                this.availableProducts[index].quantity = 0;
                return `The entire quantity of the ${type} has been removed.`;
            } else {
                this.availableProducts[index].quantity -= quantity;
                return `Some quantity of the ${type} has been removed.`
            }
        }
    }

    revision () {
        const result = [
            'Available vegetables:'
        ];

        this.availableProducts.sort(p => p.price).reverse();

        for (const product of this.availableProducts) {
            result.push(`${product.type}-${product.quantity}-$${product.price}`);
        }

        result.push(`The owner of the store is ${this.owner}, and the location is ${this.location}.`);
        return result.join('\n');
    }
}


let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());