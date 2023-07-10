using System;
using System.ComponentModel;
using RocketCalculator.Models;

namespace RocketCalculator.ViewModels
{
    public class CalculationsViewModel : BindedObject
    {
        public RocketEngineData RocketEngineData { get; } = new();
        public RocketExteriorData RocketExteriorData { get; } = new();
        Func<float, double> Double = (float x) => Math.Pow(x, 2);

        double _rocketVolume;
        public double RocketVolume { 
            get => _rocketVolume;
            private set
            {
                _rocketVolume = value;
                OnPropertyChanged();
            } 
        }

        double _burningTime;
        public double BurningTime { 
            get => _burningTime;
            private set
            {
                _burningTime = value;
                OnPropertyChanged();
            } 
        }

        public CalculationsViewModel()
        {
            RocketExteriorData.OnChangeProperty += Calculate;
            RocketEngineData.OnChangeProperty += Calculate;
        }
        
        private void Calculate()
        {
            RocketVolume = GetRocketVolume();
            BurningTime = GetBurningSpeed();
        }
        
        private double GetRocketVolume() =>
            Double(RocketExteriorData.RocketDiameter / 2) * Math.PI * RocketExteriorData.RocketHeight;

        private double GetBurningSpeed() => (RocketExteriorData.RocketDiameter - RocketEngineData.EngineChannelDiameter) / RocketEngineData.BurningSpeed;

    }
}