using Core.Interfaces;
using DataContainer;
using Managers;
using TMPro;

namespace Core.Garden
{
    public class TreePlant : APlant
    {
        private TreeData treeData;
        
        public TextMeshProUGUI treeNameText;

        protected void Awake()
        {
            Load();
        }
        public TreePlant(int evolutionLevel = 0) : base(evolutionLevel)
        {
            treeData = new TreeData();
        }

        protected override int GetMaxEvolutionLevel()
        {
            return 30;
        }
        
        public void Load()
        {
            SavegameManager.LoadTree(out this.treeData);
            this.Name = treeData.name;
            this.EvolutionLevel = treeData.evolutionLevel;
            this.treeNameText.text = treeData.name;
        }
    }
}