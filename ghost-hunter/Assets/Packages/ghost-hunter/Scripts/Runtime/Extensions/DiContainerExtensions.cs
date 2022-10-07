using UnityEngine;
using Zenject;

namespace GhostHunter.Runtime.Extensions
{
    public static class DiContainerExtensions
    {
        public static GameObject InstantiateInjectablePrefab(this DiContainer container, GameObject prefab, Transform parent = null)
        {
            var instance = Instantiate(container, prefab, parent);

            return instance;
        }

        public static GameObject InstantiateInjectablePrefab(this DiContainer container, GameObject prefab, Vector3 position, Transform parent = null)
        {
            var instance = Instantiate(container, prefab, parent);
            instance.transform.localPosition = position;

            return instance;
        }

        private static GameObject Instantiate(DiContainer container, GameObject prefab, Transform parent)
        {
            prefab.gameObject.SetActive(false);
            var instance = container.InstantiatePrefab(prefab, parent);
            instance.SetActive(true);
            prefab.gameObject.SetActive(true);

            return instance;
        }
    }
}