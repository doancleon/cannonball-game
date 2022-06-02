using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonballSpawner : MonoBehaviour
{
    //Edwin Aguirre
    
    [SerializeField]
    private GameObject cannonball;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float cannonForce;
    private float cannonFireForce;

    [SerializeField]
    private float cannonUpdwardForce;

    Rigidbody projectileRb;
    GameObject projectile;

    [SerializeField]
    private Text powerText;

    [SerializeField]
    private Text angleText;

    public float cannonballMass;
    [SerializeField] private float cannonMass;
    public void AdjustMass(float newMass)
    {
        cannonballMass = newMass;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CannonShoot();

        //Sets the cannon power to the text above slider
        powerText.text = "Power: " + cannonForce;

        //Sets the cannon angle to the text above slider
        angleText.text = "Angle: " + cannonUpdwardForce;
    }

    //Spawns the cannonballs
    public void OnClickSpawnCannonball()
    {
        Instantiate(cannonball, spawnPoint.position, Quaternion.identity);
    }

    private void CannonShoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            projectile = Instantiate(cannonball, spawnPoint.position, Quaternion.identity);

            projectileRb = projectile.GetComponent<Rigidbody>();
            cannonFireForce = cannonForce*9;
            Vector3 forceToAdd = transform.forward * cannonFireForce + transform.up * cannonUpdwardForce;

            projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        }
    }

    //Changes the cannon power based on the slider value
    public void AdjustPower(float newPower)
    {
        cannonForce = newPower;
    }

    //Changes the cannon power based on the slider value
    public void AdjustAngle(float newAngle)
    {
        cannonUpdwardForce = newAngle;
    }
}
