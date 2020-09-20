using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace EFCoreAutoMigratorExample
{
    // From https://docs.microsoft.com/en-us/ef/core/get-started
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=EfCoreAutoMigrator.db");
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
		public List<Comment> Comments { get; set; }
	}

	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public string CommentBy { get; set; }
	}
}
