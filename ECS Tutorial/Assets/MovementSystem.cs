using Unity.Entities;
using UnityEngine;
using Unity.Transforms;

public class MovementSystem : ComponentSystem
{

    public struct PlayerGroup
    {
        public ComponentDataArray<Position> playerPos;
        public ComponentDataArray<PlayerInput> playerInput;
        public int Length;
    }

    [Inject] PlayerGroup playerGroup;

    protected override void OnUpdate()
    {
        for (int i = 0; i < playerGroup.Length; i++)
        {

            var newPos = playerGroup.playerPos[i];
            newPos.Value.x += Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
            newPos.Value.y += Input.GetAxis("Vertical") * 5 * Time.deltaTime;
            playerGroup.playerPos[i] = newPos;


        }
    }
}