using Microsoft.EntityFrameworkCore;

namespace YGAPI.Controllers.Data
{
	public class ApplicationVideoDbContext(DbContextOptions<ApplicationVideoDbContext> options) : DbContext(options)
	{
		//DbSet<VideoGame> VideoGames {  get; set; }	
		public DbSet<VideoGame> VideoGames => Set<VideoGame>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<VideoGame>().HasData(
				new VideoGame
				{
					Id = 1,
					Title = "Spider-Man 2",
					Platform = "PS5",
					Developer = "Insomniac Games",
					Publisher = "Sony Interactive Entertainment"
				},
				new VideoGame
				{
					Id = 2,
					Title = "The Legend of Zelda: Breath of the Wild",
					Platform = "Nintendo Switch",
					Developer = "Nintendo EPD",
					Publisher = "Nintendo"
				},
				new VideoGame
				{
					Id = 3,
					Title = "The Legend of Zelda: Breath of the Wild test ",
					Platform = "Nintendo Switch test ",
					Developer = "Nintendo EPD test",
					Publisher = "Nintendo test"
				});
		}
	}
}
