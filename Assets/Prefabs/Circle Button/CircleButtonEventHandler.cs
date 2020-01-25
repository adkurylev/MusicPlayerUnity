using System;
using UnityEngine;
using UnityEngine.Events;

public class CircleButtonEventHandler : MonoBehaviour
{
    [Serializable]
    public class UnityOneArgEvent : UnityEvent<string>
    {
        public UnityOneArgEvent() : base(){}
    }

    [SerializeField] protected string code = null;
    public UnityOneArgEvent ButtonPressed = new UnityOneArgEvent();

    public void OnPointerClick()
    {
        ButtonPressed?.Invoke(code);
    }
}
