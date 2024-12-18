using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LazerShot : MonoBehaviour
{
    [SerializeField]
    public GameObject LaserBulletTemplate;
    
    public float shootPower = 100000f;
    public InputActionReference trigger;
    public AudioClip spellCast;
    public AudioSource audioSource;
    
    
    //Deals with the shooting of the laser
    void shoot(InputAction.CallbackContext context)
    {
        //creates a copy of the bullet template and makes it show in the world.
        GameObject newBullet = Instantiate(LaserBulletTemplate, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
        audioSource.GetComponent<AudioSource>().PlayOneShot(spellCast);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        trigger.action.performed += shoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
