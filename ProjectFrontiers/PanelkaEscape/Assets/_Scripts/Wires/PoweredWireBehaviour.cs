using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoweredWireBehaviour : MonoBehaviour
{
    public bool mouseDown = false;
    public PowerWireStats powerWireS;
    LineRenderer line;
    public Camera wireCam;
    // Start is called before the first frame update
    void Start()
    {
        powerWireS = gameObject.GetComponent<PowerWireStats>();
        line = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWire();
        line.SetPosition(3, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
        line.SetPosition(2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
    }
    private void OnMouseDown()
    {
        mouseDown = true;
    }
    private void OnMouseOver()
    {
        powerWireS.movable = true;
    }
    private void OnMouseExit()
    {
        if (!powerWireS.moving)
        {
            powerWireS.movable = false;
        }
    }
    private void OnMouseUp()
    {
        mouseDown = false;
        if (!powerWireS.connected)
        {
            gameObject.transform.position = powerWireS.startPosition;
        }
        if (powerWireS.connected)
        {
            gameObject.transform.position = powerWireS.connectedPosition;
        }
    }
    void MoveWire()
    {
        if(mouseDown&& powerWireS.movable)
        {
            powerWireS.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            gameObject.transform.position = wireCam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 6));
        }
        else
        {
            powerWireS.moving = false;
        }
        
    }
}
