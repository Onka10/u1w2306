using UnityEngine;
using UniRx;
using System.Collections.Generic;

public class PieceCount
{
    private Dictionary<Color, int> pieceCount;
    private HashSet<Color> colorVariety;

    public PieceCount(Tile[][] board)
    {
        pieceCount = new Dictionary<Color, int>();
        colorVariety = new HashSet<Color>();
        CountPieces(board);
    }

    private void CountPieces(Tile[][] board)
    {
        foreach (var row in board)
        {
            foreach (var tile in row)
            {
                if (tile.isIn.Value && tile.piece != null)
                {
                    Color pieceColor = tile.piece.Value.GetColor();
                    IncrementPieceCount(pieceColor);
                    colorVariety.Add(pieceColor);
                }
            }
        }
    }

    private void IncrementPieceCount(Color color)
    {
        if (pieceCount.ContainsKey(color))
        {
            pieceCount[color]++;
        }
        else
        {
            pieceCount[color] = 1;
        }
    }

    /// <summary>
    /// 引数として受け取った色のピースの個数を返します。
    /// </summary>
    public int GetCount(Color color)
    {
        if (pieceCount.ContainsKey(color))
        {
            return pieceCount[color];
        }
        return 0;
    }

    /// <summary>
    /// ボード内の色の種類の数を返します。
    /// </summary>
    public int GetColorVariety()
    {
        // colorVariety ハッシュセット内の要素数（色の種類の数）を取得して返します。
        return colorVariety.Count;
    }
}