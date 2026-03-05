using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
	public PoopPlacer PoopPlacer;
    

    // Update is called once per frame
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        
        //if pressed w
        if (keyboard.wKey.isPressed)
        {
            Corgi.Move(Vector2.up);
        }
        if (keyboard.sKey.isPressed)
        {
            Corgi.Move(Vector2.down);

        }
        if (keyboard.aKey.isPressed)
        {
            Corgi.Move(Vector2.left);

        }
        if (keyboard.dKey.isPressed)
        {
            Corgi.Move(Vector2.right);

        }
        //move up
        //etc
		if (keyboard.spaceKey.wasPressedThisFrame)
        {
            PoopPlacer.Place(Corgi.GetPosition());
        }
    }
}
