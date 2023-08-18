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
public class CharacterFiltredController : ControllerBase
{
    [HttpGet(Name = "CharacterFiltred")]
    public IEnumerable<Character> Get()
    {
        List<Character> characters = new RickAndMortyConnector.RickAndMorty().GetCharacters();

        return characters.ToArray();
    }
}
