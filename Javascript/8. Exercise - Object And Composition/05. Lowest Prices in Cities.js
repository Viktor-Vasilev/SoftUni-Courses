function lowestPrices(arr) {

    let cataloque = {};

    arr.forEach((element) => {
        let [town, product, price] = element.split(" | ");
        price = Number(price);

        if(!cataloque[product]){
            cataloque[product] = {};
        }

        cataloque[product][town] = price;
    });

    //console.log(cataloque);

   for(const prod in cataloque) {
       const sorted = Object.entries(cataloque[prod]).sort((a, b) => a[1] - b[1])
       console.log(`${prod} -> ${sorted[0][1]} (${sorted[0][0]})`);
   }

}

lowestPrices(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
);