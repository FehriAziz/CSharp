namespace OneToManyRelationShip.Models;


public class AllPostsView
{
    public List<Post> AllPosts { get; set; } = new List<Post>();
    public Like Like { get; set; } = new Like();
}