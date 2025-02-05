using UnityEngine;

public class MaterialChnage : MonoBehaviour
{
    
    public Material skyboxMaterial;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RenderSettings.skybox = skyboxMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
