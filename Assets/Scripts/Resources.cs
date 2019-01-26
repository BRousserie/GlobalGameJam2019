using System;

public enum ResourceType { Wood = 0 }; 
//Si l'on ajoute un nouveau type, il faut mettre à jour NB_RESOURCE_TYPES ligne 5

public class Resource
{
    public const int NB_RESOURCE_TYPES = 1;

    private ResourceType m_type;
    public ResourceType Type { get { return m_type; } }
    private int m_value;
    public int Value { get { return m_value; } set { m_value = value; } }

    public Resource(ResourceType type, int value = 0)
    {
        m_type = type;
        m_value = value;
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