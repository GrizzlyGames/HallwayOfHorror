using UnityEngine;
using System.Collections;

public class My_Raycast_Script : MonoBehaviour
{
    //Int to check if all the objects in the players room have been found
    ///3 objects Key, Mushrooms, Flashlight
    private int objsFound = 0;

    //Layermask only interacts with objects on the Layer 8 the RaycastObjects
    private int layerMask = 1 << 8;

    //Keys found
    private bool key2 = false;
    private bool key3 = false;
    private bool key4 = false;
    private bool key5 = false;
    private bool key6 = false;
    private bool key7 = false;
    private bool key8 = false;
    private bool key9 = false;
    private bool key10 = false;

    //Create the ray
    private Ray ray;

    //Store the information of what the ray hits
    private RaycastHit hit;

    //Check if key ha been found yet
    private bool keyFound1;
    
    //Get the Flashlight Container on the FirstPersonCharacter
    public GameObject flashlightContainer;

    //Get Door Animators
    public Animator door1Animator;

    //Get Chest Animator
    public Animator chestAnimator;

    void Start()
    {
        //Make sure flashlight isn't active on start of game
        flashlightContainer.SetActive(false);
        Debug.Log("objs found " + objsFound);
    }

    void Update()
    {
        //Don't show the cursor
        Cursor.visible = false;
        //Prevent mouse from leaving the screen
        Cursor.lockState = CursorLockMode.Locked;
        //this.transform.rotation = Quaternion.EulerAngles(0,0,0);
    }

    //Fixed update Raycasting
    /*
    void FixedUpdate()
    {
        //Set the ray position
        ray = new Ray(transform.position, transform.forward);

        //Perform action if ray hits object with 10 meters and is on layer 8 of the layermask
        if (Physics.Raycast(ray, out hit, 10, layerMask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            //Debug.Log(hit.transform.name);

            //If the ray hits the flashlight
            if (hit.transform.tag.Equals("Flashlight"))
            {
                //Get left click mouse input
                if (Input.GetMouseButtonDown(0))
                {
                    //Increase the number of objects found
                    objsFound++;
                    Debug.Log("objs found " + objsFound);
                    //Turn on flashlight
                    flashlightContainer.SetActive(true);
                    //Destroy the flashlight in the active world
                    Destroy(hit.transform.gameObject);
                    //If 3 objects are found open the cell door
                    if (objsFound >= 3)
                    {
                        //Trigger door 1 animator to open
                        door1Animator.enabled = true;
                    }
                }
            }
            //If the ray hits the mushrooms
            if (hit.transform.tag.Equals("Mushroom"))
            {
                //Get left click mouse input
                if (Input.GetMouseButtonDown(0))
                {
                    //Increase the number of objects found
                    objsFound++;
                    Debug.Log("objs found " + objsFound);
                    //Destroy the mushrooms in the active world
                    Destroy(hit.transform.gameObject);
                    //If 3 objects are found open the cell door
                    if (objsFound >= 3)
                    {
                        //Trigger door 1 animator to open
                        door1Animator.enabled = true;
                    }
                }
            }
            //If the ray hits the Key
            if (hit.transform.tag.Equals("Key"))
            {
                //Get left click mouse input
                if (Input.GetMouseButtonDown(0))
                {                    
                    //If key by number is found
                    #region Key1
                    if (hit.transform.gameObject.name.Equals("Key 01"))
                    {
                        //Set that the chest key is found
                        keyFound1 = true;
                        //Increase the number of objects found
                        objsFound++;
                        Debug.Log("objs found " + objsFound);
                        Debug.Log("Key 1 Found");
                    }
                    #endregion
                    #region Key2
                    if (hit.transform.gameObject.name.Equals("Key 02(Clone)"))
                    {
                        key2 = true;
                        Debug.Log("Key 2 Found");
                    }
                    #endregion
                    #region Key3
                    if (hit.transform.gameObject.name.Equals("Key 03(Clone)"))
                    {
                        key3 = true;
                        Debug.Log("Key 3 Found");
                    }
                    #endregion
                    #region Key4
                    if (hit.transform.gameObject.name.Equals("Key 04(Clone)"))
                    {
                        key4 = true;
                        Debug.Log("Key 4 Found");
                    }
                    #endregion
                    #region Key5
                    if (hit.transform.gameObject.name.Equals("Key 05(Clone)"))
                    {
                        key5 = true;
                        Debug.Log("Key 5 Found");
                    }
                    #endregion
                    #region Key6
                    if (hit.transform.gameObject.name.Equals("Key 06(Clone)"))
                    {
                        key6 = true;
                        Debug.Log("Key 6 Found");
                    }
                    #endregion
                    #region Key7
                    if (hit.transform.gameObject.name.Equals("Key 07(Clone)"))
                    {
                        key7 = true;
                        Debug.Log("Key 7 Found");
                    }
                    #endregion
                    #region Key8
                    if (hit.transform.gameObject.name.Equals("Key 08(Clone)"))
                    {
                        key8 = true;
                        Debug.Log("Key 8 Found");
                    }
                    #endregion     
                    #region Key9
                    if (hit.transform.gameObject.name.Equals("Key 09(Clone)"))
                    {
                        key9 = true;
                        Debug.Log("Key 9 Found");
                    }
                    #endregion   
                    #region Key10
                    if (hit.transform.gameObject.name.Equals("Key 10(Clone)"))
                    {
                        key10 = true;
                        Debug.Log("Key 10 Found");
                    }
                    #endregion   
                    //Destroy the mushrooms in the active world
                    Destroy(hit.transform.gameObject);
                    //If 3 objects are found open the cell door
                    if (objsFound >= 3)
                    {
                        //Trigger door 1 animator to open
                        door1Animator.enabled = true;
                    }
                }                
            }
            //If the ray hits the light switch
            if (hit.transform.tag.Equals("LightSwitch"))
            {
                //Debug.Log("LightSwitch Found");
                if (Input.GetMouseButtonDown(0))
                {
                    //Debug.Log("Light Message Sent");
                    hit.collider.SendMessageUpwards("setLights", SendMessageOptions.DontRequireReceiver);
                }
            }
            //If the ray hits the Chest
            if (hit.transform.gameObject.name.Equals("Chest_Lid"))
            {
                //Get left click mouse input
                //Check if the key has been found
                if (Input.GetMouseButtonDown(0) && keyFound1)
                {
                    Debug.Log("Chest Open");
                    chestAnimator.SetTrigger("Open");
                }
            }
            //If the ray hits the Key
            if (hit.transform.tag.Equals("Door"))
            {
                //Get left click mouse input
                if (Input.GetMouseButtonDown(0))
                {
                    #region Door2
                    if (hit.transform.gameObject.name.Equals("Door(2)") && key2)
                    {Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                        anim.enabled = true;
                        Debug.Log("Door 2 Found");
                    }
                    #endregion
                    #region Door3
                    if (hit.transform.gameObject.name.Equals("Door(3)") && key3)
                    {
                        Debug.Log("Door 3 Found");
                        Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                        anim.enabled = true;
                    }
                    #endregion
                    #region Door4
                    if (hit.transform.gameObject.name.Equals("Door(4)") && key4)
                    {
                        Debug.Log("Door 4 Found");
                        Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                        anim.enabled = true;
                    }
                    #endregion
                    #region Door5
                    if (hit.transform.gameObject.name.Equals("Door(5)") && key5)
                    {
                        Debug.Log("Door 5 Found");
                        Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                        anim.enabled = true;
                    }
                    #endregion
                    #region Door6
                    if (hit.transform.gameObject.name.Equals("Door(6)") && key6)
                    {
                        Debug.Log("Door 6 Found");
                        Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                        anim.enabled = true;
                    }
                    #endregion
                    #region Door7
                    if (hit.transform.gameObject.name.Equals("Door(7)") && key7)
                    {
                        Debug.Log("Door 7 Found");
                        Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                        anim.enabled = true;
                    }
                    #endregion
                    #region Door8
                    if (hit.transform.gameObject.name.Equals("Door(8)") && key8)
                    {
                        Debug.Log("Door 8 Found");
                        Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                        anim.enabled = true;
                    }
                    #endregion
                    //Destroy the mushrooms in the active world
                    //Destroy(hit.transform.gameObject);
                    //If 3 objects are found open the cell door
                    if (objsFound >= 3)
                    {
                        //Trigger door 1 animator to open
                        door1Animator.SetTrigger("Open");
                    }
                }
            }          
        }
    }
    */

    void OnTriggerStay(Collider hit)
    {
        //If the ray hits the flashlight
        if (hit.transform.tag.Equals("Flashlight"))
        {
            //Get left click mouse input
            if (Input.GetMouseButtonDown(0))
            {
                //Increase the number of objects found
                objsFound++;
                Debug.Log("objs found " + objsFound);
                //Turn on flashlight
                flashlightContainer.SetActive(true);
                //Destroy the flashlight in the active world
                Destroy(hit.transform.gameObject);
                //If 3 objects are found open the cell door
                if (objsFound >= 3)
                {
                    //Trigger door 1 animator to open
                    door1Animator.enabled = true;
                }
            }
        }
        //If the ray hits the mushrooms
        if (hit.transform.tag.Equals("Mushroom"))
        {
            //Get left click mouse input
            if (Input.GetMouseButtonDown(0))
            {
                //Increase the number of objects found
                objsFound++;
                Debug.Log("objs found " + objsFound);
                //Destroy the mushrooms in the active world
                Destroy(hit.transform.gameObject);
                //If 3 objects are found open the cell door
                if (objsFound >= 3)
                {
                    //Trigger door 1 animator to open
                    door1Animator.enabled = true;
                }
            }
        }
        //If the ray hits the Key
        if (hit.transform.tag.Equals("Key"))
        {
            //Get left click mouse input
            if (Input.GetMouseButtonDown(0))
            {
                //If key by number is found
                #region Key1
                if (hit.transform.gameObject.name.Equals("Key 01"))
                {
                    //Set that the chest key is found
                    keyFound1 = true;
                    //Increase the number of objects found
                    objsFound++;
                    Debug.Log("objs found " + objsFound);
                    Debug.Log("Key 1 Found");
                }
                #endregion
                #region Key2
                if (hit.transform.gameObject.name.Equals("Key 02(Clone)"))
                {
                    key2 = true;
                    Debug.Log("Key 2 Found");
                }
                #endregion
                #region Key3
                if (hit.transform.gameObject.name.Equals("Key 03(Clone)"))
                {
                    key3 = true;
                    Debug.Log("Key 3 Found");
                }
                #endregion
                #region Key4
                if (hit.transform.gameObject.name.Equals("Key 04(Clone)"))
                {
                    key4 = true;
                    Debug.Log("Key 4 Found");
                }
                #endregion
                #region Key5
                if (hit.transform.gameObject.name.Equals("Key 05(Clone)"))
                {
                    key5 = true;
                    Debug.Log("Key 5 Found");
                }
                #endregion
                #region Key6
                if (hit.transform.gameObject.name.Equals("Key 06(Clone)"))
                {
                    key6 = true;
                    Debug.Log("Key 6 Found");
                }
                #endregion
                #region Key7
                if (hit.transform.gameObject.name.Equals("Key 07(Clone)"))
                {
                    key7 = true;
                    Debug.Log("Key 7 Found");
                }
                #endregion
                #region Key8
                if (hit.transform.gameObject.name.Equals("Key 08(Clone)"))
                {
                    key8 = true;
                    Debug.Log("Key 8 Found");
                }
                #endregion
                #region Key9
                if (hit.transform.gameObject.name.Equals("Key 09(Clone)"))
                {
                    key9 = true;
                    Debug.Log("Key 9 Found");
                }
                #endregion
                #region Key10
                if (hit.transform.gameObject.name.Equals("Key 10(Clone)"))
                {
                    key10 = true;
                    Debug.Log("Key 10 Found");
                }
                #endregion
                //Destroy the mushrooms in the active world
                Destroy(hit.transform.gameObject);
                //If 3 objects are found open the cell door
                if (objsFound >= 3)
                {
                    //Trigger door 1 animator to open
                    door1Animator.enabled = true;
                }
            }
        }
        //If the ray hits the light switch
        if (hit.transform.tag.Equals("LightSwitch"))
        {
            //Debug.Log("LightSwitch Found");
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Light Message Sent");
                Collider col = hit.GetComponent<Collider>();
                col.SendMessageUpwards("setLights", SendMessageOptions.DontRequireReceiver);
            }
        }
        //If the ray hits the Chest
        if (hit.transform.gameObject.name.Equals("Chest_Lid"))
        {
            //Get left click mouse input
            //Check if the key has been found
            if (Input.GetMouseButtonDown(0) && keyFound1)
            {
                Debug.Log("Chest Open");
                chestAnimator.SetTrigger("Open");
            }
        }
        //If the ray hits the Key
        if (hit.transform.tag.Equals("Door"))
        {
            //Get left click mouse input
            if (Input.GetMouseButtonDown(0))
            {
                #region Door2
                if (hit.transform.gameObject.name.Equals("Door(2)") && key2)
                {
                    Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.enabled = true;
                    Debug.Log("Door 2 Found");
                }
                #endregion
                #region Door3
                if (hit.transform.gameObject.name.Equals("Door(3)") && key3)
                {
                    Debug.Log("Door 3 Found");
                    Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.enabled = true;
                }
                #endregion
                #region Door4
                if (hit.transform.gameObject.name.Equals("Door(4)") && key4)
                {
                    Debug.Log("Door 4 Found");
                    Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.enabled = true;
                }
                #endregion
                #region Door5
                if (hit.transform.gameObject.name.Equals("Door(5)") && key5)
                {
                    Debug.Log("Door 5 Found");
                    Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.enabled = true;
                }
                #endregion
                #region Door6
                if (hit.transform.gameObject.name.Equals("Door(6)") && key6)
                {
                    Debug.Log("Door 6 Found");
                    Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.enabled = true;
                }
                #endregion
                #region Door7
                if (hit.transform.gameObject.name.Equals("Door(7)") && key7)
                {
                    Debug.Log("Door 7 Found");
                    Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.enabled = true;
                }
                #endregion
                #region Door8
                if (hit.transform.gameObject.name.Equals("Door(8)") && key8)
                {
                    Debug.Log("Door 8 Found");
                    Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.enabled = true;
                }
                #endregion
                #region Door9
                if (hit.transform.gameObject.name.Equals("Door(9)") && key8)
                {
                    Debug.Log("Door 9 Found");
                    Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.enabled = true;
                }
                #endregion
                #region Door10
                if (hit.transform.gameObject.name.Equals("Door(10)") && key8)
                {
                    Debug.Log("Door 10 Found");
                    Animator anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.enabled = true;
                }
                #endregion
                //Destroy the mushrooms in the active world
                //Destroy(hit.transform.gameObject);
                //If 3 objects are found open the cell door
                if (objsFound >= 3)
                {
                    //Trigger door 1 animator to open
                    door1Animator.SetTrigger("Open");
                }
            }
        }
    }
}
