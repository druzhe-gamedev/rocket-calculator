using System.Collections.ObjectModel;
using RocketCalculator.ViewModels;

namespace RocketCalculator.Models
{
    public class RocketExteriorData : BindedObject
    {
        float _rocketHeight;
        public float RocketHeight
        {
            get => _rocketHeight;
            set
            {
                if (_rocketHeight == value) return;
                
                _rocketHeight = value;
                OnPropertyChanged();
            }
        }

        float _fairingHeight;
        public float FairingHeight
        {
            get => _fairingHeight;
            set
            {
                if (_fairingHeight == value) return;
                
                _fairingHeight = value;
                OnPropertyChanged();
            }
        }
        
        float _rocketDiameter;
        public float RocketDiameter
        {
            get => _rocketDiameter;
            set
            {
                if (_rocketDiameter == value) return;
                
                _rocketDiameter = value;
                OnPropertyChanged();
            }
        }
        
        float _rocketOuterDiameter;
        public float RocketOuterDiameter
        {
            get => _rocketOuterDiameter;
            set
            {
                if (_rocketOuterDiameter == value) return;
                
                _rocketOuterDiameter = value;
                OnPropertyChanged();
            }
        }
    }
}