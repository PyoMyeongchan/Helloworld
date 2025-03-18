using UnityEngine;

public class P38Missle : MonoBehaviour
{

    float speed = 100.0f;


    void Start()
    {
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
