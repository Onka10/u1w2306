using UnityEngine;

public class BoardInspector
{
    private BoardModel boardModel;

    public BoardInspector(BoardModel boardModel)
    {
        this.boardModel = boardModel;
    }

    public void InspectTiles()
    {
        Tile[,] tiles = boardModel.GetTile();

        for (int row = 0; row < boardModel.GetSize(); row++)
        {
            string rowLog = "Row " + row + ": ";

            for (int col = 0; col < boardModel.GetSize(); col++)
            {
                Tile tile = tiles[row, col];

                if (tile != null)
                {
                    rowLog += tile.IsIn.Value + ", ";
                }
                else
                {
                    rowLog += "null, ";
                }
            }

            Debug.Log(rowLog);
        }
    }

    public void InspectTiles2()
    {
        Tile[,] tiles = boardModel.GetTile();

        for (int row = 0; row < boardModel.GetSize(); row++)
        {
            string rowLog = "Row " + row + ": ";

            for (int col = 0; col < boardModel.GetSize(); col++)
            {
                Tile tile = tiles[row, col];

                if (tile != null)
                {
                    if (tile.piece.Value != null)
                    {
                        rowLog += "● ";
                    }
                    else
                    {
                        rowLog += "□ ";
                    }
                }
                else
                {
                    rowLog += "null ";
                }
            }

            Debug.Log(rowLog);
        }
    }

    public void InspectTiles3()
    {
        Tile[,] tiles = boardModel.GetTile();

        for (int row = 0; row < boardModel.GetSize(); row++)
        {
            string rowLog = "Row " + row + ": ";

            for (int col = 0; col < boardModel.GetSize(); col++)
            {
                Tile tile = tiles[row, col];

                if (tile != null)
                {
                    if (tile.piece.Value != null)
                    {
                        Color color = tile.piece.Value.GetColor();

                        if (color == Color.red)
                        {
                            rowLog += "赤 ";
                        }
                        else if (color == Color.blue)
                        {
                            rowLog += "青 ";
                        }
                        else if (color == Color.green)
                        {
                            rowLog += "緑 ";
                        }
                    }
                    else
                    {
                        rowLog += "□ ";
                    }
                }
                else
                {
                    rowLog += "null ";
                }
            }

            Debug.Log(rowLog);
        }
    }



}
