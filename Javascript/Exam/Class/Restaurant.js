class Restaurant {
    constructor(budget) {
        this.budgetMoney = Number(budget);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }
 
    loadProducts(arr) {
        for (let el of arr) {
            let [name, quantity, totalPrice] = el.split(' ');
            quantity = Number(quantity);
            totalPrice = Number(totalPrice);
 
            if (totalPrice <= this.budgetMoney) {
                if (!this.stockProducts[name]) {
                    this.stockProducts[name] = quantity;
                }
                this.stockProducts[name] += quantity;
                this.budgetMoney -= totalPrice;
                this.history.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }
 
        return this.history.join('\n');
    }
 
    addToMenu(meal, neededProducts, price) {
        if (!this.menu[meal]) {
            this.menu[meal] = [neededProducts, Number(price)];
            let objLength = this.objSize(this.menu);
 
            if (objLength == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            } else {
                return `Great idea! Now with the ${meal} we have ${objLength} meals in the menu, other ideas?`;
            }
 
        } else {
            return `The ${meal} is already in the our menu, try something different.`;
        }
    }
 
    objSize(obj) {
        let size = 0, key;
 
        for (key in obj) {
            if (obj.hasOwnProperty(key)) size++;
        }
        return size;
    }
 
    showTheMenu() {
        if (this.objSize(this.menu) == 0) {
            return "Our menu is not ready yet, please come later...";
        }
        let result = '';
 
        for (const food in this.menu) {
            result += `${food} - $ ${this.menu[food][1]}\n`;
        }
 
        return result.trim();
    }
 
    makeTheOrder(meal) {
        if (Object.keys(this.menu).includes(meal)) {
            let hasAllProducts = true;
 
            for (let el of this.menu[meal][0]) {
                let [demandedProduct, demandedQuantity] = el.split(' ');
                demandedQuantity = Number(demandedQuantity);
                if (demandedQuantity > this.stockProducts[demandedProduct]) {
                    hasAllProducts = false;
                }
            }
 
            if (hasAllProducts) {
                for (let el of this.menu[meal][0]) {
                    let [demandedProduct, demandedQuantity] = el.split(' ');
                    this.stockProducts[demandedProduct] -= Number(demandedQuantity);
                }
 
                this.budgetMoney += this.menu[meal][1];
                return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal][1]}.`
 
            } else {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`
            }
 
        } else {
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }
    }
}