using UnityEngine;
using UniRx;
using System.Collections.Generic;
using System;

public class PieceCount
{
    private Dictionary<Color, int> pieceCount;
    private List<Color> colorVariety;
    int[] matchingCounts = new int[13];

    public PieceCount(Tile[][] board)
    {
        pieceCount = new Dictionary<Color, int>();
        colorVariety = new List<Color>();
        CountPieces(board);
        MeasureAllTiles(board);
    }

    private void CountPieces(Tile[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j].isIn.Value && board[i][j].piece != null)
                {
                    Color pieceColor = board[i][j].piece.Value.GetColor();
                    IncrementPieceCount(pieceColor);
                    if (!colorVariety.Contains(pieceColor))
                    {
                        colorVariety.Add(pieceColor);
                    }
                }
            }
        }
    }

    private void MeasureAllTiles(Tile[][] board)
    {
        for(int i=0 ; i<13;i++){
            int row = BoardUtility<Tile>.GetCoordinatesFromId(i, board).row;
            int col = BoardUtility<Tile>.GetCoordinatesFromId(i, board).col;

            matchingCounts[i] = GetMatchingNeighborCount(row, col,board);
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

    private int GetMatchingNeighborCount(int row, int col, Tile[][] board)
    {
        int matchingCount = 0;
        int boardSize=5;

        try
        {
            // 上のマス
            if (row > 0)
            {
                Tile upperTile = board[row - 1][col];
                if (upperTile.isIn.Value)
                {
                    if (board[row][col].isIn.Value && upperTile.piece.Value.GetColor() == board[row][col].piece.Value.GetColor())
                    {
                        matchingCount++;
                    }
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            // 上のマスが範囲外の場合はスキップ
        }

        try
        {
            // 下のマス
            if (row < boardSize - 1)
            {
                // Debug.Log("メイン"+BoardUtility<Tile>.GetIdFromCoordinates(row,col,board));
                // Debug.Log("した"+BoardUtility<Tile>.GetIdFromCoordinates(row+1,col,board));

                Tile lowerTile = board[row + 1][col];
                if (lowerTile.isIn.Value)
                {
                    if (board[row][col].isIn.Value && lowerTile.piece.Value.GetColor() == board[row][col].piece.Value.GetColor())
                    {
                        matchingCount++;
                    }
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            // 下のマスが範囲外の場合はスキップ
        }

        try
        {
            // 左のマス
            if (col > 0)
            {
                Tile leftTile = board[row][col - 1];
                if (leftTile.isIn.Value)
                {
                    if (board[row][col].isIn.Value && leftTile.piece.Value.GetColor() == board[row][col].piece.Value.GetColor())
                    {
                        matchingCount++;
                    }
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            // 左のマスが範囲外の場合はスキップ
        }

        try
        {
            // 右のマス
            if (col < board[row].Length - 1)
            {
                Tile rightTile = board[row][col + 1];
                if (rightTile.isIn.Value)
                {
                    if (board[row][col].isIn.Value && rightTile.piece.Value.GetColor() == board[row][col].piece.Value.GetColor())
                    {
                        matchingCount++;
                    }
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            // 右のマスが範囲外の場合はスキップ
        }

        return matchingCount;
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
    public Color[] GetColorVariety()
    {
        return colorVariety.ToArray();
    }

    public int[] GetMatchCount(){
        return matchingCounts;
    }


}