using RocketCalculator.Models;
using RocketCalculator.Services;

namespace RocketCalculator.ViewModels;

public class CalculationsViewModel : BindedObject
{
    public RocketEngineData RocketEngineData { get; } = new();
    public RocketExteriorData RocketExteriorData { get; } = new();

    IService _calculationService;
    public IService CalculationService => _calculationService;//=> GetService<CalculationService>();

    public void SubscribeEvents()
    {
        _calculationService = new CalculationService(RocketExteriorData, RocketEngineData);
        
        RocketEngineData.OnChangedAction += CalculationService.GetResult;
        RocketExteriorData.OnChangedAction += CalculationService.GetResult;
    }

    /*readonly Dictionary<Type, IService> _services = new();

    public IService GetService<T>() where T : class
    {
        _services.TryGetValue(typeof(T), out IService service);
        return service;
    }

    public void SetService<T>(IService service) where T : class =>
        _services.Add(typeof(IService), service);*/
}