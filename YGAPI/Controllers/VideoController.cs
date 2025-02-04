using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YGAPI.Controllers.Data;

namespace YGAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class VideoController : ControllerBase
	{
		private readonly ApplicationVideoDbContext _context;

		public VideoController(ApplicationVideoDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetVideogames()
		{
			var result = await _context.VideoGames.ToListAsync();
			return Ok(result);
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetVideogameById(int id)
		{
			var result = await _context.VideoGames.FindAsync(id);

			if (result is null) return NotFound();
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> AddVideoGame(VideoGame videoGame)
		{
			if (videoGame is null) return BadRequest();

			_context.VideoGames.Add(videoGame);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetVideogameById), new { id = videoGame.Id }, videoGame);
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
		{
			var result = await _context.VideoGames.FindAsync(id);
			if (result is null) return NotFound();

			result.Title = updatedGame.Title;
			result.Publisher = updatedGame.Publisher;
			result.Platform = updatedGame.Platform;
			result.Developer = updatedGame.Developer;

			await _context.SaveChangesAsync();

			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteVideoGame(int id)
		{
			var result = await _context.VideoGames.FindAsync(id);
			if (result is null) return NotFound();

			_context.VideoGames.Remove(result);
			await _context.SaveChangesAsync();

			return NoContent();
		}

	}
}


