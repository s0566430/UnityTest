using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class CollectedBehaviorSystem : SystemBase
{

    protected override void OnUpdate()
    {
        Entities.WithoutBurst().ForEach((CollectedComponent collectable, ref Translation translation, ref Rotation rotation) =>
        {
            
        }).Run();
    }

}