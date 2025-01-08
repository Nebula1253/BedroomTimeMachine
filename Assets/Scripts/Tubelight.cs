using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubelight : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public Material tubelightOffMaterial;
    private Material tubelightOnMaterial;
    public float lightIntensity;
    private bool on = true;
    public static Tubelight Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this; 

        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        tubelightOnMaterial = meshRenderer.materials[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLight() {
        on = on ? false : true;

        var materials = meshRenderer.materials;
        materials[1] = on ? tubelightOnMaterial : tubelightOffMaterial;
        meshRenderer.materials = materials;

        var pointLights = gameObject.GetComponentsInChildren<Light>();
        foreach (var light in pointLights)
        {
            light.intensity = on ? 0.2f : 0f;
        }
    }
}
