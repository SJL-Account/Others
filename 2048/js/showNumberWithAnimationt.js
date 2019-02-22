function showNumberWithAnimation (i,j,randNumber)
{
    var number_cell=$('#number-cell-'+i+"-"+j);
    number_cell.css("background-color",getBorderBlockColor(randNumber));
    number_cell.css("color",getNumberColor(randNumber));
    number_cell.text(randNumber);

    number_cell.animate({
        width:"100px",
        height:"100px",
        top:getPosTop(i,j),
        left:getPosLeft(i,j)

    },50)


}

function showMoveAnimation(fromx,fromy,tox,toy)
{
    var number_cell = $("#number-cell-" + fromx + "-" + fromy);

    //alert("11");
    $("number_cell").animation({
        top: getPosTop(tox, toy),

        left:getPosLeft(tox,toy)
    },200)
    
}