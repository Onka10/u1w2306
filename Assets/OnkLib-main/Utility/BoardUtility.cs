using UnityEngine;

public class BoardUtility<T>
{
    public static (int row, int col) GetCoordinatesFromId(int id, T[][] board)
    {
        int currentId = 0;
        for (int row = 0; row < board.Length; row++)
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

        return (-1, -1);
    }

    public static int GetIdFromCoordinates(int row, int col, T[][] board)
    {
        int currentId = 0;
        for (int i = 0; i < row; i++)
        {
            currentId += board[i].Length;
        }
        currentId += col;
        return currentId;
    }

    public static void PrintBoard(T[][] board)
    {
        int boardSize = board.Length;

        for (int i = 0; i < boardSize; i++)
        {
            string rowString = "";

            if (i < boardSize / 2)
            {
                int spaceCount = (boardSize / 2) - i;
                rowString += new string(' ', spaceCount);
                for (int j = 0; j < board[i].Length; j++)
                {
                    T piece = board[i][j];
                    if (piece != null)
                    {
                        rowString += "-";
                    }
                    else
                    {
                        rowString += "p"; // P はピースの表現
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
                    T piece = board[invertedRow][j];
                    if (piece != null)
                    {
                        rowString += "-";
                    }
                    else
                    {
                        rowString += "p"; // P はピースの表現
                    }
                }
            }

            Debug.Log(rowString);
        }
    }
}
