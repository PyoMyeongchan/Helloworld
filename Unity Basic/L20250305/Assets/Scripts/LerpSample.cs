using UnityEngine;
using UnityEngine.UIElements;

public class LerpSample : MonoBehaviour
{
    public Transform A;
    public Transform B;

    [Range(0, 1)] 
    public float T = 0;
    float elapsedTime = 0;

    float sign = 1;

    public AnimationCurve curve;

    //public Material material;

    public Color Acolor;
    public Color Bcolor;    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += sign * Time.deltaTime;
        if (elapsedTime > 1 || elapsedTime < 0)
        {
            sign = sign * -1;

        }
        transform.position = Vector3.Lerp(A.position, B.position, curve.Evaluate(elapsedTime));
        transform.rotation = Quaternion.Slerp(A.rotation, B.rotation, curve.Evaluate(elapsedTime));

        GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.Lerp(Acolor, Bcolor, curve.Evaluate(elapsedTime)));
        
            //material.color = Color.Lerp(Acolor, Bcolor, curve.Evaluate(elapsedTime));
        
    }
}
