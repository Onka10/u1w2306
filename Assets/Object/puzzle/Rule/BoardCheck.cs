using System.Collections.Generic;
using UnityEngine;

public class BoardCheck
{
    private BoardModel board;
    private int size;
    private Dictionary<Tile, int> exploredCells; // 探索済みセルの結果をキャッシュするための辞書

    public BoardCheck(BoardModel board)
    {
        this.board = board;
        this.exploredCells = new Dictionary<Tile, int>();
        this.size = board.GetSize();
    }

    public int CountFilledTiles()
    {
        int filledTileCount = 0;

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Tile tile = board.GetTile(row, col);

                if (tile != null && tile.IsIn.Value && tile.piece.Value != null)
                {
                    filledTileCount++;
                }
            }
        }

        return filledTileCount;
    }

    public float GetFilledTileRatio()
    {
        int filledTileCount = CountFilledTiles();
        int totalTileCount = 13; // 画面に隠れているセルの数

        if (totalTileCount > 0)
        {
            return (float)filledTileCount / totalTileCount;
        }
        else
        {
            return 0f;
        }
    }

    public Color GetMostUsedColor()
    {
        Dictionary<Color, int> pieceCount = board.ExploreBoard();
        Color mostUsedColor = Color.clear;
        int maxCount = 0;

        foreach (KeyValuePair<Color, int> pair in pieceCount)
        {
            if (pair.Value > maxCount)
            {
                maxCount = pair.Value;
                mostUsedColor = pair.Key;
            }
        }

        return mostUsedColor;
    }

    public Color MixColorsByFrequency()
    {
        Dictionary<Color, int> pieceCount = board.ExploreBoard();

        // 各色の出現回数の総和を計算
        int totalFrequency = 0;
        foreach (KeyValuePair<Color, int> pair in pieceCount)
        {
            totalFrequency += pair.Value;
        }

        // 各色を混ぜた結果の色を計算
        Color mixedColor = Color.black;  // 初期値を黒とする
        foreach (KeyValuePair<Color, int> pair in pieceCount)
        {
            // 出現回数に比例した割合で色を混ぜる
            float ratio = (float)pair.Value / totalFrequency;
            mixedColor += pair.Key * ratio;
        }

        return mixedColor;
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
                Tile tile = board.GetTile(row, col);

                if (tile != null && tile.IsIn.Value)
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
                Tile tile = board.GetTile(row, col);

                if (tile != null && tile.IsIn.Value)
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
