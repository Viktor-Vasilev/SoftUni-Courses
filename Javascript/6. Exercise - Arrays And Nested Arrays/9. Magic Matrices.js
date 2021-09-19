function magicMatrices(matrix){
    let wantedSum = matrix[0].reduce((a, b) => a + b);
    let isMagic = true;

    for (let i = 0; i < matrix.length; i++) {
        let sumRows = matrix[i].reduce((a, b) => a + b);
        let sumCols = matrix.map(x => x[i]).reduce((a, b) => a + b);

        if (sumRows !== wantedSum || sumCols !== wantedSum) {
            isMagic = false;
            break;
        }

    }
    console.log(isMagic);
}


(magicMatrices([[4, 5, 6],
                [6, 5, 4],
                [5, 5, 5]]));

(magicMatrices([[11, 32, 45],
               [21, 0, 1],
               [21, 1, 1]]));
 
(magicMatrices([[1, 0, 0],
                [0, 0, 1],
                [0, 1, 0]]));