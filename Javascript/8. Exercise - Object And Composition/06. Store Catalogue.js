function storeCatalogue(arr) {
    const productCataloque = {};

    arr.forEach((element) => {
        let [productName, price] = element.split(" : ");
        price = Number(price);
        const index = productName[0];
        if(!productCataloque[index]){
            productCataloque[index] = {};
        }
        productCataloque[index][productName] = price;   
    })
    
    let initialSort = Object.keys(productCataloque).sort((a, b) => a.localeCompare(b));
    for(const key of initialSort){
        let products = Object.entries(productCataloque[key]).sort((a, b) => a[0].localeCompare(b[0]));
        console.log(key);
        products.forEach((element) => {
            console.log(`  ${element[0]}: ${element[1]}`);
        })
    }

    
}

storeCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);
storeCatalogue(['Banana : 2',
    'Rubics Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
);