window.onload = function () {

    var canvas = document.getElementById('hexmap');

    var hexHeight,
        hexRadius,
        rectangleHeight,
        rectangleWidth,
        hexagonAngle = 0.523598776, // 30 degrees in radians
		cols = 20,
        rows = 16,
        boardWidth = 1000,
        sideLength;


    rectangleWidth = (boardWidth / (cols+0.5));// hex width
    sideLength = (rectangleWidth / 2) / Math.cos(hexagonAngle);
    hexHeight = sideLength * 2;//Math.sin(hexagonAngle) * sideLength;
    hexRadius = rectangleWidth/2;//Math.cos(hexagonAngle) * sideLength;
    rectangleHeight = 2 * sideLength;//hex height

    if (canvas.getContext) {
        var ctx = canvas.getContext('2d');

        ctx.fillStyle = "rgba(200, 0, 0, 0.4)";
        ctx.strokeStyle = "rgba(0, 200, 0, 0.2)";
        ctx.lineWidth = 1;

        drawBoard(ctx, cols, rows);

        canvas.addEventListener("mousedown", function (eventInfo) {

            var x,
                y,
                hexX,
                hexY,
                screenX,
                screenY;

            x = eventInfo.offsetX || eventInfo.layerX;
            y = eventInfo.offsetY || eventInfo.layerY;
            y = y - sideLength / 3;
            hexY = Math.floor(y / (hexHeight - (sideLength / 2)));
            hexX = Math.floor((x - (hexY % 2) * hexRadius) / (rectangleWidth));

            screenX = (hexX * rectangleWidth) + ((hexY % 2) * hexRadius);
            screenY = hexY * (hexHeight - (sideLength / 2));

            ctx.clearRect(0, 0, canvas.width, canvas.height);

            drawBoard(ctx, cols, rows);

            // Check if the mouse's coords are on the board
            if (hexX >= 0 && hexX < cols) {
                if (hexY >= 0 && hexY < rows) {
                    drawImage(ctx, screenX, screenY, rectangleWidth, rectangleHeight, sideLength);
                }
            }
        });

        canvas.addEventListener("mousemove", function (eventInfo) {
            var x,
                y,
                hexX,
                hexY,
                screenX,
                screenY;

            x = eventInfo.offsetX || eventInfo.layerX;
            y = eventInfo.offsetY || eventInfo.layerY;
            y = y - sideLength / 3;
            hexY = Math.floor(y / (hexHeight - (sideLength / 2)));
            hexX = Math.floor((x - (hexY % 2) * hexRadius) / (rectangleWidth));

            screenX = (hexX * rectangleWidth) + ((hexY % 2) * hexRadius);
            screenY = hexY * (hexHeight - (sideLength / 2));

            ctx.clearRect(0, 0, canvas.width, canvas.height);

            drawBoard(ctx, cols, rows);

            // Check if the mouse's coords are on the board
            if (hexX >= 0 && hexX < cols) {
                if (hexY >= 0 && hexY < rows) {
                    ctx.fillStyle = "rgba(200, 0, 0, 0.4)";
                    drawHexagon(ctx, screenX, screenY, true);
                    //drawImage(ctx, screenX, screenY, rectangleWidth, rectangleHeight, sideLength);
                }
            }
        });
    }

    function drawBoard(canvasContext, cols, rows) {
        var i,
            j;

        for (i = 0; i < cols; ++i) {
            for (j = 0; j < rows; ++j) {
                drawHexagon(
                    ctx,
                    i * rectangleWidth + ((j % 2) * hexRadius),
                    j * (hexHeight-(sideLength/2)),
                    false
                );
            }
        }
    }

    //function drawObjects(canvasContext, cols, rows) {
    //    var i,
    //        j;

    //    for (i = 0; i < cols; ++i) {
    //        for (j = 0; j < rows; ++j) {
    //            drawHexagon(
    //                ctx,
    //                i * rectangleWidth + ((j % 2) * hexRadius),
    //                j * (hexHeight - (sideLength / 2)),
    //                false
    //            );
    //        }
    //    }
    //}

    function drawImage(canvasContext, x, y, width, height, sideLength) {
        var el = new Image();
        el.src = "http://icons.iconarchive.com/icons/custom-icon-design/office/128/add-1-icon.png";
        y += height / 4;
        canvasContext.drawImage(el, x, y, width, sideLength);
    }

    function drawHexagon(canvasContext, x, y, fill) {
        var fill = fill || false;

        /*ctx.setLineDash([6, 30]);/*dashes are ..px and spaces are ..px*/
        canvasContext.beginPath();
        canvasContext.moveTo(x + hexRadius, y);
        canvasContext.lineTo(x + rectangleWidth, y + sideLength/2);
        canvasContext.lineTo(x + rectangleWidth, y + sideLength / 2 + sideLength);
        canvasContext.lineTo(x + hexRadius, y + rectangleHeight);
        canvasContext.lineTo(x, y + sideLength / 2 + sideLength);
        canvasContext.lineTo(x, y + sideLength / 2);
        canvasContext.closePath();

        if (fill) {
            canvasContext.fill();
        } else {
            canvasContext.stroke();
        }
    }
}();