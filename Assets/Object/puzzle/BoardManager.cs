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
    public bool CanPlacePiece(int id, Piece piece)
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



}
