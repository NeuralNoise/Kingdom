using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDisplayableByBar
{
    OnChangePercentageEvent OnChangePercentage { get; set; }
}

public class OnChangePercentageEvent : UnityEvent<float> { }
