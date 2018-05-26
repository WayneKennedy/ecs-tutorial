using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class PlayerInputSystem : JobComponentSystem
{
    public struct PlayerInputJob : IJobProcessComponentData<PlayerInput>
    {
        public bool Left;
        public bool Right;
        public bool Up;
        public bool Down;

        public bool UpLeft;
        public bool UpRight;
        public bool DownLeft;
        public bool DownRight;

        public void Execute(ref PlayerInput input)
        {
            input.Horizontal = Left || UpLeft || DownLeft ? -1f : Right || UpRight || DownRight ? 1f : 0f;
            input.Vertical = Down || DownLeft || DownRight ? -1f : Up || UpRight || UpLeft ? 1f : 0f;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerInputJob
        {

            Left = Input.GetKeyDown(KeyCode.A),
            Right = Input.GetKeyDown(KeyCode.D),
            Up = Input.GetKeyDown(KeyCode.W),
            Down = Input.GetKeyDown(KeyCode.S),

            UpLeft = Input.GetKeyDown(KeyCode.Q),
            UpRight = Input.GetKeyDown(KeyCode.E),
            DownLeft = Input.GetKeyDown(KeyCode.Less),
            DownRight = Input.GetKeyDown(KeyCode.X),
        };


        return job.Schedule(this, 1, inputDeps);
    }

}