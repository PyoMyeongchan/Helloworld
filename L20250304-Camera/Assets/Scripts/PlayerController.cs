using UnityEngine;


// �Է��̳� �ٸ� �̺�Ʈ�� ó���Ѵ�.
// ���� ���� ������Ʈ�� �ٸ� ������Ʈ�� ����� ������.
// ����� ������Ʈ�� �Ѱ��� �ϸ� �ؾ� �ȴ�.

public class PlayerController : MonoBehaviour
{
    //Transform playerTransform;

    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;

    void Awake()
    {
        //playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // ������ǥ�� / ���� ��ǥ��

        //transform.position += transform.up * v * Time.deltaTime * moveSpeed ; // �ʴ�
        transform.Translate(Vector3.up * v * Time.deltaTime * moveSpeed, Space.Self); // �ڱ��ڽű���)                                                                             

        transform.eulerAngles += transform.forward * h * Time.deltaTime * rotationSpeed;
 

        // �Ÿ� = �ӵ� * �ð� / s = v * t = > speed * direction * time
        // velocity = vector ũ��� ����


        // if (Input.GetKey(KeyCode.UpArrow))
        //{ 
        //   transform.position += new Vector3(0, 1, 0) * Time.deltaTime; // �ʴ�
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //  transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
        //}



    }
}
