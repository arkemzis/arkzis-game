using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float h = 0f;
        float v = 0f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) h = 1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  h = -1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))    v = 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))  v = -1f;

        Vector3 move = new Vector3(h, 0, v) * speed * Time.deltaTime;
        transform.Translate(move);
    }
}