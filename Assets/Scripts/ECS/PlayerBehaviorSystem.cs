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
        Entities.WithoutBurst().ForEach((ref PlayerComponent player, ref Translation translation, ref Rotation rotation) =>
        {
            player.rotationAngle += Input.GetAxis("Horizontal")/10;
            float3 targetDirection = new float3 (math.sin(player.rotationAngle),0,math.cos(player.rotationAngle));
            rotation.Value = Quaternion.LookRotation(targetDirection, Vector3.up);
            translation.Value += targetDirection * player.speed * Input.GetAxis("Vertical")/10;
        }).Run();
    }
}
