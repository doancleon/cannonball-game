using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightAdjuster : MonoBehaviour
{
    //Edwin Aguirre
    
    private Rigidbody rb;
    private float mass = 1;

    [SerializeField]
    private Text massText;

    [SerializeField]
    private GameObject cannonball;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the RigidBody of the cannonball
        rb = cannonball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the cannonball mass to the text above slider
        massText.text = "Mass: " + mass + " kg";

        //Sets the mass of the cannonball
        rb.mass = mass;
    }


    //Changes the mass of the cannonballs based on the slider value
    public void AdjustWeight(float newWeight)
    {
        mass = newWeight;
    }
}
