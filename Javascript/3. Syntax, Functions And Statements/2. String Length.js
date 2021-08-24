function strlen(a, b, c) {
    let totalLength = 0;
    totalLength += a.length;
    totalLength += b.length;
    totalLength += c.length;

    let averageLength = Math.floor(totalLength / 3);

    console.log(totalLength);
    console.log(averageLength);
}

strlen('chocolate', 'ice cream', 'cake');
strlen('pasta', '5', '22.3');