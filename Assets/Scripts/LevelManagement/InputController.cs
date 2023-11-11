using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController current;
    void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Action onSpacePressed;
    public void OnSpace()
    {
        onSpacePressed?.Invoke();
    }

    public Action onEscapePressed;
    public void OnEscape()
    {
        onEscapePressed?.Invoke();
    }
}
