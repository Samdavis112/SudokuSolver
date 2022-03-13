const solveButton = document.getElementById("solveButton");
const clearButton = document.getElementById("clearButton");

function getCell(rowNumber, colNumber){
    const row = document.querySelector(`#Row${rowNumber}`);
    const cell = row.querySelector(`#Col${colNumber}`);
    
    //console.log(cell.firstChild.value);
    return cell.firstChild.value;
}

function setCell(rowNumber, colNumber, data){
    const row = document.querySelector(`#Row${rowNumber}`);
    const cell = row.querySelector(`#Col${colNumber}`);
    
    //console.log(cell.firstChild.value);
    cell.firstChild.value = data;
}

function clear(){
    for(let i = 1; i < 10; i++){
        for(let j = 1; j< 10; j++){
            try{setCell(i, j , "");}
            catch{}
        }
    }
}

function setAllBoard(){
    for(let l = 0; l < 9; l++){
        for(let s = 0; s < 9; s++){
            try{
                if(board[l][s] === "" || board[l][s] === "."){
                    board[l][s] = "";
                }
                setCell((l + 1),( s + 1),board[l][s]);
            }
            catch{}
        }
    }
}

function readBoard(){
    for(let l = 0; l < 9; l++){
        for(let s = 0; s < 9; s++){
            board[l][s] = getCell((l + 1),( s + 1));
            if(board[l][s] == "" || board[l][s] == " "){
                board[l][s] = '.';
            }
        }
    }
}

let board =[
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ]];
    
function solve(){
    readBoard();
    //console.log(board);
    solveSudoku();
    //console.log(board);
    setAllBoard();
    console.log(board);
}

function solveSudoku(){
    if(board == null || board.length == 0){
        return;
    }
    solveBoard(board);
}

function solveBoard(){
    for(let i = 0; i < 9; i++){
        for(let j = 0; j < 9; j++){
            if(board[i][j] == '.'){
                for(let c = 1; c <= 9; c++){
                    if(isValid(i, j, c)){
                        board[i][j] = c;

                        if(solveBoard()){
                            return true;
                        }
                        else{
                            board[i][j] = '.';
                        }
                    }
                }
                return false;
            }
        }
    }
    return true;
}

function isValid(row, col, c){
    for(let h = 0; h < 9; h++){
        //check row  
        if ((board[h][col] != '.') && (board[h][col] == c)){
            return false;
        }
        //check column  
        if ((board[row][h] != '.') && (board[row][h] == c)){
            return false;
        }
        //check 3*3 block  
        if (board[Math.floor(3 * Math.floor(row / 3) + h / 3)][(3 * Math.floor(col / 3)) + ( h % 3)] != '.' 
        && board[Math.floor(3 * Math.floor(row / 3) + h / 3)][3 * Math.floor(col / 3) + h % 3] == c){
            return false;
        }
    }
    return true;
}

function main(){
    solveButton.addEventListener('click', function(){
        solve();
    });
    clearButton.addEventListener('click', function(){
        clear();
    });
}
main();
