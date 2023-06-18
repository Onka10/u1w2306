using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireworks : MonoBehaviour
{
    public Transform targetPosition;
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
    }
}
