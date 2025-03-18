using UnityEngine;


//입력이나 다른 이벤트를 처리한다.
//현재 게임 오브젝트에 다른 컴포넌트에 명령을 내린다.
//사용자 컴포넌트는 한가지 일만 해야 된다.
public class PlayerController : MonoBehaviour
{
    public GameObject missle;
    public Transform[] fire;
    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;


    void Awake()
    {
        fire = transform.Find("fire").GetComponentsInChildren<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        //velocity => vector 크기랑 방향
        //s = v * t => speed * direction * time 

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");


        //로컬좌표계, 월드 좌표계
        //세상의 위방향
        //transform.position += transform.up * v * Time.deltaTime * moveSpeed;
        transform.Translate(Vector3.up * v * Time.deltaTime * moveSpeed);
        transform.eulerAngles += transform.forward * -h * Time.deltaTime * rotationSpeed;


        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < fire.Length; i++)
            {
                Instantiate(missle, fire[i].transform.position, fire[i].transform.rotation);
            }

        
        }
    }
}
