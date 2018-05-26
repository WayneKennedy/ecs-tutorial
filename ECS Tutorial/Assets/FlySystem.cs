using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public class FlySystem : JobComponentSystem
{

    private struct FlyJob : IJobProcessComponentData<Position, Fly>
    {

        public float dt;
        /*  public bool FlyAway;*/

        public void Execute(ref Position position, ref Fly fly)
        {

            /*        if (FlyAway)
                    {*/
            float xMove = Mathf.PerlinNoise(position.Value.x, position.Value.y) - 1.5f;
            float yMove = Mathf.PerlinNoise(position.Value.y, position.Value.x) + 0.5f;
            position.Value += dt * new float3(xMove, yMove, 0);
            /* }*/

        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new FlyJob
        {
            dt = Time.deltaTime,
            /*FlyAway = Input.GetKey(KeyCode.F),*/
        };

        return job.Schedule(this, 1, inputDeps);
    }
}
