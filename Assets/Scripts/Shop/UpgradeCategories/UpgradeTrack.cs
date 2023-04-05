using System.Collections.Generic;
using Shop.Upgrades;
using TMPro;

namespace Shop.UpgradeCategories
{
    public class UpgradeTrack
    {
        public int CurrentLevel;
        public List<Upgrade> Upgrades = new();
        public string TrackName;
        public string TrackDescription;
        public TextMeshProUGUI CostText;
        public TextMeshProUGUI UpgradeNameText;
        public delegate string GetTrackDescriptionDelegate();
        public GetTrackDescriptionDelegate GetTrackDescription;
    }
}