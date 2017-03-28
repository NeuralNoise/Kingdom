using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string Name { get; set; }
    public Color Color { get; set; }
    public Entity[] Entities { get; set; }
    public RaceEnum Race { get; set; }
    public int Gold { get; set; }
    public int Wood { get; set; }
    public int Stone { get; set; }
    public int Food { get; set; }
}
