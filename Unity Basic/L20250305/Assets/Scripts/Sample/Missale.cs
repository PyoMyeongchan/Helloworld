using TreeEditor;
using UnityEngine;

public class Missale : MonoBehaviour
{


    float speed = 10.0f;

    void Awake()
    {
        // C# ������ �÷���(�ٷ� ������ ����)
        Destroy(gameObject, 2f);
    }

    void Update()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
        // transform.Translate(transform.up * speed * Time.deltaTime, Space.World);


    }
}
