using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Bsol.Business.Template.Core.Interfaces.Services;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Bsol.Business.Template.Infrastructure.Services;

public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<PokeApiService> _logger;


    public PokeApiService(IHttpClientFactory httpClient, ILogger<PokeApiService> logger)
    {
        _httpClient = httpClient.CreateClient(nameof(PokeApiService));
        _logger = logger;
    }
    public async Task<Result<EncounterData?>> EncounterMethod(int id, CancellationToken ct)
    {
        var response = await _httpClient.GetAsync($"api/v2/encounter-method/{id}", ct);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync(ct);
            var encounterData = JsonSerializer.Deserialize<EncounterData?>(content);
            return Result.Ok(encounterData);
        }
        else
        {
            _logger.LogError("Error fetching data from PokeAPI");
            return Result.Fail(new Error("Failed to fetch data from PokeAPI"));
        }
    }
}
