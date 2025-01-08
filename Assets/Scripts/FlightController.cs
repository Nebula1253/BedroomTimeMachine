using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    private bool inFlight = false;
    private bool coordinatesSet = false;
    private GameObject player;
    public GameObject homePlane, door;
    private CoordinateKeyboard coordinateInput;
    private DematLever dematLever;
    public GameObject timeVortex;
    public Material vortexSkybox;
    public Material orbitSkybox, planetSkybox, forestSkybox; // only one possible destination in proof-of-concept
    private Material destinationSkybox;

    // let's make this a singleton weeeeeee
    public static FlightController Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this; 

        coordinateInput = GameObject.Find("CoordinateKeyboard").GetComponent<CoordinateKeyboard>();
        coordinateInput.DisableInteraction();

        dematLever = GameObject.Find("DematBase").GetComponent<DematLever>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InFlight() {
        inFlight = true;
        coordinateInput.EnableInteraction();
        dematLever.DisableInteraction();

        homePlane.SetActive(false);
        timeVortex.SetActive(true);

        RenderSettings.skybox = vortexSkybox;

        DynamicGI.UpdateEnvironment();

        door.GetComponent<AnimationInteractable>().EnableInteraction();
    }

    public bool SetCoordinates(string coordinates) {
        switch(coordinates) {
            case "K72-63B":
                destinationSkybox = orbitSkybox;
                dematLever.EnableInteraction();
                dematLever.displayText = "Land - Planetary Orbit";

                return true;
            case "J58-S7C":
                destinationSkybox = planetSkybox;
                dematLever.EnableInteraction();
                dematLever.displayText = "Land - Curzon V";

                return true;
            case "335-A9G":
                destinationSkybox = forestSkybox;
                dematLever.EnableInteraction();
                dematLever.displayText = "Land - Idyll Forest";

                return true;
            default:
                return false;
        }
    }

    public void Landing() {
        inFlight = false;
        coordinateInput.DisableInteraction();

        timeVortex.SetActive(false);

        RenderSettings.skybox = destinationSkybox;
        DynamicGI.UpdateEnvironment();

        dematLever.displayText = "Take Off";
    }
}
