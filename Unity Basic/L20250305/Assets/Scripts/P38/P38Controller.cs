using UnityEngine;

public class P38Controller : MonoBehaviour
{ 
    float moveSpeed = 30.0f;
    float rotationSpeed = 60.0f;
    public GameObject missle;
    public Transform[] fire;

    void Start()
    {
        fire = transform.Find("Fire").GetComponentsInChildren<Transform>();
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(-v, 0, -h).normalized * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < fire.Length; i++)
            {
                Instantiate(missle, fire[i].transform.position, fire[i].transform.rotation);
            }


        }

    }
}
