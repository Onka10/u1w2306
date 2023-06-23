using UnityEngine;
using System.Collections.Generic;

public class BoardModel
{
    private Tile[,] tiles; // タイルを保持する2次元配列
    private int size; // ボードのサイズ

    public BoardModel(int size)
    {
        this.size = size;
        InitializeTiles();
    }

    private void InitializeTiles()
    {
        tiles = new Tile[size, size];

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                tiles[row, col] = new Tile();
            }
        }
    }

    public Tile GetTile(int row, int col)
    {
        if (row >= 0 && row < size && col >= 0 && col < size)
        {
            return tiles[row, col];
        }
        else
        {
            Debug.LogWarning("Invalid tile coordinates: (" + row + ", " + col + ")");
            return null;
        }
    }

    public bool PlacePiece(int row, int col, Piece piece)
    {
        Tile tile = GetTile(row, col);

        if (tile != null)
        {
            if (!tile.isIn.Value)
            {
                tile.SetPiece(piece);
                return true;
            }
            else
            {
                Debug.LogWarning("Cannot place piece. Tile already occupied: (" + row + ", " + col + ")");
            }
        }
        else
        {
            Debug.LogWarning("Cannot place piece. Invalid tile coordinates: (" + row + ", " + col + ")");
        }

        return false;
    }

    public void LogBoardState()
    {
        string log = "";

        for (int col = 0; col < size; col++)
        {
            for (int row = 0; row < size; row++)
            {
                if (tiles[row, col].isIn.Value)
                {
                    log += "P ";
                }
                else
                {
                    log += "□ ";
                }
            }

            Debug.Log(log);
            log = ""; // 列ごとにログを出力した後、ログ変数をリセットする
        }
    }

    public int GetPieceCount()
    {
        int count = 0;

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Tile tile = GetTile(row, col);

                if (tile != null && tile.isIn.Value && tile.piece.Value != null)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public Dictionary<Color, int> ExploreBoard()
    {
        Dictionary<Color, int> pieceCount = new Dictionary<Color, int>();

        foreach (Tile tile in tiles)
        {
            if (tile != null && tile.isIn.Value)
            {
                Piece piece = tile.piece.Value;

                if (piece != null)
                {
                    Color color = piece.GetColor();

                    if (pieceCount.ContainsKey(color))
                    {
                        pieceCount[color]++;
                    }
                    else
                    {
                        pieceCount[color] = 1;
                    }
                }
            }
        }

        return pieceCount;
    }

    public bool HasChain(int consecutiveCount)
    {
        int verticalMatchCount = GetVerticalMatchCount(consecutiveCount);
        int horizontalMatchCount = GetHorizontalMatchCount(consecutiveCount);

        return verticalMatchCount > 0 || horizontalMatchCount > 0;
    }

        public int GetVerticalMatchCount(int consecutiveCount)
    {
        int matchCount = 0;

        for (int col = 0; col < size; col++)
        {
            int count = 1;
            Color prevColor = Color.clear;

            for (int row = 0; row < size; row++)
            {
                Tile tile = GetTile(row, col);

                if (tile != null && tile.isIn.Value)
                {
                    Piece piece = tile.piece.Value;

                    if (piece != null)
                    {
                        Color color = piece.GetColor();

                        if (color == prevColor)
                        {
                            count++;
                            if (count >= consecutiveCount)
                            {
                                matchCount++;
                                break;
                            }
                        }
                        else
                        {
                            count = 1;
                            prevColor = color;
                        }
                    }
                }
                else
                {
                    count = 1;
                    prevColor = Color.clear;
                }
            }
        }

        return matchCount;
    }

    public int GetHorizontalMatchCount(int consecutiveCount)
    {
        int matchCount = 0;

        for (int row = 0; row < size; row++)
        {
            int count = 1;
            Color prevColor = Color.clear;

            for (int col = 0; col < size; col++)
            {
                Tile tile = GetTile(row, col);

                if (tile != null && tile.isIn.Value)
                {
                    Piece piece = tile.piece.Value;

                    if (piece != null)
                    {
                        Color color = piece.GetColor();

                        if (color == prevColor)
                        {
                            count++;
                            if (count >= consecutiveCount)
                            {
                                matchCount++;
                                break;
                            }
                        }
                        else
                        {
                            count = 1;
                            prevColor = color;
                        }
                    }
                }
                else
                {
                    count = 1;
                    prevColor = Color.clear;
                }
            }
        }

        return matchCount;
    }

}
