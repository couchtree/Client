using Core.Interfaces;
using DataContainer;
using Managers;
using TMPro;

namespace Core.Garden
{
    /// <summary>
    /// The TreePlant is the main plant of this game.
    /// 
    /// It does not grow in the garden but on the homescreen itsself.
    /// </summary>
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
        
        /// <summary>
        /// Loads this tree plant
        /// </summary>
        public override void Load()
        {
            SavegameManager.LoadTree(out this.data);
            this.treeNameText.text = data.name;
        }

        /// <summary>
        /// Stores this tree plant
        /// </summary>
        public override void Save()
        {
            SavegameManager.SaveTree(this.data);
        }
    }
}