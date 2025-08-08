using UnityEngine;

namespace Cobra.GUI
{
    public interface IMenuSettingSaveLoad
    {
        void Save();

        void LoadFromSave();

        void LoadDefault();
    }
}
