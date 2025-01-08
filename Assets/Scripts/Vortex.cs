using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public Vector2 scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.materials[0].mainTextureOffset += scrollSpeed * Time.deltaTime;
    }
}
