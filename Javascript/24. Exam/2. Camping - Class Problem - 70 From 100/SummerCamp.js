class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { "child": 150, "student": 300, "collegian": 500 };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {

        if (this.priceForTheCamp[condition] === undefined) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        let playerr = this.listOfParticipants.find(c => c.name == name);

        if (playerr != undefined) {
            return `The ${name} is already registered at the camp.`;
        }
        if (this.priceForTheCamp[condition] > money) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        let participant = {
            name: name,
            condition: condition,
            power: 100,
            wins: 0
        };

        this.listOfParticipants.push(participant);
        return `The ${name} was successfully registered.`;

    }

    unregisterParticipant (name) {
        let currentParticipant = this.listOfParticipants.find(c => c.name == name);

        if (!currentParticipant) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants = this.listOfParticipants.filter(c => c.name != currentParticipant.name);
        return `The ${name} removed successfully.`

    }

    timeToPlay (typeOfGame, participant1, participant2) {
        //let typeofGamesArray = ['WaterBalloonFights', 'Battleship'];

        if(typeOfGame === "WaterBalloonFights")
        {

            let currentParticipant1 = this.listOfParticipants.find(c => c.name == participant1);
            let currentParticipant2 = this.listOfParticipants.find(c => c.name == participant2);


            if(currentParticipant1 === undefined || currentParticipant2 === undefined) {
                throw new Error(`Invalid entered name/s.`);
            }

            if(currentParticipant1.condition != currentParticipant2.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if(currentParticipant1.power > currentParticipant2.power) {
                currentParticipant1.wins += 1;
                return(`The ${currentParticipant1.name} is winner in the game ${typeOfGame}.`);
            }

            if(currentParticipant2.power < currentParticipant1.power) {
                currentParticipant2.wins += 1;
                return(`The ${currentParticipant2.name} is winner in the game ${typeOfGame}.`);
            }

            if(currentParticipant1.power = currentParticipant2.power) {
                return(`There is no winner.`);
            }
            
        }

        if(typeOfGame === "Battleship")
        {
            let player = this.listOfParticipants.find(c => c.name == participant1);
            if(player === undefined) {
                throw new Error(`Invalid entered name/s.`);
            }

            this.player.power += 20;

            return(`The ${this.player.name} successfully completed the game ${typeOfGame}.`);

        }
    }

        toString() {
            let inMessage = (`${this.organizer} will take ${this.listOfParticipants} participants on camping to ${this.location}\n`);
        
        
            const result = [];
        
            result.push(inMessage);
        
            result.push(
                this.listOfParticipants.sort((a, b) => a.wins - b.wins).forEach(s => result.push(`${player.name} - ${player.condition} - ${player.power} - ${player.wins}\n`))
            )
            return result;
        
        };


    }
    
const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());

