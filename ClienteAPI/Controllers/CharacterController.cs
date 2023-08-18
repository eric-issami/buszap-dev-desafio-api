using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RickAndMortyConnector.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClienteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    [HttpGet(Name = "Character")]
    public IEnumerable<Character> Get(string status = "", string species = "", byte episodeCount = 0)
    {
        List<Character> characters = new RickAndMortyConnector.RickAndMorty().GetCharacters(_status: status, _species: species, _episodeCount: episodeCount);

        return characters.ToArray();
    }
}
