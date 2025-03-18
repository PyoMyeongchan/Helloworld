using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 3.0f; // 3�� �Ϲ������� �ȴ� ��
    public float rotateSpeed = 360.0f; // �Ϲ����� �ӵ�
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * v * moveSpeed *Time.deltaTime);
        transform.Rotate(Vector3.up * h * rotateSpeed *Time.deltaTime);



    }
}
