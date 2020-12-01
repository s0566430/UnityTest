using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class SpawnCollectableSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.WithoutBurst().ForEach((in SpawnCollectableComponent spawnCollectable) =>
        {
            for (int i=0; i<spawnCollectable.count; i++) {
                //Instantiate(spawnCollectable.entity, new float3(UnityEngine.Random.Range(-5,5),1,UnityEngine.Random.Range(-5,5)), new Quaternion(0,0,0,1));
            }
        }).Run();
    }
}
