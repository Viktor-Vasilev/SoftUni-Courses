function heroicInventory(arr) {
    const result = [];

    arr.forEach((el) => {
        let [name, level, items] = el.split(" / ");
        result.push({
            name: name,
            level: Number(level),
            items: items ? items.split(", ") : [] // проверка дали ни подават масив !!
        })
    })
    return JSON.stringify(result);
}



console.log(heroicInventory(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
));
console.log(heroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']));