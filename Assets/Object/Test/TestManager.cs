using System;
using System.Reflection;

public class TestManager : Singleton<TestManager>
{
    public void OverwriteSelectedPiece(HandManager handManager)
    {
        Piece newPiece = new(UnityEngine.Color.red);

        Type handManagerType = typeof(HandManager);
        FieldInfo selectedPieceField = handManagerType.GetField("selectedPiece", BindingFlags.NonPublic | BindingFlags.Instance);

        if (selectedPieceField != null)
        {
            selectedPieceField.SetValue(handManager, newPiece);
        }
        else
        {
            Console.WriteLine("Error: selectedPiece field not found.");
        }
    }
}
