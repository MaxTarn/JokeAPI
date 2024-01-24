using JokeAPI.Classes;
using Microsoft.AspNetCore.Mvc;

namespace JokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DadJokesController : ControllerBase
    {
        //returns all jokes
        [HttpGet(Name = "GetDadJoke")]
        public ActionResult<List<Joke>> Get()
        {
            return Ok(Joke.DadJokes);
        }

        //returns one random joke
        [HttpGet("Random", Name = "GetRandomDadJoke")]
        public ActionResult<Joke> GetRandomJoke()
        {

            int randomJokeIndex = Randomizer.RandomBetweenAndIncluding(0, Joke.DadJokes.Count - 1);

            return Ok(Joke.DadJokes.ElementAt(randomJokeIndex)); //index begins at 0
        }

        [HttpPost]
        public ActionResult Post(Joke? TheNewJoke)
        {
            if (TheNewJoke == null) return BadRequest("The New Joke was null, and didnt contain any information.");
            bool jokeWasAdded = false;
            if (TheNewJoke.IsDadJoke == true) jokeWasAdded = Joke.AddNewDadJoke(TheNewJoke);
            if (TheNewJoke.IsDadJoke == false) jokeWasAdded = Joke.AddNewMomJoke(TheNewJoke);
            if (jokeWasAdded == false) return StatusCode(500, "Was unable to add the new joke.");
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int JokeId, string? UpdatedJoke)
        {
            if (UpdatedJoke == null) return BadRequest("The New joke was null and didnt contain any information");
            if (!Joke.DadJokeExists(JokeId)) return BadRequest("The Given Id was not found.");
            bool jokeWasUpdated = Joke.UpdateExistingDadJoke(JokeId, UpdatedJoke);
            if (!jokeWasUpdated) return StatusCode(500, "Unable to update the Joke");
            return Ok("Joke Was Updated");
        }

        [HttpDelete]
        public ActionResult Delete(int JokeId)
        {
            if (Joke.DadJokeExists(JokeId) == false) return BadRequest("No Dad Joke found by that id.");
            bool jokeWasDeleted = Joke.DeleteDadJoke(JokeId);
            if (jokeWasDeleted == false) return StatusCode(500, "Unable to delete the Joke");
            return Ok("Joke Was deleted");
        }
    }
}
