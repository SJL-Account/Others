

function getPosTop(i,j)
{
    return 20 + i * 120;

}
function getPosLeft(i, j) {
    return 20 + j* 120;

}
function getBorderBlockColor(num)
{
    switch (num) {
        case 2:
            return "#eee4da"; break;
        case 4:
            return "#eede0c8" ;break;


     

    }
}

function getNumberColor(num)
{
    if(num<=4)
    {
        return "#776e65"
    }

    return "white";

}

function noSpace(board)
{

    for (var i = 0; i < 4; i++) {

        for (var j = 0; j < 4; j++) {

            if(board[i][j]==0)
            {
                return false;
            }
        }
    }

    return true;
}

function canMove(board)
{
    //左边有没有为0的格子
    //格子相同
    for (var i = 0; i < 4; i++) {
        for (var j = 0; j < 4; j++) {
            if(board[i][j-1]==0||board[i][j]==board[i][j-1])
            {
                return true;
            }

        }

    }
    
    return false;
}
//function  updateBoardView(board)
//{
//    for (var i = 0; i < 4; i++) {
//        for (var j = 0; j < 4; j++) {
//            var number_cell = $('#number-cell-' + i + "-" + j);
//            number_cell.css("background-color", getBorderBlockColor(board[i][j]));
//            number_cell.css("color", getNumberColor(board[i][j]));
//            number_cell.text(board[i][j]);
//        }
        
//    }
//}