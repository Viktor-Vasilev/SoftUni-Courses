function solve(day) {
    const weekDays = {
      "Monday": 1,
      "Tuesday": 2,
      "Wednesday": 3,
      "Thursday": 4,
      "Friday": 5,
      "Saturday": 6,
      "Sunday": 7
    }
  
    return weekDays[day] ? weekDays[day] : "error";
}

console.log(solve("Monday"));
console.log(solve("Friday"));
console.log(solve("Invalid"));
