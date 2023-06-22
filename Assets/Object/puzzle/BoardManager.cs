using UnityEngine;
using UniRx;

public class BoardManager
{
    private int boardSize;
    private Tile[][] board;

    public BoardManager()
    {
        boardSize = 5;//ややこいからハードコード
        board = new Tile[boardSize][];

        // 初期化（菱形状のセル数に合わせて各行の配列サイズを設定）
        for (int i = 0; i < boardSize; i++)
        {
            if (i < boardSize / 2)
            {
                board[i] = new Tile[i * 2 + 1];
            }
            else
            {
                board[i] = new Tile[(boardSize - i - 1) * 2 + 1];
            }
        }

        // 初期化（すべてのセルを生成して空にする）
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                board[i][j] = new Tile();
            }
        }
    }

    public Tile GetTile(int row, int col)
    {
        if (IsValidPosition(row, col))
        {
            return board[row][col];
        }
        return null;
    }

    public Tile GetTile(int id)
    {
        int row = BoardUtility<Tile>.GetCoordinatesFromId(id, board).row;
        int col = BoardUtility<Tile>.GetCoordinatesFromId(id, board).col;

        if (IsValidPosition(row, col))
        {
            return board[row][col];
        }
        return null;
    }

    public void PlacePiece(int id, Piece piece)
    {
        int row = BoardUtility<Tile>.GetCoordinatesFromId(id, board).row;
        int col = BoardUtility<Tile>.GetCoordinatesFromId(id, board).col;

        Tile tile = GetTile(row, col);
        if (tile != null)
        {
            tile.SetPiece(piece);
        }
    }


    //チェックするやつ
    //石が置けるかを判定しれくれる
    public bool CanPlacePiece(int id)
    {
        int row = BoardUtility<Tile>.GetCoordinatesFromId(id, board).row;
        int col = BoardUtility<Tile>.GetCoordinatesFromId(id, board).col;

        if (!IsValidPosition(row, col))
        {
            return false;
        }

        // 指定したセルにピースが既に存在するかチェック
        return !board[row][col].isIn.Value;
    }

    public bool CanPlacePiece(int row, int col)
    {

        if (!IsValidPosition(row, col))
        {
            return false;
        }

        // 指定したセルにピースが既に存在するかチェック
        return !board[row][col].isIn.Value;
    }

    //有効な座標かどうか
    private bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < boardSize && col >= 0 && col < board[row].Length;
    }



    //便利なやつ
    //============================================================

    public int GetTotalTiles()
    {
        int totalTiles = 0;
        for (int i = 0; i < boardSize; i++)
        {
            totalTiles += board[i].Length;
        }
        return totalTiles;
    }


    public PieceCount CountPieces()
    {
        PieceCount pieceCount = new PieceCount(board);

        return pieceCount;
    }

    public Tile[][] GetBoard(){
        return board;
    }


        //判定＝＝＝＝＝＝＝＝＝
        // public void CheckMatchingCells(int matchCount)
        // {
        //     for (int i = 0; i < boardSize; i++)
        //     {
        //         for (int j = 0; j < board[i].Length; j++)
        //         {
        //             if (IsMatchingCell(i, j, matchCount))
        //             {
        //                 Debug.Log("Matching cells found at (" + i + ", " + j + ")");
        //             }
        //             // else    Debug.Log("No Matching");
                    
        //         }
        //     }
        // }

        // private bool IsMatchingCell(int row, int col, int matchCount)
        // {
        //     if (!CanPlacePiece(row, col))
        //     {
        //         return false;
        //     }

        //     Piece piece = GetTile(row, col).piece.Value;
        //     if (piece == null)
        //     {
        //         return false;
        //     }

        //     Color targetColor = GetTile(row, col).piece.Value.GetColor();

        //     // Check horizontal matching cells
        //     if (col + matchCount - 1 < board[row].Length)
        //     {
        //         bool isHorizontalMatch = true;
        //         for (int k = 1; k < matchCount; k++)
        //         {
        //             if (!CanPlacePiece(row, col + k) || GetTile(row, col + k).piece.Value.GetColor() != targetColor)
        //             {
        //                 isHorizontalMatch = false;
        //                 break;
        //             }
        //         }
        //         if (isHorizontalMatch)
        //         {
        //             return true;
        //         }
        //     }

        //     // Check vertical matching cells
        //     if (row + matchCount - 1 < boardSize)
        //     {
        //         bool isVerticalMatch = true;
        //         for (int k = 1; k < matchCount; k++)
        //         {
        //             if (!CanPlacePiece(row + k, col) || GetTile(row + k, col).piece.Value.GetColor() != targetColor)
        //             {
        //                 isVerticalMatch = false;
        //                 break;
        //             }
        //         }
        //         if (isVerticalMatch)
        //         {
        //             return true;
        //         }
        //     }

        //     // Check diagonal matching cells (top-left to bottom-right)
        //     if (row + matchCount - 1 < boardSize && col + matchCount - 1 < board[row].Length)
        //     {
        //         bool isDiagonalMatch = true;
        //         for (int k = 1; k < matchCount; k++)
        //         {
        //             if (!CanPlacePiece(row + k, col + k) || GetTile(row + k, col + k).piece.Value.GetColor() != targetColor)
        //             {
        //                 isDiagonalMatch = false;
        //                 break;
        //             }
        //         }
        //         if (isDiagonalMatch)
        //         {
        //             return true;
        //         }
        //     }

        //     // Check diagonal matching cells (top-right to bottom-left)
        //     if (row + matchCount - 1 < boardSize && col - (matchCount - 1) >= 0)
        //     {
        //         bool isDiagonalMatch = true;
        //         for (int k = 1; k < matchCount; k++)
        //         {
        //             if (!CanPlacePiece(row + k, col - k) || GetTile(row + k, col - k).piece.Value.GetColor() != targetColor)
        //             {
        //                 isDiagonalMatch = false;
        //                 break;
        //             }
        //         }
        //         if (isDiagonalMatch)
        //         {
        //             return true;
        //         }
        //     }

        //     return false;
        // }

}
