using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoweredStatBehaviour : MonoBehaviour
{
    UnpoweredWireStat unpoweredWireS;
    // Start is called before the first frame update
    void Start()
    {
        unpoweredWireS = gameObject.GetComponent<UnpoweredWireStat>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageLight();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerWireStats>())
        {
            PowerWireStats powerWireS = collision.GetComponent<PowerWireStats>();
            if (powerWireS.objectColor == unpoweredWireS.objectColor)
            {
                powerWireS.connected = true;
                unpoweredWireS.connected = true;
                powerWireS.connectedPosition = gameObject.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PowerWireStats>())
        {
            PowerWireStats powerWireS = collision.GetComponent<PowerWireStats>();
            if(powerWireS.objectColor == unpoweredWireS.objectColor)
            {
                powerWireS.connected = false;
                unpoweredWireS.connected = false;
            }         
        }
    }


    private void ManageLight()
    {
        if (unpoweredWireS.connected)
        {
            unpoweredWireS.poweredLight.SetActive(true);
            unpoweredWireS.unpoweredLight.SetActive(false);
        }
        else
        {
            unpoweredWireS.poweredLight.SetActive(false);
            unpoweredWireS.unpoweredLight.SetActive(true);
        }
    }
}
