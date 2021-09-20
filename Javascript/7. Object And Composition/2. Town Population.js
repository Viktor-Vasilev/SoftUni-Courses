function townPopulation(townsAsStrings) {

    const towns = {};

    for (let data of townsAsStrings) {
        const tokens = data.split(' <-> ');

        const name = tokens[0];
        const population = Number(tokens[1]);

        if (towns[name] == undefined) {
            towns[name] = population;
        } else {
            towns[name] += population;
        }
    }

    for (const name in towns) {
        console.log(`${name} : ${towns[name]}`);
    }
}

townPopulation(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);
townPopulation(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
);