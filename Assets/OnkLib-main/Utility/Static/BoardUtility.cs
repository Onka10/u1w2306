using UnityEngine;

public class BoardUtility<T>
{

    public static int ConvertCoordinateToId(int row, int col,int size)
    {
        return row * size + col;
    }

    public static Vector2Int ConvertIdToCoordinate(int id, int size)
    {
        int row = id / size;
        int col = id % size;
        return new Vector2Int(row, col);
    }


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
}
