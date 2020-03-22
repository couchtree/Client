using UnityEngine;
using UnityEngine.UI;

namespace Core.Garden
{
    public class PopulateGrid : MonoBehaviour
    {
        public GameObject prefab;
        public int numberToCreate;

        void Start()
        {
            Populate();
        }

        void Populate()
        {
            GameObject newObj;

            for (int i = 0; i < this.numberToCreate; i++)
            {
                newObj = Instantiate(this.prefab, transform);
            }
        }
    }
}