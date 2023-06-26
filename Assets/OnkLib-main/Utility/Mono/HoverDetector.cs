using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isHovering = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHovering)
        {
            isHovering = true;
            StartHover();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isHovering)
        {
            isHovering = false;
            StopHover();
        }
    }

    protected virtual void StartHover()
    {
        // マウスオーバー時の共通処理
    }

    protected virtual void StopHover()
    {
        // マウスオーバー時の共通処理停止処理
    }
}
