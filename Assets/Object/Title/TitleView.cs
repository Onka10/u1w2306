using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class TitleView : MonoBehaviour
{
        void Start()
        {
            this.gameObject.GetComponent<Button>().OnClickAsObservable()
            .Where(_ => ! PhaseManager.I.IsMoved.Value)
            .Subscribe(_ =>{
                SEManager.I.Fire();
                PhaseManager.I.Play();
            })
            .AddTo(this);  
        }
}
