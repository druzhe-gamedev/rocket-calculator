using System;
using RocketCalculator.ViewModels;

namespace RocketCalculator.Models
{
    public class RocketEngineData : BindedObject
    {
        float _fuelMass;
        public float FuelMass
        {
            get => _fuelMass;
            set
            {
                if (_fuelMass == value) return;
                
                _fuelMass = value;
                OnPropertyChanged();
            }
        }
        
        float _fuelDensity;
        public float FuelDensity
        {
            get => _fuelDensity;
            set
            {
                if (_fuelDensity == value) return;
                
                _fuelDensity = value;
                OnPropertyChanged();
            }
        }
        
        float _engineHeight;
        public float EngineHeight
        {
            get => _engineHeight;
            set
            {
                if (_engineHeight == value) return;
                
                _engineHeight = value;
                OnPropertyChanged();
            }
        }

        float _rocketShellDensity;
        public float RocketShellDensity
        {
            get => _rocketShellDensity;
            set
            {
                if (_rocketShellDensity == value) return;
                
                _rocketShellDensity = value;
                OnPropertyChanged();
            }
        }
        
        float _engineChannelDiameter;
        public float EngineChannelDiameter
        {
            get => _engineChannelDiameter;
            set
            {
                if (_engineChannelDiameter == value) return;
                
                _engineChannelDiameter = value;
                OnPropertyChanged();
            }
        }

        float _burningSpeed;
        public float BurningSpeed
        {
            get => _burningSpeed;
            set
            {
                if (_burningSpeed == value) return;
                
                _burningSpeed = value;
                OnPropertyChanged();
            }
        }
    }
}