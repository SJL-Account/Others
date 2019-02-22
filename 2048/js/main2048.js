var board=new Array();


$(document).ready(function () {
    newgame();
})



function newgame()
{
    //初始化格子
    init();
    //随机生成两个4和2的格子
    generateOneNumber();
    

}

function init()
{
    //初始化格子
    for (var i = 0; i < 4; i++) {

        for (var j = 0; j < 4; j++) {
            var grid_cell = jQuery("#grid-cell-"+i+"-"+j);
            grid_cell.css('top', getPosTop(i, j));
            grid_cell.css('left', getPosLeft(i, j));


        }
    }
    //初始化数组
    for (var i = 0; i < 4; i++) {

        board[i] = new Array();
        for (var j = 0; j < 4; j++) {
            board[i][j] = 0;

        }
        
    }

    //利用该函数把数组表现成格子
    updateBoardView();



}

function updateBoardView()
{
    $(".number-cell").remove();
    for (var i = 0; i <4; i++) {

        for (var j = 0; j < 4; j++) {

            $("#grid-container").append("    <div class=\"number-cell\"  id=\"number-cell-"+ i + "-" + j + "\"></div>");
            var number_cell = $("#number-cell-" + i + "-" + j);
            if(board[i][j]==0)
            {
                number_cell.css("width", "0px");
                number_cell.css("height", "0px");
                number_cell.css("top", getPosTop(i,j)+50);
                number_cell.css("left", getPosTop(i, j) + 50);


            }
            else
            {
                number_cell.css("width", "100px");
                number_cell.css("height", "100px");
                number_cell.css("top", getPosTop(i, j) );
                number_cell.css("left", getPosTop(i, j));
                number_cell.css("background-color", getBorderBlockColor(board[i][j]));
                number_cell.css("font-color", getNumberColor(board[i][j]));
            }
            
        }

    }
}

function generateOneNumber()
{
    if (noSpace(board))
    {
        return false;
    }
    else
    {
        //随机位置
        var randx = parseInt(Math.floor(Math.random() * 3));    //下取整操作
        var randy = parseInt(Math.floor(Math.random() * 3));
       
        //判断位置是否可用
        while(true)
        {
            if(board[randx][randy]==0)
            {
                break;
            }
            else
            {
                var randx = parseInt(Math.floor(Math.random() * 3));    //下取整操作
                var randy = parseInt(Math.floor(Math.random() * 3));
            }
        }

        //随机数
        var number = Math.random() > 0.5 ? 4 : 2;


        //随机数生成在随机位置上
        board[randx][randy] = number;

        showNumberWithAnimation(randx, randy, number)

        return true;
    }


}

$(document).keydown(function (event) {
    switch (event.keyCode) {
        case 37 : //left
            //是否可以移动
            if (moveLeft()) {
                //产生新的数字
                generateOneNumber();
                //是否游戏结束
                isGameOver();

            }
            break;

        case 38:  //up
            if (moveUp()) {
                //产生新的数字
                generateOneNumber();
                //是否游戏结束
                isGameOver();

            }
          
            break;

        case 39://right
            //是否可以移动
            if (moveRight()) {
                //产生新的数字
                generateOneNumber();
                //是否游戏结束
                isGameOver();

            }
            break;

        case 40://down
            //是否可以移动
            if (moveDown()) {
                //产生新的数字
                generateOneNumber();
                //是否游戏结束
                isGameOver();

            }
            break;

        default://default
            break;
    }

   

});

function moveLeft()
{
    if (!canMove(board))

    {
        return false
    }
    //向左移动

    //落脚点为0
    //落脚点和移动点数字相同
    //中间没有障碍物

    for (var i = 0; i < 4; i++) {
        //遍历所有方块，第一列不考虑，因为第一列不可移动
        for (var j = 1; j < 4; j++) {

            if (board[i][j] != 0)
            {
                for (var k = 0; k < j; k++) {
                    //落脚点和移动点数字相同
                    //中间没有障碍物
                    if(board[i][k]==0&&noBlockH(i,j,k,board))
                    {
                        showMoveAnimation(i, j, i, k);
                        board[i][k] = board[i][j];
                        //board[i][j] = 0;
                        //move
                        

                        continue;
                    }
                    else if(board[i][j]==board[i][k]&&noBlockH(i,j,k,board))
                    {
                        showMoveAnimation(i, j, i, k);
                        board[i][k] += board[i][j];
                        board[i][j] = 0;
                        //move
                        //showMoveAnimation(i, j, k, board);
                        //add
                        
                        continue;
                    }

                }
            }


        }

    }

    //更新布局
    updateBoardView();

    return true;
}

//判断是否有障碍物的函数
function noBlockH(row,col1,col2,board)
{
    for (var i = col1 + 1 ; i < col2; i++) {
        if(board[row][i]!=0)
        {
            return false;
        }

    }
    return true;
}

function isGameOver()
{

}

