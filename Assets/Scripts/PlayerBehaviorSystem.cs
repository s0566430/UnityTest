using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class PlayerBehaviorSystem : SystemBase
{

    protected override void OnUpdate()
    {
        Entities.ForEach((ref PlayerComponent player, ref Translation translation, ref Rotation rotation) =>
        {
            player.rotationAngle += Input.GetAxis("Horizontal");
            float3 targetDirection = new float3 (math.sin(player.rotationAngle),0,math.cos(player.rotationAngle));
            rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        }).Schedule();
    }
}
