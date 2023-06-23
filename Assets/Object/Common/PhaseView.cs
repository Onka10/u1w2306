using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class PhaseView : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject blend;
    [SerializeField] GameObject Parent;

    public Vector3 BeforePosition;//480/270
    public Vector3 AfterPosition;
    private Tweener moveTweener;

    // Start is called before the first frame update
    void Start()
    {
        PhaseManager.I.Phase
        .Where(p => p == GamePhase.InGame)
        .Subscribe(_ =>{
            Hide_title();
            Show_blend();
        })
        .AddTo(this);


        PhaseManager.I.IsMoved
        .Subscribe(m => Moved(m))
        .AddTo(this);
    }

    void Moved(bool m)
    {
        if (m)
        {
            MoveTo(AfterPosition, 0.2f);
        }
        else
        {
            MoveTo(BeforePosition, 0.2f);
        }
    }
    void MoveTo(Vector3 targetPosition, float moveDuration)
    {
        if (moveTweener != null && moveTweener.IsActive())
        {
            moveTweener.Kill();
        }

        moveTweener = Parent.transform.DOMove(targetPosition, moveDuration).SetEase(Ease.Linear);
    }

    void Show_title(){
        title.SetActive(true);
    }

    void Show_blend(){
        blend.SetActive(true);
    }

    void Hide_title(){
        title.SetActive(false);
    }
}
