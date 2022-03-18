using UnityEngine;

public class cubeController : MonoBehaviour
{
    public float distance;
    public float speed;

    private void FixedUpdate()
    {
        Vector3 endPosition = new Vector3(0, 1, distance);
        transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.fixedDeltaTime * speed);
        if (transform.position.z == distance)
            Invoke("destroyCube", 0.2f);
    }
    private void destroyCube()
    {
        Destroy(gameObject);
    }
}
