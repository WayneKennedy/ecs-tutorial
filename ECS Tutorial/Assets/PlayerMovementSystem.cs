using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class PlayerMovementSystem : JobComponentSystem
{
    public struct PlayerInputJob : IJobProcessComponentData<Position, PlayerInput>
    {

        public void Execute(ref Position position, ref PlayerInput playerInput)
        {
            position.Value.x += playerInput.Horizontal;
            position.Value.y += playerInput.Vertical;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerInputJob { };

        return job.Schedule(this, 1, inputDeps);
    }

}