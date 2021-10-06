function createProcessor() {
    let state = '';

    return {
        append,
        removeStart,
        removeEnd,
        print
    };

    function append(str) {
        state += str;
    }

    function removeStart(n) {
        state = state.slice(n);
    }

    function removeEnd(n) {
        state = state.slice(0, -n);
    }

    function print() {
        console.log(state);
    }
}

const firstZeroTest = createProcessor();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();


// function solution() {
//     let str = '';
//     return {
//       append: (s) => str += s,
//       removeStart: (n) => str = str.substring(n),
//       removeEnd: (n) => str = str.substring(0, str.length - n),
//       print: () => console.log(str),
//     }
//   }
  
  
//   let firstZeroTest = solution();
  
//   firstZeroTest.append('hello');
//   firstZeroTest.append('again');
//   firstZeroTest.removeStart(3);
//   firstZeroTest.removeEnd(4);