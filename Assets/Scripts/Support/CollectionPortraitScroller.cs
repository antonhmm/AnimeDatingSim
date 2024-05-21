using UnityEngine;
using System.Collections;

public class CollectionPortraitScroller : MonoBehaviour
{
    [SerializeField] private float totalDistanceToMove = 200.0f;
    private float remainingDistance;
    [SerializeField] private float speed = 200.0f;
    private bool isMoving = false;

    public void ScrollPortrait(int dir)
    {
        if (!isMoving)
        {
            remainingDistance = totalDistanceToMove;
            StartCoroutine(MoveObject(dir));
        }
        if (isMoving)
        {
            remainingDistance += totalDistanceToMove;
        }
    }

    private IEnumerator MoveObject(int dir)
    {
        isMoving = true;
        while (remainingDistance > 0)
        {
            float step = speed * Time.deltaTime;
            if (step > remainingDistance)
            {
                step = remainingDistance;
            }
            if (dir == 0)
            {
                transform.Translate(Vector3.left * step);
                remainingDistance -= step;
                yield return null;
            }
            else
            {
                if (transform.localPosition.x >= 0)
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    remainingDistance = 0;
                    yield return null;
                }
                else
                {
                    transform.Translate(Vector3.right * step);
                    remainingDistance -= step;
                    yield return null;
                }
                
            }
        }
        isMoving = false;
        yield return null;
    }
}