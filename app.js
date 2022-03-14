//Variables that reference HTML elements.
const solveButton = document.querySelector("#solveButton");
const clearButton = document.querySelector("#clearButton");

//A function to get the data within a specific cell.
function getCell(rowNumber, colNumber){
    const row = document.querySelector(`#Row${rowNumber}`);
    const cell = row.querySelector(`#Col${colNumber}`);
    
    //console.log(cell.firstChild.value);
    return cell.firstChild.value;
}

//A procedure to set the data within a specific cell.
function setCell(rowNumber, colNumber, data){
    const row = document.querySelector(`#Row${rowNumber}`);
    const cell = row.querySelector(`#Col${colNumber}`);
    
    //console.log(cell.firstChild.value);
    cell.firstChild.value = data;
}

//A procedure that clears all cells by looping through the set cell proceure with data ""
function clear(){
    for(let i = 1; i < 10; i++){
        for(let j = 1; j< 10; j++){
            try{setCell(i, j , "");}
            catch{}
        }
    }
}

//A procedure that fills in the HTML board with the 2d array "Board"
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

//A procedure that fills the 2d array "Board" with the data from the HTML table
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

//2d array "Board"
let board =[
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.' ],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
    ['.', '.', '.', '.', '.', '.', '.', '.', '.']
];
   
//The main solve procedure that calls multiple functions.
function solve(){
    readBoard();
    //console.log(board);
    solveSudoku();
    //console.log(board);
    setAllBoard();
    console.log(board);
}

function solveSudoku() {
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

//Main procedure that adds event listeners to the clear and solve buttons.
function main(){
    solveButton.addEventListener('click', function(){
        solve();
    });
    clearButton.addEventListener('click', function(){
        clear();
    });
}
main();
