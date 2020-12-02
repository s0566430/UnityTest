using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class SpawnCollectableSystem : SystemBase
{
    public BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;
    private static Unity.Mathematics.Random rand = new Unity.Mathematics.Random((uint) UnityEngine.Random.Range(0,1000));

    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer();
        Entities.WithoutBurst().ForEach((Entity entity, in SpawnCollectableComponent spawnCollectable) =>
        {
            for (int i=0; i<spawnCollectable.count; i++) {
                Entity e = commandBuffer.Instantiate(spawnCollectable.entity);
                commandBuffer.SetComponent(e, new Translation { Value = new float3(rand.NextInt(-5,5),1,rand.NextInt(-5,5)) });
            }
            commandBuffer.DestroyEntity(entity);
        }).Run();

        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
