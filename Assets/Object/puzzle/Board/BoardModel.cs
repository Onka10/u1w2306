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
            if (!tile.IsIn.Value)
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

    public int GetSize(){
        return size;
    }

    public Tile[,] GetTile(){
        return tiles;
    }

    public Dictionary<Color, int> ExploreBoard()
    {
        Dictionary<Color, int> pieceCount = new Dictionary<Color, int>();

        foreach (Tile tile in tiles)
        {
            if (tile != null && tile.IsIn.Value)
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
}
