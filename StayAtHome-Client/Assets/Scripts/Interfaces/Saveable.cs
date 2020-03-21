using System;
using UnityEngine;

namespace Interfaces
{
    public abstract class Saveable
    {
        protected String SavegameName = "changeMe";

        protected Saveable()
        {
            if (this.SavegameName == "changeMe")
            {
                Debug.LogError("You did not change the name of the Class for savegame Stuff!");
            }
        }

        public String GetSavegameName()
        {
            return this.SavegameName;
        }
    }
}