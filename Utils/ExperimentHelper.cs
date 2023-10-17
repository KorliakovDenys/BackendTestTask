using KorliakovBackendTestTask.Models;
using KorliakovBackendTestTask.Repository;

namespace KorliakovBackendTestTask.Utils;

public class ExperimentHelper : IExperimentHelper {
    private readonly ILogger<ExperimentHelper> _logger;
    private readonly IRepository<Client?> _repository;
    private readonly string[] _colors;
    private readonly PriceProbability[] _priceProbabilities;
    private readonly Random _random = new();

    public ExperimentHelper(
        ILogger<ExperimentHelper> logger,
        IRepository<Client?> repository,
        string[] colors,
        PriceProbability[] priceProbabilities) {
        _logger = logger;
        _repository = repository;
        _colors = colors;
        _priceProbabilities = priceProbabilities;
    }

    public string GetButtonColor(string deviceToken) {
        var client = GetClient(deviceToken);

        return client.Color;
    }

    public int GetPrice(string deviceToken) {
        var client = GetClient(deviceToken);

        return client.Price;
    }

    private Client GetClient(string deviceToken) {
        var client = _repository.Read(deviceToken) ?? CreateClient(deviceToken);

        return client;
    }

    private Client CreateClient(string deviceToken) {
        var client = new Client {
            DeviceToken = deviceToken,
            Price = GetRandomPrice(),
            Color = _colors[_random.Next(_colors.Length)]
        };
        _repository.Create(client);

        _logger.LogInformation("Client created.");

        return client;
    }

    private int GetRandomPrice() {
        //є вірогідність, що probabilitiesSum буде більша ніж 4 байти, тому і стоїть обробник виключень 
        try {
            // сума вірогідностей a.k.a 100%
            var probabilitiesSum = _priceProbabilities.Sum(p => p.Probability);
            // точка на відрізку в 100%
            var result = _random.Next(probabilitiesSum);
            var probability = 0;
            foreach (var t in _priceProbabilities) {
                probability += t.Probability;
                if (result < probability) return t.Value; // у який відрізок потрапила точка, така ціна і буде
            }
        }
        catch (Exception e) {
            _logger.LogWarning("The experiment with a random price did not go as planned; " +
                               "the price will be issued with the highest probability of issuance.");
            _logger.LogError(e.Message);
        }

        // на випадок, якщо щось піде не за планом.
        return _priceProbabilities.OrderByDescending(p => p.Probability).FirstOrDefault().Value;
    }
}