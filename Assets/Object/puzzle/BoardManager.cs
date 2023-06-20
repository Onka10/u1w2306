using UnityEngine;
using UniRx;

public class BoardManager
{
    private int boardSize;
    private Tile[][] board;

    public BoardManager(int size)
    {
        boardSize = size;
        board = new Tile[boardSize][];

        // 初期化（ピラミッド状のセル数に合わせて各行の配列サイズを設定）
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

    public void PlacePiece(int row, int col, Piece piece)
    {
        Tile tile = GetTile(row, col);
        if (tile != null)
        {
            tile.SetPiece(piece);
        }
    }


    //チェックするやつ
    //石が置けるかを判定しれくれる
    //隣接するマスにPieceが存在し、かつそのPieceのColorが同じでない場合は、石の設置ができません。
    public bool CanPlacePiece(int row, int col, Piece piece)
    {
        if (!IsValidPosition(row, col))
        {
            return false;
        }

        // 隣接するセルに同じ色のピースが存在するかチェック
        if (HasAdjacentPiece(row, col, piece.color))
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

    //隣接するセルに同じ色のピースが存在するかどうかをチェックします。もし隣接するセルに同じ色のピースが存在する場合は false を返します
    private bool HasAdjacentPiece(int row, int col, Color color)
    {
        // 上下左右のセルをチェック
        int[][] directions = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        foreach (int[] dir in directions)
        {
            int adjacentRow = row + dir[0];
            int adjacentCol = col + dir[1];
            if (IsValidPosition(adjacentRow, adjacentCol) && board[adjacentRow][adjacentCol].isIn.Value && board[adjacentRow][adjacentCol].piece.Value.color == color)
            {
                return true;
            }
        }
        return false;
    }





    //便利なやつ
    //============================================================

    // IDから座標を取得するメソッド
    public (int row, int col) GetCoordinatesFromId(int id)
    {
        int currentId = 0;
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                if (currentId == id)
                {
                    return (row, col);
                }
                currentId++;
            }
        }

        // IDに対応する座標が見つからなかった場合は (-1, -1) を返す
        return (-1, -1);
    }

    // 座標からIDを取得するメソッド
    public int GetIdFromCoordinates(int row, int col)
    {
        int currentId = 0;
        for (int i = 0; i < row; i++)
        {
            currentId += board[i].Length;
        }
        currentId += col;
        return currentId;
    }


    public void PrintBoard()
    {
        for (int i = 0; i < boardSize; i++)
        {
            string rowString = "";

            if (i < boardSize / 2)
            {
                int spaceCount = (boardSize / 2) - i;
                rowString += new string(' ', spaceCount);
                for (int j = 0; j < board[i].Length; j++)
                {
                    Tile piece = board[i][j];
                    if (piece != null)
                    {
                        rowString += "-";
                    }
                    else
                    {
                        rowString += "p";// P はピースの表現
                    }
                }
            }
            else
            {
                int invertedRow = boardSize - i - 1;
                int spaceCount = (boardSize / 2) - invertedRow;
                rowString += new string(' ', spaceCount);
                for (int j = 0; j < board[invertedRow].Length; j++)
                {
                    Tile piece = board[invertedRow][j];
                    if (piece != null)
                    {
                        rowString += "-";
                    }
                    else
                    {
                        rowString += "p";// P はピースの表現
                    }
                }
            }

            Debug.Log(rowString);
        }
    }

    public int GetTotalTiles()
    {
        int totalTiles = 0;
        for (int i = 0; i < boardSize; i++)
        {
            totalTiles += board[i].Length;
        }
        return totalTiles;
    }
}
