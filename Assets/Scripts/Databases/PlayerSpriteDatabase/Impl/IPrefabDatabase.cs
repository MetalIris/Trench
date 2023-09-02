using UnityEngine;

namespace Databases.PlayerSpriteDatabase.Impl
{
    public interface IPrefabDatabase
    {
        GameObject GetPrefab(string name);
    }
}
