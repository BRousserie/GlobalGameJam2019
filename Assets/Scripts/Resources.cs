using System;

public enum ResourceType { Wood = 0, Money }; 
//Si l'on ajoute un nouveau type, il faut mettre à jour NB_RESOURCE_TYPES ligne 5

[Serializable]
public class Resource
{
    public const int NB_RESOURCE_TYPES = 2;

    public ResourceType Type;
    public int Value;

    public Resource(ResourceType type, int value = 0)
    {
        Type = type;
        Value = value;
    }

    public static Resource[] resourcesList()
    {
        Resource[] resources = new Resource[NB_RESOURCE_TYPES];
        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
        {
            resources[(int)type] = new Resource(type);
        }
        return resources;
    }
}