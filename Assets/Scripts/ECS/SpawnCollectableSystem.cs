using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class SpawnCollectableSystem : SystemBase
{
    public BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

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
                commandBuffer.SetComponent(e, new Translation { Value = new float3 (UnityEngine.Random.Range(-5,5),1,UnityEngine.Random.Range(-5,5)) });
            }
            commandBuffer.DestroyEntity(entity);
        }).Run();

        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
