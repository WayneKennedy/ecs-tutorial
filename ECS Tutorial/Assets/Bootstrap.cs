using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{

    public Mesh PlayerMesh;
    public Material PlayerMaterial;

    public Mesh BlockMesh;
    public Material BlockMaterial;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void Start()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        var playerArchetype = entityManager.CreateArchetype(
            typeof(TransformMatrix),
            typeof(Position),
            typeof(MeshInstanceRenderer),
            typeof(PlayerInput)
        );

        var player = entityManager.CreateEntity(playerArchetype);

        entityManager.SetSharedComponentData(player, new MeshInstanceRenderer
        {
            mesh = PlayerMesh,
            material = PlayerMaterial
        });

        var blockArchetype = entityManager.CreateArchetype(
            typeof(TransformMatrix),
            typeof(Position),
            typeof(MeshInstanceRenderer),
            typeof(Block)
        );


        for (int x = -3; x < 2; x++)
        {
            for (int y = -3; y < 2; y++)
            {
                var block = entityManager.CreateEntity(blockArchetype);

                entityManager.SetSharedComponentData(block, new MeshInstanceRenderer
                {
                    mesh = BlockMesh,
                    material = BlockMaterial
                });

                entityManager.SetComponentData(block, new Position { Value = new float3(x, y, 0) });
            }
        }

    }
}