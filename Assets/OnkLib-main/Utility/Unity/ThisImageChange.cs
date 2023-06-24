using UnityEngine;
using UnityEngine.UI;

public class ThisImageChange : MonoBehaviour
{
    public void ChangeImageColor(GameObject obj, Color color)
    {
        if (obj == null)
        {
            Debug.LogError("Object is null. Cannot change image color.");
            return;
        }

        Image[] images = obj.GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image != null)
            {
                image.color = color;
            }
        }
    }

    public void ChangeImageSprite(GameObject obj, Sprite sprite)
    {
        if (obj == null)
        {
            Debug.LogError("Object is null. Cannot change image sprite.");
            return;
        }

        Image[] images = obj.GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image != null)
            {
                image.sprite = sprite;
            }
        }
    }
}