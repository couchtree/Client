using Core.Interfaces;
using DataContainer;
using Managers;
using TMPro;

namespace Core.Garden
{
    public class TreePlant : APlant
    {        
        public TextMeshProUGUI treeNameText;

        protected void Awake()
        {
            Load();
        }

        public TreePlant(int evolutionLevel = 0) : base(evolutionLevel)
        {
        }

        protected override int GetMaxEvolutionLevel()
        {
            return 30;
        }
        
        public override void Load()
        {
            SavegameManager.LoadTree(out this.data);
            this.treeNameText.text = data.name;
        }

        public override void Save()
        {
            SavegameManager.SaveTree(this.data);
        }
    }
}