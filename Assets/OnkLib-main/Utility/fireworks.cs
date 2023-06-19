using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireworks : MonoBehaviour
{
    public Transform targetPosition;
    public GameObject effectPrefab;
    public float moveSpeed = 5f;

    private bool isMoving = false;


    public void Go()
    {
        StartCoroutine(MoveToTarget());
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = targetPosition.position;

        float elapsedTime = 0f;

        while (elapsedTime < moveSpeed)
        {
            float newY = Mathf.Lerp(startPosition.y, endPosition.y, elapsedTime / moveSpeed);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, endPosition.y, transform.position.z);
        isMoving = false;

        Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Debug.Log("てすと");
        // effectPrefab.transform.localScale
        effectPrefab.transform.localPosition = Vector3.zero;

        Vector3 initialScale;
        initialScale = transform.localScale;
        effectPrefab.transform.localScale = initialScale * 5f;
    }


        // //ここからスケール
        // private Vector3 initialScale;

        // private void Start()
        // {
        //     initialScale = transform.localScale;
        // }

        // public void SetScale(float scale)
        // {
        //     transform.localScale = initialScale * scale;
        // }
}
