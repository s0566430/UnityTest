using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public class SpawnCollectableComponent : IComponentData
{
    public int count;
    public Entity entity;
}
