// using UnityEngine;

public class BoardManager0
{
//     private Piece[][] board;
//     private int boardSize;

//     public BoardManager0(int size)
//     {
//         boardSize = size;
//         board = new Piece[boardSize][];

//         // 初期化（ピラミッド状のセル数に合わせて各行の配列サイズを設定）
//         for (int i = 0; i < boardSize; i++)
//         {
//             if (i < boardSize / 2)
//             {
//                 board[i] = new Piece[i * 2 + 1];
//             }
//             else
//             {
//                 board[i] = new Piece[(boardSize - i - 1) * 2 + 1];
//             }
//         }

//         // 初期化（すべてのセルを空にする）
//         for (int i = 0; i < boardSize; i++)
//         {
//             for (int j = 0; j < board[i].Length; j++)
//             {
//                 board[i][j] = null;
//             }
//         }
//     }

//     // private Piece[][] board;
//     // private int boardSize;

//     // public BoardManager(int size)
//     // {
//     //     boardSize = size;
//     //     board = new Piece[size][];
//     //     for (int i = 0; i < size; i++)
//     //     {
//     //         int rowSize = i < size / 2 ? i + 1 : size - i;
//     //         board[i] = new Piece[rowSize];
//     //     }
//     // }

//     // 石の設置可能を判定するメソッド
//     public bool CanPlacePiece(int row, int col, Piece piece)
//     {
//         // 範囲外のマスは設置不可
//         if (row < 0 || row >= boardSize || col < 0 || col >= board[row].Length)
//         {
//             return false;
//         }

//         // 既に石が存在する場合は設置不可
//         if (board[row][col] != null)
//         {
//             return false;
//         }

//         return true;
//     }

//     //追加ルールに適応してるかの判定
//     public bool CanPlacePieceRule(int row, int col, Piece piece){

//         // 上下左右のマスをチェック
//         if (HasAdjacentPiece(row - 1, col, piece.color) ||
//             HasAdjacentPiece(row + 1, col, piece.color) ||
//             HasAdjacentPiece(row, col - 1, piece.color) ||
//             HasAdjacentPiece(row, col + 1, piece.color))
//         {
//             return true; // 隣接するマスに同じ色の石が存在する場合は設置可能
//         }

//         return false;
//     }

//     // 指定したマスに隣接するマスに同じ色の石が存在するかを判定するメソッド
//     private bool HasAdjacentPiece(int row, int col, Color color)
//     {
//         if (row < 0 || row >= boardSize || col < 0 || col >= board[row].Length)
//         {
//             return false;
//         }

//         if (board[row][col] != null && board[row][col].color == color)
//         {
//             return true;
//         }

//         return false;
//     }

//     public Piece GetCellPiece(int row, int column)
//     {
//         // セルのピースを取得
//         if (IsValidCell(row, column))
//         {
//             return board[row][column];
//         }
//         else
//         {
//             // インデックスが範囲外の場合はエラーコード（例: null）を返すなどのエラーハンドリングを行う
//             return null;
//         }
//     }

//     public void SetCellPiece(int row, int column, Piece piece)
//     {
//         // セルにピースを設定
//         if (IsValidCell(row, column))
//         {
//             board[row][column] = piece;
//         }
//         else
//         {
//             // インデックスが範囲外の場合はエラーハンドリングを行う
//             Debug.LogError("Invalid cell index: (" + row + ", " + column + ")");
//         }
//     }

//     private bool IsValidCell(int row, int column)
//     {
//         // インデックスが範囲内かどうかを判定
//         if (row < 0 || row >= boardSize || column < 0)
//         {
//             return false;
//         }

//         if (row < boardSize / 2)
//         {
//             return column < board[row].Length;
//         }
//         else
//         {
//             int invertedRow = boardSize - row - 1;
//             return column < board[invertedRow].Length;
//         }
//     }


//     public void PrintBoard()
//     {
//         for (int i = 0; i < boardSize; i++)
//         {
//             string rowString = "";

//             if (i < boardSize / 2)
//             {
//                 int spaceCount = (boardSize / 2) - i;
//                 rowString += new string(' ', spaceCount);
//                 for (int j = 0; j < board[i].Length; j++)
//                 {
//                     Piece piece = board[i][j];
//                     if (piece != null)
//                     {
//                         rowString += "P"; // P はピースの表現
//                     }
//                     else
//                     {
//                         rowString += "-";
//                     }
//                 }
//             }
//             else
//             {
//                 int invertedRow = boardSize - i - 1;
//                 int spaceCount = (boardSize / 2) - invertedRow;
//                 rowString += new string(' ', spaceCount);
//                 for (int j = 0; j < board[invertedRow].Length; j++)
//                 {
//                     Piece piece = board[invertedRow][j];
//                     if (piece != null)
//                     {
//                         rowString += "P";
//                     }
//                     else
//                     {
//                         rowString += "-";
//                     }
//                 }
//             }

//             Debug.Log(rowString);
//         }
//     }


//         // IDから座標を取得するメソッド
//     public (int row, int col) GetCoordinatesFromId(int id)
//     {
//         int currentId = 0;
//         for (int row = 0; row < boardSize; row++)
//         {
//             for (int col = 0; col < board[row].Length; col++)
//             {
//                 if (currentId == id)
//                 {
//                     return (row, col);
//                 }
//                 currentId++;
//             }
//         }

//         // IDに対応する座標が見つからなかった場合は (-1, -1) を返す
//         return (-1, -1);
//     }

//     // 座標からIDを取得するメソッド
//     public int GetIdFromCoordinates(int row, int col)
//     {
//         int currentId = 0;
//         for (int i = 0; i < row; i++)
//         {
//             currentId += board[i].Length;
//         }
//         currentId += col;
//         return currentId;
//     }
}
