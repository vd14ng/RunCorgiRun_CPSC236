using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    public PoopPlacer PoopPlacer;
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        
        // if pressed "w"
        if (keyboard.wKey.isPressed)
        {
            // move up
            Corgi.Move(Vector2.up);
        }
        // if pressed "s"
        if (keyboard.sKey.isPressed)
        {
            // move down
            Corgi.Move(Vector2.down);
        }
        // if pressed "a"
        if (keyboard.aKey.isPressed)
        {
            // move left
            Corgi.Move(Vector2.left);
        }
        // if pressed "d"
        if (keyboard.dKey.isPressed)
        {
            // move right
            Corgi.Move(Vector2.right);
        }

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            PoopPlacer.Place(Corgi.GetPosition());
        }
    }
}
