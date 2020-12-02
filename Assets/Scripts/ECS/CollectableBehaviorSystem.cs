using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class CollectedBehaviorSystem : SystemBase
{
    private static float3 eulerRotation = new float3(0,0,0);

    protected override void OnUpdate()
    {
        Entities.WithoutBurst().ForEach((CollectedComponent collectable, ref Rotation rotation) =>
        {
            eulerRotation.y += 0.01f;
            if (eulerRotation.y >= Mathf.PI*2) eulerRotation.y = 0;
            rotation.Value = quaternion.EulerXYZ(eulerRotation);
        }).Run();
    }

}