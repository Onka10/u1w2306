using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

public class HideButton : MonoBehaviour
{
        [SerializeField]    private TextMeshProUGUI text;
        void Start()
        {
            PhaseManager PM = PhaseManager.I;
            
            this.gameObject.GetComponent<Button>().OnClickAsObservable()
            .Subscribe(_ => PM.MoveHide())
            .AddTo(this);  

            PM.IsMoved
            .Subscribe(m => Moved(m))
            .AddTo(this);
        }

        void Moved(bool m){
        if(m){
            text.text = "▲";
        }else{
            text.text = "▼";
        }

    }
}
