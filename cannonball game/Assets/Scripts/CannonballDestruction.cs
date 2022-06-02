using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballDestruction : MonoBehaviour
{
    //Edwin Aguirre
    
    [SerializeField]
    private ParticleSystem cannonballExplosion;

    public float cannonballMass;


    private void Awake() 
    {
        cannonballExplosion.Pause();
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    public void AdjustMass(float newMass)
    {
        cannonballMass = newMass;
    }
    //Breaks the cannonball when it hits the ground
    private void OnTriggerEnter(Collider other) 
    {
        cannonballMass -= 10;
        if(other.gameObject.tag == "Ground" || cannonballMass<=0)
        {
            StartCoroutine("DestroyCannonball");
        }
   
    }

    // Update is called once per frame
    void Update()
    {  
        //This is temporary!!!
        //StartCoroutine(DestroyCannonball());
    }

    //Enables the particles, then destroys the cannonball after 5 seconds.
    //After the cannonball is destroyed, the particles play and get destroyed after 1 second.
    private IEnumerator DestroyCannonball()
    {
        cannonballExplosion.gameObject.SetActive(true);
        cannonballExplosion.Play();
        yield return new WaitForSeconds(2);
        Destroy(cannonballExplosion);

        Destroy(gameObject);
        yield return new WaitForSeconds(1);
    }
}
