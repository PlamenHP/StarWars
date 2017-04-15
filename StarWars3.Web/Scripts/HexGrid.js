window.onload = function () {
    var canvas = document.getElementById('hexmap');

    var hexHeight,
        hexRadius,
        hexRectangleHeight,
        hexRectangleWidth,
        hexagonAngle = 0.523598776, // 30 degrees in radians
		boardWidth = 20,
        boardHeight = 16;
        sideLength = 1024 / boardWidth / 1.8,


    hexHeight = Math.sin(hexagonAngle) * sideLength;
    hexRadius = Math.cos(hexagonAngle) * sideLength;
    hexRectangleHeight = sideLength + 2 * hexHeight;
    hexRectangleWidth = 2 * hexRadius;

    if (canvas.getContext) {
        var ctx = canvas.getContext('2d');

        ctx.fillStyle = "rgba(200, 0, 0, 0.4)";
        ctx.strokeStyle = "rgba(0, 200, 0, 0.2)";
        ctx.lineWidth = 1;

        drawBoard(ctx, boardWidth, boardHeight);

        canvas.addEventListener("mousemove", function (eventInfo) {
            var x,
                y,
                hexX,
                hexY,
                screenX,
                screenY;

            x = eventInfo.offsetX || eventInfo.layerX;
            y = eventInfo.offsetY || eventInfo.layerY;


            hexY = Math.floor(y / (hexHeight + sideLength));
            hexX = Math.floor((x - (hexY % 2) * hexRadius) / hexRectangleWidth);

            screenX = hexX * hexRectangleWidth + ((hexY % 2) * hexRadius);
            screenY = hexY * (hexHeight + sideLength);

            ctx.clearRect(0, 0, canvas.width, canvas.height);

            drawBoard(ctx, boardWidth, boardHeight);

            // Check if the mouse's coords are on the board
            if (hexX >= 0 && hexX < boardWidth) {
                if (hexY >= 0 && hexY < boardHeight) {
                    ctx.fillStyle = "rgba(200, 0, 0, 0.4)";
                    drawHexagon(ctx, screenX, screenY, true);
                    drawImage(ctx, screenX, screenY, hexRectangleWidth, hexRectangleHeight, sideLength);
                }
            }
        });
    }

    function drawBoard(canvasContext, width, height) {
        var i,
            j;

        for (i = 0; i < width; ++i) {
            for (j = 0; j < height; ++j) {
                drawHexagon(
                    ctx,
                    i * hexRectangleWidth + ((j % 2) * hexRadius),
                    j * (sideLength + hexHeight),
                    false
                );
            }
        }
    }

    function drawImage(canvasContext, x, y, width, height, sideLength) {
        var el = new Image();
        el.src = "../../Content/icon.jpg";
        y += height / 4;
        canvasContext.drawImage(el, x, y, width, sideLength);
    }

    function drawHexagon(canvasContext, x, y, fill) {
        var fill = fill || false;

        /*ctx.setLineDash([6, 30]);/*dashes are ..px and spaces are ..px*/
        canvasContext.beginPath();
        canvasContext.moveTo(x + hexRadius, y);
        canvasContext.lineTo(x + hexRectangleWidth, y + hexHeight);
        canvasContext.lineTo(x + hexRectangleWidth, y + hexHeight + sideLength);
        canvasContext.lineTo(x + hexRadius, y + hexRectangleHeight);
        canvasContext.lineTo(x, y + sideLength + hexHeight);
        canvasContext.lineTo(x, y + hexHeight);
        canvasContext.closePath();

        if (fill) {
            canvasContext.fill();
        } else {
            canvasContext.stroke();
        }
    }
}();