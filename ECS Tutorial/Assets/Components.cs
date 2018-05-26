using Unity.Entities;

public struct PlayerInput : IComponentData
{
    public float horizontal;
    public float vertical;
}

public struct Block : IComponentData {}
public struct Fly : IComponentData {}
