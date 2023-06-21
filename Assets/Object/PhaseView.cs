using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     Debug.Log("es");
        //     Hide();
        // }

        // if (Input.GetKeyDown(KeyCode.Z))
        // {
        //     Debug.Log("es");
        //     Show();
        // }

    
    }

    [SerializeField] GameObject obj;

    public void Show(){
        obj.SetActive(true);
    }

    public void Hide(){
        obj.SetActive(false);
    }
}
