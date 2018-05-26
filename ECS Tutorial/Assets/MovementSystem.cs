using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class MovementSystem : ComponentSystem
{
    public struct PlayerGroup
    {
        public ComponentDataArray<Position> playerPos;
        public ComponentDataArray<PlayerInput> playerInput;
        public int length;
    }

    [Inject] PlayerGroup playerGroup;

    protected override void OnUpdate()
    {
        for (int i = 0; i < playerGroup.length; i++)
        {
            var newPos = playerGroup.playerPos[i];
            newPos.Value.x += Input.GetAxis("Horizontal");
            newPos.Value.y += Input.GetAxis("Vertical");
            playerGroup.playerPos[i] = newPos;
        }
    }
}
